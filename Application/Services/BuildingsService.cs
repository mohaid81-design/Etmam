using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Gui/General/Masters/Buildings/{frmBuildingAddEdit,ucBuildingsList}.cs.</summary>
    public sealed class BuildingsService
    {
        private readonly IApplicationDbContext _db;

        public BuildingsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<BuildingDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.BuildingsList.OrderBy(b => b.Name).ToListAsync(ct);
            return items.Select(ToDto).ToList();
        }

        public async Task<BuildingDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.BuildingsList.FirstOrDefaultAsync(b => b.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(BuildingCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new BuildingsList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.BuildingsList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, BuildingUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.BuildingsList.FirstOrDefaultAsync(b => b.Id == id, ct)
                ?? throw new KeyNotFoundException($"Building {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.BuildingsList.FirstOrDefaultAsync(b => b.Id == id, ct)
                ?? throw new KeyNotFoundException($"Building {id} not found.");

            if (await IsUsedAsync(id, ct))
                throw new InvalidOperationException("لا يمكن حذف هذا المبنى لأنه مستخدم في مستندات محفوظة.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        // Mirrors Etmam/Code/Helper/ItemStoreLock.cs's IsBuildingUsed.
        private async Task<bool> IsUsedAsync(int buildingId, CancellationToken ct) =>
            await _db.ConstructionInspectionRequestList.AnyAsync(x => x.BuildingId == buildingId && !x.IsDelete, ct)
            || await _db.FloorsList.AnyAsync(x => x.BuildingId == buildingId && !x.IsDelete, ct);

        private static void Apply(BuildingSaveRequest request, BuildingsList entity)
        {
            entity.PrjId = request.PrjId;
            entity.Name = request.Name;
            entity.IsActive = request.IsActive;
        }

        private static BuildingDto ToDto(BuildingsList b) => new()
        {
            Id = b.Id,
            PrjId = b.PrjId,
            Name = b.Name,
            IsActive = b.IsActive
        };
    }
}
