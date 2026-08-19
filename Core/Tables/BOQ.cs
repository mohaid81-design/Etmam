using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    // Master contract/project-level Bill of Quantities — distinct from SubcontractBOQDetails, which is
    // a subcontractor's own priced breakdown of the scope it was awarded.
    public class BOQList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(Project))]
        public int? PrjId { get; set; }
        public ProjectsList? Project { get; set; }

        public string? BOQCode { get; set; }
        public string? BOQName { get; set; }
        public string? Revision { get; set; }
        public string? Discipline { get; set; }

        [ForeignKey(nameof(Contract))]
        public int? ContractId { get; set; }
        public ContractList? Contract { get; set; }

        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }

        public byte[]? RowVersion { get; set; }
    }

    public class BOQSectionDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(BOQ))]
        public int BOQId { get; set; }
        public BOQList? BOQ { get; set; }

        public string? SectionNo { get; set; }
        public string? SectionName { get; set; }
        public int? SeqNo { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }

    public class BOQItemDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(BOQ))]
        public int BOQId { get; set; }
        public BOQList? BOQ { get; set; }

        [ForeignKey(nameof(Section))]
        public int? SectionId { get; set; }
        public BOQSectionDetails? Section { get; set; }

        public string? ItemNo { get; set; }
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? Unit { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? UnitRate { get; set; }
        public decimal? Total { get; set; }

        public string? CostCode { get; set; }
        public string? WBS { get; set; }
        public string? CBS { get; set; }
        public string? ResourceCode { get; set; }
        public string? Remarks { get; set; }

        // ترتيب البند ضمن مجموعته (القسم) — يُستخدم في تحريك البند لأعلى/لأسفل وإعادة الترقيم.
        public int? SeqNo { get; set; }

        // عرض فقط: هوية القسم الأب (رقم واسم القسم)، تُملأ يدوياً من Section بعد التحميل — غير مخزَّنة
        // لأن العلاقة الحقيقية للتجميع هي SectionId، وهذا العمود موجود فقط لأن الشبكة المصمَّمة مسبقاً
        // (ucBOQEditor) تعرض عمود "البند الأب" منفصلاً عن التجميع نفسه.
        [NotMapped]
        public string? ParentItemNo => Section == null ? null : $"{Section.SectionNo} - {Section.SectionName}";

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }

        [ForeignKey(nameof(Created))] public int CreatedBy { get; set; }
        public UsersList? Created { get; set; }
        [ForeignKey(nameof(Update))] public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
        [ForeignKey(nameof(Deletion))] public int DeletionBy { get; set; }
        public UsersList? Deletion { get; set; }
    }
}
