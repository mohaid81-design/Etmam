using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseReturnList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? Code { get; set; }
        public int? StoreId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? StakeholderId { get; set; } // Supplier ID
        public string? InvoiceNo { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }
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
