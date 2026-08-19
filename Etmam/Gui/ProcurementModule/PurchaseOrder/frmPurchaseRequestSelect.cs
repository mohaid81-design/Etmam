using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;

namespace Etmam
{
    /// <summary>Modal picker for choosing an approved Purchase Request with un-ordered lines remaining —
    /// same list/search/select toolbar pattern as frmItemSelect (used by frmPurchaseRequestAddEdit to add
    /// items). Opened from frmPurchaseOrderAddEdit.btnPurchaseRequest.</summary>
    public partial class frmPurchaseRequestSelect : XtraForm
    {
        protected DataContext DC => Data.DataContext.Shared;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public PurchaseRequestList? SelectedPR { get; private set; }

        private List<PurchaseRequestList> _allPRs = new();

        public frmPurchaseRequestSelect()
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
            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        private void LoadData()
        {
            try
            {
                _allPRs = DC.PurchaseRequestList
                    .GetBy("IsDelete = 0 AND OverallStatus = @a", new { a = PurchaseRequestStatus.Approved })
                    .Where(pr => PurchaseRequestOrderProgress.HasRemainingItems(DC, pr.Id))
                    .OrderByDescending(pr => pr.RequestDate)
                    .ToList();

                foreach (var pr in _allPRs)
                    pr.FormattedNum = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);

                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل طلبات الشراء: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter(string? term)
        {
            term = term?.Trim();
            var filtered = string.IsNullOrEmpty(term)
                ? _allPRs
                : _allPRs.Where(p =>
                    (p.FormattedNum?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (p.Purpose?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = new BindingList<PurchaseRequestList>(filtered);
            barStaticItem1.Caption = $"عدد السجلات : {filtered.Count}";
        }

        private void ConfirmSelection()
        {
            if (gridView1.GetFocusedRow() is not PurchaseRequestList pr)
            {
                XtraMessageBox.Show("يرجى اختيار طلب شراء.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedPR = pr;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
