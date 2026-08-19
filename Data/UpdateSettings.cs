namespace Data
{
    /// <summary>Central "latest published version" gate, configured once via Etmam.SettingsForm
    /// (gated by SystemSettingsPermissions.CanManage) so every machine against the same database
    /// checks the same value before login - same DB-backed-shared-setting pattern as
    /// AttachmentStorageSettings. See Etmam.frmStart's version check for where this actually
    /// blocks login, and Etmam.frmUpdateRequired for the blocking dialog it shows.</summary>
    public static class UpdateSettings
    {
        public const string LatestVersionKey = "LatestAppVersion";
        public const string UpdateLocationKey = "UpdateLocationPath";

        /// <summary>The version every installed copy should be on, e.g. "1.0.1". Null/empty means
        /// the gate is unconfigured - frmStart treats that as "don't block" rather than locking
        /// everyone out because nobody has set this yet.</summary>
        public static string? GetLatestVersion(DataContext dc) =>
            SystemSettingsHelper.GetString(dc, LatestVersionKey);

        /// <summary>Where to send an out-of-date user to get the new installer - a UNC folder or a
        /// URL, opened via ShellExecute so either works. Null/empty just hides the "open" button.</summary>
        public static string? GetUpdateLocation(DataContext dc) =>
            SystemSettingsHelper.GetString(dc, UpdateLocationKey);
    }
}
