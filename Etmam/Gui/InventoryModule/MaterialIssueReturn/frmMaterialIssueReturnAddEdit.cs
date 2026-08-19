using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for Material Issue Return vouchers ("مرتجع صرف مواد"): header (store/returned-
    /// by/date/note) + a returned-items grid. Returns previously-issued materials back into the same store
    /// they were issued from. Mirrors frmMaterialIssuedAddEdit's stock-awareness, but with the mirror-image
    /// metric: colIssuedQty shows how much of each item was issued out and not yet returned (via
    /// StoreBalanceHelper.ComputeIssuedNotReturnedBalances), and Qty is capped at that instead of at the
    /// store's stock balance — you can't "return" more than was ever actually taken out.</summary>
    public partial class frmMaterialIssueReturnAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private bool _readOnly = false;                               // true عند الفتح من ucMaterialIssueReturn.btnOpen: عرض فقط، بلا تعديل أو إضافة
        private List<MaterialIssueReturnList> _list = new();
        private int _currentIndex = -1;

        private BindingList<MaterialIssueReturnDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        // الكمية الصادرة من هذا الصنف من المخزن المختار ولم تُرتجَع بعد (يُحدَّث عند تغيير المخزن) —
        // للعرض في colIssuedQty ولمنع إرجاع كمية أكبر مما صُرف فعلياً (انظر ValidateReturnAvailability).
        private Dictionary<int, decimal> _outstandingBalances = new();

        // لقطة من كميات هذا السجل كما كانت محفوظة في قاعدة البيانات عند التحميل (فارغة لسجل جديد) —
        // الكمية المتبقية الحقيقية تستثني بالفعل ما أرجعه هذا السجل نفسه سابقاً، فتُضاف هذه الكميات
        // مجدداً عند حساب "المتاح لإعادة الإرجاع" أثناء التعديل.
        private Dictionary<int, decimal> _originalQtyByItemId = new();

        public frmMaterialIssueReturnAddEdit(int id = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupAttachments();
            LoadList();

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

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick += (s, e) => PrintRecord();

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItem1.EditValue != null)
                    FetchBySearch();
            };

            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditStore.EditValueChanged += (s, e) => { OnStoreChanged(s, e); RevalidateField(lookUpEditStore, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value); };
            textEditReceivedBy.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(textEditReceivedBy, !string.IsNullOrWhiteSpace(textEditReceivedBy.Text)); };
            dateEditReturnedDate.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(dateEditReturnedDate, dateEditReturnedDate.EditValue != null && dateEditReturnedDate.EditValue != DBNull.Value); };
            memoEditDesrp.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(memoEditDesrp, !string.IsNullOrWhiteSpace(memoEditDesrp.Text)); };

            gridView1.CellValueChanged += GridView_CellValueChanged;
            gridView1.InitNewRow += GridView_InitNewRow;
            gridView1.KeyDown += GridView_KeyDown;
            gridView1.ValidatingEditor += GridView_ValidatingEditor;
            repositoryItemButtonEditAddItem.ButtonClick += RepositoryItemButtonEditAddItem_ButtonClick;
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            this.FormClosing += FrmMaterialIssueReturnAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            lookUpEditStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- اختر المخزن --";
        }

        private void SetupGrid()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            repositoryItemLookUpEditItem.DataSource = _itemsCache;
            repositoryItemLookUpEditItem.ValueMember = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText = "";
            colItem.ColumnEdit = repositoryItemLookUpEditItem;

            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";

            repositoryItemLookUpEditCC.DataSource = dc.CostCenterList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditCC.ValueMember = "Id";
            repositoryItemLookUpEditCC.DisplayMember = "Name";
            repositoryItemLookUpEditCC.NullText = "";

            repositoryItemLookUpEditBDG.DataSource = dc.BudgetList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditBDG.ValueMember = "Id";
            repositoryItemLookUpEditBDG.DisplayMember = "Description";
            repositoryItemLookUpEditBDG.NullText = "";

            // عمود عرض غير مرتبط بالديزاينر (بلا FieldName) — الكمية الصادرة ولم تُرتجَع بعد، انظر
            // StoreBalanceHelper وRefreshOutstandingBalances.
            colIssuedQty.FieldName = "IssuedQty";
            colIssuedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIssuedQty.DisplayFormat.FormatString = "n2";

            // الافتراضي في DevExpress هو NewItemRowPosition.None (بلا سطر إضافة أصلاً) — يجب تفعيله
            // صراحة كي يستطيع المستخدم الكتابة المباشرة في سطر جديد أسفل الشبكة.
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindDetails(new List<MaterialIssueReturnDetails>());
        }

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab's navigation frame.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments);
            _ucAttachments.SaveRequired += SaveAndReturnId;
        }

        private void SetupNavigationPage(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            navigationFrame1.Pages.Add(page);
            navigationFrame1.SelectedPage = page;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadList()
        {
            _list = dc.MaterialIssueReturnList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.ReturnDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.MaterialIssueReturnList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewRecord();
                return;
            }

            _id = id;
            _rowVersion = rec.RowVersion;
            _isDirty = false; // إيقاف تتبع التعديلات مؤقتاً أثناء تعبئة الحقول

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = MaterialIssueReturnPrinter.FormatReturnNumber(rec.Num, rec.ReturnDate);
            dateEditReturnedDate.EditValue = rec.ReturnDate;

            // يُوقَف معالج التغيير مؤقتاً كي لا يُفرَّغ الجدول (المُعَدّ لاستقبال LoadDetails بعد قليل)
            // ولا تظهر رسالة "تم تفريغ الجدول" أثناء مجرد التنقل بين السجلات.
            lookUpEditStore.EditValueChanged -= OnStoreChanged;
            lookUpEditStore.EditValue = rec.StoreId;
            lookUpEditStore.EditValueChanged += OnStoreChanged;

            textEditReceivedBy.Text = rec.ReturnBy ?? "";
            memoEditDesrp.Text = rec.Note ?? "";

            LoadDetails(id);
            RefreshOutstandingBalances(rec.StoreId);
            _ucAttachments?.LoadFor("MaterialIssueReturnList", _id);

            UpdateNavigatorCaption();
            SetDirty(false);
            SetEditLock(_readOnly);
        }

        /// <summary>يفتح السجل المحدَّد بعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — نقطة الدخول المستخدمة من
        /// btnOpen في ucMaterialIssueReturn، بديلاً عن الفتح الكامل للتعديل (bbiEdit).</summary>
        public void OpenReadOnly(int id)
        {
            _readOnly = true;
            LoadRecord(id);
            bbiNew.Enabled = false;
        }

        /// <summary>يقفل/يحرِّر حقول الترويسة وجدول الأصناف وزر الحفظ معاً — يُستدعى من LoadRecord في كل
        /// مرة (كي يبقى القفل قائماً أثناء التنقل بين السجلات في وضع العرض فقط) وعند الدخول لوضع العرض
        /// فقط أول مرة.</summary>
        private void SetEditLock(bool locked)
        {
            lookUpEditStore.Properties.ReadOnly = locked;
            textEditReceivedBy.Properties.ReadOnly = locked;
            dateEditReturnedDate.Properties.ReadOnly = locked;
            memoEditDesrp.Properties.ReadOnly = locked;

            gridView1.OptionsBehavior.Editable = !locked;
            gridView1.OptionsView.NewItemRowPosition = locked ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            colAddItem.Visible = !locked;
            colDeleteItem.Visible = !locked;

            bbiSave.Enabled = !locked;
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.MaterialIssueReturnDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            // الكمية المتبقية الحقيقية تستثني أصلاً ما أرجعه هذا السجل، فنحتفظ بكمياته الأصلية هنا كي
            // "تُضاف" مجدداً عند حساب المتاح لإعادة الإرجاع (انظر ValidateReturnAvailability).
            _originalQtyByItemId = list
                .Where(d => d.ItemId is > 0)
                .GroupBy(d => d.ItemId!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));

            BindDetails(list);
        }

        private void BindDetails(List<MaterialIssueReturnDetails> source)
        {
            _details = new BindingList<MaterialIssueReturnDetails>(source);
            gridControl1.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save / Delete) ──────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _deletedDetailIds.Clear();
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = "جديد";
            dateEditReturnedDate.EditValue = DateTime.Today;

            lookUpEditStore.EditValueChanged -= OnStoreChanged;
            lookUpEditStore.EditValue = null;
            lookUpEditStore.EditValueChanged += OnStoreChanged;

            textEditReceivedBy.Text = "";
            memoEditDesrp.Text = "";

            _outstandingBalances = new();
            _originalQtyByItemId = new();
            BindDetails(new List<MaterialIssueReturnDetails>());
            _ucAttachments?.LoadFor("MaterialIssueReturnList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditStore.Focus();
        }

        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _id : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            try
            {
                var rec = BuildHeaderEntity();
                bool isNew = _id == 0;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (isNew)
                    {
                        rec.Num = GetNextNumber(rec.ReturnDate ?? DateTime.Today);
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;
                        _id = dc.MaterialIssueReturnList.Add(rec, tx);
                    }
                    else
                    {
                        var existing = dc.MaterialIssueReturnList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync
                        dc.MaterialIssueReturnList.Edit(_id, rec, tx);
                    }

                    SaveDetails(_id, tx);
                });

                if (isNew) textEditNum.Text = MaterialIssueReturnPrinter.FormatReturnNumber(rec.Num, rec.ReturnDate);
                _rowVersion = rec.RowVersion;

                // بعد الحفظ، أصبحت هذه الكميات هي "المحفوظة أصلاً" لهذا السجل — تُحدَّث اللقطة كي يبقى
                // حساب "المتاح لإعادة الإرجاع" صحيحاً إن تابع المستخدم التعديل والحفظ مجدداً بنفس الجلسة.
                _originalQtyByItemId = _details
                    .Where(d => d.ItemId is > 0)
                    .GroupBy(d => d.ItemId!.Value)
                    .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));

                SetDirty(false);
                _anySaved = true;

                LoadList();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("MaterialIssueReturnList", _id);

                if (!silent)
                {
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
            var helper = dc.MaterialIssueReturnDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<MaterialIssueReturnDetails>();
            var toEdit = new List<MaterialIssueReturnDetails>();
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
            var row = gridView1.GetFocusedRow() as MaterialIssueReturnDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا السطر؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
            else if (e.Control && e.KeyCode == Keys.Insert)
            {
                gridView1.AddNewRow();
                e.Handled = true;
            }
        }

        /// <summary>يعبّئ الوحدة/الوصف/الكمية الصادرة غير المرتجعة تلقائياً عند اختيار صنف (سواء عبر القائمة
        /// المنسدلة أو زر الإضافة بالأسفل).</summary>
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colItem) return;
            if (gridView1.GetRow(e.RowHandle) is not MaterialIssueReturnDetails row) return;

            var itemId = e.Value as int?;
            var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
            row.Description = item?.Name;
            row.UnitId = item?.UnitId;
            row.IssuedQty = itemId.HasValue ? _outstandingBalances.GetValueOrDefault(itemId.Value) : null;

            gridView1.RefreshRow(e.RowHandle);
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) is not MaterialIssueReturnDetails row) return;

            row.Qty = 1;
            row.IsDelete = false;
        }

        /// <summary>يمنع فورياً (قبل مغادرة الخلية) كتابة كمية بعمود colQty تتجاوز ما صُرف فعلياً من هذا
        /// الصنف من المخزن ولم يُرتجَع بعد — بعد إضافة كمية الأسطر الأخرى لنفس الصنف في هذا الجدول. لا
        /// يُطبَّق قبل اختيار مخزن أو صنف للسطر (يُترك لتحقّق ValidateHeader النهائي عند الحفظ).</summary>
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn != colQty) return;
            if (lookUpEditStore.EditValue is not int storeId || storeId <= 0) return;
            if (gridView1.GetFocusedRow() is not MaterialIssueReturnDetails row) return;
            if (row.ItemId is not > 0) return;
            if (!decimal.TryParse(e.Value?.ToString(), out var newQty) || newQty <= 0) return;

            decimal available = GetAvailableQtyForItem(row.ItemId.Value, _outstandingBalances);
            decimal othersQty = _details.Where(d => d != row && d.ItemId == row.ItemId).Sum(d => d.Qty ?? 0);
            decimal remaining = available - othersQty;

            if (newQty > remaining)
            {
                e.Valid = false;
                gridView1.SetColumnError(colQty, $"الكمية أكبر من المتاح للإرجاع ({remaining:N2})");
            }
        }

        /// <summary>المتاح الفعلي لإرجاع صنف = ما صُدر منه ولم يُرتجَع بعد + ما أرجعه هذا السجل نفسه سابقاً
        /// (عند التعديل، لأن الرصيد الحالي يستثنيه أصلاً). يُستدعى بمصدر أرصدة مختلف حسب السياق: النسخة
        /// المخزَّنة مؤقتاً (_outstandingBalances) أثناء الكتابة الفورية، أو استعلام حي طازج عند الحفظ.</summary>
        private decimal GetAvailableQtyForItem(int itemId, Dictionary<int, decimal> balances) =>
            balances.GetValueOrDefault(itemId) + _originalQtyByItemId.GetValueOrDefault(itemId);

        /// <summary>colAddItem → يفتح شجرة الأصناف (frmItemSelect) لاختيار عدة أصناف دفعة واحدة، كل صنف
        /// يضيف سطراً جديداً. مقيَّد بالأصناف التي صُرفت فعلاً من هذا المخزن ولم تُرتجَع بالكامل بعد — لا
        /// يمكن إرجاع صنف لم يُصرف أصلاً، ولا الأصناف الموجودة أصلاً بجدول التفاصيل (تُستبعَد من القائمة
        /// نفسها). frmItemSelect لا يدعم تصفية إيجابية بمقياس "الصادر غير المرتجع" مباشرة، فنستبعد كل
        /// الأصناف غير المؤهلة عبر ExcludeItemIds بدلاً من ذلك.</summary>
        private void RepositoryItemButtonEditAddItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (lookUpEditStore.EditValue is not int storeId || storeId <= 0)
            {
                XtraMessageBox.Show("يرجى اختيار المخزن أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingItemIds = _details
                .Where(d => d.ItemId is > 0)
                .Select(d => d.ItemId!.Value)
                .ToHashSet();

            var eligibleItemIds = _outstandingBalances
                .Where(kv => kv.Value != 0)
                .Select(kv => kv.Key)
                .ToHashSet();

            var excludeItemIds = _itemsCache
                .Select(i => i.Id)
                .Where(id => !eligibleItemIds.Contains(id))
                .ToHashSet();
            excludeItemIds.UnionWith(existingItemIds);

            using var frm = new frmItemSelect { ExcludeItemIds = excludeItemIds };
            if (frm.ShowDialog(this) != DialogResult.OK) return;

            foreach (var item in frm.SelectedItems)
            {
                _details.Add(new MaterialIssueReturnDetails
                {
                    ItemId = item.Id,
                    UnitId = item.UnitId,
                    Description = item.Name,
                    IssuedQty = _outstandingBalances.GetValueOrDefault(item.Id)
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

        private void FetchBySearch()
        {
            string term = barEditItem1.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(term)) return;

            var found = _list.FirstOrDefault(r =>
                r.Num?.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) == true ||
                MaterialIssueReturnPrinter.FormatReturnNumber(r.Num, r.ReturnDate).Contains(term, StringComparison.OrdinalIgnoreCase));
            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{term}]", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ConfirmNavigation()) return;
            _currentIndex = _list.IndexOf(found);
            var handle = ShowOverlay();
            try { LoadRecord(found.Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (_id <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ مرتجع الصرف قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                XtraMessageBox.Show("توجد تغييرات غير محفوظة. يرجى الحفظ قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { MaterialIssueReturnPrinter.Print(_id); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The four fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditStore as DevExpress.XtraEditors.BaseEdit, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value),
            (memoEditDesrp as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditDesrp.Text)),
            (dateEditReturnedDate as DevExpress.XtraEditors.BaseEdit, dateEditReturnedDate.EditValue != null && dateEditReturnedDate.EditValue != DBNull.Value),
            (textEditReceivedBy as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(textEditReceivedBy.Text)),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user types/selects — called from each required
        /// field's EditValueChanged, independent of the next Save attempt.</summary>
        private void RevalidateField(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            if (isFilled) SetRequiredFieldState(control, true);
        }

        private bool ValidateRequiredFields()
        {
            DevExpress.XtraEditors.BaseEdit? firstInvalid = null;
            foreach (var (control, isFilled) in RequiredFieldChecks())
            {
                SetRequiredFieldState(control, isFilled);
                if (!isFilled && firstInvalid == null) firstInvalid = control;
            }

            if (firstInvalid == null) return true;

            XtraMessageBox.Show("الرجاء تعبئة كل الحقول المطلوبة (باللون الأحمر).", "بيانات ناقصة",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (!ValidateRequiredFields()) return false;

            if (_id == 0 && lookUpEditStore.EditValue is int storeId && !InventoryStorePermissions.CanIssue(dc, storeId))
            {
                XtraMessageBox.Show("ليس لديك صلاحية صرف مواد في هذا المخزن (مطلوبة لمرتجع الصرف).", "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditStore.Focus();
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة صنف واحد على الأقل في جدول الأصناف المرتجعة.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                XtraMessageBox.Show("يرجى تحديد كمية صحيحة لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            if (!ValidateReturnAvailability())
            {
                gridControl1.Focus();
                return false;
            }
            return true;
        }

        /// <summary>يمنع حفظ إرجاع كمية أكبر مما صُرف فعلياً ولم يُرتجَع بعد — يُجمَع الصنف الواحد عبر كل
        /// أسطره (قد يتكرر بأكثر من سطر بمراكز تكلفة/بنود موازنة مختلفة)، ويُقارَن بالكمية الحقيقية غير
        /// المرتجعة حالياً مضافاً إليها ما أرجعه هذا السجل نفسه سابقاً (عند التعديل)، لأنها تستثنيه أصلاً.</summary>
        private bool ValidateReturnAvailability()
        {
            if (lookUpEditStore.EditValue is not int storeId || storeId <= 0) return true; // تحقّق منه أعلاه بالفعل

            var trueBalances = StoreBalanceHelper.ComputeIssuedNotReturnedBalances(dc, storeId);

            var requestedByItem = _details
                .Where(d => d.ItemId is > 0)
                .GroupBy(d => d.ItemId!.Value)
                .Select(g => new { ItemId = g.Key, Qty = g.Sum(d => d.Qty ?? 0) });

            foreach (var req in requestedByItem)
            {
                decimal available = GetAvailableQtyForItem(req.ItemId, trueBalances);
                if (req.Qty > available)
                {
                    var itemName = _itemsCache.FirstOrDefault(i => i.Id == req.ItemId)?.Name ?? $"#{req.ItemId}";
                    XtraMessageBox.Show(
                        $"الكمية المطلوب إرجاعها من الصنف [{itemName}] ({req.Qty:N2}) أكبر من المتاح للإرجاع ({available:N2}).",
                        "تجاوز الكمية المصروفة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private MaterialIssueReturnList BuildHeaderEntity()
        {
            return new MaterialIssueReturnList
            {
                StoreId = lookUpEditStore.EditValue as int?,
                ReturnDate = DateTimeHelper.WithCurrentTime(dateEditReturnedDate.EditValue as DateTime?),
                ReturnBy = textEditReceivedBy.Text?.Trim(),
                Note = memoEditDesrp.Text?.Trim()
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number within the calendar year of the voucher's own ReturnDate — the
        /// series resets to 1 every year (see MaterialIssueReturnPrinter.FormatReturnNumber for the display format).</summary>
        private int GetNextNumber(DateTime returnDate)
        {
            return dc.MaterialIssueReturnList
                .GetBy("IsDelete = 0 AND YEAR(ReturnDate) = @year", new { year = returnDate.Year })
                .Select(r => r.Num ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"مرتجع صرف مواد رقم [{MaterialIssueReturnPrinter.FormatReturnNumber(_list[_currentIndex].Num, _list[_currentIndex].ReturnDate)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة مرتجع صرف مواد جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
        }

        private void OnHeaderChanged(object? sender, EventArgs e) => SetDirty();

        /// <summary>يعيد حساب الكمية غير المرتجعة للمخزن المختار، ويحدّث عمود colIssuedQty لكل سطر موجود
        /// بالفعل، ويُفرِّغ الجدول إن تغيَّر المخزن بعد إضافة بيانات (لأن الأرقام المعروضة كانت مرتبطة
        /// بالمخزن السابق).</summary>
        private void OnStoreChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            RefreshOutstandingBalances(lookUpEditStore.EditValue as int?);
            ClearDetailsAfterStoreChange();
        }

        private void RefreshOutstandingBalances(int? storeId)
        {
            _outstandingBalances = storeId is > 0 ? StoreBalanceHelper.ComputeIssuedNotReturnedBalances(dc, storeId.Value) : new();

            foreach (var row in _details)
                row.IssuedQty = row.ItemId is > 0 ? _outstandingBalances.GetValueOrDefault(row.ItemId.Value) : null;

            gridView1.RefreshData();
        }

        /// <summary>البنود المحفوظة أصلاً (Id > 0) تُضاف لقائمة الحذف كي تُزال فعلياً من قاعدة البيانات عند
        /// الحفظ، لا أن تختفي من الشاشة فقط.</summary>
        private void ClearDetailsAfterStoreChange()
        {
            if (_details.Count == 0) return;

            foreach (var row in _details)
                if (row.Id > 0) _deletedDetailIds.Add(row.Id);

            BindDetails(new List<MaterialIssueReturnDetails>());
            SetDirty();

            XtraMessageBox.Show(
                "تم تغيير المخزن، لذا تم تفريغ جدول الأصناف تلقائياً لأن الكميات المعروضة كانت مرتبطة بالمخزن السابق.",
                "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ── Form Closing Guard ────────────────────────────────────────────────
        private void FrmMaterialIssueReturnAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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

            // يُقرأ من ucMaterialIssueReturn.OpenAddEdit لتحديث القائمة بعد أي حفظ ناجح فقط
            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
