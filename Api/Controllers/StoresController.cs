using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/stores")]
    public sealed class StoresController : ControllerBase
    {
        private readonly StoresService _storesService;

        public StoresController(StoresService storesService)
        {
            _storesService = storesService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<StoreDto>>> GetAll(CancellationToken ct) =>
            Ok(await _storesService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StoreDto>> GetById(int id, CancellationToken ct)
        {
            var store = await _storesService.GetByIdAsync(id, ct);
            return store is null ? NotFound() : Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(StoreCreateRequest request, CancellationToken ct)
        {
            var id = await _storesService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, StoreUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _storesService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _storesService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
