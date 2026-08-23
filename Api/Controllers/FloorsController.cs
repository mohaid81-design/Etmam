using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/floors")]
    public sealed class FloorsController : ControllerBase
    {
        private readonly FloorsService _floorsService;

        public FloorsController(FloorsService floorsService)
        {
            _floorsService = floorsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<FloorDto>>> GetAll(CancellationToken ct) =>
            Ok(await _floorsService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FloorDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _floorsService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(FloorCreateRequest request, CancellationToken ct)
        {
            var id = await _floorsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, FloorUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _floorsService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _floorsService.DeleteAsync(id, CurrentUserId, ct);
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
