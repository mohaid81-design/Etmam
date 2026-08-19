using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Line-level detail of what changed within a PO Amendment — optionally tied to a specific
    /// Purchase Order line (POLineId), or left null for a general/header-level change (e.g. a revised
    /// delivery date or contract term) that isn't about any one line's quantity/price.</summary>
    public class POAmendmentDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(Amendment))]
        public int? ParentId { get; set; }
        public POAmendmentList? Amendment { get; set; }

        [ForeignKey(nameof(POLine))]
        public int? POLineId { get; set; }
        public PurchaseOrderDetails? POLine { get; set; }

        public string? Description { get; set; }
        public decimal? OldValue { get; set; }
        public decimal? NewValue { get; set; }
        public string? Note { get; set; }

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
    }
}
