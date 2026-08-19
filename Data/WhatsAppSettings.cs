namespace Data
{
    /// <summary>Typed wrapper over SystemSettingsHelper's generic KV store for the WhatsApp workflow
    /// notification feature (see WhatsAppNotifier and WorkflowEngine.Act). Configured once via
    /// Etmam.SettingsForm's "الإشعارات" section, gated by SystemSettingsPermissions.CanManage.</summary>
    public static class WhatsAppSettings
    {
        public const string EnabledKey = "WhatsAppNotificationsEnabled";
        public const string ApiUrlKey = "WhatsAppGreenApiUrl";
        public const string MediaUrlKey = "WhatsAppGreenApiMediaUrl";
        public const string IdInstanceKey = "WhatsAppGreenApiIdInstance";
        public const string ApiTokenKey = "WhatsAppGreenApiApiToken";
        public const string InstanceNameKey = "WhatsAppGreenApiInstanceName";
        public const string LastAttemptKey = "WhatsAppLastAttempt";

        public static bool IsEnabled(DataContext dc) => SystemSettingsHelper.GetBool(dc, EnabledKey, false);

        /// <summary>Green API assigns each account its own instance-specific host (e.g.
        /// "https://7105169128.api.greenapi.com"), published in that account's console — there is no
        /// fixed shared domain, so this must be entered by the admin, not hardcoded.</summary>
        public static string? GetApiUrl(DataContext dc) => SystemSettingsHelper.GetString(dc, ApiUrlKey);

        /// <summary>Separate instance-specific host used only for file/media uploads (a different
        /// endpoint than apiUrl). Not consumed anywhere yet — WhatsAppNotifier only sends text messages
        /// via sendMessage — stored now so it's available if media-sending is added later.</summary>
        public static string? GetMediaUrl(DataContext dc) => SystemSettingsHelper.GetString(dc, MediaUrlKey);

        public static string? GetIdInstance(DataContext dc) => SystemSettingsHelper.GetString(dc, IdInstanceKey);

        public static string? GetApiToken(DataContext dc) => SystemSettingsHelper.GetString(dc, ApiTokenKey);

        /// <summary>Purely organizational label matching the "Instance Name" shown in the Green API
        /// console — not sent to Green API, just so admins can tell which instance is configured.</summary>
        public static string? GetInstanceName(DataContext dc) => SystemSettingsHelper.GetString(dc, InstanceNameKey);

        private const int MaxAttemptEntries = 8;
        private static readonly object AttemptLogLock = new();

        /// <summary>Rolling log (newest first, capped at <see cref="MaxAttemptEntries"/>) of recent real
        /// (workflow-triggered) send attempts — see WhatsAppNotifier.SendAsync. That path is
        /// fire-and-forget by design (a notification failure must never block or fail the workflow action
        /// that triggered it), which otherwise leaves failures completely invisible; this is the only
        /// place an admin can see why a real notification didn't arrive. A single Act()/ReturnToStep call
        /// can fire several sends at once (one confirmation + one per next-step assignee) — keeping a log
        /// instead of one overwritable slot means a later-finishing success can't hide an earlier failure
        /// to a different number. Not written by TrySend/the test button — that already reports
        /// success/failure directly to the admin clicking it.</summary>
        public static string? GetLastAttempt(DataContext dc) => SystemSettingsHelper.GetString(dc, LastAttemptKey);

        public static void AppendAttempt(DataContext dc, string summary)
        {
            lock (AttemptLogLock)
            {
                var existing = SystemSettingsHelper.GetString(dc, LastAttemptKey) ?? "";
                var lines = new System.Collections.Generic.List<string> { summary };
                if (!string.IsNullOrWhiteSpace(existing))
                    lines.AddRange(existing.Split('\n', System.StringSplitOptions.RemoveEmptyEntries));

                var trimmed = string.Join("\n", lines.GetRange(0, System.Math.Min(lines.Count, MaxAttemptEntries)));
                SystemSettingsHelper.SetString(dc, LastAttemptKey, trimmed, "آخر محاولات إرسال إشعارات واتساب حقيقية (تشخيصي)");
            }
        }
    }
}
