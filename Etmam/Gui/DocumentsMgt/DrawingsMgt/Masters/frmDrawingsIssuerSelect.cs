using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Modal picker for choosing a drawing issuer — same list/search/select toolbar pattern as
    /// frmDrawingsCategorySelect / frmProjectSelect. Opened from frmDrawingsAddEdit.btnSelectDrawingIssuer.</summary>
    public partial class frmDrawingsIssuerSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DrawingsIssuerList? SelectedIssuer { get; private set; }

        private List<DrawingsIssuerList> _allIssuers = new();

        public frmDrawingsIssuerSelect()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            btnAdd.ItemClick += (s, e) => AddNewIssuer();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _allIssuers = DC.DrawingsIssuerList.GetBy("IsDelete = 0").OrderBy(i => i.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل جهات إصدار المخططات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var filtered = string.IsNullOrEmpty(term)
                ? _allIssuers
                : _allIssuers.Where(i =>
                    i.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true).ToList();

            gridControl1.DataSource = new BindingList<DrawingsIssuerList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewIssuer()
        {
            if (!Data.PermissionService.HasPermission(PermNames.DrawingsApprovalRequest))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة جهات إصدار المخططات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDrawingsIssuerAddEdit frm;
            try { frm = new frmDrawingsIssuerAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not DrawingsIssuerList issuer)
            {
                XtraMessageBox.Show("يرجى اختيار جهة إصدار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedIssuer = issuer;
            DialogResult = DialogResult.OK;
            Close();
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
