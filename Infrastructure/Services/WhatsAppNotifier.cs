using System.Net.Http;
using System.Net.Http.Json;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    /// <summary>See IWhatsAppNotifier's own summary for the request-scoped-DbContext reason this
    /// awaits inline instead of desktop's Task.Run fire-and-forget. Settings keys and the Green API
    /// request shape mirror Data/WhatsAppNotifier.cs + Data/WhatsAppSettings.cs exactly (same
    /// SystemSettings rows, same sendMessage endpoint/payload), so an admin's existing configuration
    /// just works without re-entering anything.</summary>
    public sealed class WhatsAppNotifier : IWhatsAppNotifier
    {
        private const string EnabledKey = "WhatsAppNotificationsEnabled";
        private const string ApiUrlKey = "WhatsAppGreenApiUrl";
        private const string IdInstanceKey = "WhatsAppGreenApiIdInstance";
        private const string ApiTokenKey = "WhatsAppGreenApiApiToken";

        private static readonly HttpClient Http = new();

        private readonly IApplicationDbContext _db;

        public WhatsAppNotifier(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendAsync(string? rawPhoneNumber, string message, CancellationToken ct = default)
        {
            try
            {
                var digits = Normalize(rawPhoneNumber);
                if (digits is null) return;

                var settings = await _db.SystemSettings
                    .Where(s => s.SettingKey == EnabledKey || s.SettingKey == ApiUrlKey || s.SettingKey == IdInstanceKey || s.SettingKey == ApiTokenKey)
                    .ToDictionaryAsync(s => s.SettingKey!, s => s.SettingValue, ct);

                if (settings.GetValueOrDefault(EnabledKey) != "1") return;

                var apiUrl = settings.GetValueOrDefault(ApiUrlKey);
                var idInstance = settings.GetValueOrDefault(IdInstanceKey);
                var apiToken = settings.GetValueOrDefault(ApiTokenKey);
                if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(idInstance) || string.IsNullOrWhiteSpace(apiToken))
                    return;

                var url = $"{apiUrl.TrimEnd('/')}/waInstance{idInstance}/sendMessage/{apiToken}";
                using var response = await Http.PostAsJsonAsync(url, new { chatId = $"{digits}@c.us", message }, ct);
                // Best-effort only - no AppendAttempt-style diagnostic log on the web side yet (that's
                // desktop's admin-facing Settings screen; revisit if this ever needs its own).
            }
            catch
            {
                // never throw - the action that triggered this has already succeeded
            }
        }

        private static string? Normalize(string? rawPhoneNumber)
        {
            var digits = new string((rawPhoneNumber ?? "").Where(char.IsDigit).ToArray());
            return digits.Length >= 8 ? digits : null;
        }
    }
}
