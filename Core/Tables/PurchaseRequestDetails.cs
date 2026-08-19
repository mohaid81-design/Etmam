using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class PurchaseRequestDetails : IBaseEntity
    {
        [Key] public int Id { get; set; }

        [ForeignKey(nameof(PurchaseRequest))]
        public int? PRId { get; set; }
        public PurchaseRequestList? PurchaseRequest { get; set; }

        public int? PrjId { get; set; }

        [ForeignKey(nameof(Item))]
        public int? ItemId { get; set; }
        public ItemsList? Item { get; set; }

        public string? Description { get; set; }
        public decimal? Qty { get; set; }

        [ForeignKey(nameof(Unit))]
        public int? UnitId { get; set; }
        public Units? Unit { get; set; }

        [ForeignKey(nameof(CostCenter))]
        public int? CCId { get; set; }
        public CostCenterList? CostCenter { get; set; }

        [ForeignKey(nameof(Budget))]
        public int? BdgId { get; set; }
        public BudgetList? Budget { get; set; }

        public string? Note { get; set; }

        // اقتراح حر من مقدّم الطلب لاسم المورد/المصنع المفضّل لهذا البند (نص وليس ربطاً بجدول الموردين،
        // لأن مقدّم الطلب قد يقترح اسم مصنع غير مسجّل بعد كمورد في النظام) — لا يُلزم مسار الشراء اللاحق باختياره.
        public string? SupplierManufacturer { get; set; }

        // حقل عرض غير مخزَّن، يُملأ عند الطباعة فقط (انظر frmPurchaseRequestAddEdit.PrintRecord)
        [NotMapped] public string? UnitAbbreviation { get; set; }

        // ترتيب عرض البند داخل الطلب (يُحدَّث عند إعادة الترتيب بالسحب والإفلات في شبكة البنود)
        public int? SortId { get; set; }

        // رقم البند التسلسلي المعروض للمستخدم (١، ٢، ٣ ...) — يُعاد ترقيمه تلقائياً من جديد عند أي
        // إضافة/حذف/إعادة ترتيب لبنود الطلب، بحيث يبدأ من 1 لكل طلب شراء (انظر
        // frmPurchaseRequestAddEdit.RenumberDetails). يتبع نفس ترتيب SortId لكنه عمود منفصل مخصص للعرض.
        public int? Num { get; set; }

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
    }
}
