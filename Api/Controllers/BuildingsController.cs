using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/buildings")]
    public sealed class BuildingsController : ControllerBase
    {
        private readonly BuildingsService _buildingsService;

        public BuildingsController(BuildingsService buildingsService)
        {
            _buildingsService = buildingsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<BuildingDto>>> GetAll(CancellationToken ct) =>
            Ok(await _buildingsService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuildingDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _buildingsService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(BuildingCreateRequest request, CancellationToken ct)
        {
            var id = await _buildingsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BuildingUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _buildingsService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _buildingsService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
