using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraBars;
using Data;

namespace Etmam
{
    public partial class ucActivity : Etmam.BaseActivityGridControl
    {
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private GridHitInfo _downHitInfo = null;
        private bool _isInProgressMode = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilterCategory { get; set; }

        protected override GridControl MainGrid => gridControl1;
        protected override ColumnView MainView => gridView1;
        protected override BarStaticItem? StatusItem => barStaticItem1;

        public ucActivity()
        {
            InitializeComponent();
            DesignSystem.ApplyCairoFont(this);
        }

        public override void Initialize(int dailyReportId, int projectId, DateTime reportDate)
        {
            base.Initialize(dailyReportId, projectId, reportDate);
            InitializeBaseGrid();

            if (!_isInitialized)
            {
                DesignSystem.ApplyGridStyle(gridControl1, gridView1);
                SetupCategoryComboBox();
                SetupEvents();
                _isInitialized = true;
            }

            LoadData();
        }

        private void SetupEvents()
        {
            MainView.MouseDown += (s, e) => {
                _downHitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            };

            MainView.MouseMove += (s, e) => {
                if (e.Button == MouseButtons.Left && _downHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 2,
                        _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        object row = MainView.GetRow(_downHitInfo.RowHandle);
                        if (row != null)
                        {
                            object dragData = (row as DailyReportWorkDone)?.Activity ?? row;
                            MainGrid.DoDragDrop(dragData, DragDropEffects.Link);
                        }
                        _downHitInfo = null;
                    }
                }
            };

            gridView1.InitNewRow += (s, e) => {
                if (gridView1.GetRow(e.RowHandle) is ActivityList activity && !string.IsNullOrEmpty(FilterCategory))
                {
                    activity.Category = FilterCategory;
                }
            };
        }

        private void SetupCategoryComboBox()
        {
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemComboBox1.Items.AddRange(new object[] {
                "انشائي",
                "معماري",
                "ميكانيكا",
                "كهرباء",
                "اخرى"});
            repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.Add(repositoryItemComboBox1);
            if (colCategory != null) colCategory.ColumnEdit = repositoryItemComboBox1;
        }

        public virtual void LoadData()
        {
            _isInProgressMode = false;
            DataSource.Clear();
            
            IEnumerable<ActivityList> data = string.IsNullOrEmpty(FilterCategory)
                ? DC.ActivityList.GetAll()
                : DC.ActivityList.GetBy("Category = @Category", new { Category = FilterCategory });

            foreach (var item in data)
                DataSource.Add(item);
            
            MainGrid.DataSource = DataSource;

            // Restore standard column mappings using nameof for refactor-safety
            if (colItem != null) colItem.FieldName = nameof(ActivityList.Item);
            if (colDescription != null) colDescription.FieldName = nameof(ActivityList.Description);
            if (colLocation != null) colLocation.FieldName = nameof(ActivityList.Location);
            if (colCategory != null) colCategory.FieldName = nameof(ActivityList.Category);

            if (gridView1.Columns["Qty"] != null)
                gridView1.Columns["Qty"].Visible = false;

            UpdateRecordCount();
        }

        public void LoadInProgressActivities()
        {
            _isInProgressMode = true;
            
            var workDoneList = DC.DailyReportWorkDone.GetBy("Qty < 100 AND IsDelete = 0");
            var allActivities = DC.ActivityList.GetAll();

            foreach (var item in workDoneList)
                item.Activity = allActivities.FirstOrDefault(a => a.Id == item.ActivityId);

            // Update Grid Columns for nested binding
            if (colItem != null) colItem.FieldName = "Activity.Item";
            if (colDescription != null) colDescription.FieldName = "Activity.Description";
            if (colLocation != null) colLocation.FieldName = "Activity.Location";
            if (colCategory != null) colCategory.FieldName = "Activity.Category";

            var colQty = gridView1.Columns["Qty"];
            if (colQty == null)
            {
                colQty = gridView1.Columns.AddVisible("Qty", "النسبة %");
                colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                colQty.DisplayFormat.FormatString = "P0";
                colQty.OptionsColumn.AllowEdit = false;
                DesignSystem.SetColumnCentered(colQty);
            }
            else
            {
                colQty.Visible = true;
            }

            MainGrid.DataSource = new BindingList<DailyReportWorkDone>(workDoneList.ToList());
            
            if (StatusItem != null)
                StatusItem.Caption = $"أنشطة قيد التنفيذ: {workDoneList.Count()}";
        }

        protected override void UpdateRecordCount()
        {
            if (_isInProgressMode) return; // Handled in LoadInProgressActivities
            base.UpdateRecordCount();
        }
    }

    /// <summary>
    /// Intermediate non-generic base class to support Visual Studio Designer.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    public class BaseActivityGridControl : BaseUserControl
    {
        protected System.ComponentModel.BindingList<ActivityList> DataSource { get; set; } = new System.ComponentModel.BindingList<ActivityList>();
        protected System.Collections.Generic.List<int> DeletedIds { get; } = new System.Collections.Generic.List<int>();

        protected virtual DevExpress.XtraGrid.GridControl? MainGrid => null;
        protected virtual DevExpress.XtraGrid.Views.Base.ColumnView? MainView => null;
        protected virtual DevExpress.XtraBars.BarStaticItem? StatusItem => null;

        protected void InitializeBaseGrid()
        {
            if (MainView == null || MainGrid == null) return;
            if (MainView is DevExpress.XtraGrid.Views.Grid.GridView gv)
            {
                DesignSystem.ApplyProfessionalStyle(gv);
                DesignSystem.HideAuditColumns(gv);
            }
            MainGrid.DataSource = DataSource;
            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateRecordCount(); };
            MainView.KeyDown += StandardGridView_KeyDown;
        }

        protected virtual void UpdateRecordCount()
        {
            if (StatusItem != null)
                StatusItem.Caption = $"عدد السجلات : {DataSource.Count}";
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
            if (MainView == null) return;
            var row = MainView.GetFocusedRow() as ActivityList;
            if (row == null) return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0) DeletedIds.Add(row.Id);
                MainView.DeleteSelectedRows();
                OnDataChanged();
                UpdateRecordCount();
            }
        }

        public virtual void HandleManualPaste()
        {
            try
            {
                if (!(MainView is DevExpress.XtraGrid.Views.Grid.GridView gv)) return;
                gv.CloseEditor();
                gv.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gv.BeginUpdate();
                int startRowHandle       = gv.FocusedRowHandle;
                bool startAtNewRow       = gv.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gv.FocusedColumn != null ? gv.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gv.DataRowCount || 
                        currentRowHandle < 0 || gv.IsNewItemRow(currentRowHandle))
                    {
                        gv.AddNewRow();
                        currentRowHandle = gv.FocusedRowHandle;
                        startAtNewRow    = true;
                    }

                    string[] cellValues = lines[i].Split('\t');
                    for (int j = 0; j < cellValues.Length; j++)
                    {
                        int currentVisibleColIndex = startVisibleColIndex + j;
                        if (currentVisibleColIndex < gv.VisibleColumns.Count)
                        {
                            var col = gv.VisibleColumns[currentVisibleColIndex];
                            if (col.OptionsColumn.AllowEdit && !col.OptionsColumn.ReadOnly)
                                gv.SetRowCellValue(currentRowHandle, col, cellValues[j]);
                        }
                    }
                }
                gv.EndUpdate();
                OnDataChanged();
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
