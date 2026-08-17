using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Etmam
{
    /// <summary>List/grid screen for Purchase Requests: filter by project, bulk status actions, export.</summary>
    public partial class ucPurchaseRequests : DevExpress.XtraEditors.XtraUserControl
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext DB => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private List<PurchaseRequestList> _allRecords = new();

        // ── Constructor ───────────────────────────────────────────────────────
        public ucPurchaseRequests()
        {
            InitializeComponent();
            if (DesignMode) return;

            DesignSystem.ApplyCairoFont(this);
            SetupLookups();
            SetupGrid();

            this.Load += (s, e) => LoadData();
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void SetupLookups()
        {
            // فلتر المشروع
            var projects = DB.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.DataSource    = projects;
            lookUpEditPrj.Properties.ValueMember   = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText      = "-- الكل --";

            // عند تغيير المشروع → إعادة تحميل
            lookUpEditPrj.EditValueChanged += (s, e) => LoadData();

            // تعيين المشروع الحالي كقيمة افتراضية
            lookUpEditPrj.EditValue = Session.SelectedProjectId;

            // عمود المخزن في الشبكة (Lookup)
            repositoryItemLookUpEditStore.DataSource    = DB.StoreList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditStore.ValueMember   = "Id";
            repositoryItemLookUpEditStore.DisplayMember = "Name";

            // عمود المشروع في الشبكة (Lookup)
            repositoryItemLookUpEditProject.DataSource    = projects;
            repositoryItemLookUpEditProject.ValueMember   = "Id";
            repositoryItemLookUpEditProject.DisplayMember = "Name";

            // عمود مركز التكلفة في الشبكة (Lookup)
            repositoryItemLookUpEditCC.DataSource    = DB.CostCenterList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCC.ValueMember   = "Id";
            repositoryItemLookUpEditCC.DisplayMember = "Name";
        }

        private void SetupGrid()
        {
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            DesignSystem.ApplyStatusColoring(gridView1, "Status");

            gridView1.OptionsView.ShowAutoFilterRow = false;
            gridView1.OptionsBehavior.Editable = false;         // للقراءة فقط
            gridView1.OptionsSelection.MultiSelect = true;

            // عند النقر المزدوج → فتح نموذج التعديل
            gridView1.DoubleClick += (s, e) => EditSelectedRecord();

            // تحديث حالة الأزرار عند تغيير الصف
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadData()
        {
            try
            {
                string filter = "IsDelete = 0";
                var prjId = lookUpEditPrj.EditValue;

                if (prjId != null && prjId != DBNull.Value)
                    filter += " AND PrjId = @PrjId";

                _allRecords = DB.PurchaseRequestList.GetBy(filter, new { PrjId = prjId })
                                .OrderByDescending(r => r.RequestDate)
                                .ThenByDescending(r => r.Id)
                                .ToList();

                gridControl1.DataSource = _allRecords;

                UpdateStatusBar();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء تحميل البيانات:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Toolbar Button Handlers ───────────────────────────────────────────
        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenAddEdit(0);

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => EditSelectedRecord();

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => DeleteSelectedRecords();

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => PrintGrid();

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => LoadData();

        private void bbiAction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => ShowBulkActionMenu();

        // ── Record Operations ─────────────────────────────────────────────────
        private void OpenAddEdit(int prId)
        {
            var frm = new frmPurchaseRequestAddEdit();
            if (prId > 0) frm.OpenForEdit(prId);
            frm.FormClosed += (s, e) => LoadData();   // تحديث القائمة بعد الإغلاق
            frm.ShowDialog(this);
        }

        private void EditSelectedRecord()
        {
            int id = GetFocusedId();
            if (id <= 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenAddEdit(id);
        }

        private void DeleteSelectedRecords()
        {
            var selectedIds = GetSelectedIds();
            if (selectedIds.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل واحد على الأقل للحذف.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // منع حذف الطلبات المعتمدة أو المحوّلة لأمر شراء
            var locked = _allRecords
                .Where(r => selectedIds.Contains(r.Id) &&
                            (r.OverallStatus == PurchaseRequestStatus.Approved || r.OverallStatus == PurchaseRequestStatus.ConvertedToPO))
                .Select(r => r.Num)
                .ToList();

            if (locked.Any())
            {
                XtraMessageBox.Show(
                    $"لا يمكن حذف الطلبات التالية (معتمدة أو محوّلة لأمر شراء):\n{string.Join(", ", locked)}",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = selectedIds.Count == 1
                ? "هل أنت متأكد من حذف طلب الشراء المحدد؟"
                : $"هل أنت متأكد من حذف {selectedIds.Count} طلبات شراء؟";

            if (XtraMessageBox.Show(msg, "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int successCount = 0;
            foreach (var id in selectedIds)
            {
                try
                {
                    DB.DeletePurchaseRequest(id);
                    successCount++;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ عند حذف طلب #{id}:\n{ex.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (successCount > 0)
            {
                XtraMessageBox.Show($"تم حذف {successCount} طلبات بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void PrintGrid()
        {
            try
            {
                gridControl1.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الطباعة:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Bulk Actions ──────────────────────────────────────────────────────
        private void ShowBulkActionMenu()
        {
            var selectedIds = GetSelectedIds();
            if (selectedIds.Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد سجل واحد على الأقل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var menu = new ContextMenuStrip();
            menu.RightToLeft = RightToLeft.Yes;
            menu.Font = DesignSystem.Fonts.Regular(9);

            menu.Items.Add($"📤 إرسال {selectedIds.Count} طلبات للاعتماد", null,
                (s, e) => BulkChangeStatus(selectedIds, PurchaseRequestStatus.PendingApproval));

            if (PurchaseRequestPermissions.CanApprove(DB))
            {
                menu.Items.Add($"✅ اعتماد {selectedIds.Count} طلبات", null,
                    (s, e) => BulkChangeStatus(selectedIds, PurchaseRequestStatus.Approved));
                menu.Items.Add($"❌ رفض {selectedIds.Count} طلبات", null,
                    (s, e) => BulkChangeStatus(selectedIds, PurchaseRequestStatus.Rejected));
            }

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("📊 تصدير إلى Excel", null,
                (s, e) => ExportToExcel());

            menu.Show(Cursor.Position);
        }

        private void BulkChangeStatus(List<int> ids, string newStatus)
        {
            bool isApprovalDecision = newStatus == PurchaseRequestStatus.Approved || newStatus == PurchaseRequestStatus.Rejected;
            if (isApprovalDecision && !PurchaseRequestPermissions.CanApprove(DB))
            {
                XtraMessageBox.Show("ليس لديك صلاحية اعتماد أو رفض طلبات الشراء.", "غير مصرّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusAr = PurchaseRequestStatus.ToDisplay(newStatus);
            if (XtraMessageBox.Show(
                $"هل تريد تغيير حالة {ids.Count} طلبات إلى [{statusAr}]؟",
                "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int done = 0;
            foreach (var id in ids)
            {
                try
                {
                    var pr = DB.PurchaseRequestList.Find(id);
                    if (pr == null) continue;

                    pr.OverallStatus        = newStatus;
                    pr.UpdateDate    = DateTime.Now;
                    pr.UpdateMachine = Session.Machine;
                    pr.UpdateBy      = Session.CurrentUser?.Id ?? 1;

                    if (newStatus == PurchaseRequestStatus.Approved)
                    {
                        pr.ApprovedBy   = Session.CurrentUser?.Id ?? 1;
                        pr.ApprovedDate = DateTime.Now;
                    }

                    DB.PurchaseRequestList.Edit(id, pr);
                    done++;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ عند تحديث طلب #{id}:\n{ex.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (done > 0)
            {
                XtraMessageBox.Show($"✓ تم تغيير حالة {done} طلبات إلى [{statusAr}]", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void ExportToExcel()
        {
            using var dlg = new SaveFileDialog
            {
                Filter      = "Excel Files|*.xlsx",
                FileName    = $"طلبات_الشراء_{DateTime.Today:yyyy-MM-dd}.xlsx",
                DefaultExt  = "xlsx"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                gridControl1.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetFocusedId()
        {
            var row = gridView1.GetFocusedRow() as PurchaseRequestList;
            return row?.Id ?? 0;
        }

        private List<int> GetSelectedIds()
        {
            var ids = new List<int>();

            var selectedHandles = gridView1.GetSelectedRows();
            if (selectedHandles != null && selectedHandles.Length > 0)
            {
                foreach (int h in selectedHandles)
                {
                    if (gridView1.GetRow(h) is PurchaseRequestList pr)
                        ids.Add(pr.Id);
                }
            }
            else
            {
                // Fall back to the focused row when nothing is multi-selected
                int id = GetFocusedId();
                if (id > 0) ids.Add(id);
            }

            return ids;
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && _allRecords.Count > 0;
            bbiEdit.Enabled   = hasSelection;
            bbiDelete.Enabled = hasSelection;
            bbiPrint.Enabled  = _allRecords.Count > 0;
        }

        private void UpdateStatusBar()
        {
            bar3.Text = $"إجمالي الطلبات: {_allRecords.Count}  |  " +
                        $"قيد الاعتماد: {_allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.PendingApproval)}  |  " +
                        $"معتمد: {_allRecords.Count(r => r.OverallStatus == PurchaseRequestStatus.Approved)}";
        }
    }
}
