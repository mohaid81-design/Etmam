using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmSecondaryDisciplineAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private SecondaryDisciplinesList? _entity;

        public frmSecondaryDisciplineAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueDiscipline.Properties.DataSource = dc.DisciplinesList.GetBy("IsDelete = 0").ToList();
            lueDiscipline.Properties.DisplayMember = "Name";
            lueDiscipline.Properties.ValueMember = "Id";

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadRecord();
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.SecondaryDisciplinesList.Find(_id) : new SecondaryDisciplinesList { IsActive = true };
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new SecondaryDisciplinesList { IsActive = true };
            }

            Text = $"تخصص ثانوي - {(_id > 0 ? "تعديل" : "جديد")}";
            lueDiscipline.EditValue = _entity.DisciplineId;
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم التخصص الثانوي.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new SecondaryDisciplinesList();
                _entity.DisciplineId = (int)lueDiscipline.EditValue;
                _entity.Name = txtName.Text.Trim();
                _entity.Code = txtCode.Text.Trim();
                _entity.IsActive = chkActive.Checked;

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.SecondaryDisciplinesList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.SecondaryDisciplinesList.Add(_entity);
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
            _entity = new SecondaryDisciplinesList { IsActive = true };
            Text = "تخصص ثانوي - جديد";
            lueDiscipline.EditValue = null;
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
