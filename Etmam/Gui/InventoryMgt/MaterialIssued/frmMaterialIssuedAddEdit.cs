using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Core;
using Data;

namespace Etmam
{
    public class frmMaterialIssuedAddEdit : XtraForm
    {
        private readonly DataContext dc = Data.DataContext.Shared;
        private int _id;
        private MaterialIssuedList? _entity;
        private BindingList<MaterialIssuedDetails> _details = new();
        private List<int> _deletedDetailIds = new();

        // UI Controls
        private TextEdit txtCode = null!;
        private DateEdit dtIssuedDate = null!;
        private LookUpEdit lkStore = null!;
        private MemoEdit txtNote = null!;
        private TextEdit txtAmount = null!;

        private GridControl gridControl1 = null!;
        private GridView gridView1 = null!;
        private RepositoryItemLookUpEdit repoItems = null!;

        private SimpleButton btnSave = null!;
        private SimpleButton btnCancel = null!;
        private SimpleButton btnAddLine = null!;
        private SimpleButton btnDeleteLine = null!;

        public frmMaterialIssuedAddEdit(int id = 0)
        {
            _id = id;
            InitializeComponent();
            if (DesignMode) return;

            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyButtonStyle(btnSave, true);
            DesignSystem.ApplyButtonStyle(btnCancel);
            DesignSystem.ApplyButtonStyle(btnAddLine);
            DesignSystem.ApplyButtonStyle(btnDeleteLine);

            LoadLookups();
            LoadRecord();
        }

        private void InitializeComponent()
        {
            // Set Form Properties
            this.Size = new Size(950, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = $"إذن صرف مواد - {(_id > 0 ? "تعديل" : "جديد")}";

            // Top Panel for Header
            var pnlHeader = new GroupControl { Text = "بيانات الصرف الرئيسية", Dock = DockStyle.Top, Height = 170, Margin = new Padding(10) };
            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
                Padding = new Padding(10)
            };
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));

            // Controls
            txtCode = new TextEdit { ReadOnly = true, Dock = DockStyle.Fill };
            dtIssuedDate = new DateEdit { EditValue = DateTime.Today, Dock = DockStyle.Fill };
            lkStore = new LookUpEdit { Dock = DockStyle.Fill };
            txtNote = new MemoEdit { Dock = DockStyle.Fill };

            // Add Header Controls to Table
            tableLayout.Controls.Add(new LabelControl { Text = "رقم الصرف:", Anchor = AnchorStyles.Left }, 0, 0);
            tableLayout.Controls.Add(txtCode, 1, 0);
            tableLayout.Controls.Add(new LabelControl { Text = "تاريخ الصرف:", Anchor = AnchorStyles.Left }, 2, 0);
            tableLayout.Controls.Add(dtIssuedDate, 3, 0);

            tableLayout.Controls.Add(new LabelControl { Text = "من مخزن:", Anchor = AnchorStyles.Left }, 0, 1);
            tableLayout.Controls.Add(lkStore, 1, 1);
            tableLayout.Controls.Add(new LabelControl { Text = "الغرض / البيان:", Anchor = AnchorStyles.Left }, 2, 1);
            tableLayout.Controls.Add(txtNote, 3, 1);

            pnlHeader.Controls.Add(tableLayout);
            this.Controls.Add(pnlHeader);

            // Bottom Buttons Panel
            var pnlButtons = new PanelControl { Dock = DockStyle.Bottom, Height = 55 };
            btnSave = new SimpleButton { Text = "حفظ المستند", Location = new Point(12, 12), Size = new Size(120, 30) };
            btnCancel = new SimpleButton { Text = "إلغاء", Location = new Point(140, 12), Size = new Size(100, 30) };
            txtAmount = new TextEdit { ReadOnly = true, Location = new Point(730, 12), Size = new Size(180, 30) };
            var lblAmount = new LabelControl { Text = "الإجمالي:", Location = new Point(670, 18) };

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(lblAmount);
            pnlButtons.Controls.Add(txtAmount);
            this.Controls.Add(pnlButtons);

            // Grid Layout (Middle)
            var pnlGrid = new GroupControl { Text = "تفاصيل المواد المصروفة", Dock = DockStyle.Fill };
            
            // Grid Action Buttons Panel (Top of Grid)
            var pnlGridActions = new PanelControl { Dock = DockStyle.Top, Height = 40 };
            btnAddLine = new SimpleButton { Text = "إضافة مادة", Location = new Point(10, 5), Size = new Size(100, 28) };
            btnDeleteLine = new SimpleButton { Text = "حذف مادة", Location = new Point(120, 5), Size = new Size(100, 28) };
            
            btnAddLine.Click += (s, e) => gridView1.AddNewRow();
            btnDeleteLine.Click += btnDeleteLine_Click;

            pnlGridActions.Controls.Add(btnAddLine);
            pnlGridActions.Controls.Add(btnDeleteLine);
            pnlGrid.Controls.Add(pnlGridActions);

            gridControl1 = new GridControl { Dock = DockStyle.Fill };
            gridView1 = new GridView();
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            pnlGrid.Controls.Add(gridControl1);
            this.Controls.Add(pnlGrid);

            // Setup Details Grid Columns
            var colId = gridView1.Columns.AddVisible("Id", "م");
            colId.Visible = false;

            var colItem = gridView1.Columns.AddVisible("ItemId", "اسم الصنف");
            colItem.Width = 350;
            repoItems = new RepositoryItemLookUpEdit();
            gridControl1.RepositoryItems.Add(repoItems);
            colItem.ColumnEdit = repoItems;

            var colQty = gridView1.Columns.AddVisible("Qty", "الكمية المصروفة");
            colQty.Width = 100;
            DesignSystem.SetColumnCentered(colQty);

