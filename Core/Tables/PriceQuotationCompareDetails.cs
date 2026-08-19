using System.ComponentModel.DataAnnotations;

namespace Core
{
    /// <summary>One selected quotation within a saved comparison — links back to the specific supplier's
    /// PriceQuotationRequestList row that was included when the comparison was built/saved.</summary>
    public class PriceQuotationCompareDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? ParentId { get; set; }                 // PriceQuotationCompareList.Id
        public int? PriceQuotationRequestId { get; set; }  // PriceQuotationRequestList.Id (العرض المختار للمقارنة)

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
