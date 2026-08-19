using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmFloorAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private FloorsList? _entity;
        private List<BuildingsList> _buildings = new();

        public frmFloorAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueProject.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0").ToList();
            lueProject.Properties.DisplayMember = "Name";
            lueProject.Properties.ValueMember = "Id";

            lueBuilding.Properties.DisplayMember = "Name";
            lueBuilding.Properties.ValueMember = "Id";
            _buildings = dc.BuildingsList.GetBy("IsDelete = 0").ToList();
            UpdateBuildingDataSource();
            lueProject.EditValueChanged += (s, e) => UpdateBuildingDataSource();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadRecord();
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

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.FloorsList.Find(_id) : new FloorsList { IsActive = true };
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new FloorsList { IsActive = true };
            }

            Text = $"طابق - {(_id > 0 ? "تعديل" : "جديد")}";

            var building = _entity.BuildingId is int bId ? _buildings.FirstOrDefault(b => b.Id == bId) : null;
            lueProject.EditValue = building?.PrjId;
            UpdateBuildingDataSource();
            lueBuilding.EditValue = _entity.BuildingId;

            txtName.Text = _entity.Name ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private bool Save()
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
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.FloorsList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.FloorsList.Add(_entity);
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
