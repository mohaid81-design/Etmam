using System.Collections.Generic;
using System.Linq;
using Core;

namespace Data
{
    /// <summary>Granular per-store action being checked against <see cref="UserStoreAccess"/>.</summary>
    public enum StoreAction
    {
        View,
        Receive,
        Issue,
        Transfer
    }

    /// <summary>
    /// Central, cached permission-check API. Consolidates what used to be four separate idioms
    /// scattered across the app (frmMainPage/frmUsersMgt's local `HasPerm(int)` closures keyed to
    /// hard-coded PermissionsList row Ids, the `*Permissions.CanX(dc)` static helpers each running
    /// their own uncached SQL round-trip, inline UserPermissionStatus queries such as the one in
    /// ucWorkflowDefinitions, and the store-flag helper InventoryStorePermissions) behind one surface.
    ///
    /// Permissions are looked up by <see cref="PermissionsList.Name"/> rather than by numeric Id —
    /// a live-database check found the hard-coded Ids frmMainPage relied on had already drifted from
    /// the actual PermissionsList rows in at least one environment, so Id-based lookups are fragile
    /// across databases. Name-based lookup matches the pattern the *Permissions helpers already used
    /// successfully.
    ///
    /// Session.CurrentUser.Id == 1 bypasses every check here, matching the superuser convention
    /// already used throughout the app. Results are cached per current user; call <see cref="Invalidate"/>
    /// after login and after any admin edit to a user's grants (frmUsersMgt.SavePermissions) so the
    /// cache never serves stale data.
    /// </summary>
    public static class PermissionService
    {
        private static int? _cachedUserId;
        private static Dictionary<string, int>? _permNameToId;
        private static HashSet<int>? _grantedPermIds;
        private static HashSet<int>? _grantedProjectIds;
        private static Dictionary<StoreAction, HashSet<int>>? _grantedStoreIdsByAction;
        private static HashSet<int>? _grantedWorkflowDefinitionIds;

        // عام كي تستطيع نقاط قفل خارج هذا الصنف (مثل ItemStoreLock) استثناء المستخدم المدير (Id=1) من
        // قيود القفل، بنفس معنى تجاوزه لكل الصلاحيات هنا.
        public static bool IsSuperUser => Session.CurrentUser?.Id == 1;

        /// <summary>Clears every cached grant. Call after login and after saving permission changes.</summary>
        public static void Invalidate()
        {
            _cachedUserId = null;
            _permNameToId = null;
            _grantedPermIds = null;
            _grantedProjectIds = null;
            _grantedStoreIdsByAction = null;
            _grantedWorkflowDefinitionIds = null;
        }

        private static void EnsureLoaded(DataContext dc)
        {
            int userId = Session.CurrentUser?.Id ?? 1;
            if (_cachedUserId == userId && _grantedPermIds != null) return;

            _cachedUserId = userId;

            _permNameToId = dc.PermissionsList.GetAll()
                .Where(p => !string.IsNullOrEmpty(p.Name))
                .GroupBy(p => p.Name!)
                .ToDictionary(g => g.Key, g => g.First().Id);

            _grantedPermIds = dc.UserPermissionStatus
                .GetBy("UserID = @u AND PermsStatus = 1", new { u = userId })
                .Select(p => p.PermsID)
                .ToHashSet();

            _grantedProjectIds = dc.UserProjectAccess
                .GetBy("UserID = @u AND PermsStatus = 1", new { u = userId })
                .Select(a => a.PrjId)
                .ToHashSet();

            var storeRows = dc.UserStoreAccess.GetBy("UserID = @u", new { u = userId });
            _grantedStoreIdsByAction = new Dictionary<StoreAction, HashSet<int>>
            {
                [StoreAction.View] = storeRows.Where(a => a.PermsStatus).Select(a => a.StoreId).ToHashSet(),
                [StoreAction.Receive] = storeRows.Where(a => a.CanReceive).Select(a => a.StoreId).ToHashSet(),
                [StoreAction.Issue] = storeRows.Where(a => a.CanIssue).Select(a => a.StoreId).ToHashSet(),
                [StoreAction.Transfer] = storeRows.Where(a => a.CanTransfer).Select(a => a.StoreId).ToHashSet(),
            };

            _grantedWorkflowDefinitionIds = dc.UserWorkflowAccess
                .GetBy("UserID = @u AND PermsStatus = 1", new { u = userId })
                .Select(a => a.WorkflowId)
                .ToHashSet();
        }

        /// <summary>Whether the current user holds the named permission (admin always does).</summary>
        public static bool HasPermission(string name) => HasPermission(DataContext.Shared, name);

