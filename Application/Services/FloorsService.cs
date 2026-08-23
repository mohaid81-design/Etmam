using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Gui/General/Masters/Floors/{frmFloorAddEdit,ucFloorsList}.cs.</summary>
    public sealed class FloorsService
    {
        private readonly IApplicationDbContext _db;

        public FloorsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<FloorDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.FloorsList.OrderBy(f => f.Name).ToListAsync(ct);
            return items.Select(ToDto).ToList();
        }

        public async Task<FloorDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.FloorsList.FirstOrDefaultAsync(f => f.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(FloorCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new FloorsList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.FloorsList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, FloorUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.FloorsList.FirstOrDefaultAsync(f => f.Id == id, ct)
                ?? throw new KeyNotFoundException($"Floor {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.FloorsList.FirstOrDefaultAsync(f => f.Id == id, ct)
                ?? throw new KeyNotFoundException($"Floor {id} not found.");

            if (await IsUsedAsync(id, ct))
                throw new InvalidOperationException("لا يمكن حذف هذا الطابق لأنه مستخدم في مستندات محفوظة.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        // Mirrors Etmam/Code/Helper/ItemStoreLock.cs's IsFloorUsed - ConstructionInspectionRequestList.FloorIds
        // stores checked floor ids as a comma-separated string (CheckedComboBoxEdit's native format)
        // rather than a normal FK column, so this can't be a SQL WHERE clause; every non-deleted CIR
        // is fetched and each one's list is parsed and searched in C#, same as the desktop version.
        private async Task<bool> IsUsedAsync(int floorId, CancellationToken ct)
        {
            var idText = floorId.ToString();
            var requests = await _db.ConstructionInspectionRequestList.Where(r => !r.IsDelete).ToListAsync(ct);
            return requests.Any(r => (r.FloorIds ?? string.Empty)
                .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Contains(idText));
        }

        private static void Apply(FloorSaveRequest request, FloorsList entity)
        {
            entity.BuildingId = request.BuildingId;
            entity.Name = request.Name;
            entity.IsActive = request.IsActive;
        }

        private static FloorDto ToDto(FloorsList f) => new()
        {
            Id = f.Id,
            BuildingId = f.BuildingId,
            Name = f.Name,
            IsActive = f.IsActive
        };
    }
}
