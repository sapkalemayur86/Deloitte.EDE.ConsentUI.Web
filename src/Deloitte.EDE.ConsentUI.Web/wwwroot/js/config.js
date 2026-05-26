// Static runtime configuration for the Consent UI when hosted as a static site
// (GitLab Pages / GitHub Pages / any static host).
//
// IMPORTANT: set apiBase to the public base URL of the EDE API.
// Example: "https://ede-api.example.com"
//
// The EDE API MUST send CORS headers allowing the site origin, e.g.:
//   Access-Control-Allow-Origin: https://<group>.gitlab.io
window.EDE_CONFIG = {
    apiBase: "https://localhost:7214"
};
