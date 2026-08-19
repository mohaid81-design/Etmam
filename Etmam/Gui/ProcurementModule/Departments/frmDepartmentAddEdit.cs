using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public class frmDepartmentAddEdit : SimpleEditFormBase<DepartmentsList>
    {
        private TextEdit txtName = null!;

        public frmDepartmentAddEdit(int id = 0) : base(id) { }

        protected override IDataHelper<DepartmentsList> Helper => dc.DepartmentsList;
        protected override string TitleSingular => "إدارة";

        protected override void BuildFields()
        {
            txtName = new TextEdit();

            AddField("اسم الإدارة:", txtName);

            Height = 200;
        }

        protected override void PopulateFields(DepartmentsList entity)
        {
            txtName.Text = entity.Name ?? "";
        }

        protected override bool ValidateFields(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error = "الرجاء إدخال اسم الإدارة.";
                return false;
            }
            return true;
        }

        protected override void CollectFields(DepartmentsList entity)
        {
            entity.Name = txtName.Text.Trim();

            if (Id == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedMachine = Session.Machine;
                entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
            }
        }
    }
}
