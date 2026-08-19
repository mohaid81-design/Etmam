using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    public partial class ucDisruptedActivity : BaseUserControl
    {
        protected System.ComponentModel.BindingList<DailyReportDisruptedActivity> DataSource { get; set; } = new System.ComponentModel.BindingList<DailyReportDisruptedActivity>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gvDisrupted == null || gridDisrupted == null) return;
            DesignSystem.ApplyProfessionalStyle(gvDisrupted);
            DesignSystem.HideAuditColumns(gvDisrupted);
            gridDisrupted.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gvDisrupted.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
            if (barStaticItem1 != null)
                barStaticItem1.Caption = $"عدد السجلات : {DataSource.Count}";
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
            if (gvDisrupted == null) return;
            var row = gvDisrupted.GetFocusedRow() as DailyReportDisruptedActivity;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gvDisrupted.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gvDisrupted == null) return;
                gvDisrupted.CloseEditor();
                gvDisrupted.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gvDisrupted.BeginUpdate();
                int startRowHandle       = gvDisrupted.FocusedRowHandle;
                bool startAtNewRow       = gvDisrupted.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gvDisrupted.FocusedColumn != null ? gvDisrupted.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gvDisrupted.DataRowCount || 
                        currentRowHandle < 0 || gvDisrupted.IsNewItemRow(currentRowHandle))
                    {
                        gvDisrupted.AddNewRow();
                        currentRowHandle = gvDisrupted.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gvDisrupted.VisibleColumns.Count)
                        {
                            var col = gvDisrupted.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gvDisrupted.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gvDisrupted.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearDeletedIds() => DeletedIds.Clear();
        public System.Collections.Generic.List<int> GetDeletedIds() => DeletedIds;

        public virtual void HandleToolbarCopy()
        {
            if (CurrentProjectId == 0) return;

            var handle = ShowOverlay();
            try
            {
                var lastReport = DC.DailyReport.GetBy(
                    "PrjId = @pId AND ReportDate < @rDate AND IsDelete = 0 ORDER BY ReportDate DESC",
                    new { pId = CurrentProjectId, rDate = CurrentReportDate }).FirstOrDefault();

                if (lastReport == null)
                {
                    XtraMessageBox.Show("لا يوجد تقرير سابق لنسخ البيانات منه لهذا المشروع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int count = CopyFromPrevious(lastReport.Id);
                if (count > 0)
                {
                    XtraMessageBox.Show($"تم نسخ {count} سجلات بنجاح من تقرير يوم {lastReport.ReportDate:yyyy/MM/dd}.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("تم نسخ كافة البيانات المتاحة مسبقاً أو لا توجد بيانات جديدة للنسخ.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        public override int CopyFromPrevious(int lastReportId)
        {
            if (lastReportId == 0) return 0;
            var previousItems = DC.GetHelper<DailyReportDisruptedActivity>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new DailyReportDisruptedActivity();
                MapForCopy(prevItem, newItem);
                newItem.DailyReportId = CurrentDailyReportId;
                newItem.Id = 0;
                newItem.CreatedDate = DateTime.Now;
                newItem.CreatedMachine = Session.Machine;
                newItem.CreatedBy = Session.CurrentUser?.Id ?? 0;
                DataSource.Add(newItem);
                count++;
            }

            if (count > 0)
            {
                UpdateRecordCount();
                OnDataChanged();
            }
            return count;
        }

        protected virtual void MapForCopy(DailyReportDisruptedActivity source, DailyReportDisruptedActivity destination)
        {
            var props = typeof(DailyReportDisruptedActivity).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId, SqlTransaction? transaction = null)
        {
            var helper = DC.GetHelper<DailyReportDisruptedActivity>();
            var deletedIds = GetDeletedIds();
            if (deletedIds.Count > 0) helper.DeleteRange(deletedIds, transaction);
            ClearDeletedIds();

            var toAdd = new List<DailyReportDisruptedActivity>();
            var toEdit = new List<DailyReportDisruptedActivity>();
            foreach (var item in DataSource)
            {
                item.DailyReportId = dailyReportId;
                if (item.Id == 0)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy = Session.CurrentUser?.Id ?? 0;
                    toAdd.Add(item);
                }
                else
                {
                    item.UpdateDate = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy = Session.CurrentUser?.Id ?? 0;
                    toEdit.Add(item);
                }
            }
            if (toAdd.Count > 0) helper.AddRange(toAdd, transaction);
            if (toEdit.Count > 0) helper.EditRange(toEdit, transaction);
        }

        public override void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                if (CurrentDailyReportId == 0) return;
                var list = DC.GetHelper<DailyReportDisruptedActivity>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = CurrentDailyReportId });
                DataSource = new System.ComponentModel.BindingList<DailyReportDisruptedActivity>(list);
                InitializeBaseGrid();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        protected bool CopyFilter(DailyReportDisruptedActivity item) => true;

        public ucDisruptedActivity()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            DesignSystem.ApplyGridStyle(gridDisrupted, gvDisrupted);
            InitializeBaseGrid();

            // Toolbar events
            bbiAdd.ItemClick    += (s, e) => { gvDisrupted.AddNewRow(); };
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiCopy.ItemClick   += (s, e) => HandleToolbarCopy();

            LoadData();
            FormatGrid();
        }

        private void FormatGrid()
        {
            gvDisrupted.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            
            var colActivity = gvDisrupted.Columns[nameof(DailyReportDisruptedActivity.ActivityName)];
            if (colActivity != null)
            {
                colActivity.Caption = "البند/ وصف التعثر";
                colActivity.VisibleIndex = 0;
                colActivity.Width = 300;
            }

            var colReason = gvDisrupted.Columns[nameof(DailyReportDisruptedActivity.DisruptionReason)];
            if (colReason != null)
            {
                colReason.Caption = "سبب التعثر";
                colReason.VisibleIndex = 1;
                colReason.Width = 300;
            }

            var colImpact = gvDisrupted.Columns[nameof(DailyReportDisruptedActivity.Impact)];
            if (colImpact != null)
            {
                colImpact.Caption = "الأثر المتوقع";
                colImpact.VisibleIndex = 2;
                colImpact.Width = 200;
            }
        }

        // ─── Standardization Overrides ─────────────────────────────────────
 
        protected Func<DailyReportDisruptedActivity, DailyReportDisruptedActivity, bool> GetDuplicatePredicate()
            => (a, b) => (a.ActivityName ?? string.Empty) == (b.ActivityName ?? string.Empty)
                      && (a.DisruptionReason ?? string.Empty) == (b.DisruptionReason ?? string.Empty);

        // ─── مؤشر الانتظار ──────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
