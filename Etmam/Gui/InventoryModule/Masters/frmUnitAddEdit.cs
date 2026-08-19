using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmUnitAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private Units? _entity;

        public frmUnitAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            txtDescription.EditValueChanged += (s, e) => RevalidateField(txtDescription, !string.IsNullOrWhiteSpace(txtDescription.Text));
            txtAbbreviation.EditValueChanged += (s, e) => RevalidateField(txtAbbreviation, !string.IsNullOrWhiteSpace(txtAbbreviation.Text));

            LoadRecord();
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The two fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (txtDescription as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(txtDescription.Text)),
            (txtAbbreviation as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(txtAbbreviation.Text)),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user types/selects — called from each required
        /// field's EditValueChanged, independent of the next Save attempt.</summary>
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

            _entity = _id > 0 ? dc.Units.Find(_id) : new Units();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new Units();
            }

            Text = $"وحدة قياس - {(_id > 0 ? "تعديل" : "جديد")}";
            txtDescription.Text = _entity.Description ?? "";
            txtAbbreviation.Text = _entity.Abbreviation ?? "";
            txtCategory.Text = _entity.Category ?? "";
        }

        private bool Save()
        {
            if (!ValidateRequiredFields()) return false;

            var handle = ShowOverlay();
            try
            {
                _entity ??= new Units();
                _entity.Description = txtDescription.Text.Trim();
                _entity.Abbreviation = txtAbbreviation.Text.Trim();
                _entity.Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text.Trim();

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.Units.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.Units.Add(_entity);
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
            _entity = new Units();
            Text = "وحدة قياس - جديد";
            txtDescription.Text = "";
            txtAbbreviation.Text = "";
            txtCategory.Text = "";
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);
            txtDescription.Focus();
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
