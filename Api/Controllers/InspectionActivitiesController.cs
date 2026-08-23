using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/inspection-activities")]
    public sealed class InspectionActivitiesController : ControllerBase
    {
        private readonly InspectionActivitiesService _inspectionActivitiesService;

        public InspectionActivitiesController(InspectionActivitiesService inspectionActivitiesService)
        {
            _inspectionActivitiesService = inspectionActivitiesService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<InspectionActivityDto>>> GetAll(CancellationToken ct) =>
            Ok(await _inspectionActivitiesService.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InspectionActivityDto>> GetById(int id, CancellationToken ct)
        {
            var item = await _inspectionActivitiesService.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(InspectionActivityCreateRequest request, CancellationToken ct)
        {
            var id = await _inspectionActivitiesService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, InspectionActivityUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _inspectionActivitiesService.UpdateAsync(id, request, CurrentUserId, ct);
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
                await _inspectionActivitiesService.DeleteAsync(id, CurrentUserId, ct);
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
