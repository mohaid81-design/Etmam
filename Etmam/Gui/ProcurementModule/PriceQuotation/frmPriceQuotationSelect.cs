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
    /// <summary>Modal picker for choosing a Price Quotation ("عرض سعر") — same list/search/select toolbar
    /// pattern as frmItemSelect / frmPurchaseRequestSelect. Opened from frmPurchaseOrderAddEdit.btnProposal,
    /// scoped to quotations submitted against the currently-selected Purchase Request (PriceQuotationList.PRId).</summary>
    public partial class frmPriceQuotationSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public PriceQuotationList? SelectedQuotation { get; private set; }

        private readonly int _prId;
        private List<PriceQuotationList> _allQuotations = new();

        public frmPriceQuotationSelect(int prId)
        {
            _prId = prId;
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
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var suppliersById = DC.StakeholdersList.GetBy("IsDelete = 0").ToDictionary(s => s.Id, s => s.Name);

                _allQuotations = DC.PriceQuotationList
                    .GetBy("PRId = @id AND IsDelete = 0", new { id = _prId })
                    .OrderByDescending(q => q.QuotationDate)
                    .ToList();

                foreach (var q in _allQuotations)
                    q.SupplierName = q.StakeholderId is > 0 && suppliersById.TryGetValue(q.StakeholderId.Value, out var name)
                        ? name : null;

                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل عروض الأسعار: {ex.Message}", "خطأ",
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
                ? _allQuotations
                : _allQuotations.Where(q =>
                    (q.Num?.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (q.SupplierName?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<PriceQuotationList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not PriceQuotationList quotation)
            {
                XtraMessageBox.Show("يرجى اختيار عرض سعر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedQuotation = quotation;
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
