namespace Data
{
    /// <summary>Typed wrapper over SystemSettingsHelper's generic KV store for outgoing SMTP email
    /// (document "send by email" buttons, e.g. frmCIRAddEdit's btnSend). Configured once via
    /// Etmam.SettingsForm's "البريد الإلكتروني" section, gated by SystemSettingsPermissions.CanManage —
    /// same shape as WhatsAppSettings.</summary>
    public static class EmailSettings
    {
        public const string EnabledKey = "EmailEnabled";
        public const string SmtpHostKey = "EmailSmtpHost";
        public const string SmtpPortKey = "EmailSmtpPort";
        public const string SmtpUserKey = "EmailSmtpUser";
        public const string SmtpPasswordKey = "EmailSmtpPassword";
        public const string SmtpUseSslKey = "EmailSmtpUseSsl";
        public const string SmtpFromNameKey = "EmailSmtpFromName";
        public const string SmtpFromAddressKey = "EmailSmtpFromAddress";

        public static bool IsEnabled(DataContext dc) => SystemSettingsHelper.GetBool(dc, EnabledKey, false);

        public static string? GetSmtpHost(DataContext dc) => SystemSettingsHelper.GetString(dc, SmtpHostKey);

        public static int GetSmtpPort(DataContext dc)
        {
            var raw = SystemSettingsHelper.GetString(dc, SmtpPortKey, "587");
            return int.TryParse(raw, out int port) ? port : 587;
        }

        public static string? GetSmtpUser(DataContext dc) => SystemSettingsHelper.GetString(dc, SmtpUserKey);

        public static string? GetSmtpPassword(DataContext dc) => SystemSettingsHelper.GetString(dc, SmtpPasswordKey);

        public static bool GetUseSsl(DataContext dc) => SystemSettingsHelper.GetBool(dc, SmtpUseSslKey, true);

        public static string? GetFromName(DataContext dc) => SystemSettingsHelper.GetString(dc, SmtpFromNameKey);

        public static string? GetFromAddress(DataContext dc) => SystemSettingsHelper.GetString(dc, SmtpFromAddressKey);

        public static void SetSettings(DataContext dc, bool enabled, string host, int port, string user,
            string password, bool useSsl, string fromName, string fromAddress)
        {
            SystemSettingsHelper.SetBool(dc, EnabledKey, enabled, "تفعيل إرسال البريد الإلكتروني من داخل النظام");
            SystemSettingsHelper.SetString(dc, SmtpHostKey, host, "عنوان خادم SMTP");
            SystemSettingsHelper.SetString(dc, SmtpPortKey, port.ToString(), "منفذ خادم SMTP");
            SystemSettingsHelper.SetString(dc, SmtpUserKey, user, "اسم مستخدم SMTP");
            SystemSettingsHelper.SetString(dc, SmtpPasswordKey, password, "كلمة مرور SMTP");
            SystemSettingsHelper.SetBool(dc, SmtpUseSslKey, useSsl, "استخدام SSL/TLS عند الإرسال");
            SystemSettingsHelper.SetString(dc, SmtpFromNameKey, fromName, "اسم المرسل الظاهر في البريد");
            SystemSettingsHelper.SetString(dc, SmtpFromAddressKey, fromAddress, "عنوان بريد المرسل");
        }

        /// <summary>True only once host/user/from-address are all present — the minimum needed to
        /// attempt a send. Doesn't guarantee the credentials are actually valid.</summary>
        public static bool IsConfigured(DataContext dc) =>
            !string.IsNullOrWhiteSpace(GetSmtpHost(dc)) &&
            !string.IsNullOrWhiteSpace(GetSmtpUser(dc)) &&
            !string.IsNullOrWhiteSpace(GetFromAddress(dc));
    }
}