            var colUnitPrice = gridView1.Columns.AddVisible("UnitPrice", "سعر الوحدة");
            colUnitPrice.Width = 120;
            colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colUnitPrice.DisplayFormat.FormatString = "n2";
            DesignSystem.SetColumnCentered(colUnitPrice);

            var colTotalPrice = gridView1.Columns.AddVisible("TotalPrice", "الإجمالي");
            colTotalPrice.Width = 150;
            colTotalPrice.OptionsColumn.AllowEdit = false;
            colTotalPrice.OptionsColumn.ReadOnly = true;
            colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotalPrice.DisplayFormat.FormatString = "n2";
            DesignSystem.SetColumnCentered(colTotalPrice);

            var colNote = gridView1.Columns.AddVisible("Note", "ملاحظات");
            colNote.Width = 200;

            DesignSystem.ApplyGridStyle(gridControl1, gridView1);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            // Update TotalPrice dynamically on Qty/UnitPrice change
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.InitNewRow += GridView1_InitNewRow;
        }

        private void LoadLookups()
        {
            lkStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lkStore.Properties.ValueMember = "Id";
            lkStore.Properties.DisplayMember = "Name";
            lkStore.Properties.NullText = "-- اختر المخزن --";

            repoItems.DataSource = dc.ItemsList.GetBy("IsDelete = 0");
            repoItems.ValueMember = "Id";
            repoItems.DisplayMember = "Name";
            repoItems.NullText = "";
        }

        private void LoadRecord()
        {
            if (_id > 0)
            {
                _entity = dc.MaterialIssuedList.Find(_id);
                if (_entity == null)
                {
                    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _entity = new MaterialIssuedList();
                }
                
                txtCode.Text = _entity.Code ?? "";
                dtIssuedDate.EditValue = _entity.IssuedDate;
                lkStore.EditValue = _entity.StoreId;
                txtNote.Text = _entity.Note ?? "";
                txtAmount.Text = (_entity.Amount ?? 0).ToString("N2");

                var list = dc.MaterialIssuedDetails.GetBy("ParentId = @id AND IsDelete = 0", new { id = _id });
                _details = new BindingList<MaterialIssuedDetails>(list);
            }
            else
            {
                _entity = new MaterialIssuedList();
                txtCode.Text = GenerateNextCode();
                dtIssuedDate.EditValue = DateTime.Today;
                lkStore.EditValue = null;
                txtNote.Text = "";
                txtAmount.Text = "0.00";
                _details = new BindingList<MaterialIssuedDetails>();
            }

            gridControl1.DataSource = _details;
            _details.ListChanged += (s, e) => UpdateTotalAmount();
        }

        private string GenerateNextCode()
        {
            try
            {
                var all = dc.MaterialIssuedList.GetBy("IsDelete = 0");
                int maxCode = 0;
                foreach (var issue in all)
                {
                    if (int.TryParse(issue.Code, out int c) && c > maxCode)
                    {
                        maxCode = c;
                    }
                }
                return (maxCode + 1).ToString();
            }
            catch
            {
                return "1";
            }
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as MaterialIssuedDetails;
            if (row == null) return;

            if (e.Column.FieldName == "Qty" || e.Column.FieldName == "UnitPrice")
            {
                row.TotalPrice = (row.Qty ?? 0) * (row.UnitPrice ?? 0);
                gridView1.UpdateCurrentRow();
                UpdateTotalAmount();
            }
        }

        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as MaterialIssuedDetails;
            if (row != null)
            {
                row.Qty = 0;
                row.UnitPrice = 0;
                row.TotalPrice = 0;
                row.IsDelete = false;
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = _details.Sum(d => d.TotalPrice ?? 0);
            txtAmount.Text = total.ToString("N2");
        }

        private void btnDeleteLine_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow() as MaterialIssuedDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا السطر؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (row.Id > 0)
                {
                    _deletedDetailIds.Add(row.Id);
                }
                gridView1.DeleteSelectedRows();
                UpdateTotalAmount();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lkStore.EditValue == null)
            {
                XtraMessageBox.Show("يرجى اختيار المخزن.", "بيانات ناقصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();

                _entity ??= new MaterialIssuedList();
                _entity.Code = txtCode.Text.Trim();
                _entity.IssuedDate = dtIssuedDate.DateTime;
                _entity.StoreId = lkStore.EditValue as int?;
                _entity.Note = txtNote.Text.Trim();
                _entity.Amount = _details.Sum(d => d.TotalPrice ?? 0);
                _entity.PrjId = Session.SelectedProjectId;

                if (_id > 0)
                {
                    _entity.UpdateDate = DateTime.Now;
                    _entity.UpdateMachine = Session.Machine;
                    _entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    dc.MaterialIssuedList.Edit(_id, _entity);
                }
                else
                {
                    _entity.CreatedDate = DateTime.Now;
                    _entity.CreatedMachine = Session.Machine;
                    _entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    _entity.IsDelete = false;
                    _id = dc.MaterialIssuedList.Add(_entity);
                }

                // Delete removed items
                foreach (int detId in _deletedDetailIds)
                {
                    dc.MaterialIssuedDetails.Delete(detId);
                }
                _deletedDetailIds.Clear();

                // Save Detail items
                foreach (var detail in _details)
                {
                    detail.ParentId = _id;
                    if (detail.Id > 0)
                    {
                        detail.UpdateDate = DateTime.Now;
                        detail.UpdateMachine = Session.Machine;
                        detail.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        dc.MaterialIssuedDetails.Edit(detail.Id, detail);
                    }
                    else
                    {
                        detail.CreatedDate = DateTime.Now;
                        detail.CreatedMachine = Session.Machine;
                        detail.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        detail.IsDelete = false;
                        dc.MaterialIssuedDetails.Add(detail);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
