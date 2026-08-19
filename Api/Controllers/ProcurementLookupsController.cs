using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/lookups")]
    public sealed class ProcurementLookupsController : ControllerBase
    {
        private readonly ProcurementLookupsService _lookupsService;

        public ProcurementLookupsController(ProcurementLookupsService lookupsService)
        {
            _lookupsService = lookupsService;
        }

        [HttpGet("cost-centers")]
        public async Task<ActionResult<List<CostCenterLookupDto>>> GetCostCenters(CancellationToken ct) =>
            Ok(await _lookupsService.GetCostCentersAsync(ct));

        [HttpGet("budgets")]
        public async Task<ActionResult<List<BudgetLookupDto>>> GetBudgets(CancellationToken ct) =>
            Ok(await _lookupsService.GetBudgetsAsync(ct));

        [HttpGet("disciplines")]
        public async Task<ActionResult<List<DisciplineLookupDto>>> GetDisciplines(CancellationToken ct) =>
            Ok(await _lookupsService.GetDisciplinesAsync(ct));

        [HttpGet("departments")]
        public async Task<ActionResult<List<DepartmentLookupDto>>> GetDepartments(CancellationToken ct) =>
            Ok(await _lookupsService.GetDepartmentsAsync(ct));
    }
}
