using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseOrderList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? PrjId { get; set; }
        public int? StoreId { get; set; }
        public int? StakeholderId { get; set; } // Supplier
        public int? PRId { get; set; } // Source Purchase Request (nullable — a PO may also be created standalone)
        public int? QuotationId { get; set; } // PriceQuotationList.Id — رقم عرض السعر المعتمد لهذا الأمر (اختياري)
        public DateTime? OrderDate { get; set; }       // تاريخ الإعداد
        public DateTime? DeliveryDate { get; set; }    // تاريخ التسليم النهائي

        /// Draft / PendingApproval / Approved / Rejected / Closed
        public string? OverallStatus { get; set; }

        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? RejectReason { get; set; }
        public string? Note { get; set; }
        public decimal? Amount { get; set; }

        // Captured once, the moment this PO is FIRST approved (see PurchaseOrderWorkflowSync.Reconcile)
        // — never overwritten afterward, even as POAmendmentList rows change the PO's effective value
        // over time. Null for a PO never yet approved.
        public decimal? OriginalValue { get; set; }

        public string? Description { get; set; }       // وصف أمر الشراء
        public string? PurchaseMethod { get; set; }     // طريقة الشراء: عرض مباشر / منافسة / عقد اطاري
        public string? PriorityLevel { get; set; }      // مستوى الأولوية: عادي / عاجل / طارئ

        // ─── Contract Terms (أحكام التعاقد) ─────────────────────────────
        public string? PaymentTerms { get; set; }           // شروط الدفع: نقدا / آجل / دفعات
        public string? ExecutionDuration { get; set; }      // مدة التنفيذ/ التوريد
        public decimal? DailyPenaltyRate { get; set; }       // غرامة التأخير لليوم %
        public decimal? DailyPenaltyMaxPercent { get; set; } // غرامة التأخير بحد أقصى %
        public decimal? PerformanceBondPercent { get; set; } // ضمان حسن الأداء % (null = لا يوجد)
        public string? WarrantyDuration { get; set; }        // مدة الضمان/ الصيانة
        public string? ContractTermsOther { get; set; }      // شروط أخرى

        // حقل عرض غير مخزَّن، يُملأ عند العرض فقط (انظر frmPurchaseOrderSelect.LoadData)
        [NotMapped] public string? FormattedNum { get; set; }

        // حقول عرض غير مخزَّنة، تُملأ عند الطباعة فقط (انظر PurchaseOrderPrinter.BuildReport) — مرتبطة
        // بتقرير rptPurchaseOrder عبر ExpressionBindings باسمَي [ProjectName]/[StoreName]
        [NotMapped] public string? ProjectName { get; set; }
        [NotMapped] public string? StoreName { get; set; }

        // حقل عرض غير مخزَّن — اسم المورد (StakeholdersList عبر StakeholderId)، يُملأ عند الطباعة فقط
        // (انظر PurchaseOrderPrinter.BuildReport/PrintLog)
        [NotMapped] public string? SupplierName { get; set; }

        // حقل عرض غير مخزَّن — نص الحالة المزخرف، يعرض اسم خطوة الاعتماد الجارية أثناء "قيد الاعتماد"
        // بدل النص العام (انظر PurchaseOrderWorkflowSync.GetStatusDisplay وucPurchaseOrder.LoadData)
        [NotMapped] public string? StatusDisplay { get; set; }

        // حقول عرض غير مخزَّنة (رقم طلب الشراء المنسَّق/رقم عرض السعر المرتبط) — تُملأ فقط في شبكة
        // ucPurchaseOrder (انظر LoadData هناك)، عبر PRId/QuotationId أعلاه
        [NotMapped] public string? PRNumber { get; set; }
        [NotMapped] public string? QuotationNumber { get; set; }

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
