using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>Modal picker for choosing a supplier — same list/search/select toolbar pattern as
    /// frmItemSelect / frmPurchaseRequestSelect. Opened from frmPurchaseOrderAddEdit.btnSupplier.</summary>
    public partial class frmSupplierSelect : XtraForm
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public SupplierItem? SelectedSupplier { get; private set; }

        private List<SupplierItem> _allSuppliers = new();

        public frmSupplierSelect()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGrid();
            await LoadDataAsync();
        }

        private void SetupGrid()
        {
            gridView1.DoubleClick += (s, e) => ConfirmSelection();

            bbiSelect.ItemClick += (s, e) => ConfirmSelection();
            bbiRefresh.ItemClick += async (s, e) => await LoadDataAsync();
            btnAdd.ItemClick += async (s, e) => await AddNewSupplierAsync();
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                _allSuppliers = await ApiClient.GetSuppliersAsync();
                _allSuppliers = _allSuppliers.OrderBy(s => s.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الموردين: {ex.Message}", "خطأ",
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
                ? _allSuppliers
                : _allSuppliers.Where(s =>
                    (s.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (s.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (s.ContactName1?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<SupplierItem>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private async Task AddNewSupplierAsync()
        {
            var handle = ShowOverlay();
            frmSupplierAddEdit frm;
            try { frm = new frmSupplierAddEdit(); }
            finally { CloseOverlay(handle); }
            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                await LoadDataAsync();
            }
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not SupplierItem supplier)
            {
                XtraMessageBox.Show("يرجى اختيار مورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedSupplier = supplier;
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
