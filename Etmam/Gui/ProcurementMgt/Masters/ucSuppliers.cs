using Core;
using Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>
    /// Concrete non-generic intermediate base class.
    /// Reuses the existing StakeholdersList master (filtered to IsVendor = true) instead of a
    /// duplicate Supplier table, per the approved Procurement module design.
    /// Carries all runtime logic so Visual Studio Designer can instantiate this class
    /// without hitting the generic ProcurementListControlBase&lt;T&gt; directly.
    /// </summary>
    public class ucSuppliersBase : ProcurementListControlBase<StakeholdersList>
    {
        protected override IDataHelper<StakeholdersList> Helper => DC.StakeholdersList;
        protected override string TitleSingular => "مورد";
        protected override string? AdditionalFilter => "IsVendor = 1";

        protected override void ConfigureColumns(GridView gv)
        {
            SetCaption("Name", "اسم المورد");
            SetCaption("PhoneNumber", "الجوال", centered: true);
            SetCaption("CommercialNumber", "السجل التجاري", centered: true);
            SetCaption("PaymentTermsDays", "مدة السداد (يوم)", centered: true);
            SetCaption("Rating", "التقييم", centered: true);
            SetCaption("IsActive", "فعّال", centered: true);
        }

        protected override void OpenEditForm(int id)
        {
            using var frm = new frmSupplierAddEdit(id);
            if (frm.ShowDialog(FindForm()) == System.Windows.Forms.DialogResult.OK)
                LoadData();
        }
    }

    public partial class ucSuppliers : ucSuppliersBase
    {
        public ucSuppliers()
        {
            InitializeComponent();
        }
    }
}
