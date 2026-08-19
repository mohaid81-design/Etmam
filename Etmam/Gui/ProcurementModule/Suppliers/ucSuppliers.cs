using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>List/grid screen for Suppliers (StakeholdersList). Unlike PurchaseOrder/PurchaseRequest there's
    /// no approval workflow here — it's a plain master-data record — so "فتح" and "تعديل" both just open
    /// frmSupplierAddEdit, which has its own internal First/Prev/Next/Last navigator.</summary>
    public partial class ucSuppliers : DevExpress.XtraEditors.XtraUserControl
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private List<StakeholdersList> _allRecords = new();
        private Dictionary<int, StakeholdersCategory> _categoriesById = new();
        private bool _canManage;

        public ucSuppliers()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.Stakeholder);
            bbiNew.Enabled = _canManage;

            SetupGrid();

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiOpen.ItemClick += (s, e) => EditSelected();
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiPrint.ItemClick += (s, e) => PrintGrid();
            bbiRefresh.ItemClick += (s, e) => LoadData();

            barEditItem1.EditValueChanged += (s, e) => ApplyFilter(barEditItem1.EditValue?.ToString());
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupGrid()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = false;

            gridView1.DoubleClick += (s, e) => EditSelected();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
        }

        /// <summary>colSupplierCode/colMainCategory/colSubCategory are unbound — StakeholdersList has no Code
        /// column (see frmSupplierAddEdit.FormatSupplierCode) and the raw CategoryId FK isn't resolved by the
        /// plain ADO.NET data helper (no join), so both are looked up here from a small in-memory cache.</summary>
        private void GridView1_CustomUnboundColumnData(object? sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (!e.IsGetData || e.Row is not StakeholdersList row) return;

            if (e.Column == colSupplierCode)
            {
                e.Value = frmSupplierAddEdit.FormatSupplierCode(row.Id);
            }
            else if (e.Column == colMainCategory)
            {
                e.Value = row.CategoryId is int cid && _categoriesById.TryGetValue(cid, out var cat) ? cat.MainCategory : null;
            }
            else if (e.Column == colSubCategory)
            {
                e.Value = row.CategoryId is int cid2 && _categoriesById.TryGetValue(cid2, out var cat2) ? cat2.SubCategory : null;
            }
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                _categoriesById = dc.StakeholdersCategory.GetAll()
                    .Where(c => c.Id.HasValue)
                    .ToDictionary(c => c.Id!.Value, c => c);

                _allRecords = dc.StakeholdersList.GetBy("IsDelete = 0").OrderBy(s => s.Name).ToList();
                ApplyFilter(barEditItem1.EditValue?.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل الموردين:\n{ex.Message}", "خطأ",
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
                ? _allRecords
                : _allRecords.Where(s =>
                    (s.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (s.PhoneNumber?.Contains(term, StringComparison.OrdinalIgnoreCase) == true) ||
                    (s.ContactName1?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            gridControl1.DataSource = filtered;
            UpdateStatusBar(filtered.Count);
            UpdateButtonStates();
        }

        // ── Record Operations ─────────────────────────────────────────────────
        // نقطة الدخول الموحّدة (bbiNew/bbiOpen/bbiEdit والنقر المزدوج) — الفحص هنا يمنع تجاوز الصلاحية
        // عبر النقر المزدوج الذي لا يمر بحالة تفعيل الأزرار.
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة الموردين.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmSupplierAddEdit frm;
            try { frm = new frmSupplierAddEdit(id); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadData();
            }
        }

        private void EditSelected()
        {
            var row = gridView1.GetFocusedRow() as StakeholdersList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مورد أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(row.Id);
        }

        private void DeleteSelected()
        {
            var row = gridView1.GetFocusedRow() as StakeholdersList;
            if (row == null)
            {
                XtraMessageBox.Show("يرجى تحديد مورد أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show($"هل تريد حذف المورد \"{row.Name}\"؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var handle = ShowOverlay();
            try
            {
                row.IsDelete = true;
                row.DeletionDate = DateTime.Now;
                row.DeletionBy = Session.CurrentUser?.Id ?? 1;
                row.DeletionMachine = Session.Machine;
                dc.StakeholdersList.Edit(row.Id, row);

                XtraMessageBox.Show("تم حذف المورد بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void PrintGrid()
        {
            try { gridControl1.ShowPrintPreview(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _allRecords.Count > 0;
            // bbiOpen يستدعي نفس EditSelected() تماماً (لا يوجد وضع "عرض فقط" منفصل لهذا الكيان)، فيُمنع
            // بنفس صلاحية bbiEdit تفادياً لتجاوزها.
            bbiOpen.Enabled = hasSelection && _canManage;
            bbiEdit.Enabled = hasSelection && _canManage;
            bbiDelete.Enabled = hasSelection && _canManage;
            bbiPrint.Enabled = _allRecords.Count > 0 && _canManage;
        }

        private void UpdateStatusBar(int count)
        {
            bar3.Text = $"عدد الموردين: {count}";
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
