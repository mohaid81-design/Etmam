namespace Data
{
    /// <summary>Shared network folder (configured once via Etmam.SettingsForm, gated by
    /// SystemSettingsPermissions.CanManage) where new attachment files are stored, so every user/machine
    /// against the same database can open files uploaded by anyone else. DB-backed (not a per-machine
    /// Properties.Settings entry) because the whole point is one value shared across all installs. See
    /// Etmam.AttachmentStorage.RootFolder for the actual read + local-AppData fallback when unset.</summary>
    public static class AttachmentStorageSettings
    {
        public const string SettingKey = "AttachmentsSharedFolder";

        public static string? GetFolderPath(DataContext dc) =>
            SystemSettingsHelper.GetString(dc, SettingKey);
    }
}
