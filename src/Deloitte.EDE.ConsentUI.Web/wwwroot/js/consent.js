(function () {
    "use strict";

    var NA = "N/A";

    function getApplicationId() {
        var params = new URLSearchParams(window.location.search);
        var id = params.get("applicationId");
        return id ? id.trim() : "";
    }

    function getApiBase() {
        var cfg = window.EDE_CONFIG || {};
        var base = (cfg.apiBase || "").trim();
        // Strip trailing slash so we can safely concatenate.
        return base.replace(/\/+$/, "");
    }

    function setMainHtml(html) {
        var main = document.querySelector("main.page");
        if (main) main.innerHTML = html;
    }

    function showMissingIdError() {
        setMainHtml(
            '<section class="card">' +
            '  <header class="card__header">' +
            '    <h2>Invalid Request</h2>' +
            '  </header>' +
            '  <div class="card__body">' +
            '    <div class="notice">' +
            '      <div class="notice__text">' +
            '        <h3>Missing Application Id</h3>' +
            '        <p>The link you used is invalid. An <code>applicationId</code> query parameter is required.</p>' +
            '      </div>' +
            '    </div>' +
            '  </div>' +
            '</section>'
        );
    }

    function showApiError(message, appId) {
        var safeMessage = (message || "Unknown error").toString();
        setMainHtml(
            '<section class="card">' +
            '  <header class="card__header">' +
            '    <h2>Unable to Load Request</h2>' +
            '  </header>' +
            '  <div class="card__body">' +
            '    <div class="notice">' +
            '      <div class="notice__text">' +
            '        <h3>Failed to fetch application details</h3>' +
            '        <p>We could not load details for application id <strong>' + escapeHtml(appId) + '</strong>.</p>' +
            '        <p><em>' + escapeHtml(safeMessage) + '</em></p>' +
            '      </div>' +
            '    </div>' +
            '  </div>' +
            '</section>'
        );
    }

    function escapeHtml(s) {
        return String(s)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }

    function getEventId() {
        var path = (window.location.pathname || "").toLowerCase();
        if (path.indexOf("create-application") !== -1) return 1;
        if (path.indexOf("update-application") !== -1) return 2;
        if (path.indexOf("submit-enrollment") !== -1) return 3;
        return 0;
    }

    function getFlowLabel() {
        var ev = getEventId();
        if (ev === 1) return "create the application";
        if (ev === 2) return "update the application";
        if (ev === 3) return "submit the enrollment";
        return "process the request";
    }

    function showSuccess(decision, appId, apiMessage) {
        var heading = decision === "Approved" ? "Permission Granted" : "Permission Denied";
        var body = decision === "Approved"
            ? "You have approved the request to " + escapeHtml(getFlowLabel()) +
              " for application id <strong>" + escapeHtml(appId) + "</strong>."
            : "You have denied the request to " + escapeHtml(getFlowLabel()) +
              " for application id <strong>" + escapeHtml(appId) + "</strong>.";
        var apiLine = apiMessage
            ? '<p><em>' + escapeHtml(apiMessage) + '</em></p>'
            : '';
        setMainHtml(
            '<section class="card">' +
            '  <header class="card__header"><h2>' + heading + '</h2></header>' +
            '  <div class="card__body">' +
            '    <div class="notice">' +
            '      <div class="notice__text">' +
            '        <h3>Thank you</h3>' +
            '        <p>' + body + '</p>' +
            apiLine +
            '        <p>You may now close this window.</p>' +
            '      </div>' +
            '    </div>' +
            '  </div>' +
            '</section>'
        );
    }

    function showSubmitError(decision, message, appId) {
        var safeMessage = (message || "Unknown error").toString();
        setMainHtml(
            '<section class="card">' +
            '  <header class="card__header"><h2>Unable to Submit Decision</h2></header>' +
            '  <div class="card__body">' +
            '    <div class="notice">' +
            '      <div class="notice__text">' +
            '        <h3>Failed to record your ' + escapeHtml(decision) + ' decision</h3>' +
            '        <p>We could not update the consent for application id <strong>' + escapeHtml(appId) + '</strong>.</p>' +
            '        <p><em>' + escapeHtml(safeMessage) + '</em></p>' +
            '      </div>' +
            '    </div>' +
            '  </div>' +
            '</section>'
        );
    }

    function valueOrNA(v) {
        if (v === null || v === undefined) return NA;
        if (typeof v === "string" && v.trim() === "") return NA;
        return v;
    }

    function setField(name, value) {
        var nodes = document.querySelectorAll('[data-field="' + name + '"]');
        nodes.forEach(function (el) {
            el.textContent = valueOrNA(value);
        });
    }

    function setLoadingFields() {
        document.querySelectorAll("[data-field]").forEach(function (el) {
            el.textContent = "Loading...";
        });
    }

    function fetchApplicationData(appId) {
        // Static hosting: call the EDE API directly using the base URL from /js/config.js.
        // The EDE API must allow CORS for this site's origin.
        var apiBase = getApiBase();
        if (!apiBase) {
            return Promise.reject(new Error("API base URL is not configured (window.EDE_CONFIG.apiBase)."));
        }
        var url = apiBase + "/applications/get-mail-notification-data/" + encodeURIComponent(appId);
        return fetch(url, {
            method: "GET",
            headers: { "Accept": "application/json" }
        }).then(function (resp) {
            if (!resp.ok) {
                throw new Error("API returned HTTP " + resp.status + " " + resp.statusText);
            }
            return resp.json();
        });
    }

    function submitDecision(appId, decision) {
        var apiBase = getApiBase();
        if (!apiBase) {
            return Promise.reject(new Error("API base URL is not configured (window.EDE_CONFIG.apiBase)."));
        }
        var nowIso = new Date().toISOString();
        var payload = {
            applicationId: String(appId),
            eventId: getEventId(),
            isSent: true,
            consentStatus: decision,
            mailSentDate: nowIso,
            consentDate: nowIso
        };
        var url = apiBase + "/applications/update-mail-notification-data";
        return fetch(url, {
            method: "POST",
            headers: {
                "Accept": "*/*",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(payload)
        }).then(function (resp) {
            if (!resp.ok) {
                throw new Error("API returned HTTP " + resp.status + " " + resp.statusText);
            }
            return resp.json().catch(function () { return {}; });
        });
    }

    function applyData(appId, data) {
        // Always shown.
        document.querySelectorAll("[data-app-id]").forEach(function (el) {
            el.textContent = appId;
        });

        setField("webBroker", data.web_Broker);
        setField("coverageYear", data.coverage_Year);
        setField("planName", data.plan_Name);
        setField("requestDate", data.request_Date);

        // Requester name shown in the intro paragraph is the same as the web broker.
        setField("requesterName", data.web_Broker);

        // Not provided by this API yet -> N/A.
        setField("aptcAmount", null);
        setField("householdIncome", null);
    }

    function wireButtons(appId) {
        var approveBtn = document.getElementById("approveBtn");
        var denyBtn = document.getElementById("denyBtn");

        function handle(decision) {
            return function () {
                if (approveBtn) approveBtn.disabled = true;
                if (denyBtn) denyBtn.disabled = true;
                submitDecision(appId, decision)
                    .then(function (data) {
                        showSuccess(decision, appId, data && data.message);
                    })
                    .catch(function (err) {
                        if (approveBtn) approveBtn.disabled = false;
                        if (denyBtn) denyBtn.disabled = false;
                        showSubmitError(decision, err && err.message ? err.message : err, appId);
                    });
            };
        }

        if (approveBtn) {
            approveBtn.addEventListener("click", handle("Approved"));
        }
        if (denyBtn) {
            denyBtn.addEventListener("click", handle("Denied"));
        }
    }

    function init() {
        var appId = getApplicationId();
        if (!appId) {
            showMissingIdError();
            return;
        }

        setLoadingFields();
        wireButtons(appId);

        fetchApplicationData(appId)
            .then(function (data) {
                applyData(appId, data || {});
            })
            .catch(function (err) {
                showApiError(err && err.message ? err.message : err, appId);
            });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", init);
    } else {
        init();
    }
})();
