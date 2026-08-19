using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Mirrors the CRUD + soft-delete behavior currently in
    /// Etmam/Gui/General/ProjectsMgt/ucProjectsMgt.cs and frmProjectAddEdit.cs.
    /// </summary>
    public sealed class ProjectsService
    {
        private readonly IApplicationDbContext _db;

        public ProjectsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProjectDto>> GetAllAsync(CancellationToken ct = default)
        {
            // Eager-load + map client-side rather than `.Select(p => ToDto(p))`, so the projection
            // doesn't depend on EF Core being able to translate a call into ToDto (which touches
            // navigation properties) into SQL.
            var projects = await _db.ProjectsList
                .Include(p => p.Client)
                .Include(p => p.Consultant)
                .OrderBy(p => p.Name)
                .ToListAsync(ct);

            return projects.Select(ToDto).ToList();
        }

        public async Task<ProjectDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.ProjectsList
                .Include(p => p.Client)
                .Include(p => p.Consultant)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<List<StakeholderLookupDto>> GetClientsAsync(CancellationToken ct = default) =>
            await _db.StakeholdersList
                .Where(s => !s.IsDelete && s.IsClient == true)
                .OrderBy(s => s.Name)
                .Select(s => new StakeholderLookupDto { Id = s.Id, Name = s.Name })
                .ToListAsync(ct);

        public async Task<List<StakeholderLookupDto>> GetConsultantsAsync(CancellationToken ct = default) =>
            await _db.StakeholdersList
                .Where(s => !s.IsDelete && s.IsConsultant == true)
                .OrderBy(s => s.Name)
                .Select(s => new StakeholderLookupDto { Id = s.Id, Name = s.Name })
                .ToListAsync(ct);

        public async Task<int> CreateAsync(ProjectCreateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = new ProjectsList
            {
                CreatedDate = DateTime.Now,
                // Records the API host, not the originating client PC, now that writes go through
                // this service instead of running in-process on the user's machine.
                CreatedMachine = Environment.MachineName,
                CreatedBy = currentUserId
            };
            Apply(request, entity);

            _db.ProjectsList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, ProjectUpdateRequest request, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ProjectsList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Project {id} not found.");

            Apply(request, entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.ProjectsList.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"Project {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            // Mirrors ucProjectsMgt.cs's dc.UserProjectAccess.DeleteBy("PrjId = @PrjId", ...) side effect.
            var accessRows = await _db.UserProjectAccess.Where(a => a.PrjId == id).ToListAsync(ct);
            _db.UserProjectAccess.RemoveRange(accessRows);

            await _db.SaveChangesAsync(ct);
        }

        private static void Apply(ProjectSaveRequest request, ProjectsList entity)
        {
            entity.Num = request.Num;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.CLId = request.CLId;
            entity.CSTId = request.CSTId;
            entity.ContractDate = request.ContractDate;
            entity.ContractAmount = request.ContractAmount;
            entity.AdvancePaymentAmount = request.AdvancePaymentAmount;
            entity.AdvancePaymentPercent = request.AdvancePaymentPercent;
            entity.RetentionPercent = request.RetentionPercent;
        }

        private static ProjectDto ToDto(ProjectsList p) => new()
        {
            Id = p.Id,
            Num = p.Num,
            Name = p.Name,
            Description = p.Description,
            Status = p.Status,
            Type = p.Type,
            Situation = p.Situation,
            ProjectStartDate = p.ProjectStartDate,
            InitialHandover = p.InitialHandover,
            FinalHandover = p.FinalHandover,
            ContractDate = p.ContractDate,
            ContractAmount = p.ContractAmount,
            AdvancePaymentAmount = p.AdvancePaymentAmount,
            AdvancePaymentPercent = p.AdvancePaymentPercent,
            RetentionPercent = p.RetentionPercent,
            CLId = p.CLId,
            CSTId = p.CSTId,
            ClientName = p.Client?.Name,
            ConsultantName = p.Consultant?.Name,
            UpdateDate = p.UpdateDate
        };
    }
}
