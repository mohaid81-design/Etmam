using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Web-side port of Data/PermissionService.IsSuperUser/GrantedProjectIds/CanAccessProject - the
    /// single rule the desktop client uses everywhere a grid/lookup needs to be scoped to "projects
    /// this user may see" (ucPurchaseRequests.cs, ucPurchaseOrder.cs, ucCIR.cs, frmMainPage's project
    /// switcher, ...). Shared here (rather than duplicated per approval service) because it's a
    /// security rule, not entity-specific logic - one implementation to keep correct beats three
    /// copies that could quietly drift apart.
    ///
    /// Two things worth calling out because they're easy to get wrong by "obvious" reasoning instead
    /// of matching desktop exactly:
    /// - The superuser bypass is hard-coded to UserId == 1 (Session.CurrentUser?.Id == 1 on desktop -
    ///   the seeded admin row's identity-generated id in a fresh database), NOT UsersList.Role ==
    ///   "Admin". A user with Role="Admin" who isn't literally id 1 is NOT a superuser on desktop and
    ///   still gets filtered by UserProjectAccess - frmUsersMgt.cs has its own local `Id == 1 ||
    ///   Role == "Admin"` check, but that's cosmetic (which rows show in that one screen), it doesn't
    ///   feed PermissionService or bypass project filtering anywhere else.
    /// - UserProjectAccess is an explicit-grant model: a missing row means no access, same as
    ///   PermsStatus = 0. There's no "denied" state beyond that and no access-level/tier.
    /// </summary>
    public sealed class ProjectAccessService
    {
        private const int SuperUserId = 1;

        private readonly IApplicationDbContext _db;

        public ProjectAccessService(IApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsSuperUser(int userId) => userId == SuperUserId;

        /// <summary>Null means "unrestricted" (superuser) - kept distinct from an empty set, which
        /// means a real non-superuser who has been granted access to zero projects and should
        /// therefore see nothing.</summary>
        public async Task<HashSet<int>?> GetGrantedProjectIdsAsync(int userId, CancellationToken ct = default)
        {
            if (IsSuperUser(userId)) return null;

            return (await _db.UserProjectAccess
                .Where(a => a.UserID == userId && a.PermsStatus)
                .Select(a => a.PrjId)
                .ToListAsync(ct)).ToHashSet();
        }

        /// <summary>true if grantedProjectIds is null (superuser) or prjId is set and in the set.
        /// A record with no project at all (prjId == null) is never visible to a non-superuser -
        /// matches how the desktop grids' PrjId IN (...) filters behave.</summary>
        public static bool CanAccess(HashSet<int>? grantedProjectIds, int? prjId) =>
            grantedProjectIds is null || (prjId.HasValue && grantedProjectIds.Contains(prjId.Value));
    }
}
