using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    /// <summary>List/grid screen for saved price-quotation comparisons ("مقارنة عروض أسعار") — mirrors
    /// ucPriceQuotation's structure/conventions. No approval workflow exists for this entity, so there are
    /// no bulk status actions and no locked-record delete guard.</summary>
    public partial class ucPriceQuotationCompare : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext DB => Data.DataContext.Shared;

        private List<PriceQuotationCompareList> _allRecords = new();
        private HashSet<int> _grantedProjectIds = new();

        private RepositoryItemLookUpEdit repositoryItemLookUpEditPRCol = null!;
        private bool _canManage;

        public ucPriceQuotationCompare()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.PriceQuotation);
            bbiNew.Enabled = _canManage;

            SetupLookups();
            SetupGrid();

            this.Load += (s, e) => LoadData();

            bbiNew.ItemClick += (s, e) => OpenAddEdit(0);
            bbiOpen.ItemClick += (s, e) => EditSelected();
            bbiEdit.ItemClick += (s, e) => EditSelected();
            bbiDelete.ItemClick += (s, e) => DeleteSelected();
            bbiPrint.ItemClick += (s, e) => PrintGrid();
            bbiRefresh.ItemClick += (s, e) => LoadData();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupLookups()
        {
            // نفس منطق صلاحيات المشاريع في ucPriceQuotation/ucPurchaseOrder — يُستخدم لاحقاً لتصفية
            // السجلات المعروضة بالمشاريع المصرَّح للمستخدم بالاطلاع عليها.
            _grantedProjectIds = PermissionService.GrantedProjectIds(DB);

            repositoryItemLookUpEditProject.DataSource = DB.ProjectsList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditProject.ValueMember = "Id";
            repositoryItemLookUpEditProject.DisplayMember = "Name";
            colPrjId.ColumnEdit = repositoryItemLookUpEditProject;

            repositoryItemLookUpEditPRCol = new RepositoryItemLookUpEdit
            {
                DataSource = DB.PurchaseRequestList.GetBy("IsDelete = 0"),
                ValueMember = "Id",
                DisplayMember = "Num"
            };
            gridControl1.RepositoryItems.Add(repositoryItemLookUpEditPRCol);
            colPRId.ColumnEdit = repositoryItemLookUpEditPRCol;
        }

        private void SetupGrid()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;

            // خلفية أعمدة الأزرار (طباعة/إجراء/سجل) تتغيّر تلقائياً عند تركيز/تحديد الصف (سلوك DevExpress
            // الافتراضي)، فنفرض لون الصف الطبيعي (فردي/زوجي) عليها دائماً — نفس إصلاح ucPriceQuotation.
            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.RowCellStyle += GridView1_RowCellStyle;

            gridView1.DoubleClick += (s, e) => EditSelected();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            repositoryItemButtonEditPrint.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is PriceQuotationCompareList) PrintFocused();
            };

            repositoryItemButtonEditAction.ButtonClick += (s, e) =>
            {
                if (!_canManage) return;
                if (gridView1.GetFocusedRow() is PriceQuotationCompareList rec) OpenAddEdit(rec.Id);
            };

            repositoryItemButtonEditLog.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is PriceQuotationCompareList rec) ShowAuditInfo(rec);
            };
        }

        private void GridView1_RowCellStyle(object? sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colPrint) return;

            bool isEvenRow = e.RowHandle % 2 != 0;
            e.Appearance.BackColor = isEvenRow ? gridView1.Appearance.EvenRow.BackColor : gridView1.Appearance.Row.BackColor;
            e.Appearance.Options.UseBackColor = true;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        public void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                var ids = _grantedProjectIds.Count > 0 ? string.Join(",", _grantedProjectIds) : "-1";
                string filter = $"IsDelete = 0 AND PrjId IN ({ids})";

                _allRecords = DB.PriceQuotationCompareList.GetBy(filter)
                    .OrderByDescending(r => r.Id)
                    .ToList();

                gridControl1.DataSource = _allRecords;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل مقارنات عروض الأسعار:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── Record Operations ─────────────────────────────────────────────────
        // نقطة الدخول الموحّدة (bbiNew/bbiOpen/bbiEdit، النقر المزدوج، وزر colAction في الشبكة) — الفحص
        // هنا يمنع تجاوز الصلاحية عبر أي من هذه المسارات.
        private void OpenAddEdit(int id)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة مقارنات عروض الأسعار.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmPriceQuotationCompareAddEdit frm;
            try { frm = new frmPriceQuotationCompareAddEdit(id); }
            finally { CloseOverlay(handle); }
            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadData();
            }
        }

        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as PriceQuotationCompareList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();
            var handles = gridView1.GetSelectedRows();
            if (handles != null && handles.Length > 0)
            {
                foreach (int h in handles)
                    if (gridView1.GetRow(h) is PriceQuotationCompareList rec) ids.Add(rec.Id);
            }
            else
            {
                int id = GetFocusedId();
                if (id > 0) ids.Add(id);
            }
            return ids;
        }

        private void EditSelected()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد مقارنة عروض أسعار أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد مقارنة عروض أسعار واحدة على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = ids.Count == 1
                ? "هل أنت متأكد من حذف مقارنة عروض الأسعار المحددة؟"
                : $"هل أنت متأكد من حذف {ids.Count} مقارنات عروض أسعار؟";
            if (XtraMessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try { DB.DeletePriceQuotationCompare(id); done++; }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند حذف مقارنة #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"تم حذف {done} مقارنات عروض أسعار بنجاح ✓", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void PrintGrid()
        {
            try { gridControl1.ShowPrintPreview(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>لا يوجد بعد تقرير طباعة مخصص لمقارنة واحدة (انظر frmPriceQuotationCompareAddEdit.PrintRecord) —
        /// نفس الرسالة تماماً حتى يُبنى التقرير لاحقاً.</summary>
        private void PrintFocused() =>
            XtraMessageBox.Show("طباعة مقارنة عروض الأسعار غير متاحة حالياً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>لا يوجد لهذا الكيان مسار اعتماد/Workflow ولا مورد واحد مرتبط بالرأس (قد تضم المقارنة
        /// عروضاً من عدة موردين)، فيُكتفى بعرض طلب الشراء المرتبط وعدد العروض المُدرَجة وبيانات
        /// الإنشاء/آخر تعديل.</summary>
        private void ShowAuditInfo(PriceQuotationCompareList rec)
        {
            var linkedPr = rec.PRId is > 0 ? DB.PurchaseRequestList.Find(rec.PRId.Value) : null;
            int quotationCount = DB.PriceQuotationCompareDetails.Count("ParentId = @id AND IsDelete = 0", new { id = rec.Id });

            var text =
                $"طلب الشراء: {(linkedPr != null ? PurchaseRequestPrinter.FormatPRNumber(linkedPr.Num, linkedPr.RequestDate) : "—")}\n" +
                $"عدد عروض الأسعار المقارنة: {quotationCount}\n" +
                $"تاريخ الإنشاء: {rec.CreatedDate:yyyy-MM-dd HH:mm} — {rec.CreatedMachine}\n" +
                (rec.UpdateDate.HasValue
                    ? $"آخر تعديل: {rec.UpdateDate:yyyy-MM-dd HH:mm} — {rec.UpdateMachine}"
                    : "لم تُعدَّل بعد الإنشاء");

            XtraMessageBox.Show(text, $"بيانات مقارنة عروض الأسعار [{FormatNumber(rec.Num)}]",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string FormatNumber(int? num) => num.HasValue ? $"CMP{num.Value:D5}" : "جديد";

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

        public void OnProjectChanged() => LoadData();

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
