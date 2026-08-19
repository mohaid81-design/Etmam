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
    /// <summary>Add/Edit form for Purchase Return vouchers ("مرتجع مشتريات"): the whole document is built
    /// around picking one specific Material Receive voucher (btnMaterialReceived → frmMaterialReceiveSelect)
    /// — its header (store/supplier/voucher no./invoice no.) and remaining un-returned lines get imported
    /// wholesale, unlike Issued/Transfer/IssueReturn there's no manual item entry (colItem is locked). Each
    /// line enforces two independent caps: (1) can't return more than was received on that specific receive
    /// line (MaterialReceiveReturnProgress), and (2) can't return more than is currently in the store
    /// (StoreBalanceHelper) — if it was already issued out, it physically isn't there to hand back.</summary>
    public partial class frmPurchaseReturnAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private int _mrId = 0; // MaterialReceiveList.Id هذا المرتجع مبني عليه
        private bool _isDirty = false;
        private bool _anySaved = false;
        private bool _readOnly = false;                               // true عند الفتح من ucPurchaseReturn.btnOpen: عرض فقط، بلا تعديل أو استيراد
        private List<PurchaseReturnList> _list = new();
        private int _currentIndex = -1;

        private BindingList<PurchaseReturnDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        // رصيد الصنف الحالي بالمخزن (الكابح الأول: لا يمكن إرجاع ما صُرف بالفعل) — مفتاحه ItemId.
        private Dictionary<int, decimal> _storeBalances = new();

        // المتبقي غير المرتَجَع من كل بند بإذن الاستلام المحدد (الكابح الثاني: لا يتجاوز المستلم) —
        // مفتاحه MaterialReceiveDetails.Id (= PurchaseReturnDetails.RVDetailId).
        private Dictionary<int, decimal> _remainingByRvDetailId = new();

        // لقطتا الكميات التي كان هذا السجل نفسه قد التزم بها سابقاً — تُضافان مجدداً عند حساب "المتاح"
        // لأن كلا الرصيدين أعلاه يستثنيهما بالفعل (نفس نمط بقية نماذج هذه الدفعة).
        private Dictionary<int, decimal> _originalQtyByItemId = new();
        private Dictionary<int, decimal> _originalQtyByRvDetailId = new();

        public frmPurchaseReturnAddEdit(int id = 0)
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
            btnMaterialReceived.Click += (s, e) => SafeAction(SelectAndImportFromReceive);

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
            lookUpEditMaterialReceived.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(lookUpEditMaterialReceived, IsMaterialReceivedFilled()); };
            dateEditReturnedDate.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(dateEditReturnedDate, dateEditReturnedDate.EditValue != null && dateEditReturnedDate.EditValue != DBNull.Value); };
            memoEditDescrp.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(memoEditDescrp, !string.IsNullOrWhiteSpace(memoEditDescrp.Text)); };

            gridView1.KeyDown += GridView_KeyDown;
            gridView1.ValidatingEditor += GridView_ValidatingEditor;
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            this.FormClosing += FrmPurchaseReturnAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            // lookUpEditStore/lookUpEditSupplier مقفلان بالديزاينر (Enabled = false) — يُعبَّآن برمجياً
            // فقط من بيانات إذن الاستلام المختار، فلا حاجة لمصدر بيانات تفاعلي لهما هنا.
            RefreshMaterialReceivedLookup();
        }

        /// <summary>يعرض أذونات الاستلام التي ما زال لديها بند واحد على الأقل لم يُرتجَع بالكامل بعد فقط —
        /// نفس شرط frmMaterialReceiveSelect. includeMrId يبقي إذن الاستلام المرتبط بالسجل الحالي ظاهراً
        /// حتى لو لم يعد ضمن النتيجة (مثلاً اكتمل إرجاعه بالكامل لاحقاً).</summary>
        private void RefreshMaterialReceivedLookup(int includeMrId = 0)
        {
            var receives = dc.MaterialReceiveList
                .GetBy("IsDelete = 0")
                .Where(mr => MaterialReceiveReturnProgress.HasRemainingItems(dc, mr.Id))
                .ToList();

            if (includeMrId > 0 && receives.All(r => r.Id != includeMrId))
            {
                var current = dc.MaterialReceiveList.Find(includeMrId);
                if (current != null) receives.Add(current);
            }

            foreach (var mr in receives)
                mr.FormattedNum = MaterialReceivePrinter.FormatReceiveNumber(mr.Num, mr.ReceivedDate);

            lookUpEditMaterialReceived.Properties.DataSource = receives;
            lookUpEditMaterialReceived.Properties.ValueMember = "Id";
            lookUpEditMaterialReceived.Properties.DisplayMember = "FormattedNum";
            lookUpEditMaterialReceived.Properties.NullText = "-- اختر إذن الاستلام --";
            // الديزاينر ورّث تهيئة تنسيق تاريخ من نموذج آخر — رقم إذن الاستلام عدد صحيح وليس تاريخاً.
            lookUpEditMaterialReceived.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            lookUpEditMaterialReceived.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
        }

        private void SetupGrid()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";

            // عمود عرض غير مرتبط بالديزاينر (بلا FieldName) — الكمية الأصلية المستلمة لهذا البند.
            colReceivedQty.FieldName = "ReceivedQty";
            colReceivedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colReceivedQty.DisplayFormat.FormatString = "n2";

            // لا يوجد إدخال يدوي لبنود هذا المستند (colItem مقفل بالديزاينر أصلاً) — الاستيراد من إذن
            // استلام مختار هو الطريقة الوحيدة لإضافة سطر، فنترك NewItemRowPosition على افتراضه (None).
            BindDetails(new List<PurchaseReturnDetails>());
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
            _list = dc.PurchaseReturnList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.ReturnDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.PurchaseReturnList.Find(id);
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

            textEditNum.Text = PurchaseReturnPrinter.FormatReturnNumber(rec.Code, rec.ReturnDate);
            dateEditReturnedDate.EditValue = rec.ReturnDate;
            lookUpEditStore.EditValue = rec.StoreId;
            lookUpEditSupplier.EditValue = rec.StakeholderId;
            textEditInvoiceNo.Text = rec.InvoiceNo ?? "";
            memoEditDescrp.Text = rec.Note ?? "";

            _mrId = rec.MRId ?? 0;
            var mr = _mrId > 0 ? dc.MaterialReceiveList.Find(_mrId) : null;
            textEditVoucherNo.Text = mr?.VoucherNo ?? "";

            RefreshMaterialReceivedLookup(_mrId);
            lookUpEditMaterialReceived.EditValue = _mrId > 0 ? _mrId : null;

            LoadDetails(id);
            RefreshCaps(rec.StoreId, _mrId);
            _ucAttachments?.LoadFor("PurchaseReturnList", _id);

            UpdateNavigatorCaption();
            SetDirty(false);
            SetEditLock(_readOnly);
        }

        /// <summary>يفتح السجل المحدَّد بعرض فقط (بلا حفظ أو استيراد من إذن استلام) — نقطة الدخول المستخدمة
        /// من btnOpen في ucPurchaseReturn، بديلاً عن الفتح الكامل للتعديل (bbiEdit).</summary>
        public void OpenReadOnly(int id)
        {
            _readOnly = true;
            LoadRecord(id);
            bbiNew.Enabled = false;
        }

        /// <summary>يقفل/يحرِّر حقول الترويسة وزر استيراد إذن الاستلام وجدول الأصناف وزر الحفظ معاً —
        /// يُستدعى من LoadRecord في كل مرة (كي يبقى القفل قائماً أثناء التنقل بين السجلات في وضع العرض
        /// فقط) وعند الدخول لوضع العرض فقط أول مرة. لا يوجد عمود "إضافة" هنا (البنود تُستورَد حصراً من
        /// إذن استلام، انظر SelectAndImportFromReceive)، فيكفي قفل lookUpEditMaterialReceived وbtnMaterialReceived.</summary>
        private void SetEditLock(bool locked)
        {
            dateEditReturnedDate.Properties.ReadOnly = locked;
            memoEditDescrp.Properties.ReadOnly = locked;
            lookUpEditMaterialReceived.Properties.ReadOnly = locked;
            btnMaterialReceived.Enabled = !locked;

            gridView1.OptionsBehavior.Editable = !locked;
            colDeleteItem.Visible = !locked;

            bbiSave.Enabled = !locked;
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.PurchaseReturnDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            // كلا الرصيدين الحقيقيين (رصيد المخزن + المتبقي بإذن الاستلام) يستثني أصلاً ما التزم به هذا
            // السجل سابقاً، فنحتفظ بكمياته الأصلية هنا كي "تُضاف" مجدداً عند حساب المتاح لإعادة الإرجاع.
            _originalQtyByItemId = list
                .Where(d => d.ItemId is > 0)
                .GroupBy(d => d.ItemId!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));

            _originalQtyByRvDetailId = list
                .Where(d => d.RVDetailId is > 0)
                .ToDictionary(d => d.RVDetailId!.Value, d => d.Qty ?? 0);

            // إعادة تعبئة عمود "الكمية المستلمة" (غير مخزَّن، يُعاد حسابه من بيانات إذن الاستلام الأصلية)
            var rvDetailIds = list.Where(d => d.RVDetailId is > 0).Select(d => d.RVDetailId!.Value).ToList();
            if (rvDetailIds.Count > 0)
            {
                var originals = dc.MaterialReceiveDetails
                    .GetBy($"Id IN ({string.Join(",", rvDetailIds)})")
                    .ToDictionary(d => d.Id);

                foreach (var d in list)
                    if (d.RVDetailId is > 0 && originals.TryGetValue(d.RVDetailId.Value, out var orig))
                        d.ReceivedQty = orig.Qty;
            }

            BindDetails(list);
        }

        private void BindDetails(List<PurchaseReturnDetails> source)
        {
            _details = new BindingList<PurchaseReturnDetails>(source);
            gridControl1.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save / Delete) ──────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _mrId = 0;
            _deletedDetailIds.Clear();
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = "جديد";
            dateEditReturnedDate.EditValue = DateTime.Today;
            lookUpEditStore.EditValue = null;
            lookUpEditSupplier.EditValue = null;
            textEditVoucherNo.Text = "";
            textEditInvoiceNo.Text = "";
            memoEditDescrp.Text = "";

            RefreshMaterialReceivedLookup();
            lookUpEditMaterialReceived.EditValue = null;

            _storeBalances = new();
            _remainingByRvDetailId = new();
            _originalQtyByItemId = new();
            _originalQtyByRvDetailId = new();
            BindDetails(new List<PurchaseReturnDetails>());
            _ucAttachments?.LoadFor("PurchaseReturnList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);
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
                rec.Amount = _details.Sum(d => d.TotalPrice ?? 0);
                bool isNew = _id == 0;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (isNew)
                    {
                        rec.Code = GetNextCode(rec.ReturnDate ?? DateTime.Today);
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;
                        _id = dc.PurchaseReturnList.Add(rec, tx);
                    }
                    else
                    {
                        var existing = dc.PurchaseReturnList.Find(_id);
                        rec.Code = existing?.Code;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync
                        dc.PurchaseReturnList.Edit(_id, rec, tx);
                    }

                    SaveDetails(_id, tx);
                });

                if (isNew) textEditNum.Text = PurchaseReturnPrinter.FormatReturnNumber(rec.Code, rec.ReturnDate);
                _rowVersion = rec.RowVersion;

                // بعد الحفظ، أصبحت هذه الكميات هي "المحفوظة أصلاً" لهذا السجل — تُحدَّث اللقطتان كي يبقى
                // حساب "المتاح لإعادة الإرجاع" صحيحاً إن تابع المستخدم التعديل والحفظ مجدداً بنفس الجلسة.
                _originalQtyByItemId = _details
                    .Where(d => d.ItemId is > 0)
                    .GroupBy(d => d.ItemId!.Value)
                    .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));
                _originalQtyByRvDetailId = _details
                    .Where(d => d.RVDetailId is > 0)
                    .ToDictionary(d => d.RVDetailId!.Value, d => d.Qty ?? 0);

                SetDirty(false);
                _anySaved = true;

                LoadList();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("PurchaseReturnList", _id);

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
            var helper = dc.PurchaseReturnDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<PurchaseReturnDetails>();
            var toEdit = new List<PurchaseReturnDetails>();
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
            var row = gridView1.GetFocusedRow() as PurchaseReturnDetails;
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
        }

        /// <summary>يمنع فورياً (قبل مغادرة الخلية) كتابة كمية بعمود colQty تتجاوز أحد الكابحين: (1) المتبقي
        /// غير المرتجَع من نفس بند الاستلام المصدر لهذا السطر، أو (2) رصيد الصنف الحالي بالمخزن (بعد جمع
        /// كميات باقي أسطر نفس الصنف في هذا الجدول) — أيهما أصغر.</summary>
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn != colQty) return;
            if (gridView1.GetFocusedRow() is not PurchaseReturnDetails row) return;
            if (row.ItemId is not > 0 || row.RVDetailId is not > 0) return;
            if (!decimal.TryParse(e.Value?.ToString(), out var newQty) || newQty <= 0) return;

            decimal capReceived = GetAvailableForRvDetail(row.RVDetailId.Value);

            decimal capStoreAvailable = GetAvailableQtyForItem(row.ItemId.Value, _storeBalances);
            decimal othersQtySameItem = _details.Where(d => d != row && d.ItemId == row.ItemId).Sum(d => d.Qty ?? 0);
            decimal capStore = capStoreAvailable - othersQtySameItem;

            decimal remaining = Math.Min(capReceived, capStore);

            if (newQty > remaining)
            {
                e.Valid = false;
                gridView1.SetColumnError(colQty, $"الكمية أكبر من المتاح للإرجاع ({remaining:N2})");
            }
        }

        private decimal GetAvailableForRvDetail(int rvDetailId) =>
            _remainingByRvDetailId.GetValueOrDefault(rvDetailId) + _originalQtyByRvDetailId.GetValueOrDefault(rvDetailId);

        private decimal GetAvailableQtyForItem(int itemId, Dictionary<int, decimal> balances) =>
            balances.GetValueOrDefault(itemId) + _originalQtyByItemId.GetValueOrDefault(itemId);

        /// <summary>btnMaterialReceived → يفتح نافذة اختيار إذن استلام (frmMaterialReceiveSelect)، مقيَّدة
        /// بأذونات الاستلام التي ما زال لديها بند واحد على الأقل لم يُرتجَع بالكامل بعد — ثم يستورد بيانات
        /// رأسه وبنوده المتبقية مباشرة.</summary>
        private void SelectAndImportFromReceive()
        {
            using var frm = new frmMaterialReceiveSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedReceive == null) return;

            RefreshMaterialReceivedLookup(frm.SelectedReceive.Id);
            lookUpEditMaterialReceived.EditValue = frm.SelectedReceive.Id;
            ImportFromReceive();
        }

        /// <summary>يجلب بنود إذن الاستلام المختار المتبقية (غير المرتجَعة بالكامل بعد) دفعة واحدة إلى جدول
        /// الأصناف المرتجعة، ويملأ حقول الرأس (المخزن/المورد/رقم المستند/رقم الفاتورة) من نفس الإذن —
        /// يتجاهل أي بند سبق استيراده (RVDetailId) لتفادي التكرار عند الضغط أكثر من مرة.</summary>
        private void ImportFromReceive()
        {
            if (lookUpEditMaterialReceived.EditValue is not int mrId || mrId <= 0)
            {
                XtraMessageBox.Show("يرجى اختيار إذن الاستلام أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mr = dc.MaterialReceiveList.Find(mrId);
            if (mr == null) return;

            _mrId = mrId;
            lookUpEditStore.EditValue = mr.StoreId;
            lookUpEditSupplier.EditValue = mr.StakeholderId;
            textEditVoucherNo.Text = mr.VoucherNo ?? "";
            textEditInvoiceNo.Text = mr.InvoiceNo ?? "";

            RefreshCaps(mr.StoreId, mrId);

            var alreadyImported = _details
                .Where(d => d.RVDetailId.HasValue)
                .Select(d => d.RVDetailId!.Value)
                .ToHashSet();

            var lines = dc.MaterialReceiveDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id = mrId })
                .Where(l => !alreadyImported.Contains(l.Id))
                .Where(l => _remainingByRvDetailId.GetValueOrDefault(l.Id) > 0)
                .ToList();

            if (lines.Count == 0)
            {
                XtraMessageBox.Show("لا توجد بنود جديدة لاستيرادها من إذن الاستلام المحدد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var line in lines)
            {
                _details.Add(new PurchaseReturnDetails
                {
                    RVDetailId = line.Id,
                    ItemId = line.ItemId,
                    Description = line.Description,
                    UnitId = line.UnitId,
                    ReceivedQty = line.Qty,
                    Qty = _remainingByRvDetailId.GetValueOrDefault(line.Id)
                });
            }

            SetDirty();
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
                r.Code?.Contains(term, StringComparison.OrdinalIgnoreCase) == true ||
                PurchaseReturnPrinter.FormatReturnNumber(r.Code, r.ReturnDate).Contains(term, StringComparison.OrdinalIgnoreCase));
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
                XtraMessageBox.Show("يرجى حفظ مرتجع المشتريات قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                XtraMessageBox.Show("توجد تغييرات غير محفوظة. يرجى الحفظ قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { PurchaseReturnPrinter.Print(_id); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>مرتبط بـ _mrId وليس فقط بقيمة الحقل نفسه — الحقل والمتغيّر يُحدَّثان معاً دوماً
        /// (انظر ImportFromReceive وLoadRecord)، وهذا هو نفس شرط التحقّق الأصلي قبل الدمج.</summary>
        private bool IsMaterialReceivedFilled() =>
            _mrId > 0 && lookUpEditMaterialReceived.EditValue != null && lookUpEditMaterialReceived.EditValue != DBNull.Value;

        /// <summary>The three fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditMaterialReceived as DevExpress.XtraEditors.BaseEdit, IsMaterialReceivedFilled()),
            (memoEditDescrp as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditDescrp.Text)),
            (dateEditReturnedDate as DevExpress.XtraEditors.BaseEdit, dateEditReturnedDate.EditValue != null && dateEditReturnedDate.EditValue != DBNull.Value),
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

            if (lookUpEditStore.EditValue == null || lookUpEditStore.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("تعذّر تحديد المخزن من إذن الاستلام المختار.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_id == 0 && lookUpEditStore.EditValue is int storeId && !InventoryStorePermissions.CanReceive(dc, storeId))
            {
                XtraMessageBox.Show("ليس لديك صلاحية استلام مواد في هذا المخزن (مطلوبة لمرتجع المشتريات).", "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lookUpEditSupplier.EditValue == null || lookUpEditSupplier.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("تعذّر تحديد المورد من إذن الاستلام المختار.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى استيراد صنف واحد على الأقل من إذن الاستلام.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        /// <summary>يمنع حفظ إرجاع كمية تتجاوز أحد الكابحين: (1) الكمية المستلمة الفعلية لكل بند بإذن
        /// الاستلام (بعد طرح ما أُرجع منها في مستندات أخرى)، أو (2) رصيد الصنف الحقيقي الحالي بالمخزن —
        /// مُجمَّعاً لكل صنف عبر كل أسطره، لأن نفس الصنف قد يصل عبر أكثر من بند استلام.</summary>
        private bool ValidateReturnAvailability()
        {
            if (_mrId <= 0) return true; // تحقّق منه أعلاه بالفعل
            if (lookUpEditStore.EditValue is not int storeId || storeId <= 0) return true;

            var remainingByRvDetailId = MaterialReceiveReturnProgress.ComputeRemainingByDetailId(dc, _mrId);
            var trueBalances = StoreBalanceHelper.ComputeBalances(dc, storeId);

            foreach (var row in _details.Where(d => d.RVDetailId is > 0))
            {
                decimal available = remainingByRvDetailId.GetValueOrDefault(row.RVDetailId!.Value)
                    + _originalQtyByRvDetailId.GetValueOrDefault(row.RVDetailId.Value);

                if ((row.Qty ?? 0) > available)
                {
                    var itemName = _itemsCache.FirstOrDefault(i => i.Id == row.ItemId)?.Name ?? $"#{row.ItemId}";
                    XtraMessageBox.Show(
                        $"الكمية المرتجعة من الصنف [{itemName}] ({row.Qty:N2}) أكبر من الكمية المستلمة المتاحة للإرجاع ({available:N2}).",
                        "تجاوز الكمية المستلمة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

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
                        $"الكمية المطلوب إرجاعها من الصنف [{itemName}] ({req.Qty:N2}) أكبر من المتاح فعلياً بالمخزن ({available:N2}) — على الأرجح صُرف جزء منها بالفعل.",
                        "تجاوز رصيد المخزون", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private PurchaseReturnList BuildHeaderEntity()
        {
            return new PurchaseReturnList
            {
                MRId = _mrId > 0 ? _mrId : null,
                StoreId = lookUpEditStore.EditValue as int?,
                StakeholderId = lookUpEditSupplier.EditValue as int?,
                ReturnDate = DateTimeHelper.WithCurrentTime(dateEditReturnedDate.EditValue as DateTime?),
                InvoiceNo = textEditInvoiceNo.Text?.Trim(),
                Note = memoEditDescrp.Text?.Trim(),
                PrjId = Session.SelectedProjectId
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number within the calendar year of the return's own ReturnDate — the
        /// series resets to 1 every year (see PurchaseReturnPrinter.FormatReturnNumber for the display format).
        /// Code is a numeric string here (unlike the other voucher types' int Num), so the year scoping is
        /// done in-memory against ReturnDate rather than a SQL YEAR() filter.</summary>
        private string GetNextCode(DateTime returnDate)
        {
            int maxCode = 0;
            foreach (var r in dc.PurchaseReturnList.GetBy("IsDelete = 0"))
                if (r.ReturnDate?.Year == returnDate.Year && int.TryParse(r.Code, out int c) && c > maxCode) maxCode = c;

            return (maxCode + 1).ToString();
        }

        private void RefreshCaps(int? storeId, int mrId)
        {
            _storeBalances = storeId is > 0 ? StoreBalanceHelper.ComputeBalances(dc, storeId.Value) : new();
            _remainingByRvDetailId = mrId > 0 ? MaterialReceiveReturnProgress.ComputeRemainingByDetailId(dc, mrId) : new();
        }

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"مرتجع مشتريات رقم [{PurchaseReturnPrinter.FormatReturnNumber(_list[_currentIndex].Code, _list[_currentIndex].ReturnDate)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة مرتجع مشتريات جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
        }

        private void OnHeaderChanged(object? sender, EventArgs e) => SetDirty();

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
        private void FrmPurchaseReturnAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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

            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
