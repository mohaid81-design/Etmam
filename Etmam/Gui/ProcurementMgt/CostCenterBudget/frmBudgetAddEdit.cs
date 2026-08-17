using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public class frmBudgetAddEdit : SimpleEditFormBase<BudgetList>
    {
        private TextEdit txtDescription = null!;
        private LookUpEdit lookUpCostCenter = null!;
        private LookUpEdit lookUpProject = null!;
        private DateEdit dtPeriodStart = null!;
        private DateEdit dtPeriodEnd = null!;
        private SpinEdit spinAllocated = null!;
        private CheckEdit checkActive = null!;

        public frmBudgetAddEdit(int id = 0) : base(id) { }

        protected override IDataHelper<BudgetList> Helper => dc.BudgetList;
        protected override string TitleSingular => "ميزانية";

        protected override void BuildFields()
        {
            txtDescription = new TextEdit();
            lookUpCostCenter = new LookUpEdit();
            lookUpProject = new LookUpEdit();
            dtPeriodStart = new DateEdit();
            dtPeriodEnd = new DateEdit();
            spinAllocated = new SpinEdit();
            spinAllocated.Properties.MinValue = 0;
            spinAllocated.Properties.MaxValue = 1000000000;
            spinAllocated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spinAllocated.Properties.DisplayFormat.FormatString = "N2";

            checkActive = new CheckEdit { Text = "فعّال" };

            lookUpCostCenter.Properties.DataSource = dc.CostCenterList.GetBy("IsDelete = 0");
            lookUpCostCenter.Properties.DisplayMember = "Name";
            lookUpCostCenter.Properties.ValueMember = "Id";
            lookUpCostCenter.Properties.NullText = "";

            lookUpProject.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpProject.Properties.DisplayMember = "Name";
            lookUpProject.Properties.ValueMember = "Id";
            lookUpProject.Properties.NullText = "";

            AddField("الوصف:", txtDescription);
            AddField("مركز التكلفة:", lookUpCostCenter);
            AddField("المشروع:", lookUpProject);
            AddField("بداية الفترة:", dtPeriodStart);
            AddField("نهاية الفترة:", dtPeriodEnd);
            AddField("المبلغ المعتمد:", spinAllocated);
            AddField("", checkActive);

            Height = 480;
        }

        protected override void PopulateFields(BudgetList entity)
        {
            txtDescription.Text = entity.Description ?? "";
            lookUpCostCenter.EditValue = entity.CostCenterId;
            lookUpProject.EditValue = entity.PrjId;
            dtPeriodStart.EditValue = entity.PeriodStart;
            dtPeriodEnd.EditValue = entity.PeriodEnd;
            spinAllocated.Value = entity.AllocatedAmount ?? 0;
            checkActive.Checked = entity.IsActive ?? true;
        }

        protected override bool ValidateFields(out string error)
        {
            error = "";
            if (lookUpCostCenter.EditValue == null)
            {
                error = "الرجاء تحديد مركز التكلفة.";
                return false;
            }
            if (spinAllocated.Value <= 0)
            {
                error = "الرجاء إدخال مبلغ ميزانية أكبر من صفر.";
                return false;
            }
            return true;
        }

        protected override void CollectFields(BudgetList entity)
        {
            entity.Description = txtDescription.Text.Trim();
            entity.CostCenterId = lookUpCostCenter.EditValue as int?;
            entity.PrjId = lookUpProject.EditValue as int?;
            entity.PeriodStart = dtPeriodStart.EditValue as DateTime?;
            entity.PeriodEnd = dtPeriodEnd.EditValue as DateTime?;
            entity.AllocatedAmount = spinAllocated.Value;
            entity.IsActive = checkActive.Checked;
        }
    }
}
