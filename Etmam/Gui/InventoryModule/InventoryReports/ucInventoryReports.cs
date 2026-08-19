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
    /// <summary>شاشة "تقارير المخزون": أربعة تقارير (رصيد حالي / كارت صنف / حركة خلال فترة / جرد وفروقاته) في
    /// تبويبات منفصلة، كل واحد بفلاتره الخاصة وشبكته، وشريط أدوات مشترك (تحديث/عرض، طباعة، تصدير Excel)
    /// يعمل حسب التبويب النشط حالياً. منطق الحساب بالكامل في <see cref="InventoryReportsHelper"/>؛ هذا
    /// الكلاس يقتصر على جلب اختيارات الفلاتر وربط النتائج بالشبكات.</summary>
    public partial class ucInventoryReports : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext dc => Data.DataContext.Shared;

        private List<StoreList> _visibleStores = new();
        private Dictionary<int, string> _storeNames = new();
        private Dictionary<int, string> _categoryNames = new();
        private Dictionary<int, string> _itemNames = new();

        private List<StockBalanceRow> _balanceRows = new();
        private List<ItemStockCardRow> _stockCardRows = new();
        private List<StockMovementPeriodRow> _periodRows = new();
        private List<StockingDetails> _stockingVarianceRows = new();

        public ucInventoryReports()
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            LoadLookups();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiRun.ItemClick += (s, e) => SafeAction(RunActiveTab);
            bbiClearFilter.ItemClick += (s, e) => SafeAction(ClearActiveTabFilters);
            bbiPrint.ItemClick += (s, e) => SafeAction(PrintActiveTab);
            bbiExportExcel.ItemClick += (s, e) => SafeAction(ExportActiveTabToExcel);

            xtraTabControl1.SelectedPageChanged += (s, e) => UpdateRunEnabled();
            lookUpEditSCItem.EditValueChanged += (s, e) => UpdateRunEnabled();
            lookUpEditSCStore.EditValueChanged += (s, e) => UpdateRunEnabled();
        }

        /// <summary>يحمّل قوائم المخازن/التصنيفات/الأصناف المنسدلة في كل التبويبات، مقيَّدة بالمخازن التي
        /// يصرَّح للمستخدم برؤيتها ضمن المشروع الحالي (<see cref="InventoryReportsHelper.GetVisibleStores"/>).</summary>
        private void LoadLookups()
        {
            _visibleStores = InventoryReportsHelper.GetVisibleStores(dc);
            var categories = dc.ItemCategory.GetBy("IsDelete = 0").ToList();
            var items = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            _storeNames = _visibleStores.ToDictionary(s => s.Id, s => s.Name ?? "");
            _categoryNames = categories.ToDictionary(c => c.Id, c => c.Name ?? "");
            _itemNames = items.ToDictionary(i => i.Id, i => i.Name ?? "");

            void SetupStoreLookup(LookUpEdit edit, string nullText)
            {
                edit.Properties.DataSource = _visibleStores;
                edit.Properties.ValueMember = "Id";
                edit.Properties.DisplayMember = "Name";
                edit.Properties.NullText = nullText;
            }
            void SetupCategoryLookup(LookUpEdit edit)
            {
                edit.Properties.DataSource = categories;
                edit.Properties.ValueMember = "Id";
                edit.Properties.DisplayMember = "Name";
                edit.Properties.NullText = "-- كل التصنيفات --";
            }
            void SetupItemLookup(LookUpEdit edit, string nullText)
            {
                edit.Properties.DataSource = items;
                edit.Properties.ValueMember = "Id";
                edit.Properties.DisplayMember = "Name";
                edit.Properties.NullText = nullText;
            }

            SetupStoreLookup(lookUpEditSBStore, "-- كل المخازن المصرَّحة --");
            SetupCategoryLookup(lookUpEditSBCategory);
            SetupItemLookup(lookUpEditSBItem, "-- كل الأصناف --");

            SetupItemLookup(lookUpEditSCItem, "-- اختر الصنف --");
            SetupStoreLookup(lookUpEditSCStore, "-- اختر المخزن --");

            SetupStoreLookup(lookUpEditPMStore, "-- كل المخازن المصرَّحة --");
            SetupCategoryLookup(lookUpEditPMCategory);
            SetupItemLookup(lookUpEditPMItem, "-- كل الأصناف --");

            SetupStoreLookup(lookUpEditSVStore, "-- كل المخازن المصرَّحة --");

            dateEditPMFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateEditPMTo.EditValue = DateTime.Today;
            checkEditPMHideNoActivity.Checked = true;
            checkEditSBHideZero.Checked = true;

            UpdateRunEnabled();
        }

        /// <summary>يُستدعى بواسطة ucInventoryMgt عبر reflection عند تبديل المشروع النشط — يعيد تحميل قوائم
        /// الفلاتر حسب نطاق المشروع/الصلاحيات الجديد، ثم يُفرِّغ كل الشبكات (بلا إعادة تشغيل تلقائي، كي لا
        /// تُنفَّذ 4 استعلامات دفعة واحدة بينما تبويب واحد فقط ظاهر).</summary>
        public void OnProjectChanged()
        {
            LoadLookups();

            _balanceRows = new(); gridControlSB.DataSource = null;
            _stockCardRows = new(); gridControlSC.DataSource = null;
            _periodRows = new(); gridControlPM.DataSource = null;
            _stockingVarianceRows = new(); gridControlSV.DataSource = null;
        }

        /// <summary>تبويب "كارت الصنف" يتطلب اختيار صنف ومخزن قبل السماح بالتشغيل — بقية التبويبات بلا شرط.</summary>
        private void UpdateRunEnabled()
        {
            bool onStockCardTab = xtraTabControl1.SelectedTabPage == xtraTabPageStockCard;
            bbiRun.Enabled = !onStockCardTab || (lookUpEditSCItem.EditValue is int && lookUpEditSCStore.EditValue is int);
        }

        // ── Run ──────────────────────────────────────────────────────────────
        private void RunActiveTab()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageBalance) RunBalance();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockCard) RunStockCard();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPagePeriodMovement) RunPeriodMovement();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockingVariance) RunStockingVariance();
        }

        private void RunBalance()
        {
            var storeIds = lookUpEditSBStore.EditValue is int storeId
                ? new List<int> { storeId }
                : _visibleStores.Select(s => s.Id).ToList();
            int? categoryId = lookUpEditSBCategory.EditValue as int?;
            int? itemId = lookUpEditSBItem.EditValue as int?;

            _balanceRows = InventoryReportsHelper.GetCurrentStockBalance(dc, storeIds, categoryId, itemId);
            if (checkEditSBHideZero.Checked) _balanceRows = _balanceRows.Where(r => r.Balance != 0).ToList();

            gridControlSB.DataSource = new BindingList<StockBalanceRow>(_balanceRows);
        }

        private void RunStockCard()
        {
            if (lookUpEditSCItem.EditValue is not int itemId || lookUpEditSCStore.EditValue is not int storeId)
            {
                XtraMessageBox.Show("يرجى اختيار الصنف والمخزن أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _stockCardRows = InventoryReportsHelper.GetItemStockCard(dc, itemId, storeId);
            gridControlSC.DataSource = new BindingList<ItemStockCardRow>(_stockCardRows);
        }

        private void RunPeriodMovement()
        {
            if (dateEditPMFrom.EditValue is not DateTime fromDate || dateEditPMTo.EditValue is not DateTime toDate)
            {
                XtraMessageBox.Show("يرجى تحديد الفترة (من/إلى تاريخ).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var storeIds = lookUpEditPMStore.EditValue is int storeId
                ? new List<int> { storeId }
                : _visibleStores.Select(s => s.Id).ToList();
            int? categoryId = lookUpEditPMCategory.EditValue as int?;
            int? itemId = lookUpEditPMItem.EditValue as int?;

            _periodRows = InventoryReportsHelper.GetStockMovementForPeriod(
                dc, fromDate, toDate, storeIds, itemId, categoryId,
                perStore: checkEditPMPerStore.Checked, hideNoActivity: checkEditPMHideNoActivity.Checked);

            gridControlPM.DataSource = new BindingList<StockMovementPeriodRow>(_periodRows);
        }

        private void RunStockingVariance()
        {
            var storeIds = _visibleStores.Select(s => s.Id).ToList();
            int? storeFilter = lookUpEditSVStore.EditValue as int?;
            DateTime? from = dateEditSVFrom.EditValue as DateTime?;
            DateTime? to = dateEditSVTo.EditValue as DateTime?;

            _stockingVarianceRows = InventoryReportsHelper.GetStockingVariance(dc, storeIds, storeFilter, from, to);
            gridControlSV.DataSource = new BindingList<StockingDetails>(_stockingVarianceRows);
        }

        // ── Clear filters ────────────────────────────────────────────────────
        private void ClearActiveTabFilters()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageBalance) ClearBalanceFilters();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockCard) ClearStockCardFilters();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPagePeriodMovement) ClearPeriodMovementFilters();
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockingVariance) ClearStockingVarianceFilters();

            UpdateRunEnabled();
        }

        private void ClearBalanceFilters()
        {
            lookUpEditSBStore.EditValue = null;
            lookUpEditSBCategory.EditValue = null;
            lookUpEditSBItem.EditValue = null;
            checkEditSBHideZero.Checked = true;

            _balanceRows = new();
            gridControlSB.DataSource = null;
        }

        private void ClearStockCardFilters()
        {
            lookUpEditSCItem.EditValue = null;
            lookUpEditSCStore.EditValue = null;

            _stockCardRows = new();
            gridControlSC.DataSource = null;
        }

        private void ClearPeriodMovementFilters()
        {
            lookUpEditPMStore.EditValue = null;
            lookUpEditPMCategory.EditValue = null;
            lookUpEditPMItem.EditValue = null;
            dateEditPMFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateEditPMTo.EditValue = DateTime.Today;
            checkEditPMPerStore.Checked = false;
            checkEditPMHideNoActivity.Checked = true;

            _periodRows = new();
            gridControlPM.DataSource = null;
        }

        private void ClearStockingVarianceFilters()
        {
            lookUpEditSVStore.EditValue = null;
            dateEditSVFrom.EditValue = null;
            dateEditSVTo.EditValue = null;

            _stockingVarianceRows = new();
            gridControlSV.DataSource = null;
        }

        // ── Print ────────────────────────────────────────────────────────────
        private void PrintActiveTab()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageBalance)
            {
                if (_balanceRows.Count == 0) { WarnNoData(); return; }
                InventoryReportsPrinter.PrintCurrentStockBalance(_balanceRows, BuildBalanceFilterSummary());
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockCard)
            {
                if (_stockCardRows.Count == 0) { WarnNoData(); return; }
                string itemName = lookUpEditSCItem.EditValue is int itemId ? _itemNames.GetValueOrDefault(itemId, "") : "";
                string storeName = lookUpEditSCStore.EditValue is int storeId ? _storeNames.GetValueOrDefault(storeId, "") : "";
                InventoryReportsPrinter.PrintItemStockCard(_stockCardRows, itemName, storeName);
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPagePeriodMovement)
            {
                if (_periodRows.Count == 0) { WarnNoData(); return; }
                var fromDate = dateEditPMFrom.EditValue as DateTime? ?? DateTime.Today;
                var toDate = dateEditPMTo.EditValue as DateTime? ?? DateTime.Today;
                InventoryReportsPrinter.PrintStockMovementPeriod(_periodRows, fromDate, toDate, BuildPeriodFilterSummary());
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPageStockingVariance)
            {
                if (_stockingVarianceRows.Count == 0) { WarnNoData(); return; }
                InventoryReportsPrinter.PrintStockingVariance(_stockingVarianceRows, BuildStockingVarianceFilterSummary());
            }
        }

        private static void WarnNoData() =>
            XtraMessageBox.Show("لا توجد بيانات لعرضها — يرجى الضغط على \"تحديث / عرض\" أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private string BuildBalanceFilterSummary()
        {
            string store = lookUpEditSBStore.EditValue is int storeId ? _storeNames.GetValueOrDefault(storeId, "") : "كل المخازن المصرَّحة";
            string category = lookUpEditSBCategory.EditValue is int categoryId ? _categoryNames.GetValueOrDefault(categoryId, "") : "كل التصنيفات";
            return $"المخزن: {store}  |  التصنيف: {category}";
        }

        private string BuildPeriodFilterSummary()
        {
            string store = lookUpEditPMStore.EditValue is int storeId ? _storeNames.GetValueOrDefault(storeId, "") : "كل المخازن المصرَّحة";
            var fromDate = dateEditPMFrom.EditValue as DateTime? ?? DateTime.Today;
            var toDate = dateEditPMTo.EditValue as DateTime? ?? DateTime.Today;
            return $"المخزن: {store}  |  الفترة: {fromDate:yyyy-MM-dd} إلى {toDate:yyyy-MM-dd}";
        }

        private string BuildStockingVarianceFilterSummary()
        {
            string store = lookUpEditSVStore.EditValue is int storeId ? _storeNames.GetValueOrDefault(storeId, "") : "كل المخازن المصرَّحة";
            return $"المخزن: {store}";
        }

        // ── Excel export ─────────────────────────────────────────────────────
        /// <summary>نفس نمط ucPurchaseRequests.ExportToExcel — الاختلاف الوحيد أن الشبكة المصدَّرة تُحدَّد حسب
        /// التبويب النشط حالياً بدل شبكة واحدة ثابتة.</summary>
        private void ExportActiveTabToExcel()
        {
            DevExpress.XtraGrid.GridControl? grid =
                xtraTabControl1.SelectedTabPage == xtraTabPageBalance ? gridControlSB :
                xtraTabControl1.SelectedTabPage == xtraTabPageStockCard ? gridControlSC :
                xtraTabControl1.SelectedTabPage == xtraTabPagePeriodMovement ? gridControlPM :
                xtraTabControl1.SelectedTabPage == xtraTabPageStockingVariance ? gridControlSV : null;

            if (grid?.DataSource == null)
            {
                WarnNoData();
                return;
            }

            using var dlg = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = "تقرير المخزون.xlsx" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grid.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SafeAction(Action action)
        {
            var handle = ShowOverlay();
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private void pnlFiltersPM_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFiltersSB_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
