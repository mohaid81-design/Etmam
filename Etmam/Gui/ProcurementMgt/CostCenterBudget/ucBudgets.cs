using Core;
using Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    public class ucBudgets : ProcurementListControlBase<BudgetList>
    {
        protected override IDataHelper<BudgetList> Helper => DC.BudgetList;
        protected override string TitleSingular => "ميزانية";
        protected override bool IsProjectScoped => true;

        protected override void ConfigureColumns(GridView gv)
        {
            SetCaption("Description", "الوصف");
            SetCaption("CostCenterId", "مركز التكلفة", centered: true);
            SetCaption("PeriodStart", "بداية الفترة", centered: true);
            SetCaption("PeriodEnd", "نهاية الفترة", centered: true);
            SetCaption("AllocatedAmount", "المبلغ المعتمد", centered: true);
            SetCaption("IsActive", "فعّال", centered: true);
        }

        protected override void OpenEditForm(int id)
        {
            using var frm = new frmBudgetAddEdit(id);
            if (frm.ShowDialog(FindForm()) == System.Windows.Forms.DialogResult.OK)
                LoadData();
        }
    }
}
