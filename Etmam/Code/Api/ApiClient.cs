using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Core;
using Etmam.Properties;

namespace Etmam
{
    /// <summary>
    /// Thin HTTP client for the new Api project (plain HTTP by default against the local loopback
    /// Api process - see ApiProcessManager; HTTPS still works if ApiBaseUrl is ever pointed at a
    /// remote deployment with a real certificate). Holds the JWT issued by POST /api/auth/login in
    /// memory for the lifetime of the process and attaches it to every subsequent call — the
    /// desktop client no longer opens a SQL connection for whatever has been migrated to call
    /// through here (see docs/api-migration-checklist.md for what hasn't yet).
    ///
    /// Every internal await uses ConfigureAwait(false), matching Data/SqlDataHelper.cs's convention,
    /// so ApiDataHelper's sync wrappers can safely block on these Tasks from the WinForms UI thread
    /// (SimpleEditFormBase&lt;T&gt; and friends are sync-only) without risking a deadlock.
    /// </summary>
    public static class ApiClient
    {
        private static readonly Lazy<HttpClient> LazyHttp = new(CreateHttpClient);
        private static HttpClient Http => LazyHttp.Value;

        // ASP.NET Core controllers serialize responses camelCase; System.Text.Json's bare default
        // (new JsonSerializerOptions()) matches property names case-sensitively, so every response
        // would otherwise deserialize into all-default (0/null) properties. JsonSerializerDefaults.Web
        // turns on case-insensitive matching (and camelCase for what we send back out).
        internal static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

        public static string? Token { get; private set; }

        private static HttpClient CreateHttpClient()
        {
            var baseUrl = Settings.Default.ApiBaseUrl;
            var handler = new HttpClientHandler();

            // Dev-only: accept a self-signed/untrusted cert, but only when talking to localhost —
            // never weaken certificate validation against a real deployed host.
            var isLocal = Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri)
                && (uri.Host is "localhost" or "127.0.0.1");
            if (isLocal)
            {
                handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
            }

            return new HttpClient(handler) { BaseAddress = new Uri(baseUrl) };
        }

