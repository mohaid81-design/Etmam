namespace Data
{
    /// <summary>Fixed destination folder (configured once via Etmam.SettingsForm, gated by
    /// SystemSettingsPermissions.CanManage) where an approved Purchase Request's PDF copy + attachments
    /// are auto-saved right after the workflow's final approval step — no per-approval prompt. See
    /// Etmam.PurchaseRequestPrinter.ExportApprovedCopy for the actual export and
    /// frmPurchaseRequestAddEdit.ActOnWorkflowStep for the trigger.</summary>
    public static class PurchaseRequestExportSettings
    {
        public const string SettingKey = "PurchaseRequestApprovedExportPath";

        public static string? GetFolderPath(DataContext dc) =>
            SystemSettingsHelper.GetString(dc, SettingKey);
    }
}
