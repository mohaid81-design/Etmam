using System.Linq;
using Core;
using Data;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    public class ucWorkflowDefinitions : ProcurementListControlBase<WorkflowDefinitionList>
    {
        protected override IDataHelper<WorkflowDefinitionList> Helper => DC.WorkflowDefinitionList;
        protected override string TitleSingular => "الإجراء";

        public ucWorkflowDefinitions()
        {
            if (DesignMode) return;

            int permId = DC.PermissionsList
                .GetBy("Description = @d", new { d = "إدارة الإجراءات" })
                .FirstOrDefault()?.Id ?? -1;

            bool allowed = Session.CurrentUser.Id == 1 || DC.UserPermissionStatus
                .GetBy("UserID = @u AND PermsID = @p AND PermsStatus = 1", new { u = Session.CurrentUser.Id, p = permId })
                .Any();

            btnNew.Enabled = allowed;
            btnEdit.Enabled = allowed;
            btnDelete.Enabled = allowed;
        }

        protected override void ConfigureColumns(GridView gv)
        {
            DesignSystem.HideAuditColumns(gv);
            SetCaption("Name", "اسم الإجراء");
            SetCaption("Description", "الوصف");
            SetCaption("IsActive", "مفعّل", true);
        }

        protected override void OpenEditForm(int id)
        {
            var frm = new frmWorkflowDefinitionAddEdit();
            if (id > 0) frm.OpenForEdit(id);
            frm.FormClosed += (s, e) => LoadData();
            frm.ShowDialog(this);
        }

        protected override void DeleteRecord(int id) => DC.DeleteWorkflowDefinition(id);
    }
}
