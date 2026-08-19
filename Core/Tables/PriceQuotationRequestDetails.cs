using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class PriceQuotationRequestDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? ParentId { get; set; }     // PriceQuotationRequestList.Id
        public int? PRDetailsId { get; set; }  // PurchaseRequestDetails.Id — set when imported from a Purchase Request

        // The RFQ ask line (see RFQDetails) this priced response answers — null for rows saved before
        // the RFQ envelope existed. Set, it lets several vendors' responses to the same ask line be
        // compared/evaluated as a set instead of only being tied to the same PurchaseRequestDetails row.
        public int? RFQDetailId { get; set; }
        public int? ItemId { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? TotalPrice { get; set; } // الإجمالي قبل الضريبة = Qty * UnitPrice بعد الخصم
        public string? Note { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public decimal? TotalWithTax => TotalPrice.HasValue
            ? Math.Round(TotalPrice.Value * (1 + (TaxPercent ?? 0) / 100m), 2)
            : null;

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
