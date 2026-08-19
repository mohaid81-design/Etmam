using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam.Gui.ProcurementMgt.Suppliers
{
    /// <summary>Small modal Add/Edit for a supplier category/group (StakeholdersCategory) — same
    /// SaveClose/SaveNew pattern as frmUnitAddEdit. The entity has no IsDelete or Update* tracking
    /// fields, so edits only ever touch MainCategory/SubCategory.</summary>
    public partial class frmSupplierCategoryAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private StakeholdersCategory? _entity;

        public frmSupplierCategoryAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            // الديزاينر يعطّل comboBoxEdit1 افتراضياً رغم أنه حقل "التصنيف الرئيسي" المطلوب تعبئته فعلياً
            comboBoxEdit1.Enabled = true;

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;
            txtCategory.EditValueChanged += (s, e) => RevalidateField(txtCategory, !string.IsNullOrWhiteSpace(txtCategory.Text));

            LoadRecord();
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>Only txtCategory (التصنيف الفرعي) is marked with a green background in the Designer.
        /// comboBoxEdit1 (التصنيف الرئيسي) is validated separately below since it isn't green-marked.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (txtCategory as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(txtCategory.Text)),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        private void RevalidateField(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            if (isFilled) SetRequiredFieldState(control, true);
        }

        private bool ValidateRequiredFields()
        {
            DevExpress.XtraEditors.BaseEdit? firstInvalid = null;
            foreach (var (control, isFilled) in RequiredFieldChecks())
            {
                SetRequiredFieldState(control, isFilled);
                if (!isFilled && firstInvalid == null) firstInvalid = control;
            }

            if (firstInvalid == null) return true;

            XtraMessageBox.Show("الرجاء تعبئة كل الحقول المطلوبة (باللون الأحمر).", "بيانات ناقصة",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        private void LoadRecord()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _entity = _id > 0 ? dc.StakeholdersCategory.Find(_id) : new StakeholdersCategory();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new StakeholdersCategory();
            }

            Text = $"تصنيف موردين - {(_id > 0 ? "تعديل" : "جديد")}";
            comboBoxEdit1.Text = _entity.MainCategory ?? "";
            txtCategory.Text = _entity.SubCategory ?? "";
        }

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                XtraMessageBox.Show("الرجاء اختيار التصنيف الرئيسي.", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidateRequiredFields()) return false;

            var handle = ShowOverlay();
            try
            {
                _entity ??= new StakeholdersCategory();
                _entity.MainCategory = comboBoxEdit1.Text.Trim();
                _entity.SubCategory = txtCategory.Text.Trim();

                if (_id > 0)
                {
                    dc.StakeholdersCategory.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.FullName ?? Session.CurrentUser?.UserName ?? "مجهول";
                    _id = dc.StakeholdersCategory.Add(_entity);
                    _entity.Id = _id;
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!Save()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (!Save()) return;

            _id = 0;
            _entity = new StakeholdersCategory();
            Text = "تصنيف موردين - جديد";
            txtCategory.Text = "";
            SetRequiredFieldState(txtCategory, true);
            txtCategory.Focus();
        }
    }
}