        public static bool HasPermission(DataContext dc, string name)
        {
            if (IsSuperUser) return true;
            EnsureLoaded(dc);
            return _permNameToId!.TryGetValue(name, out int id) && _grantedPermIds!.Contains(id);
        }

        /// <summary>Whether the current user may see/act on the given project (UserProjectAccess).</summary>
        public static bool CanAccessProject(int prjId) => CanAccessProject(DataContext.Shared, prjId);

        public static bool CanAccessProject(DataContext dc, int prjId)
        {
            if (IsSuperUser) return true;
            EnsureLoaded(dc);
            return _grantedProjectIds!.Contains(prjId);
        }

        /// <summary>The set of project Ids the current user is granted access to (admin: all).</summary>
        public static HashSet<int> GrantedProjectIds(DataContext dc)
        {
            if (IsSuperUser) return dc.ProjectsList.GetAll().Where(p => !p.IsDelete).Select(p => p.Id).ToHashSet();
            EnsureLoaded(dc);
            return new HashSet<int>(_grantedProjectIds!);
        }

        /// <summary>Whether the current user may perform <paramref name="action"/> on the given store (UserStoreAccess).</summary>
        public static bool CanAccessStore(int storeId, StoreAction action) => CanAccessStore(DataContext.Shared, storeId, action);

        public static bool CanAccessStore(DataContext dc, int storeId, StoreAction action)
        {
            if (IsSuperUser) return true;
            EnsureLoaded(dc);
            return _grantedStoreIdsByAction!.TryGetValue(action, out var ids) && ids.Contains(storeId);
        }

        /// <summary>Whether the current user holds <paramref name="action"/> on at least one store —
        /// used to gate an "Add" button when the store itself is chosen inside the Add/Edit form.</summary>
        public static bool CanAccessAnyStore(DataContext dc, StoreAction action)
        {
            if (IsSuperUser) return true;
            EnsureLoaded(dc);
            return _grantedStoreIdsByAction!.TryGetValue(action, out var ids) && ids.Count > 0;
        }

        /// <summary>The set of store Ids the current user holds <paramref name="action"/> for (admin: all stores).</summary>
        public static HashSet<int> GrantedStoreIds(DataContext dc, StoreAction action)
        {
            if (IsSuperUser) return dc.StoreList.GetBy("IsDelete = 0").Select(s => s.Id).ToHashSet();
            EnsureLoaded(dc);
            return new HashSet<int>(_grantedStoreIdsByAction![action]);
        }

        /// <summary>Whether the current user may act on the given workflow *type* at all (UserWorkflowAccess) —
        /// a coarser, definition-level gate that sits alongside WorkflowStepAssigneeList's per-step,
        /// per-instance assignment (see WorkflowEngine.CanUserAct).</summary>
        public static bool CanAccessWorkflowDefinition(int workflowDefinitionId) => CanAccessWorkflowDefinition(DataContext.Shared, workflowDefinitionId);

        public static bool CanAccessWorkflowDefinition(DataContext dc, int workflowDefinitionId)
        {
            if (IsSuperUser) return true;
            EnsureLoaded(dc);
            return _grantedWorkflowDefinitionIds!.Contains(workflowDefinitionId);
        }

        /// <summary>The set of workflow definition Ids the current user is granted access to (admin: all).</summary>
        public static HashSet<int> GrantedWorkflowDefinitionIds(DataContext dc)
        {
            if (IsSuperUser) return dc.WorkflowDefinitionList.GetAll().Where(w => !w.IsDelete).Select(w => w.Id).ToHashSet();
            EnsureLoaded(dc);
            return new HashSet<int>(_grantedWorkflowDefinitionIds!);
        }

        /// <summary>Every active, non-deleted user directly granted the named permission — the admin
        /// account (Id=1) is always included since it implicitly holds every permission (see
        /// IsSuperUser). Unlike every other method here (which answers "can *the current user* do X"),
        /// this answers "who can do X" — for broadcast notifications with no single acting user to check
        /// against, e.g. WorkflowEngine's "purchase request fully approved" WhatsApp ping to everyone
        /// holding PermNames.PurchaseOrder.</summary>
        public static List<UsersList> GetUsersWithPermission(DataContext dc, string permName)
        {
            var permId = dc.PermissionsList.GetAll().FirstOrDefault(p => p.Name == permName)?.Id;

            var grantedUserIds = permId == null
                ? new HashSet<int>()
                : dc.UserPermissionStatus
                    .GetBy("PermsID = @p AND PermsStatus = 1", new { p = permId.Value })
                    .Select(g => g.UserID)
                    .ToHashSet();

            return dc.UsersList.GetBy("IsDelete = 0 AND IsActive = 1")
                .Where(u => u.Id == 1 || grantedUserIds.Contains(u.Id))
                .ToList();
        }
    }
}
