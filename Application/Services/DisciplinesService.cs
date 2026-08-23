using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Mirrors Etmam/Gui/General/Masters/Disciplines/{frmDisciplineAddEdit,ucDisciplinesList}.cs.</summary>
    public sealed class DisciplinesService
    {
        private readonly IApplicationDbContext _db;

        public DisciplinesService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<DisciplineDto>> GetAllAsync(CancellationToken ct = default)
        {
            var items = await _db.DisciplinesList.OrderBy(d => d.Name).ToListAsync(ct);
            return items.Select(ToDto).ToList();
        }

        public async Task<DisciplineDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.DisciplinesList.FirstOrDefaultAsync(d => d.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<int> CreateAsync(DisciplineCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new DisciplinesList
            {
                CreatedDate = DateTime.Now,
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.DisciplinesList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, DisciplineUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.DisciplinesList.FirstOrDefaultAsync(d => d.Id == id, ct)
                ?? throw new KeyNotFoundException($"Discipline {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.DisciplinesList.FirstOrDefaultAsync(d => d.Id == id, ct)
                ?? throw new KeyNotFoundException($"Discipline {id} not found.");

            if (await IsUsedAsync(id, ct))
                throw new InvalidOperationException("لا يمكن حذف هذا التخصص لأنه مستخدم في مستندات محفوظة.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        // Mirrors Etmam/Code/Helper/ItemStoreLock.cs's IsDisciplineUsed.
        private async Task<bool> IsUsedAsync(int disciplineId, CancellationToken ct) =>
            await _db.ConstructionInspectionRequestList.AnyAsync(x => x.DisciplineId == disciplineId && !x.IsDelete, ct)
            || await _db.MaterialReceiveList.AnyAsync(x => x.DisciplineId == disciplineId && !x.IsDelete, ct)
            || await _db.PurchaseRequestList.AnyAsync(x => x.DisciplineId == disciplineId && !x.IsDelete, ct)
            || await _db.SecondaryDisciplinesList.AnyAsync(x => x.DisciplineId == disciplineId && !x.IsDelete, ct)
            || await _db.WorkflowDefinitionDisciplineList.AnyAsync(x => x.DisciplineId == disciplineId && !x.IsDelete, ct);

        private static void Apply(DisciplineSaveRequest request, DisciplinesList entity)
        {
            entity.Name = request.Name;
            entity.Code = request.Code;
            entity.IsActive = request.IsActive;
        }

        private static DisciplineDto ToDto(DisciplinesList d) => new()
        {
            Id = d.Id,
            Name = d.Name,
            Code = d.Code,
            IsActive = d.IsActive
        };
    }
}
