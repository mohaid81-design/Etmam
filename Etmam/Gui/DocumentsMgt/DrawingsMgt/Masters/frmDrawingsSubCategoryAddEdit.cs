using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDrawingsSubCategoryAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private DrawingsSubCategory? _entity;

        public frmDrawingsSubCategoryAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            lueType.Properties.DataSource = dc.DrawingsType.GetAll();
            lueType.Properties.DisplayMember = "Name";
            lueType.Properties.ValueMember = "Name";

            lueCategory.Properties.DataSource = dc.DrawingsCategory.GetBy("IsDelete = 0").ToList();
            lueCategory.Properties.DisplayMember = "Name";
            lueCategory.Properties.ValueMember = "Id";

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadRecord();
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.DrawingsSubCategory.Find(_id) : new DrawingsSubCategory();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new DrawingsSubCategory();
            }

            Text = $"تصنيف فرعي - {(_id > 0 ? "تعديل" : "جديد")}";
            lueType.EditValue = _entity.Type;
            lueCategory.EditValue = _entity.CategoryId;
            txtName.Text = _entity.Name ?? "";
        }

        private bool Save()
        {
            if (lueType.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء تحديد نوع المخطط.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueCategory.EditValue == null)
            {
                XtraMessageBox.Show("الرجاء تحديد التصنيف.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم التصنيف الفرعي.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new DrawingsSubCategory();
                _entity.Type = lueType.EditValue?.ToString();
                _entity.CategoryId = int.TryParse(lueCategory.EditValue?.ToString(), out int catId) ? catId : null;
                _entity.Name = txtName.Text.Trim();

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.DrawingsSubCategory.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _id = dc.DrawingsSubCategory.Add(_entity);
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
            _entity = new DrawingsSubCategory();
            Text = "تصنيف فرعي - جديد";
            lueType.EditValue = null;
            lueCategory.EditValue = null;
            txtName.Text = "";
            txtName.Focus();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
