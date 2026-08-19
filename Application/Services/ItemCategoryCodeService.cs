using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    // Web-side port of Data.ItemCategoryCodeService. Recalculate() is copied verbatim (pure,
    // no persistence dependency) so both the desktop client and this Api compute identical
    // Code/LvlId/SortId values from the same ParentId/SortId tree. Only RecalculateAndSaveAsync
    // differs, using IApplicationDbContext/EF Core instead of DataContext.
    public static class ItemCategoryCodeService
    {
        public static void Recalculate(IList<ItemCategory> data)
        {
            var byParent = data.Where(c => !c.IsDelete)
                                .GroupBy(c => c.ParentId ?? 0)
                                .ToDictionary(g => g.Key, g => g.OrderBy(c => c.SortId ?? c.Id).ToList());

            void Walk(int parentKey, int level, string? parentCode)
            {
                if (!byParent.TryGetValue(parentKey, out var siblings)) return;

                int seq = 1;
                foreach (var node in siblings)
                {
                    node.SortId = seq;
                    node.LvlId = level;
                    node.Code = $"{parentCode}{seq:00}";
                    Walk(node.Id, level + 1, node.Code);
                    seq++;
                }
            }

            var fixedRoots = data.Where(c => !c.IsDelete && c.IsFixed)
                                  .OrderBy(c => c.SortId ?? c.Id)
                                  .ToList();
            int fixedSeq = 1;
            foreach (var root in fixedRoots)
            {
                root.SortId = fixedSeq++;
                root.LvlId = 0;
                Walk(root.Id, 1, root.Code);
            }
        }

        public static async Task RecalculateAndSaveAsync(IApplicationDbContext db, CancellationToken ct = default)
        {
            var data = await db.ItemCategory.Where(c => !c.IsDelete).ToListAsync(ct);

            var before = data.ToDictionary(c => c.Id, c => (c.SortId, c.LvlId, c.Code, c.ParentId));

            Recalculate(data);

            var changed = data.Any(c =>
                !before.TryGetValue(c.Id, out var old) ||
                old.SortId != c.SortId || old.LvlId != c.LvlId ||
                old.Code != c.Code || old.ParentId != c.ParentId);

            if (changed)
                await db.SaveChangesAsync(ct);
        }
    }
}
