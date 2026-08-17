using System;

namespace Core
{
    /// <summary>
    /// Represents a file attachment linked to a drawing in the register.
    /// Files are stored on disk; this record stores the metadata and path.
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

        /// <summary>Full path where the file is stored on disk</summary>
        public string? StoredPath { get; set; }

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
