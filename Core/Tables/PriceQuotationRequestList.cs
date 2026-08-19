using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>Request For Quotation ("طلب عرض سعر") sent to a supplier asking them to quote — the
    /// outbound counterpart of PriceQuotationList (which models the supplier's incoming quote). See
    /// Etmam/Gui/ProcurementMgt/PriceQuotation/frmPriceQuotationAddEdit.cs.</summary>
    public class PriceQuotationRequestList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public int? PrjId { get; set; }

        // Owning RFQ envelope (see RFQList) — null for rows saved before the RFQ envelope existed, or
        // for a standalone single-vendor request never grouped under one. When set, this row is one of
        // possibly several vendor responses invited under the same RFQId (see RFQVendorList).
        public int? RFQId { get; set; }
        public int? StoreId { get; set; }        // موقع التسليم
        public int? StakeholderId { get; set; }  // المورد
        public int? PRId { get; set; }           // طلب الشراء المصدر (اختياري)
        public DateTime? RequestDate { get; set; }
        public DateTime? RequiredDate { get; set; }  // آخر موعد لتقديم العرض
        public string? Purpose { get; set; }
        public string? Priority { get; set; }        // عاجل / عادي
        public string? RequestType { get; set; }      // سلعة / خدمة / مقاولات

        // ─── Contract Terms (الشروط العامة المطلوبة من المورد) ─────────────────
        public string? PaymentTerms { get; set; }                // شروط الدفع: نقدا / آجل / دفعات
        public decimal? ExecutionDuration { get; set; }          // مدة التنفيذ/ التوريد
        public string? ExecutionDurationUnit { get; set; }       // يوم / شهر
        public decimal? WarrantyDuration { get; set; }           // مدة الضمان/ الصيانة
        public string? WarrantyDurationUnit { get; set; }        // يوم / شهر / سنة
        public decimal? QuotationValidityPeriod { get; set; }    // مدة صلاحية العرض
        public string? QuotationValidityUnit { get; set; }       // يوم / شهر
        public decimal? DailyPenaltyRate { get; set; }           // غرامة التأخير لليوم %
        public decimal? DailyPenaltyMaxPercent { get; set; }     // غرامة التأخير بحد أقصى %
        public decimal? PerformanceBondPercent { get; set; }     // ضمان حسن الأداء % (null = لا يوجد)
        public string? OtherConditions { get; set; }             // شروط أخرى

        public decimal? Amount { get; set; }  // إجمالي البنود (محسوب عند الحفظ)
        public string? Note { get; set; }

        // Display-only, populated where a lookup needs to show "supplier + quotation number" together
        // (e.g. frmTechnicalEvaluationAddEdit's quotation picker) — never persisted.
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

        // Optimistic-concurrency token (SQL Server ROWVERSION) — see SqlDataHelper<T> and
        // DatabaseInitializer.GetSqlType. A save against a stale copy throws ConcurrencyConflictException
        // instead of silently overwriting another user's edit.
        public byte[]? RowVersion { get; set; }
    }
}
