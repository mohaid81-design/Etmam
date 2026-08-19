using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class ConstructionInspectionRequestList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public int? Num { get; set; }
        public string? RegisterNo { get; set; }
        public int? Rev { get; set; }
        public DateTime? PreparedDate { get; set; }

        /// <summary>Discipline of the inspection — FK to DisciplinesList.Id.</summary>
        public int? DisciplineId { get; set; }

        /// <summary>Optional sub-discipline nested under DisciplineId — FK to SecondaryDisciplinesList.Id.</summary>
        public int? SecondaryDisciplineId { get; set; }

        /// <summary>Inspection activity nested under SecondaryDisciplineId — FK to InspectionActivityList.Id.</summary>
        public int? InspectionActivityId { get; set; }

        public string? Description { get; set; }
        public string? BOQRef { get; set; }
        public string? DWGRef { get; set; }
        public string? MSRef { get; set; }
        public string? SpecRef { get; set; }
        public string? Location { get; set; }

        /// <summary>FK to BuildingsList.Id — scoped to the same project as this request.</summary>
        public int? BuildingId { get; set; }

        /// <summary>Comma-separated FloorsList.Id values (e.g. "3,5,9") — a request may span more than
        /// one floor, entered via lueFloor's CheckedComboBoxEdit in frmCIRAddEdit. Independent of
        /// BuildingId, not nested under a specific building.</summary>
        public string? FloorIds { get; set; }

        public DateTime? RequestedDate { get; set; }
        public DateTime? RequestedTime { get; set; }
        public int? PrjId { get; set; }

        /// <summary>1 = Draft, 2 = Submitted, 3 = Reissued, 4 = Closed (mirrors Drawings' OverallStatus convention).</summary>
        public int OverallStatus { get; set; }

        public string? CSTReviewStatus { get; set; }
        public string? CSTReviewComment { get; set; }
        public string? SubmittedDate { get; set; }
        public string? CSTReturnedDate { get; set; }
        public string? ReviewedBy { get; set; }
        public string? ReviewedJobTitle { get; set; }
        public string? ApprovedBy { get; set; }
        public string? ApprovedJobTitle { get; set; }

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

        // Populated in-memory only (never persisted) right before printing — see
        // frmCIRAddEdit.BuildPrintRecord. Kept as flat strings (rather than a Project navigation
        // property) so the report's ExpressionBindings never have to walk a nested object graph
        // that could be null.
        [NotMapped] public string? PrintNum { get; set; }
        // "المبنى + الطابق + الموقع" مُجمَّعة في سطر واحد للتقرير المطبوع فقط — الحقول الثلاثة تبقى
        // مخزَّنة/مُحرَّرة منفصلة في النموذج والشبكة كما هي (انظر CIRPrinter.BuildPrintRecord).
        [NotMapped] public string? PrintLocation { get; set; }
        [NotMapped] public string? PrintPrjName { get; set; }
        [NotMapped] public string? PrintSponsorName { get; set; }
        [NotMapped] public string? PrintCSTName { get; set; }
        [NotMapped] public string? PrintClientEmail { get; set; }
        [NotMapped] public string? PrintConsultantEmail { get; set; }
        [NotMapped] public byte[]? PrintSponsorLogo { get; set; }
        [NotMapped] public byte[]? PrintCSTLogo { get; set; }

        // Populated in-memory only, hydrated from DisciplinesList/SecondaryDisciplinesList wherever a
        // record is loaded/printed (DisciplineId has no short code of its own to build "CIR-ST-001-R0"
        // with, so callers resolve it once and cache it here) — see CIRNumberFormatter, CIRPrinter.
        [NotMapped] public string? DisciplineCode { get; set; }
        [NotMapped] public string? DisciplineName { get; set; }
        [NotMapped] public string? SecondaryDisciplineCode { get; set; }
        [NotMapped] public string? SecondaryDisciplineName { get; set; }
        [NotMapped] public string? InspectionActivityCode { get; set; }
        [NotMapped] public string? InspectionActivityName { get; set; }
        [NotMapped] public string? BuildingName { get; set; }
        [NotMapped] public string? FloorName { get; set; }

        // "بيانات طلب الإعتماد السابق" block on the print report — hydrated from the previous
        // revision's row (same Num/PrjId/DisciplineId, Rev - 1) only when Rev > 0. See
        // CIRPrinter.BuildPrintRecord.
        [NotMapped] public string? PrintPreviousCIRNum { get; set; }
        [NotMapped] public string? PrintPreviousCIRDate { get; set; }
        [NotMapped] public string? PrintPreviousResult { get; set; }

        // "عدد أيام الإجراء" على سجل rptConstructionInspectionLog — الفرق بين SubmittedDate وCSTReturnedDate
        // (أو اليوم الحالي إن لم تتم المراجعة بعد)، نفس صيغة ucCIR.ComputeProcessingDays. غير مخزَّن —
        // يُحسَب وقت الطباعة فقط (انظر CIRPrinter.PrintLog).
        [NotMapped] public int? PrintProcessingDays { get; set; }
    }
}
