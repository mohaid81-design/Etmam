using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/projects")]
    public sealed class ProjectsController : ControllerBase
    {
        private readonly ProjectsService _projectsService;

        public ProjectsController(ProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAll(CancellationToken ct) =>
            Ok(await _projectsService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> GetById(int id, CancellationToken ct)
        {
            var project = await _projectsService.GetByIdAsync(id, ct);
            return project is null ? NotFound() : Ok(project);
        }

        [HttpGet("clients")]
        public async Task<ActionResult<List<StakeholderLookupDto>>> GetClients(CancellationToken ct) =>
            Ok(await _projectsService.GetClientsAsync(ct));

        [HttpGet("consultants")]
        public async Task<ActionResult<List<StakeholderLookupDto>>> GetConsultants(CancellationToken ct) =>
            Ok(await _projectsService.GetConsultantsAsync(ct));

        [HttpPost]
        public async Task<ActionResult<int>> Create(ProjectCreateRequest request, CancellationToken ct)
        {
            var id = await _projectsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProjectUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _projectsService.UpdateAsync(id, request, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                await _projectsService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
