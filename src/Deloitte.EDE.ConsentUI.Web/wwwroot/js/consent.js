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

        if (approveBtn) {
            approveBtn.addEventListener("click", function () {
                alert("Approved for application id: " + appId);
            });
        }
        if (denyBtn) {
            denyBtn.addEventListener("click", function () {
                alert("Denied for application id: " + appId);
            });
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
