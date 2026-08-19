using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    public partial class ucDailyStaff : BaseUserControl
    {
        protected System.ComponentModel.BindingList<DailyReportManpower> DataSource { get; set; } = new System.ComponentModel.BindingList<DailyReportManpower>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gvStaff == null || gridStaff == null) return;
            DesignSystem.ApplyProfessionalStyle(gvStaff);
            DesignSystem.HideAuditColumns(gvStaff);
            gridStaff.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gvStaff.KeyDown += StandardGridView_KeyDown;
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
            if (gvStaff == null) return;
            var row = gvStaff.GetFocusedRow() as DailyReportManpower;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gvStaff.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gvStaff == null) return;
                gvStaff.CloseEditor();
                gvStaff.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gvStaff.BeginUpdate();
                int startRowHandle       = gvStaff.FocusedRowHandle;
                bool startAtNewRow       = gvStaff.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gvStaff.FocusedColumn != null ? gvStaff.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gvStaff.DataRowCount || 
                        currentRowHandle < 0 || gvStaff.IsNewItemRow(currentRowHandle))
                    {
                        gvStaff.AddNewRow();
                        currentRowHandle = gvStaff.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gvStaff.VisibleColumns.Count)
                        {
                            var col = gvStaff.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gvStaff.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gvStaff.EndUpdate();
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
            var previousItems = DC.GetHelper<DailyReportManpower>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new DailyReportManpower();
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

        protected virtual void MapForCopy(DailyReportManpower source, DailyReportManpower destination)
        {
            var props = typeof(DailyReportManpower).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId, SqlTransaction? transaction = null)
        {
            var helper = DC.GetHelper<DailyReportManpower>();
            var deletedIds = GetDeletedIds();
            if (deletedIds.Count > 0) helper.DeleteRange(deletedIds, transaction);
            ClearDeletedIds();

            var toAdd = new List<DailyReportManpower>();
            var toEdit = new List<DailyReportManpower>();
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

        private string _category = "الطاقم الفني";
        private List<ManpowerList> _allManpower = new List<ManpowerList>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Category { get; set; } = "Staff";

        private RepositoryItemLookUpEdit? _filteredRepoManpower;

        public ucDailyStaff()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);

            // Map English categories from frmDailyReport to DB Arabic strings
            if (Category == "Staff") _category = "الطاقم الفني";
            else if (Category == "Labor") _category = "العمالة";
            else _category = Category;

            groupControl1.Text = _category;

            DesignSystem.ApplyGridStyle(gridStaff, gvStaff);
            InitializeBaseGrid();

            // Toolbar events
            bbiAdd.ItemClick += (s, e) => AddStaff();
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiCopy.ItemClick += (s, e) => HandleToolbarCopy();

            gvStaff.CustomRowCellEditForEditing += GvStaff_CustomRowCellEditForEditing;
            gvStaff.CellValueChanged += GvStaff_CellValueChanged;
            gvStaff.InitNewRow += GvStaff_InitNewRow;

            LoadLookups();
            LoadData();
            FormatGrid();
        }

        public override void LoadData()
        {
            var handle = ShowOverlay();
            try
            {
                DataSource.Clear();
                if (CurrentDailyReportId == 0)
                {
                    UpdateRecordCount();
                    return;
                }

                var helper = DC.DailyReportManpower;
                var data = helper.GetBy(
                    "DailyReportId = @drId AND IsDelete = 0 AND ManpowerListId IN (SELECT Id FROM ManpowerList WHERE Category = @cat AND IsDelete = 0)",
                    new { drId = CurrentDailyReportId, cat = _category });

                foreach (var item in data)
                {
                    DataSource.Add(item);
                }

                UpdateRecordCount();
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void LoadLookups()
        {
            _allManpower = DC.ManpowerList.GetBy("Category = @cat AND IsDelete = 0", new { cat = _category }).ToList();
            repoManpower.DataSource = _allManpower;
            repoManpower.DisplayMember = nameof(ManpowerList.Name);
            repoManpower.ValueMember = nameof(ManpowerList.Id);
            repoManpower.PopulateColumns();
            foreach (LookUpColumnInfo col in repoManpower.Columns) col.Visible = col.FieldName == nameof(ManpowerList.Name);
            repoManpower.Columns[nameof(ManpowerList.Name)].Caption = "المسمى الوظيفي";
        }

        private void GvStaff_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gvStaff.SetRowCellValue(e.RowHandle, nameof(DailyReportManpower.Qty), 1);
        }

        private void GvStaff_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != nameof(DailyReportManpower.ManpowerListId)) return;

            var currentRow = gvStaff.GetRow(e.RowHandle) as DailyReportManpower;
            var currentManpowerId = currentRow?.ManpowerListId ?? 0;

            var selectedIds = DataSource
                .Where(x => x.ManpowerListId > 0 && x != currentRow)
                .Select(x => x.ManpowerListId)
                .ToHashSet();

            var filteredManpower = _allManpower
                .Where(x => !selectedIds.Contains(x.Id) || x.Id == currentManpowerId)
                .ToList();

            if (_filteredRepoManpower == null)
            {
                _filteredRepoManpower = new RepositoryItemLookUpEdit
                {
                    DisplayMember = nameof(ManpowerList.Name),
                    ValueMember = nameof(ManpowerList.Id),
                    NullText = ""
                };
                _filteredRepoManpower.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
                _filteredRepoManpower.Columns.Add(new LookUpColumnInfo(nameof(ManpowerList.Name), "المسمى الوظيفي"));
                gridStaff.RepositoryItems.Add(_filteredRepoManpower);
            }

            _filteredRepoManpower.DataSource = filteredManpower;
            e.RepositoryItem = _filteredRepoManpower;
        }

        private void GvStaff_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != nameof(DailyReportManpower.ManpowerListId)) return;

            var newValue = e.Value == null ? 0 : Convert.ToInt32(e.Value);
            if (newValue <= 0) return;

            bool exists = DataSource.Any(x => x.ManpowerListId == newValue && x != gvStaff.GetRow(e.RowHandle));
            if (exists)
            {
                XtraMessageBox.Show("تم اختيار هذا المسمى مسبقاً، يرجى اختيار مسمى آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gvStaff.SetRowCellValue(e.RowHandle, e.Column, 0);
                return;
            }

            var qtyValue = gvStaff.GetRowCellValue(e.RowHandle, nameof(DailyReportManpower.Qty));
            if (qtyValue == null || qtyValue == DBNull.Value || !int.TryParse(qtyValue.ToString(), out var qty) || qty <= 0)
            {
                gvStaff.SetRowCellValue(e.RowHandle, nameof(DailyReportManpower.Qty), 1);
            }
        }

        private void AddStaff()
        {
            var existingIds = DataSource.Select(d => d.ManpowerListId).ToList();

            using (frmManpower frm = new frmManpower { IsSelectionMode = true, FilterCategory = _category, ExcludedIds = existingIds })
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadLookups();

                    foreach (var staff in frm.SelectedItems)
                    {
                        if (DataSource.Any(d => d.ManpowerListId == staff.Id)) continue;

                        DataSource.Add(new DailyReportManpower
                        {
                            DailyReportId = CurrentDailyReportId,
                            ManpowerListId = staff.Id,
                            Qty = 1
                        });
                    }

                    gvStaff.RefreshData();
                    OnDataChanged();
                    UpdateRecordCount();
                }
            }
        }

        // ─── Standardization Overrides ─────────────────────────────────────
 
        protected Func<DailyReportManpower, DailyReportManpower, bool> GetDuplicatePredicate() 
            => (a, b) => a.ManpowerListId == b.ManpowerListId;
 
        protected bool CopyFilter(DailyReportManpower item)
        {
            var manpowerList = DC.ManpowerList.GetBy("Category = @cat AND IsDelete = 0", new { cat = _category });
            return manpowerList.Any(m => m.Id == item.ManpowerListId);
        }

        private void FormatGrid()
        {
            gvStaff.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            
            if (gvStaff.Columns[nameof(DailyReportManpower.ManpowerListId)] != null)
            {
                gvStaff.Columns[nameof(DailyReportManpower.ManpowerListId)].ColumnEdit = repoManpower;
                gvStaff.Columns[nameof(DailyReportManpower.ManpowerListId)].Width = 250;
            }

            if (gvStaff.Columns[nameof(DailyReportManpower.Qty)] != null)
            {
                gvStaff.Columns[nameof(DailyReportManpower.Qty)].Width = 80;
                DesignSystem.SetColumnCentered(gvStaff.Columns[nameof(DailyReportManpower.Qty)]);
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
