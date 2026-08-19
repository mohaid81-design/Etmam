using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Header for "رصيد افتتاحي" (opening balance) — a document that seeds a store's starting
    /// inventory for one or more items. Wired into StoreBalanceHelper.ComputeBalances as an "in" movement
    /// alongside Material Receive; it's the only supported way to introduce non-zero starting stock for a
    /// store (e.g. onboarding a warehouse whose stock predates this system) other than fabricating a receive
    /// voucher.</summary>
    public class OpeningBalanceList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? StoreId { get; set; }
        public DateTime? BalanceDate { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }

        // حقول عرض غير مخزَّنة — تُملأ عند الطباعة فقط (انظر OpeningBalancePrinter)
        [NotMapped] public string? StoreName { get; set; }
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
