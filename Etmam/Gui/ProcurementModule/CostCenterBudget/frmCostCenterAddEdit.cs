using System.Linq;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public class frmCostCenterAddEdit : SimpleEditFormBase<CostCenterList>
    {
        private TextEdit txtCode = null!;
        private TextEdit txtName = null!;
        private LookUpEdit lookUpParent = null!;
        private LookUpEdit lookUpProject = null!;
        private CheckEdit checkActive = null!;

        public frmCostCenterAddEdit(int id = 0) : base(id) { }

        protected override IDataHelper<CostCenterList> Helper => dc.CostCenterList;
        protected override string TitleSingular => "مركز تكلفة";

        protected override void BuildFields()
        {
            txtCode = new TextEdit();
            txtName = new TextEdit();
            lookUpParent = new LookUpEdit();
            lookUpProject = new LookUpEdit();
            checkActive = new CheckEdit { Text = "فعّال" };

            var parents = dc.CostCenterList.GetBy("IsDelete = 0 AND Id <> @id", new { id = Id }).ToList();
            lookUpParent.Properties.DataSource = parents;
            lookUpParent.Properties.DisplayMember = "Name";
            lookUpParent.Properties.ValueMember = "Id";
            lookUpParent.Properties.NullText = "";

            lookUpProject.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpProject.Properties.DisplayMember = "Name";
            lookUpProject.Properties.ValueMember = "Id";
            lookUpProject.Properties.NullText = "";

            AddField("الرمز:", txtCode);
            AddField("الاسم:", txtName);
            AddField("المركز الأب:", lookUpParent);
            AddField("المشروع:", lookUpProject);
            AddField("", checkActive);
        }

        protected override void PopulateFields(CostCenterList entity)
        {
            txtCode.Text = entity.Code ?? "";
            txtName.Text = entity.Name ?? "";
            lookUpParent.EditValue = entity.ParentId;
            lookUpProject.EditValue = entity.PrjId;
            checkActive.Checked = entity.IsActive ?? true;
        }

        protected override bool ValidateFields(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error = "الرجاء إدخال اسم مركز التكلفة.";
                return false;
            }
            return true;
        }

        protected override void CollectFields(CostCenterList entity)
        {
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.ParentId = lookUpParent.EditValue as int?;
            entity.PrjId = lookUpProject.EditValue as int?;
            entity.IsActive = checkActive.Checked;
        }
    }
}
