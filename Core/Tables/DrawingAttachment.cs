using System;

namespace Core
{
    /// <summary>
    /// Represents a file attachment linked to a drawing in the register.
    /// File bytes are stored directly in this row (FileData); StoredPath is a legacy fallback for
    /// attachments uploaded before this change, still stored on disk.
    /// </summary>
    public class DrawingAttachment : IBaseEntity
    {
        // ── Audit (IBaseEntity) ───────────────────────────────────────────────
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }

        // ── Relationship ─────────────────────────────────────────────────────
        /// <summary>FK → DrawingsRegisterList.Id</summary>
        public int DrawingId { get; set; }

        // ── File Metadata ────────────────────────────────────────────────────
        /// <summary>Original file name shown to the user (e.g. "Plan_Rev2.pdf")</summary>
        public string? FileName { get; set; }

        /// <summary>Legacy: full path where the file used to be stored on disk. Left populated only on
        /// attachments uploaded before file bytes moved into the database (see FileData) — no longer
        /// written for new uploads, kept so old rows still open via AttachmentStorage's disk fallback.</summary>
        public string? StoredPath { get; set; }

        /// <summary>The file's raw bytes, stored directly in the database (VARBINARY(MAX)) — avoids the
        /// stale-path problem of disk/network storage (moved/renamed shared folders orphaning StoredPath).
        /// Null on legacy rows that still rely on StoredPath.</summary>
        public byte[]? FileData { get; set; }

        /// <summary>Extension without dot, lowercase (e.g. "pdf", "dwg")</summary>
        public string? FileExtension { get; set; }

        /// <summary>File size in kilobytes</summary>
        public int FileSizeKB { get; set; }

        /// <summary>Optional description / comment for this attachment</summary>
        public string? Comment { get; set; }

        // ── Upload Info ──────────────────────────────────────────────────────
        public DateTime? UploadDate { get; set; }
        public string? UploadedBy { get; set; }
    }
}
