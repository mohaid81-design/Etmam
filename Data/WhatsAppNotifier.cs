using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Data
{
    /// <summary>Sends WhatsApp messages via the Green API (green-api.com) REST gateway, using
    /// credentials configured in Etmam.SettingsForm (see WhatsAppSettings). Two entry points:
    /// SendAsync (fire-and-forget, used by WorkflowEngine.Act — a notification failure must never
    /// block or fail the workflow action that triggered it) and TrySend (synchronous, used only by
    /// the Settings screen's "اختبار الإرسال" test button, where the admin wants immediate feedback).</summary>
    public static class WhatsAppNotifier
    {
        private static readonly HttpClient Http = new();

        /// <summary>Fire-and-forget send — never throws, no-ops silently if disabled/unconfigured/no
        /// usable phone number. Records the outcome via WhatsAppSettings.AppendAttempt so an admin can
        /// still diagnose a failure afterward, even though nothing surfaces to the user who triggered it.</summary>
        public static void SendAsync(string? rawPhoneNumber, string message)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    bool ok = TrySend(rawPhoneNumber, message, out string? error);
                    var when = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    // Flatten to one line — the log stores one attempt per physical line, and
                    // ExtractErrorDescription's messages can themselves contain newlines.
                    var flatError = (error ?? "").Replace('\n', ' ').Replace('\r', ' ');
                    var summary = ok
                        ? $"{when} — ✅ نجح الإرسال إلى {rawPhoneNumber}"
                        : $"{when} — ❌ فشل الإرسال إلى {rawPhoneNumber}: {flatError}";
                    WhatsAppSettings.AppendAttempt(DataContext.Shared, summary);
                }
                catch
                {
                    // notification failures must never surface — the triggering action already succeeded
                }
            });
        }

        /// <summary>Synchronous send. Returns true on success; on failure returns false and sets
        /// <paramref name="error"/> to a user-facing reason.</summary>
        public static bool TrySend(string? rawPhoneNumber, string message, out string? error)
        {
            error = null;
            var dc = DataContext.Shared;

            if (!WhatsAppSettings.IsEnabled(dc))
            {
                error = "إشعارات واتساب غير مفعّلة من الإعدادات.";
                return false;
            }

            var apiUrl = WhatsAppSettings.GetApiUrl(dc);
            var idInstance = WhatsAppSettings.GetIdInstance(dc);
            var apiToken = WhatsAppSettings.GetApiToken(dc);
            if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(idInstance) || string.IsNullOrWhiteSpace(apiToken))
            {
                error = "لم يتم إدخال API URL أو Instance ID أو API Token.";
                return false;
            }

            var digits = Normalize(rawPhoneNumber);
            if (digits == null)
            {
                error = "رقم الهاتف غير صالح.";
                return false;
            }

            try
            {
                var url = $"{apiUrl.TrimEnd('/')}/waInstance{idInstance}/sendMessage/{apiToken}";
                var payload = JsonSerializer.Serialize(new { chatId = $"{digits}@c.us", message });
                using var content = new StringContent(payload, Encoding.UTF8, "application/json");
                using var response = Http.PostAsync(url, content).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    error = $"فشل الإرسال — رمز الاستجابة: {(int)response.StatusCode}\n{ExtractErrorDescription(body)}".TrimEnd();
                    return false;
                }

                return true;
            }
            catch (System.Exception ex)
            {
                error = $"فشل الاتصال بخدمة واتساب: {ex.Message}";
                return false;
            }
        }

        /// <summary>Green API error bodies (e.g. HTTP 466 "Developer plan" quota/chat-limit errors) carry
        /// the actual actionable reason in invokeStatus/correspondentsStatus.description — surface that
        /// instead of leaving the admin staring at a bare status code.</summary>
        private static string ExtractErrorDescription(string body)
        {
            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;

                if (root.TryGetProperty("correspondentsStatus", out var corr) &&
                    corr.TryGetProperty("description", out var corrDesc))
                    return corrDesc.GetString() ?? "";

                if (root.TryGetProperty("invokeStatus", out var invoke) &&
                    invoke.TryGetProperty("description", out var invokeDesc))
                    return invokeDesc.GetString() ?? "";

                if (root.TryGetProperty("message", out var msg))
                    return msg.GetString() ?? "";

                return body;
            }
            catch
            {
                return body;
            }
        }

        private static string? Normalize(string? rawPhoneNumber)
        {
            var digits = new string((rawPhoneNumber ?? "").Where(char.IsDigit).ToArray());
            return digits.Length >= 8 ? digits : null;
        }

        /// <summary>Queries Green API's own instance status. sendMessage returns HTTP 200 and queues the
        /// message (for up to 24h) even when the instance was never linked to a phone via QR code — so a
        /// "successful" send does not by itself mean anything was actually delivered. Returns the raw
        /// stateInstance value ("authorized" is the only state that actually delivers messages) or null
        /// with <paramref name="error"/> set if the check itself couldn't be made.</summary>
        public static string? GetInstanceState(out string? error)
        {
            error = null;
            var dc = DataContext.Shared;

            var apiUrl = WhatsAppSettings.GetApiUrl(dc);
            var idInstance = WhatsAppSettings.GetIdInstance(dc);
            var apiToken = WhatsAppSettings.GetApiToken(dc);
            if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(idInstance) || string.IsNullOrWhiteSpace(apiToken))
            {
                error = "لم يتم إدخال API URL أو Instance ID أو API Token.";
                return null;
            }

            try
            {
                var url = $"{apiUrl.TrimEnd('/')}/waInstance{idInstance}/getStateInstance/{apiToken}";
                using var response = Http.GetAsync(url).GetAwaiter().GetResult();
                var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    error = $"فشل الاستعلام عن حالة الجهاز — رمز الاستجابة: {(int)response.StatusCode}";
                    return null;
                }

                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("stateInstance", out var stateProp))
                    return stateProp.GetString();

                error = "تعذّرت قراءة حالة الجهاز من الاستجابة.";
                return null;
            }
            catch (System.Exception ex)
            {
                error = $"فشل الاتصال بخدمة واتساب: {ex.Message}";
                return null;
            }
        }
    }
}
