using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

namespace Etmam
{
    public partial class ucIssue : BaseUserControl
    {
        private readonly RepositoryItemComboBox _repoImportance = new RepositoryItemComboBox();

        protected System.ComponentModel.BindingList<DailyReportIssue> DataSource { get; set; } = new System.ComponentModel.BindingList<DailyReportIssue>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gvIssue == null || gridIssue == null) return;
            DesignSystem.ApplyProfessionalStyle(gvIssue);
            DesignSystem.HideAuditColumns(gvIssue);
            gridIssue.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gvIssue.KeyDown += StandardGridView_KeyDown;
        }

        protected void UpdateRecordCount()
        {
            if (barStaticItem1 != null)
            {
                barStaticItem1.Caption = $"عدد السجلات: {DataSource.Count}";
            }
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
            if (gvIssue == null) return;
            var row = gvIssue.GetFocusedRow() as DailyReportIssue;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gvIssue.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gvIssue == null) return;
                gvIssue.CloseEditor();
                gvIssue.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gvIssue.BeginUpdate();
                int startRowHandle       = gvIssue.FocusedRowHandle;
                bool startAtNewRow       = gvIssue.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gvIssue.FocusedColumn != null ? gvIssue.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gvIssue.DataRowCount || 
                        currentRowHandle < 0 || gvIssue.IsNewItemRow(currentRowHandle))
                    {
                        gvIssue.AddNewRow();
                        currentRowHandle = gvIssue.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gvIssue.VisibleColumns.Count)
                        {
                            var col = gvIssue.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gvIssue.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gvIssue.EndUpdate();
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
            var lastReport = DC.DailyReport.GetBy(
                "PrjId = @pId AND ReportDate < @rDate AND IsDelete = 0 ORDER BY ReportDate DESC",
                new { pId = CurrentProjectId, rDate = CurrentReportDate }).FirstOrDefault();

            if (lastReport == null)
            {
                XtraMessageBox.Show("لا يوجد تقرير سابق لنسخ البيانات منه لهذا المشروع.", "تنبهم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public override int CopyFromPrevious(int lastReportId)
        {
            if (lastReportId == 0) return 0;
            var previousItems = DC.GetHelper<DailyReportIssue>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new DailyReportIssue();
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

        protected virtual bool CopyFilter(DailyReportIssue item) => true;

        protected virtual void MapForCopy(DailyReportIssue source, DailyReportIssue destination)
        {
            var props = typeof(DailyReportIssue).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId)
        {
            var helper = DC.GetHelper<DailyReportIssue>();
            foreach (var id in GetDeletedIds()) helper.Delete(id);
            ClearDeletedIds();

            foreach (var item in DataSource)
            {
                item.DailyReportId = dailyReportId;
                if (item.Id == 0)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy = Session.CurrentUser?.Id ?? 0;
                    helper.Add(item);
                }
                else
                {
                    item.UpdateDate = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy = Session.CurrentUser?.Id ?? 0;
                    helper.Edit(item.Id, item);
                }
            }
        }

        public override void LoadData()
        {
            if (CurrentDailyReportId == 0) return;
            var list = DC.GetHelper<DailyReportIssue>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = CurrentDailyReportId });
            DataSource = new System.ComponentModel.BindingList<DailyReportIssue>(list);
            InitializeBaseGrid();
        }

        public ucIssue()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            DesignSystem.ApplyGridStyle(gridIssue, gvIssue);
            InitializeBaseGrid();

            // Toolbar events
            bbiAdd.ItemClick    += (s, e) => { gvIssue.AddNewRow(); };
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiCopy.ItemClick   += (s, e) => HandleToolbarCopy();
            gvIssue.InitNewRow += GvIssue_InitNewRow;

            ConfigureImportanceEditor();
            LoadData();
            FormatGrid();
        }

        private void ConfigureImportanceEditor()
        {
            _repoImportance.Items.Clear();
            _repoImportance.Items.AddRange(new object[] { "منخفضة", "متوسطة", "مرتفعة" });
            _repoImportance.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (!gridIssue.RepositoryItems.Contains(_repoImportance))
            {
                gridIssue.RepositoryItems.Add(_repoImportance);
            }
        }

        private void GvIssue_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gvIssue.SetRowCellValue(e.RowHandle, nameof(DailyReportIssue.Importance), "متوسطة");
        }

        private void FormatGrid()
        {
            gvIssue.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            var colItem = gvIssue.Columns[nameof(DailyReportIssue.Item)];
            if (colItem != null)
            {
                colItem.Caption = "البند";
                colItem.VisibleIndex = 0;
                colItem.Width = 250;
            }

            var colDesc = gvIssue.Columns[nameof(DailyReportIssue.Description)];
            if (colDesc != null) 
            {
                colDesc.Caption = "الوصف";
                colDesc.VisibleIndex = 1;
                colDesc.Width = 250;
            }

            var colRec = gvIssue.Columns[nameof(DailyReportIssue.Recommendation)];
            if (colRec != null)
            {
                colRec.Caption = "التوصيات";
                colRec.VisibleIndex = 2;
                colRec.Width = 250;
            }

            var colNote = gvIssue.Columns[nameof(DailyReportIssue.Note)];
            if (colNote != null)
            {
                colNote.Caption = "المخاطر/ الملاحظات";
                colNote.VisibleIndex = 3;
                colNote.Width = 250;
            }

            var colImp = gvIssue.Columns[nameof(DailyReportIssue.Importance)];
            if (colImp != null)
            {
                colImp.Caption = "درجة الأهمية";
                colImp.VisibleIndex = 4;
                colImp.ColumnEdit = _repoImportance;
                colImp.Width = 120;
            }
        }

        // ─── Standardization Overrides ─────────────────────────────────────

        protected virtual Func<DailyReportIssue, DailyReportIssue, bool> GetDuplicatePredicate() 
            => (a, b) => (a.Item ?? string.Empty) == (b.Item ?? string.Empty) 
                      && (a.Description ?? string.Empty) == (b.Description ?? string.Empty);
    }
}
