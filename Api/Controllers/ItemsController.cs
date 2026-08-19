using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/items")]
    public sealed class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> GetAll(CancellationToken ct) =>
            Ok(await _itemsService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _itemsService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(ItemCreateRequest request, CancellationToken ct)
        {
            var id = await _itemsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ItemUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _itemsService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _itemsService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
