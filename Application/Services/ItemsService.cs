using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Code is never client-settable — it's derived from the chosen category via the ported
    /// ItemCodeService (category.Code + a 3-digit sequence within that category), recomputed
    /// after every create/update since a category change shifts which sequence applies.
    /// </summary>
    public sealed class ItemsService
    {
        private readonly IApplicationDbContext _db;

        public ItemsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ItemDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.ItemsList
                .Include(i => i.Category)
                .Include(i => i.Unit)
                .OrderBy(i => i.Name)
                .ToListAsync(ct);

            return items.Select(ToDto).ToList();
        }

        public async Task<ItemDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.ItemsList
                .Include(i => i.Category)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(i => i.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(ItemCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new ItemsList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.ItemsList.Add(entity);
            await _db.SaveChangesAsync(ct);

            await ItemCodeService.RecalculateAndSaveAsync(_db, ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, ItemUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ItemsList.FirstOrDefaultAsync(i => i.Id == id, ct)
                ?? throw new KeyNotFoundException($"Item {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
            await ItemCodeService.RecalculateAndSaveAsync(_db, ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ItemsList.FirstOrDefaultAsync(i => i.Id == id, ct)
                ?? throw new KeyNotFoundException($"Item {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(ItemSaveRequest request, ItemsList entity)
        {
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.IsActive = request.IsActive;
            entity.CategoryId = request.CategoryId;
            entity.UnitId = request.UnitId;
        }

        private static ItemDto ToDto(ItemsList i) => new()
        {
            Id = i.Id,
            Code = i.Code,
            Name = i.Name,
            Description = i.Description,
            IsActive = i.IsActive,
            CategoryId = i.CategoryId,
            CategoryName = i.Category?.Name,
            UnitId = i.UnitId,
            UnitName = i.Unit?.Description
        };
    }
}
