using Data;

namespace Etmam
{
    /// <summary>
    /// Permission check for managing system-wide settings (SettingsForm), same
    /// name-based pattern as StorePermissions.CanManage.
    /// </summary>
    public static class SystemSettingsPermissions
    {
        private const string ManagePermissionName = "إدارة إعدادات النظام";

        /// <summary>Whether the current user may view/change system settings (admin always can).</summary>
        public static bool CanManage(DataContext dc) => PermissionService.HasPermission(dc, ManagePermissionName);
    }
}
