using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class MaterialReceiveList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Code { get; set; }
        public string? ReceiveType { get; set; } // e.g. "Supplier", "PO", "Return"
        public int? StoreId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int? StakeholderId { get; set; } // Supplier ID
        public string? InvoiceNo { get; set; }
        public string? ReceiveVoucherNo { get; set; }
        public int? PRId { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int? PrjId { get; set; }

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
