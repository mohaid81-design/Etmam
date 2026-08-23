using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Add/edit a single "نشاط الفحص" row — mirrors frmSecondaryDisciplineAddEdit's own
    /// pattern one level deeper: lueDiscipline here is a filter-only aid (not stored), the actual FK
    /// stored on the entity is SecondaryDisciplineId via lueSecondaryDiscipline.</summary>
    public partial class frmInspectionActivityAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private int _id;
        private InspectionActivityList? _entity;
        private List<SecondaryDisciplinesList> _secondaryDisciplines = new();

        public frmInspectionActivityAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.ValueMember = "Id";
            lueDiscipline.EditValueChanged += (s, e) => UpdateSecondaryDisciplineDataSource();

            lueSecondaryDiscipline.Properties.DisplayMember = "Name";
            lueSecondaryDiscipline.Properties.ValueMember = "Id";

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            this.Load += async (s, e) => await LoadRecordAsync();
        }

        private void UpdateSecondaryDisciplineDataSource()
        {
            int? disciplineId = lueDiscipline.EditValue is int d ? d : null;
            var filtered = _secondaryDisciplines.Where(s => s.DisciplineId == disciplineId).ToList();
            lueSecondaryDiscipline.Properties.DataSource = filtered;

            if (lueSecondaryDiscipline.EditValue is int currentSubId && !filtered.Any(x => x.Id == currentSubId))
                lueSecondaryDiscipline.EditValue = null;
        }

        private async Task LoadRecordAsync()
        {
            var handle = ShowOverlay();
            try
            {
                lueDiscipline.Properties.DataSource = await ApiClient.GetDisciplinesAsync();
                _secondaryDisciplines = await ApiClient.GetSecondaryDisciplinesAsync();
                UpdateSecondaryDisciplineDataSource();

                _entity = _id > 0 ? await ApiClient.GetInspectionActivityAsync(_id) : new InspectionActivityList { IsActive = true };
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new InspectionActivityList { IsActive = true };
                }
            }
            finally
            {
                CloseOverlay(handle);
            }

            Text = $"نشاط فحص - {(_id > 0 ? "تعديل" : "جديد")}";

            var secondaryDiscipline = _entity.SecondaryDisciplineId != null
                ? _secondaryDisciplines.FirstOrDefault(s => s.Id == _entity.SecondaryDisciplineId.Value)
                : null;
            lueDiscipline.EditValue = secondaryDiscipline?.DisciplineId;
            UpdateSecondaryDisciplineDataSource();
            lueSecondaryDiscipline.EditValue = _entity.SecondaryDisciplineId;

            txtName.Text = _entity.Name ?? "";
            txtCode.Text = _entity.Code ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private async Task<bool> SaveAsync()
        {
            if (lueDiscipline.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء اختيار التخصص الرئيسي.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueSecondaryDiscipline.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء اختيار التخصص الثانوي.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم نشاط الفحص.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new InspectionActivityList();
                _entity.SecondaryDisciplineId = (int)lueSecondaryDiscipline.EditValue;
                _entity.Name = txtName.Text.Trim();
                _entity.Code = txtCode.Text.Trim();
                _entity.IsActive = chkActive.Checked;

                if (_id > 0)
                {
                    await ApiClient.UpdateInspectionActivityAsync(_id, _entity);
                }
                else
                {
                    _id = await ApiClient.CreateInspectionActivityAsync(_entity);
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
            _entity = new InspectionActivityList { IsActive = true };
            Text = "نشاط فحص - جديد";
            lueDiscipline.EditValue = null;
            lueSecondaryDiscipline.EditValue = null;
            txtName.Text = "";
            txtCode.Text = "";
            chkActive.Checked = true;
            txtName.Focus();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
