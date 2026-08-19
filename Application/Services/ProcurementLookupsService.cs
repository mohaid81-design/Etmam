using Application.Dtos;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>Read-only lookups for the Purchase Request form's dropdowns - no management/CRUD
    /// screens for these entities in this slice.</summary>
    public sealed class ProcurementLookupsService
    {
        private readonly IApplicationDbContext _db;

        public ProcurementLookupsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<CostCenterLookupDto>> GetCostCentersAsync(CancellationToken ct = default) =>
            await _db.CostCenterList
                .OrderBy(c => c.Name)
                .Select(c => new CostCenterLookupDto { Id = c.Id, Code = c.Code, Name = c.Name })
                .ToListAsync(ct);

        public async Task<List<BudgetLookupDto>> GetBudgetsAsync(CancellationToken ct = default) =>
            await _db.BudgetList
                .OrderBy(b => b.Description)
                .Select(b => new BudgetLookupDto { Id = b.Id, Description = b.Description })
                .ToListAsync(ct);

        public async Task<List<DisciplineLookupDto>> GetDisciplinesAsync(CancellationToken ct = default) =>
            await _db.DisciplinesList
                .OrderBy(d => d.Name)
                .Select(d => new DisciplineLookupDto { Id = d.Id, Name = d.Name })
                .ToListAsync(ct);

        public async Task<List<DepartmentLookupDto>> GetDepartmentsAsync(CancellationToken ct = default) =>
            await _db.DepartmentsList
                .OrderBy(d => d.Name)
                .Select(d => new DepartmentLookupDto { Id = d.Id, Name = d.Name })
                .ToListAsync(ct);
    }
}
