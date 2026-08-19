using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// عرض سعر (Price Quotation) submitted by a supplier — currently a lightweight standalone record
    /// referenced by its Num from frmPurchaseOrderAddEdit's "رقم عرض السعر" field (see btnProposal there).
    /// Not yet linked into the approval/workflow engine.
    /// </summary>
    public class PriceQuotationList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }              // رقم عرض السعر
        public int? StakeholderId { get; set; }     // المورد مقدّم العرض
        public int? PrjId { get; set; }
        public int? PRId { get; set; }              // طلب الشراء المرتبط (اختياري)
        public DateTime? QuotationDate { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }

        // حقل عرض غير مخزَّن، يُملأ عند العرض فقط (انظر frmPriceQuotationSelect.LoadData)
        [NotMapped] public string? SupplierName { get; set; }

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
