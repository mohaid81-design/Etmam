using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    // Web-side port of Data.ItemCodeService. Recalculate() is copied verbatim (pure, no
    // persistence dependency) so both clients derive identical Code = category.Code + a 3-digit
    // sequence within that category, preserving old relative order via the trailing-3-char
    // sequence already documented in the desktop version (do NOT "improve" this to parse all
    // trailing digits — categories' own codes are digits too, which caused runaway codes there).
    public static class ItemCodeService
    {
        public static void Recalculate(IList<ItemsList> items, IReadOnlyDictionary<int, ItemCategory> categoriesById)
        {
            var groups = items.Where(i => !i.IsDelete && i.CategoryId is > 0)
                               .GroupBy(i => i.CategoryId!.Value);

            foreach (var group in groups)
            {
                if (!categoriesById.TryGetValue(group.Key, out var category) || string.IsNullOrEmpty(category.Code))
                    continue;

                int seq = 1;
                foreach (var item in group.OrderBy(i => ExtractTrailingSeq(i.Code)).ThenBy(i => i.Id))
                {
                    item.Code = category.Code + seq.ToString("000");
                    seq++;
                }
            }
        }

        private static int ExtractTrailingSeq(string? code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 3) return int.MaxValue;

            var last3 = code.Substring(code.Length - 3);
            return int.TryParse(last3, out var n) ? n : int.MaxValue;
        }

        public static async Task RecalculateAndSaveAsync(IApplicationDbContext db, CancellationToken ct = default)
        {
            var items = await db.ItemsList.Where(i => !i.IsDelete).ToListAsync(ct);
            var categoriesById = await db.ItemCategory.Where(c => !c.IsDelete).ToDictionaryAsync(c => c.Id, ct);

            var before = items.ToDictionary(i => i.Id, i => i.Code);

            Recalculate(items, categoriesById);

            var changed = items.Any(i => before[i.Id] != i.Code);
            if (changed)
                await db.SaveChangesAsync(ct);
        }
    }
}
