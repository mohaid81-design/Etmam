namespace Data
{
    /// <summary>Typed wrapper over SystemSettingsHelper's generic KV store for uploading approved
    /// Purchase Request PDFs/attachments to a shared SharePoint Online document library via Microsoft
    /// Graph (app-only client-credentials auth) — unlike PurchaseRequestExportSettings' local folder
    /// (which is per-machine/per-Windows-user and can't serve as one shared destination for several
    /// users), this reaches the same online library regardless of who runs the app or from where.
    /// Configured once via Etmam.SettingsForm's "الموافقات وفصل المهام" section, gated by
    /// SystemSettingsPermissions.CanManage. See Data.SharePointUploader for the actual Graph calls, and
    /// its own summary for the Azure AD app registration this requires.</summary>
    public static class SharePointExportSettings
    {
        public const string EnabledKey = "SharePointExportEnabled";
        public const string TenantIdKey = "SharePointExportTenantId";
        public const string ClientIdKey = "SharePointExportClientId";
        public const string ClientSecretKey = "SharePointExportClientSecret";
        public const string SiteUrlKey = "SharePointExportSiteUrl";
        public const string FolderPathKey = "SharePointExportFolderPath";

        public static bool IsEnabled(DataContext dc) => SystemSettingsHelper.GetBool(dc, EnabledKey, false);

        /// <summary>Azure AD (Entra ID) tenant Id/domain the app registration belongs to, e.g.
        /// "contoso.onmicrosoft.com" or its GUID.</summary>
        public static string? GetTenantId(DataContext dc) => SystemSettingsHelper.GetString(dc, TenantIdKey);

        /// <summary>The Azure AD app registration's Application (client) Id.</summary>
        public static string? GetClientId(DataContext dc) => SystemSettingsHelper.GetString(dc, ClientIdKey);

        /// <summary>The app registration's client secret value — stored the same way WhatsAppSettings
        /// stores its Green API token (plain in SystemSettings; no separate encryption layer exists yet
        /// in this app), so protecting it is a matter of restricting who has SystemSettingsPermissions.
        /// CanManage, same as every other credential configured in this screen.</summary>
        public static string? GetClientSecret(DataContext dc) => SystemSettingsHelper.GetString(dc, ClientSecretKey);

        /// <summary>Full SharePoint site URL, e.g. "https://contoso.sharepoint.com/sites/Procurement".</summary>
        public static string? GetSiteUrl(DataContext dc) => SystemSettingsHelper.GetString(dc, SiteUrlKey);

        /// <summary>Folder path inside the site's default document library to upload into, e.g.
        /// "Purchase Requests" — leave empty to upload straight into the library root.</summary>
        public static string? GetFolderPath(DataContext dc) => SystemSettingsHelper.GetString(dc, FolderPathKey);
    }
}
