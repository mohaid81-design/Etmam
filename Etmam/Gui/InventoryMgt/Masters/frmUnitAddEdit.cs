using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class frmUnitAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private readonly int _id;
        private Units? _entity;

        public frmUnitAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();
            DesignSystem.ApplyButtonStyle(btnSave, true);
            DesignSystem.ApplyButtonStyle(btnCancel);
            DesignSystem.ApplyCairoFont(this);
            Text = $"وحدة قياس - {(id > 0 ? "تعديل" : "جديد")}";
            LoadRecord();
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.Units.Find(_id) : new Units();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                _entity = new Units();
            }
            txtDescription.Text = _entity.Description ?? "";
            txtAbbreviation.Text = _entity.Abbreviation ?? "";
            txtCategory.Text = _entity.Category ?? "";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال وصف الوحدة.", "بيانات ناقصة",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _entity ??= new Units();
                _entity.Description = txtDescription.Text.Trim();
                _entity.Abbreviation = txtAbbreviation.Text.Trim();
                _entity.Category = txtCategory.Text.Trim();

                if (_id > 0)
                    dc.Units.Edit(_id, _entity);
                else
                    dc.Units.Add(_entity);

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
