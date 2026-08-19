using Core;
using Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    public class ucDepartments : ProcurementListControlBase<DepartmentsList>
    {
        protected override IDataHelper<DepartmentsList> Helper => DC.DepartmentsList;
        protected override string TitleSingular => "إدارة";
        protected override string RequiredPermissionName => PermNames.Departments;

        protected override void ConfigureColumns(GridView gv)
        {
            SetCaption("Name", "الاسم");
        }

        protected override void OpenEditForm(int id)
        {
            var handle = ShowOverlay();
            frmDepartmentAddEdit frm;
            try { frm = new frmDepartmentAddEdit(id); }
            finally { CloseOverlay(handle); }
            using (frm)
            {
                if (frm.ShowDialog(FindForm()) == System.Windows.Forms.DialogResult.OK)
                    LoadData();
            }
        }
    }
}
