using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using Core;
using Data;

namespace Etmam
{
    public partial class ucDailyReports : BaseUserControl
    {
        private bool _canManage;

        protected System.ComponentModel.BindingList<Core.DailyReport> DataSource { get; set; } = new System.ComponentModel.BindingList<Core.DailyReport>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gridView1 == null || gridControl1 == null) return;
            DesignSystem.ApplyProfessionalStyle(gridView1);
            DesignSystem.HideAuditColumns(gridView1);
            gridControl1.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gridView1.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
        }

        protected void StandardGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                ConfirmAndDeleteFocusedRow();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                HandleManualPaste();
                e.Handled = true;
            }
        }

        public virtual void ConfirmAndDeleteFocusedRow()
        {
            if (gridView1 == null) return;
            var row = gridView1.GetFocusedRow() as Core.DailyReport;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gridView1.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gridView1 == null) return;
                gridView1.CloseEditor();
                gridView1.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gridView1.BeginUpdate();
                int startRowHandle       = gridView1.FocusedRowHandle;
                bool startAtNewRow       = gridView1.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gridView1.FocusedColumn != null ? gridView1.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gridView1.DataRowCount || 
                        currentRowHandle < 0 || gridView1.IsNewItemRow(currentRowHandle))
                    {
                        gridView1.AddNewRow();
                        currentRowHandle = gridView1.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gridView1.VisibleColumns.Count)
                        {
                            var col = gridView1.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gridView1.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gridView1.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ucDailyReports()
        {
            InitializeComponent();
            if (DesignMode) return;

            _canManage = PermissionService.HasPermission(PermNames.DailyReport);
            bbiNew.Enabled = _canManage;
            bbiEdit.Enabled = _canManage;
            bbiDelete.Enabled = _canManage;
            bbiPrint.Enabled = _canManage;

            DesignSystem.ApplyCairoFont(this);
            gridView1.DoubleClick += GridView1_DoubleClick;
            this.Load += UcDailyReports_Load;
        }

        private async void UcDailyReports_Load(object? sender, EventArgs e)
        {
            if (IsSelectionMode)
            {
                bar1.Visible = false;
            }
            
            InitializeBaseGrid();
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            
            // Standardize column captions if not set in designer
            var colId = gridView1.Columns[nameof(Core.DailyReport.Id)];
            if (colId != null) colId.Visible = false;

            var colDate = gridView1.Columns[nameof(Core.DailyReport.ReportDate)];
            if (colDate != null)
            {
                colDate.Caption = "تاريخ التقرير";
                colDate.VisibleIndex = 0;
                colDate.Width = 120;
            }

            var colStatus = gridView1.Columns[nameof(Core.DailyReport.Status)];
            if (colStatus != null)
            {
                colStatus.Caption = "الحالة";
                colStatus.VisibleIndex = 1;
            }

            await LoadDataAsync();
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public bool IsSelectionMode { get; set; } = false;
        public event EventHandler<int>? OnReportSelected;

        private void GridView1_DoubleClick(object? sender, EventArgs e)
        {
            if (IsSelectionMode && gridView1.GetFocusedRow() is Core.DailyReport report)
            {
                OnReportSelected?.Invoke(this, report.Id);
            }
        }

        public async Task LoadDataAsync()
        {
            var handle = ShowOverlay();
            try
            {
                gridControl1.BeginUpdate();

                int prjId = CurrentProjectId > 0 ? CurrentProjectId : (Session.SelectedProjectId ?? 1);
                var data = await Task.Run(() => DC.DailyReport.GetBy("PrjId = @prjId AND IsDelete = 0 ORDER BY ReportDate DESC", new { prjId }));

                DataSource.Clear();
                foreach (var item in data) DataSource.Add(item);

                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridControl1.EndUpdate();
                CloseOverlay(handle);
            }
        }

        public override async void OnProjectChanged()
        {
            base.OnProjectChanged();
            await LoadDataAsync();
        }

        // كل نقاط الدخول (bbiNew/bbiEdit/bbiDelete) تتحقق من الصلاحية بنفسها لأن الشاشة لا تمر
        // بدالّة فتح موحّدة واحدة — النقر المزدوج في وضع الاختيار (IsSelectionMode) لا يفتح نموذج
        // تعديل فعلي (فقط يُرجع رقم التقرير)، لذا لا حاجة لحمايته.
        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التقرير اليومي (DR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            frmDailyReport frm;
            try { frm = new frmDailyReport(); }
            finally { CloseOverlay(handle); }
            frm.FormClosed += async (s, args) => await LoadDataAsync();
            frm.Show();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التقرير اليومي (DR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.GetFocusedRow() is Core.DailyReport report)
            {
                var handle = ShowOverlay();
                frmDailyReport frm;
                try { frm = new frmDailyReport(report.Id); }
                finally { CloseOverlay(handle); }
                frm.FormClosed += async (s, args) => await LoadDataAsync();
                frm.Show();
            }
        }

        private async void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canManage)
            {
                XtraMessageBox.Show("ليس لديك صلاحية إدارة التقرير اليومي (DR).", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridView1.GetFocusedRow() is Core.DailyReport report)
            {
                if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا التقرير؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Use centralized cascading delete
                    var handle = ShowOverlay();
                    try { DC.DeleteDailyReport(report.Id); }
                    finally { CloseOverlay(handle); }

                    await LoadDataAsync();
                }
            }
        }

        private async void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadDataAsync();
        }

        private async void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is Core.DailyReport report)
            {
                var handle = ShowOverlay();
                try { await DailyReportPrinter.PrintAsync(report.Id, this); }
                finally { CloseOverlay(handle); }
            }
            else
            {
                gridControl1.ShowPrintPreview();
            }
        }

        // ─── مؤشر الانتظار ──────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
