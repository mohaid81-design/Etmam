using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/purchase-requests")]
    public sealed class PurchaseRequestsController : ControllerBase
    {
        private readonly PurchaseRequestsService _purchaseRequestsService;

        public PurchaseRequestsController(PurchaseRequestsService purchaseRequestsService)
        {
            _purchaseRequestsService = purchaseRequestsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        [HttpGet]
        public async Task<ActionResult<List<PurchaseRequestDto>>> GetAll(CancellationToken ct) =>
            Ok(await _purchaseRequestsService.GetAllAsync(CurrentUserId, ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseRequestDto>> GetById(int id, CancellationToken ct)
        {
            var pr = await _purchaseRequestsService.GetByIdAsync(id, CurrentUserId, ct);
            return pr is null ? NotFound() : Ok(pr);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(PurchaseRequestCreateRequest request, CancellationToken ct)
        {
            var id = await _purchaseRequestsService.CreateAsync(request, CurrentUserId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PurchaseRequestUpdateRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.UpdateAsync(id, request, CurrentUserId, ct));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.DeleteAsync(id, CurrentUserId, ct));

        [HttpGet("{id:int}/available-procedures")]
        public async Task<ActionResult<List<WorkflowDefinitionDto>>> GetAvailableProcedures(int id, CancellationToken ct)
        {
            try
            {
                return Ok(await _purchaseRequestsService.GetAvailableProceduresAsync(id, ct));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{id:int}/send")]
        public async Task<IActionResult> Send(int id, SendForApprovalRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.SendForApprovalAsync(id, request.WorkflowDefinitionId, CurrentUserId, ct));

        [HttpPost("{id:int}/approve")]
        public async Task<IActionResult> Approve(int id, WorkflowActionRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.ApproveAsync(id, request.Comment, CurrentUserId, ct));

        [HttpPost("{id:int}/reject")]
        public async Task<IActionResult> Reject(int id, WorkflowActionRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.RejectAsync(id, request.Comment, CurrentUserId, ct));

        [HttpGet("{id:int}/return-to-step-options")]
        public async Task<ActionResult<List<WorkflowStepOptionDto>>> GetReturnToStepOptions(int id, CancellationToken ct)
        {
            try
            {
                return Ok(await _purchaseRequestsService.GetReturnToStepOptionsAsync(id, ct));
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

        [HttpPost("{id:int}/return-to-step")]
        public async Task<IActionResult> ReturnToStep(int id, ReturnToStepRequest request, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.ReturnToStepAsync(id, request.TargetStepOrder, request.Comment, CurrentUserId, ct));

        [HttpPost("{id:int}/close")]
        public async Task<IActionResult> Close(int id, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.CloseAsync(id, CurrentUserId, ct));

        [HttpPost("{id:int}/return-for-edit")]
        public async Task<IActionResult> ReturnForEdit(int id, CancellationToken ct) =>
            await Guarded(() => _purchaseRequestsService.ReturnForEditAsync(id, CurrentUserId, ct));

        /// <summary>Shared error mapping for every state-changing action above: a missing record is a
        /// 404, and every workflow/state-machine guard (wrong status, not the assignee, self-approval,
        /// ...) is a 400 with the exact Arabic message the service already produced.</summary>
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
