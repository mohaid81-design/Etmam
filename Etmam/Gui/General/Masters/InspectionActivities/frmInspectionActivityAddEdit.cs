using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Add/edit a single "نشاط الفحص" row — mirrors frmSecondaryDisciplineAddEdit's own
    /// pattern one level deeper: lueDiscipline here is a filter-only aid (not stored), the actual FK
    /// stored on the entity is SecondaryDisciplineId via lueSecondaryDiscipline.</summary>
    public partial class frmInspectionActivityAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private InspectionActivityList? _entity;

        public frmInspectionActivityAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueDiscipline.Properties.DataSource = dc.DisciplinesList.GetBy("IsDelete = 0").ToList();
            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.ValueMember = "Id";
            lueDiscipline.EditValueChanged += (s, e) => UpdateSecondaryDisciplineDataSource();

            lueSecondaryDiscipline.Properties.DisplayMember = "Name";
            lueSecondaryDiscipline.Properties.ValueMember = "Id";
            UpdateSecondaryDisciplineDataSource();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadRecord();
        }

        private void UpdateSecondaryDisciplineDataSource()
        {
            int? disciplineId = lueDiscipline.EditValue is int d ? d : null;
            var filtered = dc.SecondaryDisciplinesList.GetBy("IsDelete = 0")
                .Where(s => s.DisciplineId == disciplineId).ToList();
            lueSecondaryDiscipline.Properties.DataSource = filtered;

            if (lueSecondaryDiscipline.EditValue is int currentSubId && !filtered.Any(x => x.Id == currentSubId))
                lueSecondaryDiscipline.EditValue = null;
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.InspectionActivityList.Find(_id) : new InspectionActivityList { IsActive = true };
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new InspectionActivityList { IsActive = true };
            }

            Text = $"نشاط فحص - {(_id > 0 ? "تعديل" : "جديد")}";

            var secondaryDiscipline = _entity.SecondaryDisciplineId != null
                ? dc.SecondaryDisciplinesList.Find(_entity.SecondaryDisciplineId.Value)
                : null;
            lueDiscipline.EditValue = secondaryDiscipline?.DisciplineId;
            UpdateSecondaryDisciplineDataSource();
            lueSecondaryDiscipline.EditValue = _entity.SecondaryDisciplineId;

            txtName.Text = _entity.Name ?? "";
            txtCode.Text = _entity.Code ?? "";
            chkActive.Checked = _entity.IsActive ?? true;
        }

        private bool Save()
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
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.InspectionActivityList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.InspectionActivityList.Add(_entity);
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
