using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Per-line technical compliance verdict — one row per PriceQuotationRequestDetails line of
    /// the quotation being evaluated (see TechnicalEvaluationList.PriceQuotationRequestId). Deliberately
    /// carries no commercial fields (no price/total) — this table is read/written only from the
    /// compliance side of frmTechnicalEvaluationAddEdit, keeping the technical/commercial separation
    /// structural rather than just a UI hint.</summary>
    public class TechnicalEvaluationDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(TechnicalEvaluation))]
        public int? ParentId { get; set; }
        public TechnicalEvaluationList? TechnicalEvaluation { get; set; }

        [ForeignKey(nameof(QuotationLine))]
        public int? PriceQuotationRequestDetailId { get; set; }
        public PriceQuotationRequestDetails? QuotationLine { get; set; }

        public bool? IsCompliant { get; set; }
        public string? Comment { get; set; }

        // Display-only, populated at load/creation time by joining the quotation line this row
        // evaluates (PriceQuotationRequestDetailId) — never persisted here, so editing a quotation
        // line afterward is always reflected instead of going stale. Commercial fields (UnitPrice/
        // TotalPrice) are populated regardless of the viewer's permission; the UI alone decides
        // whether to bind/show those specific columns (see PermNames.ViewCommercialPrices).
        [NotMapped] public string? ItemDisplay { get; set; }
        [NotMapped] public decimal? Qty { get; set; }
        [NotMapped] public string? UnitDisplay { get; set; }
        [NotMapped] public decimal? UnitPrice { get; set; }
        [NotMapped] public decimal? TotalPrice { get; set; }

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
