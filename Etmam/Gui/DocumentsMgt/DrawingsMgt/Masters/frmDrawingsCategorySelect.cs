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
    /// <summary>Modal picker for choosing a drawing category — same list/search/select toolbar pattern as
    /// frmProjectSelect / frmSupplierSelect. Opened from frmDrawingsAddEdit.btnSelectCategory.</summary>
    public partial class frmDrawingsCategorySelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DrawingsCategory? SelectedCategory { get; private set; }

        private List<DrawingsCategory> _allCategories = new();

        public frmDrawingsCategorySelect()
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
            btnAdd.ItemClick += (s, e) => AddNewCategory();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _allCategories = DC.DrawingsCategory.GetBy("IsDelete = 0").OrderBy(c => c.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل تصنيفات المخططات: {ex.Message}", "خطأ",
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
                ? _allCategories
                : _allCategories.Where(c =>
                    (c.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (c.Abb?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<DrawingsCategory>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewCategory()
        {
            if (!Data.PermissionService.HasPermission(PermNames.DrawingsApprovalRequest))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة تصنيفات المخططات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDrawingsCategoryAddEdit frm;
            try { frm = new frmDrawingsCategoryAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not DrawingsCategory category)
            {
                XtraMessageBox.Show("يرجى اختيار تصنيف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedCategory = category;
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
