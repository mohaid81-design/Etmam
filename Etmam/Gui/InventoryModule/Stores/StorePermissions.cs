using Data;

namespace Etmam
{
    /// <summary>
    /// Permission check for managing stores (إضافة/تعديل/حذف مخزن), shared by the list
    /// grid (ucStores) and the Add/Edit form (frmStoreAddEdit) so both gate the exact same
    /// action with the exact same rule.
    /// </summary>
    public static class StorePermissions
    {
        private const string ManagePermissionName = "إدارة المخازن";

        /// <summary>Whether the current user may add/edit/delete stores (admin always can).</summary>
        public static bool CanManage(DataContext dc) => PermissionService.HasPermission(dc, ManagePermissionName);
    }
}
