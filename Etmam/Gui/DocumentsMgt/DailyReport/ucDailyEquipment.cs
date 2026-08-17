using System;
using System.Collections.Generic;
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

namespace Etmam
{
    public partial class ucDailyEquipment : BaseUserControl
    {
        protected System.ComponentModel.BindingList<DailyReportEquipment> DataSource { get; set; } = new System.ComponentModel.BindingList<DailyReportEquipment>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected void InitializeBaseGrid()
        {
            if (gvEquipment == null || gridEquipment == null) return;
            DesignSystem.ApplyProfessionalStyle(gvEquipment);
            DesignSystem.HideAuditColumns(gvEquipment);
            gridEquipment.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            gvEquipment.KeyDown += StandardGridView_KeyDown;
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
            if (gvEquipment == null) return;
            var row = gvEquipment.GetFocusedRow() as DailyReportEquipment;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                gvEquipment.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (gvEquipment == null) return;
                gvEquipment.CloseEditor();
                gvEquipment.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gvEquipment.BeginUpdate();
                int startRowHandle       = gvEquipment.FocusedRowHandle;
                bool startAtNewRow       = gvEquipment.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gvEquipment.FocusedColumn != null ? gvEquipment.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gvEquipment.DataRowCount || 
                        currentRowHandle < 0 || gvEquipment.IsNewItemRow(currentRowHandle))
                    {
                        gvEquipment.AddNewRow();
                        currentRowHandle = gvEquipment.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gvEquipment.VisibleColumns.Count)
                        {
                            var col = gvEquipment.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gvEquipment.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gvEquipment.EndUpdate();
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

        public override void LoadData()
        {
            DataSource.Clear();
            if (CurrentDailyReportId == 0) return;
            var data = DC.GetHelper<DailyReportEquipment>().GetBy("DailyReportId = @drId AND IsDelete = 0", new { drId = CurrentDailyReportId });
            foreach (var item in data)
            {
                DataSource.Add(item);
            }
            UpdateRecordCount();
        }

        public virtual void HandleToolbarCopy()
        {
            if (CurrentProjectId == 0) return;
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

        public override int CopyFromPrevious(int lastReportId)
        {
            if (lastReportId == 0) return 0;
            var previousItems = DC.GetHelper<DailyReportEquipment>().GetBy("DailyReportId = @id AND IsDelete = 0", new { id = lastReportId });
            int count = 0;
            var duplicatePredicate = GetDuplicatePredicate();

            foreach (var prevItem in previousItems)
            {
                if (DataSource.Any(curr => duplicatePredicate(curr, prevItem))) continue;
                if (!CopyFilter(prevItem)) continue;

                var newItem = new DailyReportEquipment();
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

        protected virtual Func<DailyReportEquipment, DailyReportEquipment, bool> GetDuplicatePredicate() 
            => (a, b) => a.EquipmentListId == b.EquipmentListId;

        protected virtual bool CopyFilter(DailyReportEquipment item) => true;

        protected virtual void MapForCopy(DailyReportEquipment source, DailyReportEquipment destination)
        {
            var props = typeof(DailyReportEquipment).GetProperties().Where(p => p.CanWrite && p.CanRead);
            var skipList = new[] { "Id", "DailyReportId", "CreatedDate", "CreatedMachine", "CreatedBy", "UpdateDate", "UpdateMachine", "UpdateBy", "IsDelete", "DeletionDate", "DeletionMachine", "DeletionBy", "Created", "Update", "Deletion", "DailyReport" };
            foreach (var prop in props)
            {
                if (skipList.Contains(prop.Name)) continue;
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public override void SaveData(int dailyReportId)
        {
            var helper = DC.GetHelper<DailyReportEquipment>();
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

        private List<EquipmentList> _allEquipment = new List<EquipmentList>();
        private readonly RepositoryItemComboBox _repoStatus = new RepositoryItemComboBox();
        private readonly RepositoryItemLookUpEdit _filteredRepoEquipment = new RepositoryItemLookUpEdit();

        public ucDailyEquipment()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            DesignSystem.ApplyGridStyle(gridEquipment, gvEquipment);
            InitializeBaseGrid();

            // Toolbar events
            bbiAdd.ItemClick += (s, e) => AddEquipment();
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();
            bbiCopy.ItemClick += (s, e) => HandleToolbarCopy();

            gvEquipment.CustomRowCellEditForEditing += GvEquipment_CustomRowCellEditForEditing;
            gvEquipment.CellValueChanged += GvEquipment_CellValueChanged;
            gvEquipment.InitNewRow += GvEquipment_InitNewRow;

            LoadLookups();
            ConfigureStatusEditor();
            LoadData();
            FormatGrid();
        }

        private void LoadLookups()
        {
            _allEquipment = DC.EquipmentList.GetBy("IsDelete = 0").ToList();
            repoEquipment.DataSource = _allEquipment;
            repoEquipment.DisplayMember = nameof(EquipmentList.Name);
            repoEquipment.ValueMember = nameof(EquipmentList.Id);
            repoEquipment.PopulateColumns();
            foreach (LookUpColumnInfo col in repoEquipment.Columns) col.Visible = col.FieldName == nameof(EquipmentList.Name);
            repoEquipment.Columns[nameof(EquipmentList.Name)].Caption = "المعدة";

            // Initialize filtered editor
            _filteredRepoEquipment.Buttons.Clear();
            _filteredRepoEquipment.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            _filteredRepoEquipment.DisplayMember = nameof(EquipmentList.Name);
            _filteredRepoEquipment.ValueMember = nameof(EquipmentList.Id);
            _filteredRepoEquipment.NullText = "";
        }

        private void ConfigureStatusEditor()
        {
            _repoStatus.Items.Clear();
            _repoStatus.Items.AddRange(new object[] { "يعمل", "متوقف", "صيانة" });
            _repoStatus.TextEditStyle = TextEditStyles.DisableTextEditor;

            if (!gridEquipment.RepositoryItems.Contains(_repoStatus))
            {
                gridEquipment.RepositoryItems.Add(_repoStatus);
            }
        }

        private void GvEquipment_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gvEquipment.SetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Qty), 1);
            gvEquipment.SetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Status), "يعمل");
        }

        private void GvEquipment_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != nameof(DailyReportEquipment.EquipmentListId)) return;

