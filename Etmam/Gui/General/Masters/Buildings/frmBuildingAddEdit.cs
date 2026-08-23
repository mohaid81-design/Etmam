using System;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmBuildingAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private int _id;
        private BuildingsList? _entity;

        public frmBuildingAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            this.Load += async (s, e) => await LoadRecordAsync();
        }

        private async Task LoadRecordAsync()
        {
            var handle = ShowOverlay();
            try
            {
                lueProject.Properties.DataSource = await ApiClient.GetProjectsAsync();
                _entity = _id > 0 ? await ApiClient.GetBuildingAsync(_id) : new BuildingsList { IsActive = true };
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new BuildingsList { IsActive = true };
                }
            }
            finally
            {
                CloseOverlay(handle);
            }

            Text = $"مبنى - {(_id > 0 ? "تعديل" : "جديد")}";
            lueProject.EditValue = _entity.PrjId;
            txtName.Text = _entity.Name ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private async Task<bool> SaveAsync()
        {
            if (lueProject.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المشروع.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم المبنى.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new BuildingsList();
                _entity.PrjId = (int)lueProject.EditValue;
                _entity.Name = txtName.Text.Trim();
                _entity.IsActive = chkActive.Checked;

                if (_id > 0)
                {
                    await ApiClient.UpdateBuildingAsync(_id, _entity);
                }
                else
                {
                    _id = await ApiClient.CreateBuildingAsync(_entity);
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
            _entity = new BuildingsList { IsActive = true };
            Text = "مبنى - جديد";
            lueProject.EditValue = null;
            txtName.Text = "";
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
