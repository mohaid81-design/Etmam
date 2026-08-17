using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmSupplierAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private readonly int _id;
        private StakeholdersList? _entity;

        public frmSupplierAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();
            DesignSystem.ApplyButtonStyle(btnSave, true);
            DesignSystem.ApplyButtonStyle(btnCancel);
            DesignSystem.ApplyCairoFont(this);
            Text = $"مورد - {(id > 0 ? "تعديل" : "جديد")}";
            LoadRecord();
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.StakeholdersList.Find(_id) : new StakeholdersList();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                _entity = new StakeholdersList();
            }
            txtName.Text = _entity.Name ?? "";
            txtPhone.Text = _entity.PhoneNumber ?? "";
            txtEmail.Text = _entity.Email ?? "";
            txtContactName.Text = _entity.ContactName1 ?? "";
            txtContactPhone.Text = _entity.ContactPhone1 ?? "";
            txtCommercialNumber.Text = _entity.CommercialNumber ?? "";
            txtTaxNumber.Text = _entity.TaxNumber ?? "";
            txtVatNumber.Text = _entity.VATNumber ?? "";
            spinPaymentTerms.Value = _entity.PaymentTermsDays ?? 0;
            spinCreditLimit.Value = _entity.CreditLimit ?? 0;
            spinRating.Value = _entity.Rating ?? 0;
            checkActive.Checked = _entity.IsActive ?? true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم المورد.", "بيانات ناقصة",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _entity ??= new StakeholdersList();
                _entity.Name = txtName.Text.Trim();
                _entity.PhoneNumber = txtPhone.Text.Trim();
                _entity.Email = txtEmail.Text.Trim();
                _entity.ContactName1 = txtContactName.Text.Trim();
                _entity.ContactPhone1 = txtContactPhone.Text.Trim();
                _entity.CommercialNumber = txtCommercialNumber.Text.Trim();
                _entity.TaxNumber = txtTaxNumber.Text.Trim();
                _entity.VATNumber = txtVatNumber.Text.Trim();
                _entity.PaymentTermsDays = (int)spinPaymentTerms.Value;
                _entity.CreditLimit = spinCreditLimit.Value;
                _entity.Rating = (int)spinRating.Value;
                _entity.IsActive = checkActive.Checked;
                _entity.IsVendor = true;

                if (_id > 0)
                    dc.StakeholdersList.Edit(_id, _entity);
                else
                    dc.StakeholdersList.Add(_entity);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