        private static void AttachToken(HttpRequestMessage request)
        {
            if (!string.IsNullOrEmpty(Token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        private static async Task<string> ReadErrorDetailAsync(HttpResponseMessage response, CancellationToken ct) =>
            await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);

        private static async Task<HttpResponseMessage> SendAsync(HttpMethod method, string url, object? body = null, CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(method, url);
            if (body != null) request.Content = JsonContent.Create(body, options: JsonOptions);
            AttachToken(request);

            var response = await Http.SendAsync(request, ct).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var detail = await ReadErrorDetailAsync(response, ct).ConfigureAwait(false);
                throw new HttpRequestException($"{(int)response.StatusCode} {response.ReasonPhrase}: {detail}");
            }
            return response;
        }

        // ─── Auth ───────────────────────────────────────────────────────────

        public static async Task<ApiLoginResult?> LoginAsync(string userName, string password, CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/login")
            {
                Content = JsonContent.Create(new { userName, password }, options: JsonOptions)
            };

            var response = await Http.SendAsync(request, ct).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return null;

            if (!response.IsSuccessStatusCode)
            {
                var detail = await ReadErrorDetailAsync(response, ct).ConfigureAwait(false);
                throw new HttpRequestException($"{(int)response.StatusCode} {response.ReasonPhrase}: {detail}");
            }

            var result = await response.Content.ReadFromJsonAsync<ApiLoginResult>(JsonOptions, ct).ConfigureAwait(false)
                ?? throw new InvalidOperationException("استجابة تسجيل الدخول من الخادم غير صالحة.");

            Token = result.Token;
            return result;
        }

        public static async Task CompleteProfileAsync(string fullName, string jobTitle, string company, string newPassword, CancellationToken ct = default) =>
            await SendAsync(HttpMethod.Put, "api/auth/complete-profile",
                new { fullName, jobTitle, company, newPassword }, ct).ConfigureAwait(false);

        // ─── Projects ───────────────────────────────────────────────────────

        public static async Task<List<ProjectsList>> GetProjectsAsync(CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, "api/projects", ct: ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<List<ProjectsList>>(JsonOptions, ct).ConfigureAwait(false)
                ?? new List<ProjectsList>();
        }

        // Same GET /api/projects response as GetProjectsAsync, deserialized into ucProjectsList's
        // grid-shaped view model instead (see ProjectListItem.cs for why the property names differ).
        public static async Task<List<ProjectListItem>> GetProjectListAsync(CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, "api/projects", ct: ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<List<ProjectListItem>>(JsonOptions, ct).ConfigureAwait(false)
                ?? new List<ProjectListItem>();
        }

        public static async Task<ProjectsList?> GetProjectAsync(int id, CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/projects/{id}");
            AttachToken(request);
            var response = await Http.SendAsync(request, ct).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            if (!response.IsSuccessStatusCode)
            {
                var detail = await ReadErrorDetailAsync(response, ct).ConfigureAwait(false);
                throw new HttpRequestException($"{(int)response.StatusCode} {response.ReasonPhrase}: {detail}");
            }
            return await response.Content.ReadFromJsonAsync<ProjectsList>(JsonOptions, ct).ConfigureAwait(false);
        }

        public static async Task<int> CreateProjectAsync(ProjectsList project, CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Post, "api/projects", project, ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<int>(JsonOptions, ct).ConfigureAwait(false);
        }

        public static async Task UpdateProjectAsync(int id, ProjectsList project, CancellationToken ct = default) =>
            await SendAsync(HttpMethod.Put, $"api/projects/{id}", project, ct).ConfigureAwait(false);

        public static async Task DeleteProjectAsync(int id, CancellationToken ct = default) =>
            await SendAsync(HttpMethod.Delete, $"api/projects/{id}", ct: ct).ConfigureAwait(false);

        // Client/consultant lookups for ucProjectsList's filter and frmNewProjectWizard's owner/
        // consultant pickers - GET /api/projects/clients and /consultants already existed server-side
        // (Application.Services.ProjectsService) before either screen's dropdown was wired to them.
        public static async Task<List<StakeholderLookupItem>> GetProjectClientsAsync(CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, "api/projects/clients", ct: ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<List<StakeholderLookupItem>>(JsonOptions, ct).ConfigureAwait(false)
                ?? new List<StakeholderLookupItem>();
        }

        public static async Task<List<StakeholderLookupItem>> GetProjectConsultantsAsync(CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, "api/projects/consultants", ct: ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<List<StakeholderLookupItem>>(JsonOptions, ct).ConfigureAwait(false)
                ?? new List<StakeholderLookupItem>();
        }

        // ─── Units ──────────────────────────────────────────────────────────

        public static async Task<List<UnitItem>> GetUnitsAsync(CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, "api/units", ct: ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<List<UnitItem>>(JsonOptions, ct).ConfigureAwait(false)
                ?? new List<UnitItem>();
        }

        public static async Task<UnitItem?> GetUnitAsync(int id, CancellationToken ct = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/units/{id}");
            AttachToken(request);
            var response = await Http.SendAsync(request, ct).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            if (!response.IsSuccessStatusCode)
            {
                var detail = await ReadErrorDetailAsync(response, ct).ConfigureAwait(false);
                throw new HttpRequestException($"{(int)response.StatusCode} {response.ReasonPhrase}: {detail}");
            }
            return await response.Content.ReadFromJsonAsync<UnitItem>(JsonOptions, ct).ConfigureAwait(false);
        }

        public static async Task<int> CreateUnitAsync(UnitItem unit, CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Post, "api/units", unit, ct).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<int>(JsonOptions, ct).ConfigureAwait(false);
        }

        public static async Task UpdateUnitAsync(int id, UnitItem unit, CancellationToken ct = default) =>
            await SendAsync(HttpMethod.Put, $"api/units/{id}", unit, ct).ConfigureAwait(false);

        public static async Task DeleteUnitAsync(int id, CancellationToken ct = default) =>
            await SendAsync(HttpMethod.Delete, $"api/units/{id}", ct: ct).ConfigureAwait(false);
    }

    // Mirrors Application.Dtos.StakeholderLookupDto's wire shape (Id/Name only).
    public sealed class StakeholderLookupItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    // Mirrors Application.Dtos.UnitDto/UnitSaveRequest's wire shape - same class serves GET
    // responses and POST/PUT bodies (Id is simply ignored server-side on write).
    public sealed class UnitItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Abbreviation { get; set; }
        public string? Category { get; set; }
    }

    public sealed class ApiLoginResult
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAtUtc { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public string? FullName { get; set; }
        public string? JobTitle { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }
        public bool MustChangePassword { get; set; }
    }
}
