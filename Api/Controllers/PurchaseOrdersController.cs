using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/purchase-orders")]
    public sealed class PurchaseOrdersController : ControllerBase
    {
        private readonly PurchaseOrdersService _purchaseOrdersService;

        public PurchaseOrdersController(PurchaseOrdersService purchaseOrdersService)
        {
            _purchaseOrdersService = purchaseOrdersService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<PurchaseOrderDto>>> GetAll(CancellationToken ct) =>
            Ok(await _purchaseOrdersService.GetAllAsync(CurrentUserId, ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseOrderDto>> GetById(int id, CancellationToken ct)
        {
            var po = await _purchaseOrdersService.GetByIdAsync(id, CurrentUserId, ct);
            return po is null ? NotFound() : Ok(po);
        }

        [HttpPost("{id:int}/approve")]
        public async Task<IActionResult> Approve(int id, WorkflowActionRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseOrdersService.ApproveAsync(id, request.Comment, CurrentUserId, ct));

        [HttpPost("{id:int}/reject")]
        public async Task<IActionResult> Reject(int id, WorkflowActionRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseOrdersService.RejectAsync(id, request.Comment, CurrentUserId, ct));

        /// <summary>Shared error mapping: a missing record is a 404, and every workflow/state-machine
        /// guard (wrong status, not the assignee, self-approval, ...) is a 400 with the exact Arabic
        /// message the service already produced.</summary>
        private async Task<IActionResult> Guarded(Func<Task> action)
        {
            try
            {
                await action();
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