            if (gvEquipment.GetRow(e.RowHandle) is not DailyReportEquipment currentRow) return;
            var currentEquipmentId = currentRow.EquipmentListId;

            var selectedIds = DataSource
                .Where(x => x.EquipmentListId > 0 && x != currentRow)
                .Select(x => x.EquipmentListId)
                .ToHashSet();

            var filteredEquipment = _allEquipment
                .Where(x => !selectedIds.Contains(x.Id) || x.Id == currentEquipmentId)
                .ToList();

            _filteredRepoEquipment.DataSource = filteredEquipment;
            _filteredRepoEquipment.PopulateColumns();
            foreach (LookUpColumnInfo col in _filteredRepoEquipment.Columns) 
                col.Visible = col.FieldName == nameof(EquipmentList.Name);
            
            if (_filteredRepoEquipment.Columns[nameof(EquipmentList.Name)] != null)
                _filteredRepoEquipment.Columns[nameof(EquipmentList.Name)].Caption = "المعدة";

            e.RepositoryItem = _filteredRepoEquipment;
        }

        private void GvEquipment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != nameof(DailyReportEquipment.EquipmentListId)) return;

            var newValue = e.Value == null ? 0 : Convert.ToInt32(e.Value);
            if (newValue > 0)
            {
                bool exists = DataSource.Any(x => x.EquipmentListId == newValue && x != gvEquipment.GetRow(e.RowHandle));
                if (exists)
                {
                    XtraMessageBox.Show("تم اختيار هذه المعدة مسبقاً، يرجى اختيار معدة أخرى.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gvEquipment.SetRowCellValue(e.RowHandle, e.Column, 0);
                    return;
                }

                var qtyValue = gvEquipment.GetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Qty));
                var statusValue = gvEquipment.GetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Status))?.ToString();

                if (qtyValue == null || qtyValue == DBNull.Value || !int.TryParse(qtyValue.ToString(), out var qty) || qty <= 0)
                {
                    gvEquipment.SetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Qty), 1);
                }

                if (string.IsNullOrWhiteSpace(statusValue))
                {
                    gvEquipment.SetRowCellValue(e.RowHandle, nameof(DailyReportEquipment.Status), "يعمل");
                }
            }
        }

        private void AddEquipment()
        {
            var existingIds = DataSource.Select(d => d.EquipmentListId).ToList();

            using (frmEquipment frm = new frmEquipment { IsSelectionMode = true, ExcludedIds = existingIds })
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // In case user added new equipment from frmEquipmentAddEdit,
                    // refresh lookup source so the selected IDs can resolve to names.
                    LoadLookups();

                    foreach (var equip in frm.SelectedItems)
                    {
                        if (DataSource.Any(d => d.EquipmentListId == equip.Id)) continue;

                        DataSource.Add(new DailyReportEquipment
                        {
                            DailyReportId = CurrentDailyReportId,
                            EquipmentListId = equip.Id,
                            Qty = 1,
                            Status = "يعمل"
                        });
                    }

                    gvEquipment.RefreshData();
                    OnDataChanged();
                    UpdateRecordCount();
                }
            }
        }

        private void FormatGrid()
        {
            gvEquipment.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            if (gvEquipment.Columns[nameof(DailyReportEquipment.EquipmentListId)] != null)
            {
                gvEquipment.Columns[nameof(DailyReportEquipment.EquipmentListId)].ColumnEdit = repoEquipment;
                gvEquipment.Columns[nameof(DailyReportEquipment.EquipmentListId)].VisibleIndex = 0;
                gvEquipment.Columns[nameof(DailyReportEquipment.EquipmentListId)].Width = 300;
            }

            if (gvEquipment.Columns[nameof(DailyReportEquipment.Qty)] != null)
            {
                gvEquipment.Columns[nameof(DailyReportEquipment.Qty)].VisibleIndex = 1;
                gvEquipment.Columns[nameof(DailyReportEquipment.Qty)].Width = 80;
                DesignSystem.SetColumnCentered(gvEquipment.Columns[nameof(DailyReportEquipment.Qty)]);
            }

            if (gvEquipment.Columns[nameof(DailyReportEquipment.Status)] != null)
            {
                gvEquipment.Columns[nameof(DailyReportEquipment.Status)].ColumnEdit = _repoStatus;
                gvEquipment.Columns[nameof(DailyReportEquipment.Status)].VisibleIndex = 2;
                gvEquipment.Columns[nameof(DailyReportEquipment.Status)].Width = 150;
            }
        }
    }
}
