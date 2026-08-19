using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// ItemCategory is a self-referencing tree with 5 seeded, permanent root categories
    /// (IsFixed) — see Core/Tables/ItemCategory.cs. Code/LvlId/SortId are recomputed for the
    /// whole tree via the ported ItemCategoryCodeService after every write, mirroring
    /// frmItemCategoryAddEdit's behavior.
    /// </summary>
    public sealed class ItemCategoriesService
    {
        private readonly IApplicationDbContext _db;

        public ItemCategoriesService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ItemCategoryDto>> GetAllAsync(CancellationToken ct = default)
        {
            var categories = await _db.ItemCategory
                .OrderBy(c => c.LvlId).ThenBy(c => c.SortId)
                .ToListAsync(ct);

            var namesById = categories.ToDictionary(c => c.Id, c => c.Name);
            return categories.Select(c => ToDto(c, namesById)).ToList();
        }

        public async Task<ItemCategoryDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.ItemCategory.FirstOrDefaultAsync(c => c.Id == id, ct);
            if (entity is null) return null;

            var namesById = await _db.ItemCategory.ToDictionaryAsync(c => c.Id, c => c.Name, ct);
            return ToDto(entity, namesById);
        }

        public async Task<int> CreateAsync(ItemCategoryCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new ItemCategory
            {
                IsFixed = false, // the 5 permanent roots are seeded at startup, never created via this API
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.ItemCategory.Add(entity);
            await _db.SaveChangesAsync(ct);

            await ItemCategoryCodeService.RecalculateAndSaveAsync(_db, ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, ItemCategoryUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ItemCategory.FirstOrDefaultAsync(c => c.Id == id, ct)
                ?? throw new KeyNotFoundException($"Item category {id} not found.");

            if (entity.IsFixed)
                throw new InvalidOperationException("لا يمكن تعديل تصنيف رئيسي ثابت.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
            await ItemCategoryCodeService.RecalculateAndSaveAsync(_db, ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ItemCategory.FirstOrDefaultAsync(c => c.Id == id, ct)
                ?? throw new KeyNotFoundException($"Item category {id} not found.");

            if (entity.IsFixed)
                throw new InvalidOperationException("لا يمكن حذف تصنيف رئيسي ثابت.");

            var hasChildren = await _db.ItemCategory.AnyAsync(c => c.ParentId == id && !c.IsDelete, ct);
            if (hasChildren)
                throw new InvalidOperationException("لا يمكن حذف تصنيف له تصنيفات فرعية.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(ItemCategorySaveRequest request, ItemCategory entity)
        {
            entity.Name = request.Name;
            entity.ParentId = request.ParentId;
            entity.SortId = request.SortId;
        }

        private static ItemCategoryDto ToDto(ItemCategory c, IReadOnlyDictionary<int, string?> namesById) => new()
        {
            Id = c.Id,
            Code = c.Code,
            Name = c.Name,
            ParentId = c.ParentId,
            ParentName = c.ParentId is int pid && namesById.TryGetValue(pid, out var pname) ? pname : null,
            LvlId = c.LvlId,
            SortId = c.SortId,
            IsFixed = c.IsFixed
        };
    }
}
