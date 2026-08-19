using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/suppliers")]
    public sealed class SuppliersController : ControllerBase
    {
        private readonly SuppliersService _suppliersService;

        public SuppliersController(SuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAll(CancellationToken ct) =>
            Ok(await _suppliersService.GetAllAsync(ct));

        [HttpGet("categories")]
        public async Task<ActionResult<List<SupplierCategoryDto>>> GetCategories(CancellationToken ct) =>
            Ok(await _suppliersService.GetCategoriesAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id, CancellationToken ct)
        {
            var supplier = await _suppliersService.GetByIdAsync(id, ct);
            return supplier is null ? NotFound() : Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(SupplierCreateRequest request, CancellationToken ct)
        {
            var id = await _suppliersService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, SupplierUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _suppliersService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _suppliersService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
