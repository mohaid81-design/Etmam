using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for "رصيد افتتاحي" (opening balance) vouchers: header (store/date/note) + an
    /// items grid establishing each item's starting quantity/unit cost for the chosen store. Unlike
    /// frmStockingAddEdit (a reconciliation record that deliberately does NOT feed StoreBalanceHelper), a
    /// saved opening balance line IS a real "in" movement — see StoreBalanceHelper.ComputeBalances — so it
    /// actually changes what every other document (Issued/Transfer/...) computes as available stock.
    /// Hand-built entirely in code (no paired .Designer.cs/.resx), same style as frmPurchaseOrderSelect /
    /// frmMaterialReceiveSelect / frmWorkflowDefinitionAddEdit elsewhere in this module — this form has no
    /// attachments/log/link tabs, unlike the fuller Procurement/Inventory AddEdit forms, to keep the
    /// hand-built surface manageable; that can be added later the same way those were, if requested.</summary>
    public class frmOpeningBalanceAddEdit : XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        private int _id;
        private byte[]? _rowVersion;
        private bool _isDirty;
        private bool _anySaved;
        private bool _readOnly;                                       // true عند الفتح من ucOpeningBalance.btnOpen: عرض فقط، بلا تعديل أو إضافة
        private List<OpeningBalanceList> _list = new();
        private int _currentIndex = -1;

        private BindingList<OpeningBalanceDetails> _details = new();
        private readonly List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();

        // ── Controls ─────────────────────────────────────────────────────────
        private readonly SimpleButton btnFirst = MakeNavButton("«");
        private readonly SimpleButton btnPrev = MakeNavButton("‹");
        private readonly SimpleButton btnNext = MakeNavButton("›");
        private readonly SimpleButton btnLast = MakeNavButton("»");
        private readonly SimpleButton btnNew = new() { Text = "جديد", Width = 80, Height = 28 };
        private readonly SimpleButton btnSave = new() { Text = "حفظ", Width = 80, Height = 28 };
        private readonly SimpleButton btnPrint = new() { Text = "طباعة", Width = 80, Height = 28 };

        private readonly LabelControl lblNum = new() { Text = "الرقم:" };
        private readonly TextEdit textEditNum = new() { Properties = { ReadOnly = true } };
        private readonly LabelControl lblStore = new() { Text = "المخزن:" };
        private readonly LookUpEdit lookUpEditStore = new();
        private readonly LabelControl lblDate = new() { Text = "تاريخ الرصيد:" };
        private readonly DateEdit dateEditBalanceDate = new();
        private readonly LabelControl lblNote = new() { Text = "ملاحظات:" };
        private readonly MemoEdit memoEditNote = new();

        private readonly GridControl gridControl1 = new();
        private readonly GridView gridView1;
        private readonly DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riButtonAddItem = new();
        private readonly DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpItem = new();
        private readonly DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpUnit = new();
        private readonly DevExpress.XtraGrid.Columns.GridColumn colAddItem;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colItem;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colDescrp;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colQty;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private readonly DevExpress.XtraGrid.Columns.GridColumn colNote;

        public frmOpeningBalanceAddEdit(int id = 0)
        {
            gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { riButtonAddItem, riLookUpItem, riLookUpUnit });

            colAddItem = gridView1.Columns.AddField("");
            colItem = gridView1.Columns.AddField("ItemId");
            colDescrp = gridView1.Columns.AddField("Description");
            colUnit = gridView1.Columns.AddField("UnitId");
            colQty = gridView1.Columns.AddField("Qty");
            colUnitPrice = gridView1.Columns.AddField("UnitPrice");
            colTotalPrice = gridView1.Columns.AddField("TotalPrice");
            colNote = gridView1.Columns.AddField("Note");

            BuildLayout();
            ConfigureGrid();
            SetupLookups();
            WireEvents();
            LoadList();

            Text = "رصيد افتتاحي";
            DesignSystem.ApplyCairoFont(this);
            DesignSystem.ApplyGridStyle(gridControl1, gridView1);

            if (id > 0)
            {
                _currentIndex = _list.FindIndex(r => r.Id == id);
                LoadRecord(id);
            }
            else
            {
                NewRecord();
            }
        }

        private static SimpleButton MakeNavButton(string text) => new() { Text = text, Width = 32, Height = 28 };

        // ── Layout ────────────────────────────────────────────────────────────
        private void BuildLayout()
        {
            Size = new Size(900, 620);
            StartPosition = FormStartPosition.CenterParent;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            MinimizeBox = false;

            var pnlTop = new PanelControl { Dock = DockStyle.Top, Height = 44 };
            btnFirst.Location = new Point(820, 8);
            btnPrev.Location = new Point(784, 8);
            btnNext.Location = new Point(748, 8);
            btnLast.Location = new Point(712, 8);
            btnNew.Location = new Point(620, 8);
            btnSave.Location = new Point(532, 8);
            btnPrint.Location = new Point(444, 8);
            foreach (var b in new[] { btnFirst, btnPrev, btnNext, btnLast, btnNew, btnPrint })
                DesignSystem.ApplyButtonStyle(b);
            DesignSystem.ApplyButtonStyle(btnSave, isPrimary: true);
            pnlTop.Controls.AddRange(new Control[] { btnFirst, btnPrev, btnNext, btnLast, btnNew, btnSave, btnPrint });

            var pnlHeader = new PanelControl { Dock = DockStyle.Top, Height = 110 };
            lblNum.Location = new Point(830, 16);
            textEditNum.Location = new Point(690, 12);
            textEditNum.Size = new Size(130, 24);
            lblStore.Location = new Point(830, 48);
            lookUpEditStore.Location = new Point(500, 44);
            lookUpEditStore.Size = new Size(320, 24);
            lblDate.Location = new Point(460, 16);
            dateEditBalanceDate.Location = new Point(300, 12);
            dateEditBalanceDate.Size = new Size(150, 24);
            lblNote.Location = new Point(830, 80);
            memoEditNote.Location = new Point(20, 8);
            memoEditNote.Size = new Size(270, 96);
            pnlHeader.Controls.AddRange(new Control[]
            {
                lblNum, textEditNum, lblStore, lookUpEditStore, lblDate, dateEditBalanceDate, lblNote, memoEditNote
            });

            gridControl1.Dock = DockStyle.Fill;

            Controls.Add(gridControl1);
            Controls.Add(pnlHeader);
            Controls.Add(pnlTop);
        }

        private void ConfigureGrid()
        {
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None; // إضافة الأصناف عبر colAddItem فقط

            colAddItem.Caption = " ";
            colAddItem.ColumnEdit = riButtonAddItem;
            colAddItem.OptionsColumn.AllowEdit = true;
            colAddItem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colAddItem.Width = 40;
            colAddItem.VisibleIndex = 0;
            colAddItem.Visible = true;
            riButtonAddItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            riButtonAddItem.Buttons.Clear();
            riButtonAddItem.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) { ToolTip = "إضافة أصناف" });

            colItem.Caption = "الصنف";
            colItem.ColumnEdit = riLookUpItem;
            colItem.OptionsColumn.AllowEdit = false;
            colItem.OptionsColumn.AllowFocus = false;
            colItem.Width = 130;
            colItem.VisibleIndex = 1;
            colItem.Visible = true;

            colDescrp.Caption = "الوصف";
            colDescrp.OptionsColumn.AllowEdit = false;
            colDescrp.Width = 260;
            colDescrp.VisibleIndex = 2;
            colDescrp.Visible = true;

            colUnit.Caption = "الوحدة";
            colUnit.ColumnEdit = riLookUpUnit;
            colUnit.OptionsColumn.AllowEdit = false;
            colUnit.OptionsColumn.AllowFocus = false;
            colUnit.Width = 70;
            colUnit.VisibleIndex = 3;
            colUnit.Visible = true;

            colQty.Caption = "الكمية";
            colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQty.DisplayFormat.FormatString = "n2";
            colQty.Width = 90;
            colQty.VisibleIndex = 4;
            colQty.Visible = true;

            colUnitPrice.Caption = "سعر الوحدة";
            colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colUnitPrice.DisplayFormat.FormatString = "n2";
            colUnitPrice.Width = 100;
            colUnitPrice.VisibleIndex = 5;
            colUnitPrice.Visible = true;

            colTotalPrice.Caption = "الإجمالي";
            colTotalPrice.OptionsColumn.AllowEdit = false;
            colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTotalPrice.DisplayFormat.FormatString = "n2";
            colTotalPrice.Width = 110;
            colTotalPrice.VisibleIndex = 6;
            colTotalPrice.Visible = true;

            colNote.Caption = "ملاحظة";
            colNote.Width = 150;
            colNote.VisibleIndex = 7;
            colNote.Visible = true;
        }

        private void SetupLookups()
        {
            lookUpEditStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- اختر المخزن --";

            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();
            riLookUpItem.DataSource = _itemsCache;
            riLookUpItem.ValueMember = "Id";
            riLookUpItem.DisplayMember = "Code";
            riLookUpItem.NullText = "";

            riLookUpUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            riLookUpUnit.ValueMember = "Id";
            riLookUpUnit.DisplayMember = "Abbreviation";
            riLookUpUnit.NullText = "";
        }

        private void WireEvents()
        {
            btnNew.Click += (s, e) => SafeAction(NewRecord);
            btnSave.Click += (s, e) => SafeAction(() => SaveRecord());
            btnPrint.Click += (s, e) => PrintRecord();
            btnFirst.Click += (s, e) => NavigateFirst();
            btnPrev.Click += (s, e) => NavigatePrev();
            btnNext.Click += (s, e) => NavigateNext();
            btnLast.Click += (s, e) => NavigateLast();

            dateEditBalanceDate.EditValueChanged += (s, e) => SetDirty();
            lookUpEditStore.EditValueChanged += (s, e) => SetDirty();
            memoEditNote.EditValueChanged += (s, e) => SetDirty();

            gridView1.CellValueChanged += GridView_CellValueChanged;
            gridView1.KeyDown += GridView_KeyDown;
            riButtonAddItem.ButtonClick += RepositoryItemButtonEditAddItem_ButtonClick;

            FormClosing += FrmOpeningBalanceAddEdit_FormClosing;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadList()
        {
            _list = dc.OpeningBalanceList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.BalanceDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var entity = dc.OpeningBalanceList.Find(id);
            if (entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewRecord();
                return;
            }

            _id = id;
            _rowVersion = entity.RowVersion;
            _isDirty = false;

            textEditNum.Text = OpeningBalancePrinter.FormatBalanceNumber(entity.Num);
            lookUpEditStore.EditValue = entity.StoreId;
            dateEditBalanceDate.EditValue = entity.BalanceDate;
            memoEditNote.Text = entity.Note ?? "";

            LoadDetails(id);

            _currentIndex = _list.FindIndex(r => r.Id == id);
            UpdateNavigatorCaption();
            SetDirty(false);
            SetEditLock(_readOnly);
        }

        /// <summary>يفتح السجل المحدَّد بعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — نقطة الدخول المستخدمة من
        /// btnOpen في ucOpeningBalance، بديلاً عن الفتح الكامل للتعديل (btnEdit).</summary>
        public void OpenReadOnly(int id)
        {
            _readOnly = true;
            LoadRecord(id);
            btnNew.Enabled = false;
        }

        /// <summary>يقفل/يحرِّر حقول الترويسة وجدول الأصناف وزر الحفظ معاً — يُستدعى من LoadRecord في كل
        /// مرة (كي يبقى القفل قائماً أثناء التنقل بين السجلات في وضع العرض فقط) وعند الدخول لوضع العرض
        /// فقط أول مرة. لا يوجد عمود حذف مرئي هنا (الحذف عبر Ctrl+Delete فقط، انظر الحارس في
        /// DeleteFocusedDetailRow)، فيكفي قفل colAddItem.</summary>
        private void SetEditLock(bool locked)
        {
            lookUpEditStore.Properties.ReadOnly = locked;
            dateEditBalanceDate.Properties.ReadOnly = locked;
            memoEditNote.Properties.ReadOnly = locked;

            gridView1.OptionsBehavior.Editable = !locked;
            colAddItem.Visible = !locked;

            btnSave.Enabled = !locked;
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.OpeningBalanceDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<OpeningBalanceDetails> source)
        {
            _details = new BindingList<OpeningBalanceDetails>(source);
            gridControl1.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save) ────────────────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _deletedDetailIds.Clear();
            _isDirty = false;

            textEditNum.Text = "جديد";
            lookUpEditStore.EditValue = null;
            dateEditBalanceDate.EditValue = DateTime.Today;
            memoEditNote.Text = "";

            BindDetails(new List<OpeningBalanceDetails>());

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditStore.Focus();
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            try
            {
                var rec = BuildHeaderEntity();
                rec.Amount = _details.Sum(d => d.TotalPrice ?? 0);
                bool isNew = _id == 0;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently — see [[project_architecture]]'s RunInTransaction convention.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (isNew)
                    {
                        rec.Num = GetNextNumber();
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;
                        _id = dc.OpeningBalanceList.Add(rec, tx);
                    }
                    else
                    {
                        var existing = dc.OpeningBalanceList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync
                        dc.OpeningBalanceList.Edit(_id, rec, tx);
                    }

                    SaveDetails(_id, tx);
                });

                if (isNew) textEditNum.Text = OpeningBalancePrinter.FormatBalanceNumber(rec.Num);
                _rowVersion = rec.RowVersion;

                SetDirty(false);
                _anySaved = true;

                LoadList();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                if (!silent)
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Data.ConcurrencyConflictException ex)
            {
                XtraMessageBox.Show(ex.Message, "تعارض في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveDetails(int id, SqlTransaction tx)
        {
            var helper = dc.OpeningBalanceDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<OpeningBalanceDetails>();
            var toEdit = new List<OpeningBalanceDetails>();
            foreach (var detail in _details)
            {
                detail.ParentId = id;

                if (detail.Id == 0)
                {
                    detail.CreatedDate = DateTime.Now;
                    detail.CreatedMachine = Session.Machine;
                    detail.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    detail.IsDelete = false;
                    toAdd.Add(detail);
                }
                else
                {
                    detail.UpdateDate = DateTime.Now;
                    detail.UpdateMachine = Session.Machine;
                    detail.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    toEdit.Add(detail);
                }
            }
            if (toAdd.Count > 0) helper.AddRange(toAdd, tx);
            if (toEdit.Count > 0) helper.EditRange(toEdit, tx);
        }

        // ── Detail Row Operations ─────────────────────────────────────────────
        private void DeleteFocusedDetailRow()
        {
            if (_readOnly) return; // Ctrl+Delete يمر عبر GridView_KeyDown مباشرة، بلا زر مرئي يمكن إخفاؤه في وضع العرض فقط

            var row = gridView1.GetFocusedRow() as OpeningBalanceDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا السطر؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridView1.DeleteSelectedRows();
            SetDirty();
        }

        private void GridView_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteFocusedDetailRow();
                e.Handled = true;
            }
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) is not OpeningBalanceDetails row) return;

            if (e.Column != colQty && e.Column != colUnitPrice) return;

            row.TotalPrice = (row.Qty ?? 0) * (row.UnitPrice ?? 0);
            gridView1.RefreshRow(e.RowHandle);
        }

        /// <summary>يفتح شجرة الأصناف (frmItemSelect) لاختيار عدة أصناف دفعة واحدة، دون تقييد بأي رصيد
        /// مخزن حالي (خلافاً لإذن الصرف/التحويل) — الغرض من هذا المستند هو تأسيس رصيد يبدأ من الصفر، لذا
        /// يجب أن يسمح باختيار أي صنف بلا استثناء. يُستبعد فقط ما هو مُضاف بالفعل في الجدول.</summary>
        private void RepositoryItemButtonEditAddItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var existingItemIds = _details
                .Where(d => d.ItemId is > 0)
                .Select(d => d.ItemId!.Value)
                .ToHashSet();

            using var frm = new frmItemSelect { ExcludeItemIds = existingItemIds };
            if (frm.ShowDialog(this) != DialogResult.OK) return;

            foreach (var item in frm.SelectedItems)
            {
                _details.Add(new OpeningBalanceDetails
                {
                    ItemId = item.Id,
                    UnitId = item.UnitId,
                    Description = item.Name
                });
            }

            gridView1.MoveLast();
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigatePrev()
        {
            if (_list.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateNext()
        {
            if (_list.Count == 0 || _currentIndex >= _list.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateLast()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _list.Count - 1;
            var handle = ShowOverlay();
            try { LoadRecord(_list[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (_id <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ الرصيد الافتتاحي قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                XtraMessageBox.Show("توجد تغييرات غير محفوظة. يرجى الحفظ قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { OpeningBalancePrinter.Print(_id); }
            finally { CloseOverlay(handle); }
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (lookUpEditStore.EditValue == null || lookUpEditStore.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى اختيار المخزن.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditStore.Focus();
                return false;
            }
            if (_id == 0 && lookUpEditStore.EditValue is int storeId && !InventoryStorePermissions.CanReceive(dc, storeId))
            {
                XtraMessageBox.Show("ليس لديك صلاحية استلام مواد في هذا المخزن (مطلوبة لإدخال رصيد افتتاحي).", "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditStore.Focus();
                return false;
            }
            if (dateEditBalanceDate.EditValue == null || dateEditBalanceDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ الرصيد.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditBalanceDate.Focus();
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة صنف واحد على الأقل.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تحديد كمية أكبر من صفر لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private OpeningBalanceList BuildHeaderEntity()
        {
            return new OpeningBalanceList
            {
                StoreId = lookUpEditStore.EditValue as int?,
                BalanceDate = dateEditBalanceDate.EditValue as DateTime?,
                Note = memoEditNote.Text?.Trim()
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetNextNumber()
        {
            return dc.OpeningBalanceList
                .GetBy("IsDelete = 0")
                .Select(r => r.Num ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"رصيد افتتاحي رقم [{_list[_currentIndex].Num}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة رصيد افتتاحي جديد";

            btnFirst.Enabled = _currentIndex > 0;
            btnPrev.Enabled = _currentIndex > 0;
            btnNext.Enabled = _currentIndex < _list.Count - 1;
            btnLast.Enabled = _currentIndex < _list.Count - 1;
        }

        private void SetDirty(bool value = true) => _isDirty = value;

        private bool ConfirmNavigation()
        {
            if (!_isDirty) return true;

            var result = XtraMessageBox.Show(
                "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الانتقال؟",
                "تغييرات غير محفوظة",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) { SaveRecord(); return true; }
            if (result == DialogResult.No) { SetDirty(false); return true; }
            return false; // Cancel
        }

        private void SafeAction(Action action)
        {
            var handle = ShowOverlay();
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private void FrmOpeningBalanceAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = XtraMessageBox.Show(
                    "توجد تغييرات غير محفوظة. هل تريد الحفظ قبل الإغلاق؟",
                    "تغييرات غير محفوظة",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) SafeAction(() => SaveRecord());
                else if (result == DialogResult.Cancel) { e.Cancel = true; return; }
            }

            DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
