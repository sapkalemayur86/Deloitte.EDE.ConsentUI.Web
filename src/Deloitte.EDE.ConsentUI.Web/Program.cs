var builder = WebApplication.CreateBuilder(args);

// Typed HttpClient pointing at the EDE API. In Development the dev cert on the
// API may be self-signed, so we relax server cert validation for that case only.
builder.Services.AddHttpClient("EdeApi", (sp, client) =>
{
    var cfg = sp.GetRequiredService<IConfiguration>();
    var apiBase = cfg["Ede:ApiBaseUrl"] ?? "";
    if (!string.IsNullOrWhiteSpace(apiBase))
    {
        client.BaseAddress = new Uri(apiBase.TrimEnd('/') + "/");
    }
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
})
.ConfigurePrimaryHttpMessageHandler(sp =>
{
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var handler = new HttpClientHandler();
    if (env.IsDevelopment())
    {
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    }
    return handler;
});

var app = builder.Build();

// Public site — no authentication, no authorization, no headers required.
// Note: UseDefaultFiles() is intentionally NOT registered so the base URL ("/")
// does not serve any page. Users must hit one of the explicit page URLs:
//   /create-application.html?applicationId=...
//   /update-application.html?applicationId=...
//   /submit-enrollment.html?applicationId=...
app.UseStaticFiles();     // serve everything in wwwroot/

// Explicitly return 404 for the base URL so nothing loads on "/".
app.MapGet("/", () => Results.NotFound());

// Health probe for k8s / OpenShift.
app.MapGet("/healthz", () => Results.Ok(new { status = "UP" }));

// Same-origin proxy to the EDE API so the browser never has to deal with CORS.
app.MapGet("/api/mail-notification/{applicationId}", async (
    string applicationId,
    IHttpClientFactory httpFactory,
    ILoggerFactory loggerFactory,
    CancellationToken ct) =>
{
    var logger = loggerFactory.CreateLogger("MailNotificationProxy");

    if (string.IsNullOrWhiteSpace(applicationId))
    {
        return Results.BadRequest(new { error = "applicationId is required." });
    }

    var client = httpFactory.CreateClient("EdeApi");
    if (client.BaseAddress is null)
    {
        return Results.Problem("EDE API base URL is not configured (Ede:ApiBaseUrl).",
            statusCode: StatusCodes.Status500InternalServerError);
    }

    try
    {
        using var resp = await client.GetAsync(
            $"applications/get-mail-notification-data/{Uri.EscapeDataString(applicationId)}", ct);

        var body = await resp.Content.ReadAsStringAsync(ct);

        if (!resp.IsSuccessStatusCode)
        {
            logger.LogWarning("EDE API returned {Status} for application {AppId}: {Body}",
                (int)resp.StatusCode, applicationId, body);
            return Results.Problem(
                detail: $"EDE API returned HTTP {(int)resp.StatusCode}.",
                statusCode: (int)resp.StatusCode);
        }

        var contentType = resp.Content.Headers.ContentType?.MediaType ?? "application/json";
        return Results.Text(body, contentType);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to call EDE API for application {AppId}", applicationId);
        return Results.Problem("Failed to reach the EDE API: " + ex.Message,
            statusCode: StatusCodes.Status502BadGateway);
    }
});

// Expose runtime config to the page. apiBase is now empty so the JS uses same-origin /api/*.
app.MapGet("/config.js", () =>
{
    var js = "window.EDE_CONFIG = { apiBase: \"\" };";
    return Results.Text(js, "application/javascript");
});

app.Run();