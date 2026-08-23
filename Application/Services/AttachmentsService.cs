using Application.Dtos;
using Application.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    /// <summary>
    /// Mirrors the CRUD behavior currently in Etmam/Gui/General/ucAttachmentAddEdit.cs — generic
    /// file attachments keyed by (EntityName, EntityRecordId), stored as DB bytes (AttachmentList.FileData).
    /// StoredPath (the legacy on-disk fallback) is read-only here: new uploads always go straight
    /// into FileData, matching the desktop client's current behavior.
    /// </summary>
    public sealed class AttachmentsService
    {
        private readonly IApplicationDbContext _db;

        public AttachmentsService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<AttachmentDto>> GetForEntityAsync(string entityName, int entityRecordId, CancellationToken ct = default) =>
            await _db.AttachmentList
                .Where(a => a.EntityName == entityName && a.EntityRecordId == entityRecordId)
                .OrderByDescending(a => a.UploadDate)
                .Select(a => new AttachmentDto
                {
                    Id = a.Id,
                    EntityName = a.EntityName ?? "",
                    EntityRecordId = a.EntityRecordId,
                    FileName = a.FileName ?? "",
                    FileExtension = a.FileExtension,
                    FileSizeKB = a.FileSizeKB,
                    Comment = a.Comment,
                    UploadDate = a.UploadDate,
                    UploadedBy = a.UploadedBy
                })
                .ToListAsync(ct);

        /// <summary>Returns the full entity (including FileData) for the download endpoint only —
        /// never exposed via the list DTO above.</summary>
        public Task<AttachmentList?> GetForDownloadAsync(int id, CancellationToken ct = default) =>
            _db.AttachmentList.FirstOrDefaultAsync(a => a.Id == id, ct);

        public async Task<int> UploadAsync(string entityName, int entityRecordId, string fileName, byte[] data,
            string uploadedByName, int currentUserId, CancellationToken ct = default)
        {
            var entity = new AttachmentList
            {
                EntityName = entityName,
                EntityRecordId = entityRecordId,
                FileName = fileName,
                FileData = data,
                FileExtension = Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant(),
                FileSizeKB = data.Length > 0 ? Math.Max(1, data.Length / 1024) : 0,
                Comment = "",
                UploadDate = DateTime.Now,
                UploadedBy = uploadedByName,
                CreatedDate = DateTime.Now,
                CreatedBy = currentUserId,
                CreatedMachine = Environment.MachineName
            };

            _db.AttachmentList.Add(entity);
            await _db.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateCommentAsync(int id, string? comment, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.AttachmentList.FirstOrDefaultAsync(a => a.Id == id, ct)
                ?? throw new KeyNotFoundException($"Attachment {id} not found.");

            entity.Comment = comment;
            entity.UpdateDate = DateTime.Now;
            entity.UpdateMachine = Environment.MachineName;
            entity.UpdateBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int currentUserId, CancellationToken ct = default)
        {
            var entity = await _db.AttachmentList.FirstOrDefaultAsync(a => a.Id == id, ct)
                ?? throw new KeyNotFoundException($"Attachment {id} not found.");

            entity.IsDelete = true;
            entity.DeletionDate = DateTime.Now;
            entity.DeletionMachine = Environment.MachineName;
            entity.DeletionBy = currentUserId;

            await _db.SaveChangesAsync(ct);
        }
    }
}
