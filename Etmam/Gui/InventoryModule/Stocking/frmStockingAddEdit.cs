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
    /// <summary>Add/Edit form for physical stock count vouchers ("جرد المخزون"): header (store/date) + a
    /// counted-items grid comparing the system/book balance (<see cref="StoreBalanceHelper.ComputeBalances"/>)
    /// against the physically counted quantity. This is a reconciliation record only — saving it does NOT
    /// feed back into <see cref="StoreBalanceHelper"/> as a movement, so it never changes what other
    /// documents (Issued/Transfer/...) compute as available stock. SystemQty/UnitPrice are captured and
    /// persisted per line at the moment each row is added, not recomputed on reopen, so a saved count stays
    /// a stable historical snapshot even if other movements happen afterwards.</summary>
    public partial class frmStockingAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private bool _readOnly = false;                               // true عند الفتح من ucStocking.btnOpen: عرض فقط، بلا تعديل أو إضافة
        private List<StockingList> _list = new();
        private int _currentIndex = -1;

        private BindingList<StockingDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        // رصيد كل صنف في المخزن المختار حالياً — يُستخدم فقط كمرجع عند إضافة سطر جديد (يدوياً أو عبر
        // الاختيار الجماعي)؛ لا يُعاد تطبيقه على أسطر محفوظة أصلاً (انظر SystemQty في StockingDetails).
        private Dictionary<int, decimal> _storeBalances = new();

        public frmStockingAddEdit(int id = 0)
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

            // الحقلان المطلوبان (خلفية خضراء) — يُعادان للأخضر تلقائياً فور تعبئتهما إن كانا قد تحوّلا
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditStore.EditValueChanged += (s, e) => { OnStoreChanged(s, e); RevalidateField(lookUpEditStore, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value); };
            dateEditStockingDate.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(dateEditStockingDate, dateEditStockingDate.EditValue != null && dateEditStockingDate.EditValue != DBNull.Value); };

            gridView1.CellValueChanged += GridView_CellValueChanged;
            gridView1.InitNewRow += GridView_InitNewRow;
            gridView1.KeyDown += GridView_KeyDown;
            repositoryItemButtonEditAddItem.ButtonClick += RepositoryItemButtonEditAddItem_ButtonClick;
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            this.FormClosing += FrmStockingAddEdit_FormClosing;
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

            // أعمدة عرض أضافها المستخدم مسبقاً في الديزاينر بلا FieldName — نربطها هنا بالحقول الفعلية
            // (نفس نهج colStockQty في frmMaterialIssuedAddEdit).
            colStockQty.FieldName = "SystemQty";
            colStockQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colStockQty.DisplayFormat.FormatString = "n2";

            gridColumn1.FieldName = "Difference";
            gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn1.DisplayFormat.FormatString = "n2";

            gridColumn2.FieldName = "UnitPrice";
            gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn2.DisplayFormat.FormatString = "n2";

            gridColumn3.FieldName = "DifferenceValue";
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn3.DisplayFormat.FormatString = "n2";

            colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colQty.DisplayFormat.FormatString = "n2";

            // الافتراضي في DevExpress هو NewItemRowPosition.None (بلا سطر إضافة أصلاً) — يجب تفعيله
            // صراحة كي يستطيع المستخدم الكتابة المباشرة في سطر جديد أسفل الشبكة.
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            BindDetails(new List<StockingDetails>());
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
            _list = dc.StockingList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.StockingDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var entity = dc.StockingList.Find(id);
            if (entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewRecord();
                return;
            }

            _id = id;
            _rowVersion = entity.RowVersion;
            _isDirty = false; // إيقاف تتبع التعديلات مؤقتاً أثناء تعبئة الحقول

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = StockingPrinter.FormatStockingNumber(entity.Num);
            dateEditStockingDate.EditValue = entity.StockingDate;

            // نغيّر المخزن دون تفعيل OnStoreChanged (يُفرِّغ الجدول) — سيُعاد تعبئته بالأسطر المحفوظة
            // مباشرة بعد ذلك عبر LoadDetails.
            lookUpEditStore.EditValueChanged -= OnStoreChanged;
            lookUpEditStore.EditValue = entity.StoreId;
            lookUpEditStore.EditValueChanged += OnStoreChanged;

            LoadDetails(id);
            RefreshStoreBalancesCache(entity.StoreId);
            _ucAttachments?.LoadFor("StockingList", _id);

            UpdateNavigatorCaption();
            SetDirty(false);
            SetEditLock(_readOnly);
        }

        /// <summary>يفتح السجل المحدَّد بعرض فقط (بلا حفظ أو إضافة/حذف أصناف) — نقطة الدخول المستخدمة من
        /// btnOpen في ucStocking، بديلاً عن الفتح الكامل للتعديل (bbiEdit).</summary>
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
            dateEditStockingDate.Properties.ReadOnly = locked;

            gridView1.OptionsBehavior.Editable = !locked;
            gridView1.OptionsView.NewItemRowPosition = locked ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            colAddItem.Visible = !locked;
            colDeleteItem.Visible = !locked;

            bbiSave.Enabled = !locked;
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.StockingDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            foreach (var row in list) RecalculateRow(row);

            BindDetails(list);
        }

        private void BindDetails(List<StockingDetails> source)
        {
            _details = new BindingList<StockingDetails>(source);
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
            dateEditStockingDate.EditValue = DateTime.Today;

            lookUpEditStore.EditValueChanged -= OnStoreChanged;
            lookUpEditStore.EditValue = null;
            lookUpEditStore.EditValueChanged += OnStoreChanged;

            _storeBalances = new();
            BindDetails(new List<StockingDetails>());
            _ucAttachments?.LoadFor("StockingList", 0);

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
                        rec.Num = GetNextNumber();
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;
                        _id = dc.StockingList.Add(rec, tx);
                    }
                    else
                    {
                        var existing = dc.StockingList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync
                        dc.StockingList.Edit(_id, rec, tx);
                    }

                    SaveDetails(_id, tx);
                });

                if (isNew) textEditNum.Text = StockingPrinter.FormatStockingNumber(rec.Num);
                _rowVersion = rec.RowVersion;

                SetDirty(false);
                _anySaved = true;

                LoadList();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("StockingList", _id);

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
            var helper = dc.StockingDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<StockingDetails>();
            var toEdit = new List<StockingDetails>();
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
            var row = gridView1.GetFocusedRow() as StockingDetails;
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

        /// <summary>يعبّئ الوحدة/الوصف/الرصيد الدفتري/سعر الوحدة تلقائياً عند اختيار صنف (سواء عبر القائمة
        /// المنسدلة أو زر الإضافة بالأسفل)، ويُعيد حساب الفرق وقيمته عند أي تغيير على الصنف أو الكمية
        /// الفعلية.</summary>
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) is not StockingDetails row) return;

            if (e.Column == colItem)
            {
                var itemId = e.Value as int?;
                var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
                row.Description = item?.Name;
                row.UnitId = item?.UnitId;
                row.SystemQty = itemId.HasValue ? _storeBalances.GetValueOrDefault(itemId.Value) : null;
                row.UnitPrice = itemId.HasValue ? GetLastUnitPrice(itemId.Value) : null;
                row.Qty ??= row.SystemQty; // نبدأ بافتراض عدم وجود فرق؛ يُعدِّله من يقوم بالجرد الفعلي
            }
            else if (e.Column != colQty)
            {
                return;
            }

            RecalculateRow(row);
            gridView1.RefreshRow(e.RowHandle);
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (gridView1.GetRow(e.RowHandle) is not StockingDetails row) return;
            row.IsDelete = false;
        }

        /// <summary>colAddItem → يفتح شجرة الأصناف (frmItemSelect) لاختيار عدة أصناف دفعة واحدة. لا يُقيَّد
        /// بالمخزن (خلافاً لإذن الصرف/التحويل) لأن الجرد يجب أن يسمح بإضافة أي صنف — حتى ما رصيده الدفتري
        /// صفر — كي يُكشَف أي فرق فعلي (زيادة غير مسجَّلة). تُستبعَد فقط الأصناف الموجودة أصلاً بالجدول.</summary>
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

            using var frm = new frmItemSelect { ExcludeItemIds = existingItemIds };
            if (frm.ShowDialog(this) != DialogResult.OK) return;

            foreach (var item in frm.SelectedItems)
            {
                var systemQty = _storeBalances.GetValueOrDefault(item.Id);
                var row = new StockingDetails
                {
                    ItemId = item.Id,
                    UnitId = item.UnitId,
                    Description = item.Name,
                    SystemQty = systemQty,
                    UnitPrice = GetLastUnitPrice(item.Id),
                    Qty = systemQty // نبدأ بافتراض عدم وجود فرق؛ يُعدِّله من يقوم بالجرد الفعلي
                };
                RecalculateRow(row);
                _details.Add(row);
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

            var found = _list.FirstOrDefault(r => r.Num?.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) == true);
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
                XtraMessageBox.Show("يرجى حفظ الجرد قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                XtraMessageBox.Show("توجد تغييرات غير محفوظة. يرجى الحفظ قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { StockingPrinter.Print(_id); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The two fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditStore as DevExpress.XtraEditors.BaseEdit, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value),
            (dateEditStockingDate as DevExpress.XtraEditors.BaseEdit, dateEditStockingDate.EditValue != null && dateEditStockingDate.EditValue != DBNull.Value),
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

            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة صنف واحد على الأقل في جدول الجرد.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null || d.Qty < 0))
            {
                XtraMessageBox.Show("يرجى تحديد الكمية الفعلية المجرودة لكل سطر في الجدول (لا تقبل قيمة سالبة).", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private StockingList BuildHeaderEntity()
        {
            return new StockingList
            {
                StoreId = lookUpEditStore.EditValue as int?,
                StockingDate = dateEditStockingDate.EditValue as DateTime?
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetNextNumber()
        {
            return dc.StockingList
                .GetBy("IsDelete = 0")
                .Select(r => r.Num ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        /// <summary>آخر سعر وحدة مسجَّل لهذا الصنف من أوامر الاستلام (أقرب مصدر تكلفة موجود فعلاً بالنظام؛
        /// لا يوجد حالياً حقل سعر مخزَّن مباشرة على الصنف نفسه).</summary>
        private decimal? GetLastUnitPrice(int itemId)
        {
            return dc.MaterialReceiveDetails
                .GetBy("ItemId = @itemId AND IsDelete = 0", new { itemId })
                .Where(d => d.UnitPrice is > 0)
                .OrderByDescending(d => d.Id)
                .Select(d => d.UnitPrice)
                .FirstOrDefault();
        }

        private void RecalculateRow(StockingDetails row)
        {
            row.Difference = (row.Qty ?? 0) - (row.SystemQty ?? 0);
            row.DifferenceValue = row.Difference * (row.UnitPrice ?? 0);
        }

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"جرد مخزون رقم [{_list[_currentIndex].Num}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة جرد مخزون جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
        }

        private void OnHeaderChanged(object? sender, EventArgs e) => SetDirty();

        /// <summary>الأرصدة المعروضة كانت محسوبة على المخزن السابق — لم تعد صالحة بعد تغييره، فيُفرَّغ
        /// الجدول بدل ترك بيانات مضلِّلة (نفس نهج frmMaterialTransferAddEdit عند تغيير مخزن المصدر). البنود
        /// المحفوظة أصلاً (Id > 0) تُضاف لقائمة الحذف كي تُزال فعلياً من قاعدة البيانات عند الحفظ.</summary>
        private void OnStoreChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);

            if (_details.Count > 0)
            {
                foreach (var row in _details)
                    if (row.Id > 0) _deletedDetailIds.Add(row.Id);

                BindDetails(new List<StockingDetails>());
                SetDirty();

                XtraMessageBox.Show(
                    "تم تغيير المخزن، لذا تم تفريغ جدول الجرد تلقائياً لأن الأرصدة الدفترية المعروضة كانت مرتبطة بالمخزن السابق.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshStoreBalancesCache(lookUpEditStore.EditValue as int?);
        }

        private void RefreshStoreBalancesCache(int? storeId)
        {
            _storeBalances = storeId is > 0 ? StoreBalanceHelper.ComputeBalances(dc, storeId.Value) : new();
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
        private void FrmStockingAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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

            // يُقرأ من ucStocking.OpenAddEdit لتحديث القائمة بعد أي حفظ ناجح فقط
            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
