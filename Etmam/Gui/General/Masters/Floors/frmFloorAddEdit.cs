using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmFloorAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private int _id;
        private FloorsList? _entity;
        private List<BuildingsList> _buildings = new();

        public frmFloorAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";

            lueBuilding.Properties.DisplayMember = "Name";
            lueBuilding.Properties.ValueMember = "Id";
            lueProject.EditValueChanged += (s, e) => UpdateBuildingDataSource();

            this.Load += async (s, e) => await LoadRecordAsync();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;
        }

        /// <summary>Filters lueBuilding to the currently-selected project — same cascading pattern
        /// used in frmCIRAddEdit's UpdateBuildingDataSource.</summary>
        private void UpdateBuildingDataSource()
        {
            int? prjId = GetLookUpValue(lueProject);

            var filteredBuildings = _buildings.Where(b => b.PrjId == prjId).ToList();
            lueBuilding.Properties.DataSource = filteredBuildings;
            if (GetLookUpValue(lueBuilding) is int currentBuildingId && !filteredBuildings.Any(x => x.Id == currentBuildingId))
                lueBuilding.EditValue = null;
        }

        private static int? GetLookUpValue(LookUpEdit lookUpEdit)
        {
            var val = lookUpEdit.EditValue;
            if (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()))
                return null;
            return int.TryParse(val.ToString(), out int res) ? res : null;
        }

        private async Task LoadRecordAsync()
        {
            var handle = ShowOverlay();
            try
            {
                lueProject.Properties.DataSource = await ApiClient.GetProjectsAsync();
                _buildings = await ApiClient.GetBuildingsAsync();
                _entity = _id > 0 ? await ApiClient.GetFloorAsync(_id) : new FloorsList { IsActive = true };
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new FloorsList { IsActive = true };
                }
            }
            finally
            {
                CloseOverlay(handle);
            }

            Text = $"طابق - {(_id > 0 ? "تعديل" : "جديد")}";

            var building = _entity.BuildingId is int bId ? _buildings.FirstOrDefault(b => b.Id == bId) : null;
            lueProject.EditValue = building?.PrjId;
            UpdateBuildingDataSource();
            lueBuilding.EditValue = _entity.BuildingId;

            txtName.Text = _entity.Name ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private async Task<bool> SaveAsync()
        {
            if (GetLookUpValue(lueProject) == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المشروع.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueBuilding.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء اختيار المبنى.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم الطابق.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new FloorsList();
                _entity.BuildingId = (int)lueBuilding.EditValue;
                _entity.Name = txtName.Text.Trim();
                _entity.IsActive = chkActive.Checked;

                if (_id > 0)
                {
                    await ApiClient.UpdateFloorAsync(_id, _entity);
                }
                else
                {
                    _id = await ApiClient.CreateFloorAsync(_entity);
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
            _entity = new FloorsList { IsActive = true };
            Text = "طابق - جديد";
            lueProject.EditValue = null;
            lueBuilding.EditValue = null;
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
