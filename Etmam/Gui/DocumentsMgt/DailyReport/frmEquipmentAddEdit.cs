using System;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class frmEquipmentAddEdit : XtraForm
    {
        protected Data.DataContext DC => Data.DataContext.Shared;
        private EquipmentList _equipment;
        private readonly bool _isNew;

        public frmEquipmentAddEdit()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _equipment = new EquipmentList();
            _isNew = true;
            InitializeData();
        }

        public frmEquipmentAddEdit(EquipmentList equipment)
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
            _equipment = equipment;
            _isNew = false;
            InitializeData();
        }
        
        private void InitializeData()
        {
            this.KeyPreview = true;
            this.KeyDown += Frm_KeyDown;

            txtName.Text = _equipment.Name;

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
                XtraMessageBox.Show("يرجى إدخال اسم المعدة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            _equipment.Name = txtName.Text;

            var handle = ShowOverlay();
            try
            {
                if (_isNew)
                {
                    _equipment.IsDelete = false;
                    _equipment.CreatedDate = DateTime.Now;
                    _equipment.CreatedBy = Session.CurrentUser?.Id ?? 0;
                    _equipment.CreatedMachine = Session.Machine;
                    DC.EquipmentList.Add(_equipment);
                }
                else
                {
                    _equipment.UpdateDate = DateTime.Now;
                    _equipment.UpdateBy = Session.CurrentUser?.Id ?? 0;
                    _equipment.UpdateMachine = Session.Machine;
                    DC.EquipmentList.Edit(_equipment.Id, _equipment);
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
                _equipment = new EquipmentList();
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