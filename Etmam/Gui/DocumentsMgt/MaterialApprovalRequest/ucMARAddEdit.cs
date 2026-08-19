using System.ComponentModel;
using Core;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    public partial class ucMARAddEdit : BaseUserControl
    {
        // ── State ─────────────────────────────────────────────────────────────
        private int _MARId = 0;
        protected BindingList<MaterialApprovalRequestDetails> DataSource { get; set; } = new BindingList<MaterialApprovalRequestDetails>();
        protected List<int> DeletedIds { get; } = new List<int>();

        // ── Constructor ───────────────────────────────────────────────────────
        public ucMARAddEdit()
        {
            InitializeComponent();
            if (DesignMode) return;

            DesignSystem.ApplyCairoFont(this);
            WireEvents();
            FormatGrid();
        }

        // ── Public API ────────────────────────────────────────────────────────
        public void LoadForMAR(int MARId)
        {
            _MARId = MARId;
            DeletedIds.Clear();

            List<MaterialApprovalRequestDetails> list;
            if (_MARId <= 0)
            {
                list = new List<MaterialApprovalRequestDetails>();
            }
            else
            {
                try
                {
                    list = DC.GetHelper<MaterialApprovalRequestDetails>()
                        .GetBy("MARId = @id AND IsDelete = 0", new { id = _MARId })
                        .ToList();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ في تحميل تفاصيل طلب اعتماد المواد:\n{ex.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    list = new List<MaterialApprovalRequestDetails>();
                }
            }

            DataSource = new BindingList<MaterialApprovalRequestDetails>(list);
            gridControl1.DataSource = DataSource;

            DataSource.ListChanged += (s, e) => { OnDataChanged(); UpdateCount(); };

            UpdateCount();
            UpdateButtonStates();
        }

        public override void SaveData(int marId, SqlTransaction? transaction = null)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            var helper = DC.GetHelper<MaterialApprovalRequestDetails>();

            // 1. Process deletions
            foreach (var id in DeletedIds)
            {
                try
                {
                    helper.Delete(id);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ أثناء حذف السجل {id}:\n{ex.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            DeletedIds.Clear();

            // 2. Process additions & edits
            foreach (var item in DataSource)
            {
                item.MARId = marId;
                if (item.Id == 0)
                {
                    item.CreatedDate    = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy      = Session.CurrentUser?.Id ?? 1;
                    item.IsDelete       = false;

                    try
                    {
                        helper.Add(item);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ أثناء إضافة السجل:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    item.UpdateDate    = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy      = Session.CurrentUser?.Id ?? 1;

                    try
                    {
                        helper.Edit(item.Id, item);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطأ أثناء تعديل السجل:\n{ex.Message}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiAdd.ItemClick    += (s, e) => { gridView1.AddNewRow(); };
            bbiDelete.ItemClick += (s, e) => ConfirmAndDeleteFocusedRow();

            gridView1.KeyDown          += StandardGridView_KeyDown;
            gridView1.SelectionChanged += (s, e) => UpdateButtonStates();
            gridView1.FocusedRowChanged += (s, e) => UpdateButtonStates();
        }

        private void FormatGrid()
        {
            // Apply system-wide grid style (font, alternating rows, etc.)
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            // Show new-row at the bottom for inline data entry
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            // Allow the user to resize rows manually
            gridView1.OptionsCustomization.AllowRowSizing = true;

            // Hide standard audit columns via shared helper
            DesignSystem.HideAuditColumns(gridView1);

            // Hide additional MAR-specific system columns
            HideColumn("MARId");
            HideColumn("PrjId");
            HideColumn("Created");
            HideColumn("Update");
            HideColumn("Deletion");

            // Set column widths for visible data columns
            SetColumnWidth("Description",                     250);
            SetColumnWidth("Purpose",                         180);
            SetColumnWidth("Manufacture",                     150);
            SetColumnWidth("BOQRef",                          100);
            SetColumnWidth("DrawingRef",                      100);
            SetColumnWidth("SpecRef",                         100);
            SetColumnWidth("ReviewStatus",                    120);
            SetColumnWidth("ReviewComment",                   160);
            SetColumnWidth("IsRejectedItemRequiredResubmitt", 110);
            SetColumnWidth("IsRejectedItemResubmitted",       100);

            // Center reference and status columns
            DesignSystem.SetColumnCentered(gridView1.Columns["BOQRef"]);
            DesignSystem.SetColumnCentered(gridView1.Columns["DrawingRef"]);
            DesignSystem.SetColumnCentered(gridView1.Columns["SpecRef"]);
            DesignSystem.SetColumnCentered(gridView1.Columns["ReviewStatus"]);

            // Color-code the review status column
            DesignSystem.ApplyStatusColoring(gridView1, "ReviewStatus");
        }

        // ── Commands ──────────────────────────────────────────────────────────
        public void ConfirmAndDeleteFocusedRow()
        {
            var row = gridView1.GetFocusedRow() as MaterialApprovalRequestDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0)
                {
                    DeletedIds.Add(row.Id);
                }
                gridView1.DeleteSelectedRows();
                OnDataChanged();
                UpdateCount();
                UpdateButtonStates();
            }
        }

        private void StandardGridView_KeyDown(object sender, KeyEventArgs e)
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

        public void HandleManualPaste()
        {
            try
            {
                gridView1.CloseEditor();
                gridView1.HideEditor();

                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 0) return;

                gridView1.BeginUpdate();
                int startRowHandle = gridView1.FocusedRowHandle;
                bool startAtNewRow = gridView1.IsNewItemRow(startRowHandle);
                int startVisibleColIndex = gridView1.FocusedColumn != null ? gridView1.FocusedColumn.VisibleIndex : 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    int currentRowHandle = startRowHandle + i;
                    if (startAtNewRow || currentRowHandle >= gridView1.DataRowCount ||
                        currentRowHandle < 0 || gridView1.IsNewItemRow(currentRowHandle))
                    {
                        gridView1.AddNewRow();
                        currentRowHandle = gridView1.FocusedRowHandle;
                        startAtNewRow = true;
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
                UpdateCount();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء اللصق: " + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private void UpdateCount()
        {
            if (barStaticItem1 != null)
            {
                barStaticItem1.Caption = $"عدد البنود: {DataSource.Count}";
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = gridView1.FocusedRowHandle >= 0 && DataSource.Count > 0;
            bbiDelete.Enabled = hasSelection;
        }

        /// <summary>Hides a column by its FieldName if it exists in the view.</summary>
        private void HideColumn(string fieldName)
        {
            var col = gridView1.Columns[fieldName];
            if (col != null) col.Visible = false;
        }

        /// <summary>Sets the width of a visible column by its FieldName.</summary>
        private void SetColumnWidth(string fieldName, int width)
        {
            var col = gridView1.Columns[fieldName];
            if (col != null) col.Width = width;
        }
    }
}
