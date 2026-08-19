using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Data
{
    /// <summary>Uploads files to a shared SharePoint Online document library via Microsoft Graph, using
    /// app-only (client-credentials) auth — so it works identically regardless of which user/machine runs
    /// it, unlike a local synced OneDrive folder (per-Windows-user path). Requires an Azure AD (Entra ID)
    /// app registration with Graph API application permission Sites.ReadWrite.All (or Files.ReadWrite.All),
    /// granted admin consent, configured via SharePointExportSettings/Etmam.SettingsForm. Consumed by
    /// Etmam.PurchaseRequestPrinter's SharePoint export path alongside its existing local-folder export.</summary>
    public static class SharePointUploader
    {
        private static readonly HttpClient Http = new();

        // Microsoft Graph's "simple upload" endpoint only accepts files up to 4 MiB — anything larger
        // must go through a resumable upload session (see SessionUpload).
        private const long SimpleUploadMaxBytes = 4L * 1024 * 1024;

        private static string? _cachedAccessToken;
        private static DateTime _cachedTokenExpiryUtc = DateTime.MinValue;
        private static readonly object TokenLock = new();

        private static string? _cachedSiteId;
        private static string? _cachedSiteUrlForId;

        /// <summary>Uploads fileBytes as fileName into the configured SharePoint folder. No-ops (returns
        /// success) if the feature isn't enabled — callers should already guard on IsEnabled before
        /// building the file, but this stays a safe no-op either way. Never throws for a normal failure —
        /// the caller (exporting an already-approved PR, which must not be rolled back over this) always
        /// needs a graceful bool + message instead, same shape as WhatsAppNotifier.TrySend.</summary>
        public static bool TryUpload(DataContext dc, string fileName, byte[] fileBytes, out string? error)
        {
            error = null;
            if (!SharePointExportSettings.IsEnabled(dc)) return true;

            try
            {
                var token = GetAccessToken(dc, out error);
                if (token == null) return false;

                var siteId = ResolveSiteId(dc, token, out error);
                if (siteId == null) return false;

                var folder = (SharePointExportSettings.GetFolderPath(dc) ?? "").Trim('/', ' ');
                var itemPath = string.IsNullOrEmpty(folder) ? fileName : $"{folder}/{fileName}";

                return fileBytes.LongLength <= SimpleUploadMaxBytes
                    ? SimpleUpload(token, siteId, itemPath, fileBytes, out error)
                    : SessionUpload(token, siteId, itemPath, fileBytes, out error);
            }
            catch (Exception ex)
            {
                error = $"فشل الرفع إلى SharePoint: {ex.Message}";
                return false;
            }
        }

        /// <summary>Lists file names directly inside relativeFolder (not recursive), combined with the
        /// configured root folder the same way TryUpload does — used by PurchaseRequestPrinter to compute
        /// the next PDF/attachment revision number against what's actually on SharePoint, the online
        /// counterpart to Directory.GetFiles for the local export. Returns an empty list (not an error) if
        /// the folder doesn't exist yet — Graph returns 404 for that, which just means "no files yet",
        /// same as a brand new PR's first local export folder.</summary>
        public static List<string> ListFileNames(DataContext dc, string relativeFolder, out string? error)
        {
            error = null;
            var names = new List<string>();

            var token = GetAccessToken(dc, out error);
            if (token == null) return names;

            var siteId = ResolveSiteId(dc, token, out error);
            if (siteId == null) return names;

            var configuredRoot = (SharePointExportSettings.GetFolderPath(dc) ?? "").Trim('/', ' ');
            var relative = relativeFolder.Trim('/', ' ');
            var folder = string.IsNullOrEmpty(configuredRoot) ? relative
                : string.IsNullOrEmpty(relative) ? configuredRoot
                : $"{configuredRoot}/{relative}";

            var url = string.IsNullOrEmpty(folder)
                ? $"https://graph.microsoft.com/v1.0/sites/{siteId}/drive/root/children"
                : $"https://graph.microsoft.com/v1.0/sites/{siteId}/drive/root:/{EncodeItemPath(folder)}:/children";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = Http.SendAsync(request).GetAwaiter().GetResult();
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return names; // المجلد غير موجود بعد

            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                error = $"تعذّر قراءة محتويات المجلد — رمز الاستجابة: {(int)response.StatusCode}\n{ExtractErrorDescription(body)}";
                return names;
            }

            using var doc = JsonDocument.Parse(body);
            if (doc.RootElement.TryGetProperty("value", out var valueEl))
                foreach (var item in valueEl.EnumerateArray())
                    if (item.TryGetProperty("name", out var nameEl))
                        names.Add(nameEl.GetString() ?? "");

            return names;
        }

        /// <summary>Synchronous connectivity check for SettingsForm's "اختبار الاتصال" button — resolves a
        /// fresh token then the configured site, without uploading anything.</summary>
        public static bool TestConnection(DataContext dc, out string? error)
        {
            error = null;
            var token = GetAccessToken(dc, out error, forceRefresh: true);
            if (token == null) return false;

            var siteId = ResolveSiteId(dc, token, out error);
            return siteId != null;
        }

        private static string? GetAccessToken(DataContext dc, out string? error, bool forceRefresh = false)
        {
            error = null;
            lock (TokenLock)
            {
                if (!forceRefresh && _cachedAccessToken != null && DateTime.UtcNow < _cachedTokenExpiryUtc)
                    return _cachedAccessToken;

                var tenantId = SharePointExportSettings.GetTenantId(dc);
                var clientId = SharePointExportSettings.GetClientId(dc);
                var clientSecret = SharePointExportSettings.GetClientSecret(dc);
                if (string.IsNullOrWhiteSpace(tenantId) || string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
                {
                    error = "لم يتم إدخال Tenant ID أو Client ID أو Client Secret.";
                    return null;
                }

                var url = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";
                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                });

                using var response = Http.PostAsync(url, form).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                {
                    error = $"فشل تسجيل الدخول (Azure AD) — رمز الاستجابة: {(int)response.StatusCode}\n{ExtractErrorDescription(body)}";
                    return null;
                }

                using var doc = JsonDocument.Parse(body);
                var token = doc.RootElement.GetProperty("access_token").GetString();
                var expiresIn = doc.RootElement.TryGetProperty("expires_in", out var expEl) ? expEl.GetInt32() : 3600;

                _cachedAccessToken = token;
                // يُجدَّد قبل الانتهاء الفعلي بدقيقتين تحسباً لبطء أي طلب لاحق يستخدمه.
                _cachedTokenExpiryUtc = DateTime.UtcNow.AddSeconds(Math.Max(60, expiresIn - 120));
                return token;
            }
        }

        /// <summary>Resolves the configured site URL to its Graph site Id (format
        /// "hostname,siteCollectionGuid,webGuid") — cached as long as the configured URL doesn't change,
        /// since it never changes for a given site.</summary>
        private static string? ResolveSiteId(DataContext dc, string token, out string? error)
        {
            error = null;
            var siteUrl = SharePointExportSettings.GetSiteUrl(dc);
            if (string.IsNullOrWhiteSpace(siteUrl))
            {
                error = "لم يتم إدخال رابط موقع SharePoint.";
                return null;
            }

            if (_cachedSiteId != null && _cachedSiteUrlForId == siteUrl) return _cachedSiteId;

            Uri uri;
            try { uri = new Uri(siteUrl); }
            catch
            {
                error = "رابط موقع SharePoint غير صالح.";
                return null;
            }

            var graphUrl = $"https://graph.microsoft.com/v1.0/sites/{uri.Host}:{uri.AbsolutePath}";
            using var request = new HttpRequestMessage(HttpMethod.Get, graphUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = Http.SendAsync(request).GetAwaiter().GetResult();
            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                error = $"تعذّر العثور على موقع SharePoint — رمز الاستجابة: {(int)response.StatusCode}\n{ExtractErrorDescription(body)}";
                return null;
            }

            using var doc = JsonDocument.Parse(body);
            var siteId = doc.RootElement.GetProperty("id").GetString();
            _cachedSiteId = siteId;
            _cachedSiteUrlForId = siteUrl;
            return siteId;
        }

        /// <summary>Graph expects each path segment URL-encoded but the '/' separators themselves
        /// preserved — Uri.EscapeDataString alone would also encode the slashes.</summary>
        private static string EncodeItemPath(string itemPath) =>
            string.Join("/", itemPath.Split('/').Select(Uri.EscapeDataString));

        private static bool SimpleUpload(string token, string siteId, string itemPath, byte[] fileBytes, out string? error)
        {
            error = null;
            var url = $"https://graph.microsoft.com/v1.0/sites/{siteId}/drive/root:/{EncodeItemPath(itemPath)}:/content";

            using var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = new ByteArrayContent(fileBytes);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            using var response = Http.SendAsync(request).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode) return true;

            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            error = $"فشل الرفع — رمز الاستجابة: {(int)response.StatusCode}\n{ExtractErrorDescription(body)}";
            return false;
        }

        /// <summary>Chunked upload for files over the 4 MiB simple-upload limit — creates an upload
        /// session then PUTs sequential chunks with a Content-Range header, per Microsoft Graph's
        /// resumable upload protocol (chunk size here is a multiple of the required 320 KiB unit).</summary>
        private static bool SessionUpload(string token, string siteId, string itemPath, byte[] fileBytes, out string? error)
        {
            error = null;
            var createUrl = $"https://graph.microsoft.com/v1.0/sites/{siteId}/drive/root:/{EncodeItemPath(itemPath)}:/createUploadSession";

            using var createRequest = new HttpRequestMessage(HttpMethod.Post, createUrl);
            createRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            createRequest.Content = new StringContent("{}", Encoding.UTF8, "application/json");

            using var createResponse = Http.SendAsync(createRequest).GetAwaiter().GetResult();
            var createBody = createResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (!createResponse.IsSuccessStatusCode)
            {
                error = $"فشل إنشاء جلسة الرفع — رمز الاستجابة: {(int)createResponse.StatusCode}\n{ExtractErrorDescription(createBody)}";
                return false;
            }

            using var createDoc = JsonDocument.Parse(createBody);
            var uploadUrl = createDoc.RootElement.GetProperty("uploadUrl").GetString();
            if (string.IsNullOrWhiteSpace(uploadUrl))
            {
                error = "تعذّر الحصول على رابط جلسة الرفع.";
                return false;
            }

            const int chunkSize = 4 * 1024 * 1024; // 4 MiB — a valid multiple of the required 320 KiB unit
            long total = fileBytes.LongLength;
            for (long offset = 0; offset < total; offset += chunkSize)
            {
                int length = (int)Math.Min(chunkSize, total - offset);
                var chunk = new byte[length];
                Array.Copy(fileBytes, offset, chunk, 0, length);

                using var chunkRequest = new HttpRequestMessage(HttpMethod.Put, uploadUrl);
                chunkRequest.Content = new ByteArrayContent(chunk);
                chunkRequest.Content.Headers.ContentRange = new ContentRangeHeaderValue(offset, offset + length - 1, total);

                using var chunkResponse = Http.SendAsync(chunkRequest).GetAwaiter().GetResult();
                if (chunkResponse.IsSuccessStatusCode) continue;

                var chunkBody = chunkResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                error = $"فشل رفع جزء من الملف — رمز الاستجابة: {(int)chunkResponse.StatusCode}\n{ExtractErrorDescription(chunkBody)}";
                return false;
            }

            return true;
        }

        /// <summary>Microsoft Graph error bodies carry the actual reason in error.message — surface that
        /// instead of a bare status code, same approach as WhatsAppNotifier.ExtractErrorDescription.</summary>
        private static string ExtractErrorDescription(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("error", out var errEl))
                {
                    if (errEl.ValueKind == JsonValueKind.Object && errEl.TryGetProperty("message", out var msgEl))
                        return msgEl.GetString() ?? body;
                    if (errEl.ValueKind == JsonValueKind.String)
                        return errEl.GetString() ?? body;
                }
                return body;
            }
            catch
            {
                return body;
            }
        }
    }
}
