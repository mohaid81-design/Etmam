using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/construction-inspection-requests")]
    public sealed class ConstructionInspectionRequestsController : ControllerBase
    {
        private readonly ConstructionInspectionRequestsService _service;

        public ConstructionInspectionRequestsController(ConstructionInspectionRequestsService service)
        {
            _service = service;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<ConstructionInspectionRequestDto>>> GetAll(CancellationToken ct) =>
            Ok(await _service.GetAllAsync(CurrentUserId, ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ConstructionInspectionRequestDto>> GetById(int id, CancellationToken ct)
        {
            var cir = await _service.GetByIdAsync(id, CurrentUserId, ct);
            return cir is null ? NotFound() : Ok(cir);
        }

        /// <summary>No reject endpoint: the desktop PM-approval gate this mirrors
        /// (frmCIRAddEdit.BtnApproved_ItemClick) has no reject action either.</summary>
        [HttpPost("{id:int}/approve")]
        public async Task<IActionResult> Approve(int id, WorkflowActionRequest request, CancellationToken ct)
        {
            try
            {
                await _service.ApproveAsync(id, request.Comment, CurrentUserId, ct);
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
