using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/units")]
    public sealed class UnitsController : ControllerBase
    {
        private readonly UnitsService _unitsService;

        public UnitsController(UnitsService unitsService)
        {
            _unitsService = unitsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<UnitDto>>> GetAll(CancellationToken ct) =>
            Ok(await _unitsService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UnitDto>> GetById(int id, CancellationToken ct)
        {
            var unit = await _unitsService.GetByIdAsync(id, ct);
            return unit is null ? NotFound() : Ok(unit);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(UnitCreateRequest request, CancellationToken ct)
        {
            var id = await _unitsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UnitUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _unitsService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _unitsService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
