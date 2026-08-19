using Core;
using Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    public class ucCostCenters : ProcurementListControlBase<CostCenterList>
    {
        protected override IDataHelper<CostCenterList> Helper => DC.CostCenterList;
        protected override string TitleSingular => "مركز تكلفة";
        protected override string RequiredPermissionName => PermNames.CostCenter;

        protected override void ConfigureColumns(GridView gv)
        {
            SetCaption("Code", "الرمز", centered: true);
            SetCaption("Name", "الاسم");
            SetCaption("ParentId", "المركز الأب", centered: true);
            SetCaption("PrjId", "المشروع", centered: true);
            SetCaption("IsActive", "فعّال", centered: true);
        }

        protected override void OpenEditForm(int id)
        {
            var handle = ShowOverlay();
            frmCostCenterAddEdit frm;
            try { frm = new frmCostCenterAddEdit(id); }
            finally { CloseOverlay(handle); }
            using (frm)
            {
                if (frm.ShowDialog(FindForm()) == System.Windows.Forms.DialogResult.OK)
                    LoadData();
            }
        }
    }
}
