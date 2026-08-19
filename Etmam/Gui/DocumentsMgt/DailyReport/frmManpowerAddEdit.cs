using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmManpowerAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private ManpowerList _manpower;
        private readonly bool _isNew;

        public frmManpowerAddEdit(string category)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _manpower = new ManpowerList { Category = category };
            _isNew = true;
            InitializeData();
        }

        public frmManpowerAddEdit(ManpowerList manpower)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _manpower = manpower;
            _isNew = false;
            InitializeData();
        }
        private void InitializeData()
        {
            this.KeyPreview = true;
            this.KeyDown += Frm_KeyDown;

            txtName.Text = _manpower.Name;
            txtCategory.Text = _manpower.Category;

            btnCancel.Click += (s, e) => Close();

            // Set SaveAndNew visibility
            btnSaveAndNew.Visible = _isNew;
        }

        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (_isNew)
                    BtnSaveAndNew_Click(sender, e);
                else
                    BtnSaveAndClose_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("يرجى إدخال اسم المهنة أو العامل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            _manpower.Name = txtName.Text;

            var handle = ShowOverlay();
            try
            {
                if (_isNew)
                {
                    _manpower.IsDelete = false;
                    _manpower.CreatedDate = DateTime.Now;
                    _manpower.CreatedBy = Session.CurrentUser?.Id ?? 0;
                    _manpower.CreatedMachine = Session.Machine;
                    DC.ManpowerList.Add(_manpower);
                }
                else
                {
                    _manpower.UpdateDate = DateTime.Now;
                    _manpower.UpdateBy = Session.CurrentUser?.Id ?? 0;
                    _manpower.UpdateMachine = Session.Machine;
                    DC.ManpowerList.Edit(_manpower.Id, _manpower);
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { CloseOverlay(handle); }
        }

        private bool _anySaved = false;

        private void BtnSaveAndNew_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                _anySaved = true;
                // Reset for new entry
                string cat = _manpower.Category;
                _manpower = new ManpowerList { Category = cat };
                txtName.Text = "";
                txtName.Focus();
                // We DON'T set DialogResult here if we want to keep it open
            }
        }

        private void BtnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                _anySaved = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_anySaved && DialogResult != DialogResult.OK)
            {
                DialogResult = DialogResult.OK; // Set OK if something was saved before closing
            }
            base.OnFormClosing(e);
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

    }
}