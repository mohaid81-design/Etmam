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
        public int? MRId { get; set; } // MaterialReceiveList.Id — إذن الاستلام الذي يستند إليه هذا المرتجع
        public string? InvoiceNo { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }
        public int? PrjId { get; set; }

        // حقول عرض غير مخزَّنة — تُملأ عند الطباعة فقط (انظر PurchaseReturnPrinter)
        [NotMapped] public string? StoreName { get; set; }
        [NotMapped] public string? ProjectName { get; set; }
        [NotMapped] public string? SupplierName { get; set; }
        [NotMapped] public string? FormattedNum { get; set; }

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
        // DatabaseInitializer.GetSqlType. A save against a stale copy throws ConcurrencyConflictException
        // instead of silently overwriting another user's edit.
        public byte[]? RowVersion { get; set; }
    }
}
