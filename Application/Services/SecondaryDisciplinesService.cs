using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Gui/General/Masters/SecondaryDisciplines/{frmSecondaryDisciplineAddEdit,ucSecondaryDisciplinesList}.cs.</summary>
    public sealed class SecondaryDisciplinesService
    {
        private readonly IApplicationDbContext _db;

        public SecondaryDisciplinesService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<SecondaryDisciplineDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.SecondaryDisciplinesList.OrderBy(s => s.Name).ToListAsync(ct);
            return items.Select(ToDto).ToList();
        }

        public async Task<SecondaryDisciplineDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.SecondaryDisciplinesList.FirstOrDefaultAsync(s => s.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(SecondaryDisciplineCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new SecondaryDisciplinesList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.SecondaryDisciplinesList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, SecondaryDisciplineUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.SecondaryDisciplinesList.FirstOrDefaultAsync(s => s.Id == id, ct)
                ?? throw new KeyNotFoundException($"SecondaryDiscipline {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.SecondaryDisciplinesList.FirstOrDefaultAsync(s => s.Id == id, ct)
                ?? throw new KeyNotFoundException($"SecondaryDiscipline {id} not found.");

            if (await IsUsedAsync(id, ct))
                throw new InvalidOperationException("لا يمكن حذف هذا التخصص الثانوي لأنه مستخدم في مستندات محفوظة.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        // Mirrors Etmam/Code/Helper/ItemStoreLock.cs's IsSecondaryDisciplineUsed.
        private async Task<bool> IsUsedAsync(int secondaryDisciplineId, CancellationToken ct) =>
            await _db.ConstructionInspectionRequestList.AnyAsync(x => x.SecondaryDisciplineId == secondaryDisciplineId && !x.IsDelete, ct)
            || await _db.InspectionActivityList.AnyAsync(x => x.SecondaryDisciplineId == secondaryDisciplineId && !x.IsDelete, ct);

        private static void Apply(SecondaryDisciplineSaveRequest request, SecondaryDisciplinesList entity)
        {
            entity.DisciplineId = request.DisciplineId;
            entity.Name = request.Name;
            entity.Code = request.Code;
            entity.IsActive = request.IsActive;
        }

        private static SecondaryDisciplineDto ToDto(SecondaryDisciplinesList s) => new()
        {
            Id = s.Id,
            DisciplineId = s.DisciplineId,
            Name = s.Name,
            Code = s.Code,
            IsActive = s.IsActive
        };
    }
}
