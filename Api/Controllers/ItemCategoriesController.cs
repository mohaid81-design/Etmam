using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/item-categories")]
    public sealed class ItemCategoriesController : ControllerBase
    {
        private readonly ItemCategoriesService _itemCategoriesService;

        public ItemCategoriesController(ItemCategoriesService itemCategoriesService)
        {
            _itemCategoriesService = itemCategoriesService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<ItemCategoryDto>>> GetAll(CancellationToken ct) =>
            Ok(await _itemCategoriesService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemCategoryDto>> GetById(int id, CancellationToken ct)
        {
            var category = await _itemCategoriesService.GetByIdAsync(id, ct);
            return category is null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(ItemCategoryCreateRequest request, CancellationToken ct)
        {
            var id = await _itemCategoriesService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ItemCategoryUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _itemCategoriesService.UpdateAsync(id, request, CurrentUserId, ct);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                await _itemCategoriesService.DeleteAsync(id, CurrentUserId, ct);
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
