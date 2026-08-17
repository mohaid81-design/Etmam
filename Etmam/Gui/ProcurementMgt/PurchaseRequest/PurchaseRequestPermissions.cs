using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Permission check for Purchase Request approval decisions (اعتماد/رفض), shared by the list
    /// grid (ucPurchaseRequests) and the Add/Edit form (frmPurchaseRequestAddEdit) so both gate the
    /// exact same action with the exact same rule.
    /// </summary>
    public static class PurchaseRequestPermissions
    {
        private const string ApprovePermissionDescription = "اعتماد طلبات الشراء";

        /// <summary>Whether the current user may approve/reject purchase requests (admin always can).</summary>
        public static bool CanApprove(DataContext dc)
        {
            if (Session.CurrentUser.Id == 1) return true;

            int permId = dc.PermissionsList
                .GetBy("Description = @d", new { d = ApprovePermissionDescription })
                .FirstOrDefault()?.Id ?? -1;

            return dc.UserPermissionStatus
                .GetBy("UserID = @u AND PermsID = @p AND PermsStatus = 1",
                    new { u = Session.CurrentUser.Id, p = permId })
                .Any();
        }
    }
}
