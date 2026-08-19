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
    /// <summary>List/grid screen for Requests For Quotation ("طلب عرض سعر") — mirrors ucPurchaseOrder's
    /// structure/conventions. No approval workflow exists for this entity (see frmPriceQuotationAddEdit),
    /// so there are no bulk status actions and no locked-record delete guard.</summary>
    public partial class ucPriceQuotation : DevExpress.XtraEditors.XtraUserControl
    {
        private static DataContext DB => Data.DataContext.Shared;

        private List<PriceQuotationRequestList> _allRecords = new();
        private HashSet<int> _grantedProjectIds = new();

        private RepositoryItemLookUpEdit repositoryItemLookUpEditSupplierCol = null!;
        private RepositoryItemLookUpEdit repositoryItemLookUpEditPRCol = null!;
        private bool _canManage;

        public ucPriceQuotation()
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
            // نفس منطق صلاحيات المشاريع في ucPurchaseOrder — يُستخدم لاحقاً لتصفية السجلات المعروضة
            // بالمشاريع المصرَّح للمستخدم بالاطلاع عليها (لا يوجد فلتر مشروع منفصل في هذا الديزاينر).
            _grantedProjectIds = PermissionService.GrantedProjectIds(DB);

            repositoryItemLookUpEditProject.DataSource = DB.ProjectsList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditProject.ValueMember = "Id";
            repositoryItemLookUpEditProject.DisplayMember = "Name";
            colPrjId.ColumnEdit = repositoryItemLookUpEditProject;

            repositoryItemLookUpEditSupplierCol = new RepositoryItemLookUpEdit
            {
                DataSource = DB.StakeholdersList.GetBy("IsDelete = 0"),
                ValueMember = "Id",
                DisplayMember = "Name"
            };
            gridControl1.RepositoryItems.Add(repositoryItemLookUpEditSupplierCol);
            colStakeholderId.ColumnEdit = repositoryItemLookUpEditSupplierCol;

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

            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.DisplayFormat.FormatString = "n2";

            // خلفية أعمدة الأزرار (طباعة/إجراء/سجل) تتغيّر تلقائياً عند تركيز/تحديد الصف (سلوك DevExpress
            // الافتراضي)، فنفرض لون الصف الطبيعي (فردي/زوجي) عليها دائماً — نفس إصلاح ucPurchaseOrder.
            gridView1.Appearance.Row.BackColor = DesignSystem.Colors.Surface;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = DesignSystem.Colors.Background;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.RowCellStyle += GridView1_RowCellStyle;

            gridView1.DoubleClick += (s, e) => EditSelected();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();

            repositoryItemButtonEditPrint.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is PriceQuotationRequestList) PrintFocused();
            };

            repositoryItemButtonEditAction.ButtonClick += (s, e) =>
            {
                if (!_canManage) return;
                if (gridView1.GetFocusedRow() is PriceQuotationRequestList rec) OpenAddEdit(rec.Id);
            };

            repositoryItemButtonEditLog.ButtonClick += (s, e) =>
            {
                if (gridView1.GetFocusedRow() is PriceQuotationRequestList rec) ShowAuditInfo(rec);
            };
        }

        private void GridView1_RowCellStyle(object? sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colPrint && e.Column != colAction && e.Column != colLog) return;

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

                _allRecords = DB.PriceQuotationRequestList.GetBy(filter)
                    .OrderByDescending(r => r.RequestDate)
                    .ThenByDescending(r => r.Id)
                    .ToList();

                gridControl1.DataSource = _allRecords;
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل طلبات عروض الأسعار:\n{ex.Message}", "خطأ",
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
                XtraMessageBox.Show("ليس لديك صلاحية إدارة طلبات عروض الأسعار.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmPriceQuotationAddEdit frm;
            try { frm = new frmPriceQuotationAddEdit(id); }
            finally { CloseOverlay(handle); }
            using (frm)
            {
                if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadData();
            }
        }

        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as PriceQuotationRequestList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();
            var handles = gridView1.GetSelectedRows();
            if (handles != null && handles.Length > 0)
            {
                foreach (int h in handles)
                    if (gridView1.GetRow(h) is PriceQuotationRequestList rec) ids.Add(rec.Id);
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
                XtraMessageBox.Show("يرجى تحديد طلب عرض سعر أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedIds();
            if (ids.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد طلب عرض سعر واحد على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = ids.Count == 1
                ? "هل أنت متأكد من حذف طلب عرض السعر المحدد؟"
                : $"هل أنت متأكد من حذف {ids.Count} طلبات عروض أسعار؟";
            if (XtraMessageBox.Show(msg, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int done = 0;
            var handle = ShowOverlay();
            try
            {
                foreach (var id in ids)
                {
                    try { DB.DeletePriceQuotationRequest(id); done++; }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ عند حذف طلب #{id}:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally { CloseOverlay(handle); }

            if (done > 0)
            {
                XtraMessageBox.Show($"تم حذف {done} طلبات عروض أسعار بنجاح ✓", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>لا يوجد بعد تقرير طباعة مخصص لطلب عرض سعر واحد (انظر frmPriceQuotationAddEdit.PrintRecord) —
        /// نفس الرسالة تماماً حتى يُبنى التقرير لاحقاً.</summary>
        private void PrintFocused() =>
            XtraMessageBox.Show("طباعة طلب عرض السعر غير متاحة حالياً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>لا يوجد لهذا الكيان مسار اعتماد/Workflow (خلافاً لأمر الشراء)، فلا يوجد "سجل موافقات"
        /// فعلي لعرضه — يكتفى بعرض بيانات الإنشاء/آخر تعديل المخزَّنة أصلاً على السجل.</summary>
        private void ShowAuditInfo(PriceQuotationRequestList rec)
        {
            var supplierName = rec.StakeholderId is > 0
                ? DB.StakeholdersList.Find(rec.StakeholderId.Value)?.Name
                : null;

            var text =
                $"المورد: {supplierName ?? "—"}\n" +
                $"تاريخ الإنشاء: {rec.CreatedDate:yyyy-MM-dd HH:mm} — {rec.CreatedMachine}\n" +
                (rec.UpdateDate.HasValue
                    ? $"آخر تعديل: {rec.UpdateDate:yyyy-MM-dd HH:mm} — {rec.UpdateMachine}"
                    : "لم يُعدَّل بعد الإنشاء");

            XtraMessageBox.Show(text, $"بيانات طلب عرض السعر [{FormatNumber(rec.Num)}]",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string FormatNumber(int? num) => num.HasValue ? $"RFQ{num.Value:D5}" : "جديد";

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
