using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/disciplines")]
    public sealed class DisciplinesController : ControllerBase
    {
        private readonly DisciplinesService _disciplinesService;

        public DisciplinesController(DisciplinesService disciplinesService)
        {
            _disciplinesService = disciplinesService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<DisciplineDto>>> GetAll(CancellationToken ct) =>
            Ok(await _disciplinesService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DisciplineDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _disciplinesService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(DisciplineCreateRequest request, CancellationToken ct)
        {
            var id = await _disciplinesService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, DisciplineUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _disciplinesService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _disciplinesService.DeleteAsync(id, CurrentUserId, ct);
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
