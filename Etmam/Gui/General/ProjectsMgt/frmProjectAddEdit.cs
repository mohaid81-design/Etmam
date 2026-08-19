using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public class frmProjectAddEdit : SimpleEditFormBase<ProjectsList>
    {
        private const int SystemAdminUserId = 1;

        private TextEdit txtNum = null!;
        private TextEdit txtName = null!;
        private MemoEdit memoDescription = null!;
        private LookUpEdit lookUpClient = null!;
        private LookUpEdit lookUpConsultant = null!;
        private DateEdit dtContractDate = null!;
        private SpinEdit spinContractAmount = null!;
        private SpinEdit spinAdvancePaymentAmount = null!;
        private SpinEdit spinAdvancePaymentPercent = null!;
        private SpinEdit spinRetentionPercent = null!;

        public frmProjectAddEdit(int id = 0) : base(id) { }

        // static, not an instance field: SimpleEditFormBase<T>'s constructor calls LoadRecord() (and
        // so Helper.Find(Id)) before this derived class's instance field initializers would run, so
        // an instance-field-backed helper would still be null at that point. A static field is
        // initialized at type load, before any constructor runs, sidestepping that ordering issue —
        // same reason the base class's own `dc` accessor is a property over the static DataContext.Shared
        // singleton rather than an instance field.
        private static readonly ApiProjectsDataHelper ApiHelper = new();

        // The Find/Add/Edit calls SimpleEditFormBase<T> makes now go through the Api project
        // instead of straight to SQL Server — everything else on this form (the Client/Consultant
        // lookups below, OnAfterInsert's UserProjectAccess writes) is out of scope for this slice
        // and still reads/writes via Data directly.
        protected override IDataHelper<ProjectsList> Helper => ApiHelper;
        protected override string TitleSingular => "مشروع";

        protected override void BuildFields()
        {
            txtNum = new TextEdit();
            txtName = new TextEdit();
            memoDescription = new MemoEdit { Height = 60 };
            lookUpClient = new LookUpEdit();
            lookUpConsultant = new LookUpEdit();
            dtContractDate = new DateEdit();

            spinContractAmount = new SpinEdit();
            spinAdvancePaymentAmount = new SpinEdit();
            spinAdvancePaymentPercent = new SpinEdit();
            spinRetentionPercent = new SpinEdit();
            foreach (var spin in new[] { spinContractAmount, spinAdvancePaymentAmount, spinAdvancePaymentPercent, spinRetentionPercent })
            {
                spin.Properties.MinValue = 0;
                spin.Properties.MaxValue = 1000000000;
                spin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                spin.Properties.DisplayFormat.FormatString = "N2";
            }

            lookUpClient.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0 AND IsClient = 1");
            lookUpClient.Properties.DisplayMember = "Name";
            lookUpClient.Properties.ValueMember = "Id";
            lookUpClient.Properties.NullText = "";

            lookUpConsultant.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0 AND IsConsultant = 1");
            lookUpConsultant.Properties.DisplayMember = "Name";
            lookUpConsultant.Properties.ValueMember = "Id";
            lookUpConsultant.Properties.NullText = "";

            AddField("رقم المشروع:", txtNum);
            AddField("اسم المشروع:", txtName);
            AddField("الوصف:", memoDescription);
            AddField("المالك/العميل:", lookUpClient);
            AddField("الاستشاري:", lookUpConsultant);
            AddField("تاريخ العقد:", dtContractDate);
            AddField("قيمة العقد:", spinContractAmount);
            AddField("قيمة الدفعة المقدمة:", spinAdvancePaymentAmount);
            AddField("نسبة الدفعة المقدمة %:", spinAdvancePaymentPercent);
            AddField("نسبة الاحتجاز %:", spinRetentionPercent);

            Height = 640;
        }

        protected override void PopulateFields(ProjectsList entity)
        {
            txtNum.Text = entity.Num ?? "";
            txtName.Text = entity.Name ?? "";
            memoDescription.Text = entity.Description ?? "";
            lookUpClient.EditValue = entity.CLId;
            lookUpConsultant.EditValue = entity.CSTId;
            dtContractDate.EditValue = entity.ContractDate;
            spinContractAmount.Value = entity.ContractAmount ?? 0;
            spinAdvancePaymentAmount.Value = entity.AdvancePaymentAmount ?? 0;
            spinAdvancePaymentPercent.Value = entity.AdvancePaymentPercent ?? 0;
            spinRetentionPercent.Value = entity.RetentionPercent ?? 0;
        }

        protected override bool ValidateFields(out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error = "الرجاء إدخال اسم المشروع.";
                return false;
            }
            return true;
        }

        protected override void CollectFields(ProjectsList entity)
        {
            entity.Num = txtNum.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.Description = memoDescription.Text.Trim();
            entity.CLId = lookUpClient.EditValue as int?;
            entity.CSTId = lookUpConsultant.EditValue as int?;
            entity.ContractDate = dtContractDate.EditValue as DateTime?;
            entity.ContractAmount = spinContractAmount.Value;
            entity.AdvancePaymentAmount = spinAdvancePaymentAmount.Value;
            entity.AdvancePaymentPercent = spinAdvancePaymentPercent.Value;
            entity.RetentionPercent = spinRetentionPercent.Value;

            if (Id == 0)
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedMachine = Session.Machine;
                entity.CreatedBy = Session.CurrentUser?.Id ?? SystemAdminUserId;
            }
        }

        /// <summary>
        /// New projects aren't visible to non-admin users until explicitly granted (see UserProjectAccess /
        /// frmUsersMgt permissions tab). Grant the system administrator immediate access so the project
        /// shows up right away without a separate manual step, and create an explicit denied (false) row
        /// for every other existing user so the access matrix is complete and shows up unchecked in the
        /// permissions tab instead of silently missing.
        /// </summary>
        protected override void OnAfterInsert(ProjectsList entity)
        {
            dc.UserProjectAccess.Add(new UserProjectAccess
            {
                UserID = SystemAdminUserId,
                PrjId = entity.Id,
                PermsStatus = true,
                UpdateDate = DateTime.Now,
                UpdateMachine = Session.Machine,
                UpdateBy = Session.CurrentUser?.Id ?? SystemAdminUserId
            });

            var otherUsers = dc.UsersList.GetBy("IsDelete = 0 AND Id <> @AdminId", new { AdminId = SystemAdminUserId });
            foreach (var user in otherUsers)
            {
                dc.UserProjectAccess.Add(new UserProjectAccess
                {
                    UserID = user.Id,
                    PrjId = entity.Id,
                    PermsStatus = false,
                    UpdateDate = DateTime.Now,
                    UpdateMachine = Session.Machine,
                    UpdateBy = Session.CurrentUser?.Id ?? SystemAdminUserId
                });
            }
        }
    }
}
