using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>Single source of truth for the granular per-store action flags on
    /// <see cref="Core.UserStoreAccess"/> (PermsStatus/CanReceive/CanIssue/CanTransfer) — replaces the
    /// duplicated "_grantedStoreIds = dc.UserStoreAccess.GetBy(...).Select(a =&gt; a.StoreId).ToHashSet()"
    /// snippet that used to live independently in every sibling list uc (ucMaterialReceive, ucMaterialIssued,
    /// ucMaterialTrasfare, ucMaterialIssueReturn, ucPurchaseReturn, ucStocking, ucOpeningBalance). User Id 1
    /// bypasses every check here, matching the same superuser convention already used by
    /// StorePermissions.</summary>
    public static class InventoryStorePermissions
    {
        private static bool IsSuperUser => Session.CurrentUser?.Id == 1;

        private static List<UserStoreAccess> RowsForCurrentUser(DataContext dc) =>
            dc.UserStoreAccess.GetBy("UserID = @u", new { u = Session.CurrentUser?.Id ?? 1 });

        public static bool CanView(DataContext dc, int storeId) => Has(dc, storeId, a => a.PermsStatus);
        public static bool CanReceive(DataContext dc, int storeId) => Has(dc, storeId, a => a.CanReceive);
        public static bool CanIssue(DataContext dc, int storeId) => Has(dc, storeId, a => a.CanIssue);
        public static bool CanTransfer(DataContext dc, int storeId) => Has(dc, storeId, a => a.CanTransfer);

        private static bool Has(DataContext dc, int storeId, Func<UserStoreAccess, bool> flag)
        {
            if (IsSuperUser) return true;
            return RowsForCurrentUser(dc).Any(a => a.StoreId == storeId && flag(a));
        }

        /// <summary>The set of store Ids the current user holds <paramref name="flag"/> for — used to
        /// filter a list screen's store combo/grid to only what this user is allowed to act on.</summary>
        public static HashSet<int> GrantedStoreIds(DataContext dc, Func<UserStoreAccess, bool> flag)
        {
            if (IsSuperUser) return dc.StoreList.GetBy("IsDelete = 0").Select(s => s.Id).ToHashSet();
            return RowsForCurrentUser(dc).Where(flag).Select(a => a.StoreId).ToHashSet();
        }
    }
}
