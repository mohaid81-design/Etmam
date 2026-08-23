using System;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDisciplineAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private int _id;
        private DisciplinesList? _entity;

        public frmDisciplineAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            this.Load += async (s, e) => await LoadRecordAsync();
        }

        private async Task LoadRecordAsync()
        {
            var handle = ShowOverlay();
            try
            {
                _entity = _id > 0 ? await ApiClient.GetDisciplineAsync(_id) : new DisciplinesList { IsActive = true };
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new DisciplinesList { IsActive = true };
                }
            }
            finally
            {
                CloseOverlay(handle);
            }

            Text = $"تخصص - {(_id > 0 ? "تعديل" : "جديد")}";
            txtName.Text = _entity.Name ?? "";
            txtCode.Text = _entity.Code ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private async Task<bool> SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم التخصص.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new DisciplinesList();
                _entity.Name = txtName.Text.Trim();
                _entity.Code = txtCode.Text.Trim();
                _entity.IsActive = chkActive.Checked;

                if (_id > 0)
                {
                    await ApiClient.UpdateDisciplineAsync(_id, _entity);
                }
                else
                {
                    _id = await ApiClient.CreateDisciplineAsync(_entity);
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
            _entity = new DisciplinesList { IsActive = true };
            Text = "تخصص - جديد";
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
