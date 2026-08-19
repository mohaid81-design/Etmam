using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmDrawingsIssuerAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private DrawingsIssuerList? _entity;

        public frmDrawingsIssuerAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();

            btnSaveClose.Click += btnSaveClose_Click;
            btnSaveNew.Click += btnSaveNew_Click;

            LoadRecord();
        }

        private void LoadRecord()
        {
            _entity = _id > 0 ? dc.DrawingsIssuerList.Find(_id) : new DrawingsIssuerList();
            if (_entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _entity = new DrawingsIssuerList();
            }

            Text = $"جهة إصدار - {(_id > 0 ? "تعديل" : "جديد")}";
            txtName.Text = _entity.Name ?? "";
        }

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم جهة الإصدار.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var handle = ShowOverlay();
            try
            {
                _entity ??= new DrawingsIssuerList();
                _entity.Name = txtName.Text.Trim();

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.DrawingsIssuerList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = (Session.CurrentUser?.Id ?? 1).ToString();
                    _id = dc.DrawingsIssuerList.Add(_entity);
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
            _entity = new DrawingsIssuerList();
            Text = "جهة إصدار - جديد";
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
