using System;

namespace Core
{
    /// <summary>
    /// Generic file attachment linked to any record in the system (identified by EntityName + EntityRecordId).
    /// Files are stored on disk; this record stores the metadata and path.
    /// Used by the reusable ucAttachmentAddEdit control, so any Add/Edit form can attach files
    /// without a dedicated per-module attachment table.
    /// </summary>
    public class AttachmentList : IBaseEntity
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
        /// <summary>Name of the Core.Tables entity/table this attachment belongs to (e.g. "PurchaseRequestList").</summary>
        public string? EntityName { get; set; }
        public int EntityRecordId { get; set; }

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
