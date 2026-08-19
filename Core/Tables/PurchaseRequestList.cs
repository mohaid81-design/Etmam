using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseRequestList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? PrjId { get; set; }
        public int? DeptId { get; set; }
        public int? StoreId { get; set; }

        /// <summary>Which discipline this request belongs to (see DisciplinesList) — used to route the
        /// request to a matching WorkflowDefinitionList automatically. Optional: null just means no
        /// discipline-scoped procedure can match, only a "عام" one. See
        /// PurchaseRequestWorkflowSync.GetAvailableProcedures.</summary>
        public int? DisciplineId { get; set; }

        public DateTime? RequestDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string? Purpose { get; set; }
        public string? Priority { get; set; }

        /// نوع طلب الشراء: سلعة / خدمة / مقاولات — انظر frmPurchaseRequestAddEdit (comboBoxEdit1).
        public string? Type { get; set; }
        public string? OverallStatus { get; set; }
        public string? DeliveryStatus { get; set; }

        /// Draft / PendingApproval / Approved / Rejected / Closed — see PurchaseRequestStatus.
        /// PO fulfillment (partial/full) is a separate, purely-derived dimension — see
        /// PurchaseRequestOrderProgress.GetPurchaseOrderStatusDisplay / PurchaseOrderStatusDisplay below.

        public int? IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? RejectReason { get; set; }

        // حقول عرض غير مخزَّنة، تُملأ عند الطباعة فقط (انظر frmPurchaseRequestAddEdit.PrintRecord)
        [NotMapped] public string? ProjectName { get; set; }
        [NotMapped] public string? StoreName { get; set; }
        [NotMapped] public string? DisciplineName { get; set; }
        [NotMapped] public string? FormattedNum { get; set; }
        [NotMapped] public string? StatusDisplay { get; set; }
        // حالة إصدار أمر الشراء (لم يصدر / جزئي / كلي) — مستقلة تماماً عن حالة الاعتماد أعلاه، انظر
        // PurchaseRequestOrderProgress.GetPurchaseOrderStatusDisplay وعمود colPurchaseOrderStatus في ucPurchaseRequests
        [NotMapped] public string? PurchaseOrderStatusDisplay { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))]
        public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }

        [ForeignKey(nameof(Deletion))]
        public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        // Optimistic-concurrency token (SQL Server ROWVERSION) — see SqlDataHelper<T> and
        // DatabaseInitializer.GetSqlType. A save against a stale copy throws ConcurrencyConflictException
        // instead of silently overwriting another user's edit.
        public byte[]? RowVersion { get; set; }
    }
}
