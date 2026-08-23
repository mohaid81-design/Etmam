using System.IdentityModel.Tokens.Jwt;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Generic file-attachment endpoints keyed by (EntityName, EntityRecordId) — see
    /// Application/Services/AttachmentsService.cs and Etmam/Gui/General/ucAttachmentAddEdit.cs
    /// (the WinForms control this is the API-backed replacement for).
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/attachments")]
    public sealed class AttachmentsController : ControllerBase
    {
        private readonly AttachmentsService _attachmentsService;

        public AttachmentsController(AttachmentsService attachmentsService)
        {
            _attachmentsService = attachmentsService;
        }

        private int CurrentUserId =>
            int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        // The JWT only carries the username (see Infrastructure/Auth/JwtTokenGenerator.cs), not a
        // display FullName — matches the desktop client's own fallback order
        // (Session.CurrentUser?.FullName ?? ...UserName ?? "مجهول") minus the FullName step, which
        // isn't available here without an extra DB round-trip for a purely cosmetic field.
        private string CurrentUserName =>
            User.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value ?? "مجهول";

        [HttpGet]
        public async Task<ActionResult<List<AttachmentDto>>> GetForEntity(
            [FromQuery] string entityName, [FromQuery] int entityRecordId, CancellationToken ct) =>
            Ok(await _attachmentsService.GetForEntityAsync(entityName, entityRecordId, ct));

        [HttpGet("{id:int}/download")]
        public async Task<IActionResult> Download(int id, CancellationToken ct)
        {
            var entity = await _attachmentsService.GetForDownloadAsync(id, ct);
            if (entity is null) return NotFound();

            if (entity.FileData is not { Length: > 0 })
                return NotFound(new { message = "الملف غير مخزّن في قاعدة البيانات (مرفق قديم على القرص)." });

            return File(entity.FileData, "application/octet-stream", entity.FileName ?? "attachment");
        }

        [HttpPost]
        [RequestSizeLimit(50_000_000)]
        public async Task<ActionResult<int>> Upload(
            [FromForm] string entityName, [FromForm] int entityRecordId, [FromForm] IFormFile file, CancellationToken ct)
        {
            if (file.Length == 0)
                return BadRequest(new { message = "الملف فارغ." });

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, ct);

            var id = await _attachmentsService.UploadAsync(
                entityName, entityRecordId, file.FileName, ms.ToArray(), CurrentUserName, CurrentUserId, ct);

            return CreatedAtAction(nameof(GetForEntity), new { entityName, entityRecordId }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment(int id, AttachmentUpdateRequest request, CancellationToken ct)
        {
            try
            {
                await _attachmentsService.UpdateCommentAsync(id, request.Comment, CurrentUserId, ct);
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
                await _attachmentsService.DeleteAsync(id, CurrentUserId, ct);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
