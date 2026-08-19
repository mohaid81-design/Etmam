using System.ComponentModel.DataAnnotations;

namespace Core
{
    /// <summary>
    /// Generic entity-level audit trail — records who changed what and when, independent of any
    /// approval workflow. Deliberately separate from WorkflowInstanceHistoryList, which only records
    /// workflow actions (Approve/Reject/ReturnedToStep) and says nothing about direct header/detail
    /// edits made outside the workflow (e.g. editing a Draft before submission). Never written to
    /// directly; always go through AuditService so every entry is captured inside the same transaction
    /// as the change it describes.
    /// </summary>
    public class AuditLog
    {
        [Key] public int Id { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public int EntityId { get; set; }

        /// Create / Update / Delete
        public string Action { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }

        /// JSON snapshot of the entity's mapped column values before the change (null for Create).
        public string? OldValuesJson { get; set; }

        /// JSON snapshot of the entity's mapped column values after the change (null for Delete).
        public string? NewValuesJson { get; set; }

        /// Groups multiple AuditLog rows written from the same logical save (e.g. a header + its
        /// detail rows) — see AuditService's correlationId parameter. Not yet populated by every
        /// caller; null means "not correlated to anything else".
        public string? CorrelationId { get; set; }

        public string? MachineName { get; set; }
    }
}
