using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Core;
using Data;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>
    /// A specialized grid control for a specific category of Daily Work Done.
    /// </summary>
    public partial class ucWorkDoneCategoryGrid : BaseUserControl
    {
        protected System.ComponentModel.BindingList<DailyReportWorkDone> DataSource { get; set; } = new System.ComponentModel.BindingList<DailyReportWorkDone>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gvMain == null || gridMain == null) return;
            DesignSystem.ApplyProfessionalStyle(gvMain);
            DesignSystem.HideAuditColumns(gvMain);
            gridMain.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gvMain.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
            // This control doesn't have a status bar, so this is a no-op but kept for consistency
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
            if (gvMain == null) return;
            var row = gvMain.GetFocusedRow() as DailyReportWorkDone;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gvMain.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gvMain == null) return;
                gvMain.CloseEditor();
                gvMain.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gvMain.BeginUpdate();
                int startRowHandle       = gvMain.FocusedRowHandle;
                bool startAtNewRow       = gvMain.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gvMain.FocusedColumn != null ? gvMain.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gvMain.DataRowCount || 
                        currentRowHandle < 0 || gvMain.IsNewItemRow(currentRowHandle))
                    {
                        gvMain.AddNewRow();
                        currentRowHandle = gvMain.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gvMain.VisibleColumns.Count)
                        {
                            var col = gvMain.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gvMain.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gvMain.EndUpdate();
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
            var previousItems = DC.GetHelper<DailyReportWorkDone>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new DailyReportWorkDone();
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

        protected virtual void MapForCopy(DailyReportWorkDone source, DailyReportWorkDone destination)
        {
            var props = typeof(DailyReportWorkDone).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId, SqlTransaction? transaction = null)
        {
            var helper = DC.GetHelper<DailyReportWorkDone>();
            var deletedIds = GetDeletedIds();
            if (deletedIds.Count > 0) helper.DeleteRange(deletedIds, transaction);
            ClearDeletedIds();

            var toAdd = new List<DailyReportWorkDone>();
            var toEdit = new List<DailyReportWorkDone>();
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
                var list = DC.GetHelper<DailyReportWorkDone>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = CurrentDailyReportId });
                DataSource = new System.ComponentModel.BindingList<DailyReportWorkDone>(list);
                InitializeBaseGrid();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private string _category = string.Empty;
        private Dictionary<int, ActivityList> _activityCache = new Dictionary<int, ActivityList>();

        public ucWorkDoneCategoryGrid()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public void Initialize(string category, Dictionary<int, ActivityList> activityCache, int dailyReportId, int projectId, DateTime reportDate)
        {
            _category = category;
            _activityCache = activityCache;
            base.Initialize(dailyReportId, projectId, reportDate);
            
            DesignSystem.ApplyGridStyle(gridMain, gvMain);
            InitializeBaseGrid();
            SetupWorkDoneColumns();
        }

        private void SetupWorkDoneColumns()
        {
            // Add unbound columns for activity details
            AddUnboundColumn("colItem",         "البند/ النشاط",       0, 180);
            AddUnboundColumn("colLocation",     "موقع الأعمال",      1, 150);
            AddUnboundColumn("colDescription",  "وصف النشاط",        2, 300);
            
            if (gvMain.Columns["Qty"] != null)
            {
                gvMain.Columns["Qty"].VisibleIndex = 3;
                gvMain.Columns["Qty"].Width = 100;
            }

            if (gvMain.Columns["AcumQty"] != null)
            {
                gvMain.Columns["AcumQty"].VisibleIndex = 4;
                gvMain.Columns["AcumQty"].Width = 80;
            }

            gvMain.CustomUnboundColumnData += GvMain_CustomUnboundColumnData;
            gvMain.DoubleClick += GvMain_DoubleClick;
            
            // Apply category-specific coloring to focused row if needed
            // (The parent will handle the tab colors, here we just ensure basic professional style)
        }

        private void AddUnboundColumn(string fieldName, string caption, int visibleIndex, int width)
        {
            if (gvMain.Columns[fieldName] != null) return;
            var col = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = fieldName,
                Caption = caption,
                UnboundType = DevExpress.Data.UnboundColumnType.String,
                VisibleIndex = visibleIndex,
                Width = width,
                OptionsColumn = { AllowEdit = false, ReadOnly = true }
            };
            DesignSystem.SetColumnCentered(col);
            gvMain.Columns.Add(col);
        }

        private void GvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (!e.IsGetData) return;
            var row = e.Row as DailyReportWorkDone;
            if (row == null || row.ActivityId == null) return;

            if (_activityCache.TryGetValue(row.ActivityId.Value, out var act))
            {
                e.Value = e.Column.FieldName switch
                {
                    "colItem" => act.Item,
                    "colLocation" => act.Location,
                    "colDescription" => act.Description,
                    _ => null
                };
            }
        }

        private void GvMain_DoubleClick(object sender, EventArgs e)
        {
            var pt = gridMain.PointToClient(Control.MousePosition);
            var info = gvMain.CalcHitInfo(pt);
            if (info.InRow && !info.InColumnPanel)
            {
                EditFocusedRow();
            }
        }

        public void EditFocusedRow()
        {
            var row = gvMain.GetFocusedRow() as DailyReportWorkDone;
            if (row == null) return;

            var handle = ShowOverlay();
            frmWorkDoneAddEdit frm;
            try { frm = new frmWorkDoneAddEdit(row); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gvMain.RefreshData();
                    OnDataChanged();
                }
            }
        }

        public void AddActivities(List<ActivityList> activities)
        {
            bool added = false;
            foreach (var act in activities)
            {
                if (DataSource.Any(x => x.ActivityId == act.Id)) continue;

                DataSource.Add(new DailyReportWorkDone
                {
                    DailyReportId = CurrentDailyReportId,
                    ActivityId = act.Id,
                    Qty = 0
                });
                added = true;
            }

            if (added)
            {
                gvMain.RefreshData();
                OnDataChanged();
            }
        }

        public BindingList<DailyReportWorkDone> GetItems() => DataSource;

        public void Clear() => DataSource.Clear();
        
        public void AddRange(IEnumerable<DailyReportWorkDone> items)
        {
            foreach(var item in items) DataSource.Add(item);
        }

        // ─── Standardization Overrides ─────────────────────────────────────

        protected virtual Func<DailyReportWorkDone, DailyReportWorkDone, bool> GetDuplicatePredicate() 
            => (a, b) => a.ActivityId == b.ActivityId;

        protected virtual bool CopyFilter(DailyReportWorkDone item)
        {
            if (item.ActivityId.HasValue && _activityCache.TryGetValue(item.ActivityId.Value, out var act))
            {
                // Simple equality check, handling nulls
                return (act.Category ?? string.Empty) == (_category ?? string.Empty);
            }
            // If no activity info, only "Other" category or empty category should take it
            return string.IsNullOrEmpty(_category) || _category == "Other";
        }

        // ─── مؤشر الانتظار ──────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
