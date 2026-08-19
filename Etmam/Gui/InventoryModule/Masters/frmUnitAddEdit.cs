using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmUnitAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private int _id;
        private UnitItem? _entity;

        public frmUnitAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            txtDescription.EditValueChanged += (s, e) => RevalidateField(txtDescription, !string.IsNullOrWhiteSpace(txtDescription.Text));
            txtAbbreviation.EditValueChanged += (s, e) => RevalidateField(txtAbbreviation, !string.IsNullOrWhiteSpace(txtAbbreviation.Text));

            this.Load += async (s, e) => await LoadRecordAsync();
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

        private async Task LoadRecordAsync()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            if (_id > 0)
            {
                _entity = await ApiClient.GetUnitAsync(_id);
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new UnitItem();
                }
            }
            else
            {
                _entity = new UnitItem();
            }

            Text = $"وحدة قياس - {(_id > 0 ? "تعديل" : "جديد")}";
            txtDescription.Text = _entity.Description ?? "";
            txtAbbreviation.Text = _entity.Abbreviation ?? "";
            txtCategory.Text = _entity.Category ?? "";
        }

        private async Task<bool> SaveAsync()
        {
            if (!ValidateRequiredFields()) return false;

            var handle = ShowOverlay();
            try
            {
                _entity ??= new UnitItem();
                _entity.Description = txtDescription.Text.Trim();
                _entity.Abbreviation = txtAbbreviation.Text.Trim();
                _entity.Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text.Trim();

                if (_id > 0)
                {
                    await ApiClient.UpdateUnitAsync(_id, _entity);
                }
                else
                {
                    _id = await ApiClient.CreateUnitAsync(_entity);
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

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!await SaveAsync()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (!await SaveAsync()) return;

            _id = 0;
            _entity = new UnitItem();
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
