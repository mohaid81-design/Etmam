using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// One amendment to an already-approved Purchase Order (see the methodology doc's PO Amendments
    /// section: "Original PO / Previous Approved Amendments / Current Value Before Amendment / This
    /// Amendment / Revised PO Value"). PurchaseOrderList.OriginalValue is the true "Original PO" figure
    /// (captured once, never touched again); PreviousValue here is this specific amendment's own
    /// "current value before" snapshot — the prior approved amendment's RevisedValue, or OriginalValue
    /// if this is the first amendment (see POAmendmentService.GetCurrentValue). Only createable against
    /// a PO that is already Approved — the doc's rule that any change after approval must go through an
    /// amendment, never a direct edit to the PO itself.
    /// </summary>
    public class POAmendmentList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }

        [ForeignKey(nameof(PurchaseOrder))]
        public int? POId { get; set; }
        public PurchaseOrderList? PurchaseOrder { get; set; }

        public DateTime? AmendmentDate { get; set; }

        // Snapshot of the PO's effective value immediately before this amendment — captured at creation
        // time, never recomputed later (so this row's own history stays true even if amendments are
        // added/removed afterward elsewhere).
        public decimal? PreviousValue { get; set; }

        // The delta this amendment introduces — positive (increase) or negative (decrease).
        public decimal? AmendmentValue { get; set; }

        // PreviousValue + AmendmentValue, computed and stored at save time (not a live join), matching
        // PreviousValue's own "frozen snapshot" reasoning.
        public decimal? RevisedValue { get; set; }

        public string? Reason { get; set; }

        /// Draft / PendingApproval / Approved / Rejected — see POAmendmentStatus.
        public string? Status { get; set; }

        [NotMapped] public string? FormattedNum { get; set; }
        [NotMapped] public string? StatusDisplay { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }

        // Optimistic-concurrency token (SQL Server ROWVERSION) — see SqlDataHelper<T> and
        // DatabaseInitializer.GetSqlType.
        public byte[]? RowVersion { get; set; }
    }
}
