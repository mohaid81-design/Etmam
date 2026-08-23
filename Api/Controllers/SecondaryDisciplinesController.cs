using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/secondary-disciplines")]
    public sealed class SecondaryDisciplinesController : ControllerBase
    {
        private readonly SecondaryDisciplinesService _secondaryDisciplinesService;

        public SecondaryDisciplinesController(SecondaryDisciplinesService secondaryDisciplinesService)
        {
            _secondaryDisciplinesService = secondaryDisciplinesService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<SecondaryDisciplineDto>>> GetAll(CancellationToken ct) =>
            Ok(await _secondaryDisciplinesService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SecondaryDisciplineDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _secondaryDisciplinesService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(SecondaryDisciplineCreateRequest request, CancellationToken ct)
        {
            var id = await _secondaryDisciplinesService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, SecondaryDisciplineUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _secondaryDisciplinesService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _secondaryDisciplinesService.DeleteAsync(id, CurrentUserId, ct);
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
