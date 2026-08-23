using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Gui/General/Masters/InspectionActivities/{frmInspectionActivityAddEdit,ucInspectionActivitiesList}.cs.</summary>
    public sealed class InspectionActivitiesService
    {
        private readonly IApplicationDbContext _db;

        public InspectionActivitiesService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<InspectionActivityDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.InspectionActivityList.OrderBy(i => i.Name).ToListAsync(ct);
            return items.Select(ToDto).ToList();
        }

        public async Task<InspectionActivityDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.InspectionActivityList.FirstOrDefaultAsync(i => i.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(InspectionActivityCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new InspectionActivityList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.InspectionActivityList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, InspectionActivityUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.InspectionActivityList.FirstOrDefaultAsync(i => i.Id == id, ct)
                ?? throw new KeyNotFoundException($"InspectionActivity {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.InspectionActivityList.FirstOrDefaultAsync(i => i.Id == id, ct)
                ?? throw new KeyNotFoundException($"InspectionActivity {id} not found.");

            if (await IsUsedAsync(id, ct))
                throw new InvalidOperationException("لا يمكن حذف نشاط الفحص هذا لأنه مستخدم في مستندات محفوظة.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        // Mirrors Etmam/Code/Helper/ItemStoreLock.cs's IsInspectionActivityUsed.
        private async Task<bool> IsUsedAsync(int inspectionActivityId, CancellationToken ct) =>
            await _db.ConstructionInspectionRequestList.AnyAsync(x => x.InspectionActivityId == inspectionActivityId && !x.IsDelete, ct);

        private static void Apply(InspectionActivitySaveRequest request, InspectionActivityList entity)
        {
            entity.SecondaryDisciplineId = request.SecondaryDisciplineId;
            entity.Name = request.Name;
            entity.Code = request.Code;
            entity.IsActive = request.IsActive;
        }

        private static InspectionActivityDto ToDto(InspectionActivityList i) => new()
        {
            Id = i.Id,
            SecondaryDisciplineId = i.SecondaryDisciplineId,
            Name = i.Name,
            Code = i.Code,
            IsActive = i.IsActive
        };
    }
}
