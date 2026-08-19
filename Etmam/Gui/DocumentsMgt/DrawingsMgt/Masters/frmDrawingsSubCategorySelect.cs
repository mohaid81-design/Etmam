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
    /// <summary>Modal picker for choosing a drawing sub-category — same list/search/select toolbar pattern as
    /// frmDrawingsCategorySelect / frmProjectSelect. Opened from frmDrawingsAddEdit.btnSelectSubCategory.</summary>
    public partial class frmDrawingsSubCategorySelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DrawingsSubCategory? SelectedSubCategory { get; private set; }

        private List<DrawingsSubCategory> _allSubCategories = new();

        public frmDrawingsSubCategorySelect()
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
            repositoryItemLookUpCategory.DataSource = DC.DrawingsCategory.GetBy("IsDelete = 0").ToList();
            repositoryItemLookUpCategory.DisplayMember = "Name";
            repositoryItemLookUpCategory.ValueMember = "Id";

            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += (s, e) => LoadData();
            btnAdd.ItemClick += (s, e) => AddNewSubCategory();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _allSubCategories = DC.DrawingsSubCategory.GetBy("IsDelete = 0").OrderBy(s => s.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل التصنيفات الفرعية للمخططات: {ex.Message}", "خطأ",
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
                ? _allSubCategories
                : _allSubCategories.Where(s =>
                    (s.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (s.Type?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<DrawingsSubCategory>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void AddNewSubCategory()
        {
            if (!Data.PermissionService.HasPermission(PermNames.DrawingsApprovalRequest))
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التصنيفات الفرعية للمخططات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDrawingsSubCategoryAddEdit frm;
            try { frm = new frmDrawingsSubCategoryAddEdit(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }

            LoadData();
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not DrawingsSubCategory subCategory)
            {
                XtraMessageBox.Show("يرجى اختيار تصنيف فرعي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedSubCategory = subCategory;
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
