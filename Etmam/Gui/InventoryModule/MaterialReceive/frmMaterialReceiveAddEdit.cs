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
    /// <summary>Add/Edit form for Material Receive vouchers ("إذن استلام مواد"): header (store/supplier/
    /// invoice/voucher, linked Purchase Order) + a received-items grid. Lines are imported exclusively from
    /// the linked Purchase Order via ImportFromPO — same PO-only-lines restriction as
    /// frmPurchaseOrderAddEdit's own PR-linked grid; no manual row entry.</summary>
    public partial class frmMaterialReceiveAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private bool _loadingHeader = false;                          // suppresses PO auto-import while LoadRecord/NewRecord assign lookUpEditPO.EditValue
        private bool _readOnly = false;                               // true عند الفتح من ucMaterialReceive.btnOpen: عرض فقط، بلا تعديل أو استيراد
        private List<MaterialReceiveList> _list = new();
        private int _currentIndex = -1;

        private BindingList<MaterialReceiveDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        public frmMaterialReceiveAddEdit(int id = 0)
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
            btnPO.Click += (s, e) => SafeAction(SelectAndImportFromPO);

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItem1.EditValue != null)
                    FetchBySearch();
            };

            lookUpEditStore.EditValueChanged += OnHeaderChanged;
            lookUpEditSupplier.EditValueChanged += OnHeaderChanged;
            dateEditReceivedDate.EditValueChanged += OnHeaderChanged;
            textEditInvoiceNo.EditValueChanged += OnHeaderChanged;
            textEditVoucherNo.EditValueChanged += OnHeaderChanged;
            memoEditDescrp.EditValueChanged += OnHeaderChanged;
            lookUpEditPO.EditValueChanged += OnPOLookupChanged;

            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditStore.EditValueChanged += (s, e) => RevalidateField(lookUpEditStore, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value);
            dateEditReceivedDate.EditValueChanged += (s, e) => RevalidateField(dateEditReceivedDate, dateEditReceivedDate.EditValue != null && dateEditReceivedDate.EditValue != DBNull.Value);
            memoEditDescrp.EditValueChanged += (s, e) => RevalidateField(memoEditDescrp, !string.IsNullOrWhiteSpace(memoEditDescrp.Text));
            lookUpEditPO.EditValueChanged += (s, e) => RevalidateField(lookUpEditPO, lookUpEditPO.EditValue != null && lookUpEditPO.EditValue != DBNull.Value);

            gv.CellValueChanged += GridView_CellValueChanged;
            gv.KeyDown += GridView_KeyDown;
            gv.ValidatingEditor += GridView_ValidatingEditor;
            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            this.FormClosing += FrmMaterialReceiveAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            lookUpEditStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- اختر المخزن --";

            lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.Properties.ValueMember = "Id";
            lookUpEditSupplier.Properties.DisplayMember = "Name";
            lookUpEditSupplier.Properties.NullText = "-- اختر المورد --";
            lookUpEditSupplier.Enabled = true; // الديزاينر يعطّله افتراضياً؛ هذا الحقل يتطلب اختياراً يدوياً

            RefreshPOLookup();
        }

        /// <summary>يعرض أوامر الشراء المعتمدة التي ما زال لديها بند واحد على الأقل لم يُستلم بالكامل بعد
        /// فقط في حقل "أمر الشراء المرجعي" — نفس شرط frmPurchaseOrderSelect (استلام بضاعة غير معتمدة
        /// أمرها لا معنى له، وكذلك أمر اكتمل استلامه بالكامل). includePOId يبقي أمر الشراء المرتبط
        /// بالسجل الحالي ظاهراً حتى لو لم يعد ضمن النتيجة (مثلاً اكتمل استلامه أو أُغلق لاحقاً).</summary>
        private void RefreshPOLookup(int includePOId = 0)
        {
            var pos = dc.PurchaseOrderList
                .GetBy("IsDelete = 0 AND OverallStatus = @s", new { s = PurchaseOrderStatus.Approved })
                .Where(po => PurchaseOrderReceiveProgress.HasRemainingItems(dc, po.Id))
                .ToList();

            if (includePOId > 0 && pos.All(p => p.Id != includePOId))
            {
                var current = dc.PurchaseOrderList.Find(includePOId);
                if (current != null) pos.Add(current);
            }

            foreach (var po in pos)
                po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

            lookUpEditPO.Properties.DataSource = pos;
            lookUpEditPO.Properties.ValueMember = "Id";
            lookUpEditPO.Properties.DisplayMember = "FormattedNum";
            lookUpEditPO.Properties.NullText = "-- اختر --";
            // الديزاينر ورّث تهيئة تنسيق تاريخ من نموذج آخر — رقم أمر الشراء عدد صحيح وليس تاريخاً.
            lookUpEditPO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            lookUpEditPO.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
        }

        private void SetupGrid()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            repositoryItemLookUpEditItem.DataSource = _itemsCache;
            repositoryItemLookUpEditItem.ValueMember = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText = "";

            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";

            // بنود إذن الاستلام تُستورد حصراً من أمر الشراء المرتبط (ImportFromPO) — لا يُسمح بإضافة سطر
            // يدوياً، نفس نمط colItem في frmPurchaseOrderAddEdit (الديزاينر يمنع التحرير/التركيز أصلاً).
            gv.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            BindDetails(new List<MaterialReceiveDetails>());
        }

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab's navigation frame.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments, navigationFrame1);
            _ucAttachments.SaveRequired += SaveAndReturnId;
        }

        private void SetupNavigationPage(UserControl control, DevExpress.XtraBars.Navigation.NavigationFrame frame)
        {
            control.Dock = DockStyle.Fill;
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(control);
            frame.Pages.Add(page);
            frame.SelectedPage = page;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void LoadList()
        {
            _list = dc.MaterialReceiveList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.ReceivedDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var entity = dc.MaterialReceiveList.Find(id);
            if (entity == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل المطلوب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewRecord();
                return;
            }

            _id = id;
            _rowVersion = entity.RowVersion;
            _isDirty = false; // إيقاف تتبع التعديلات مؤقتاً أثناء تعبئة الحقول

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف/جديد.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _loadingHeader = true; // تحميل سجل موجود لا يجب أن يُطلق الاستيراد التلقائي لبنود أمر الشراء
            textEditNum.Text = MaterialReceivePrinter.FormatReceiveNumber(entity.Num, entity.ReceivedDate);
            dateEditReceivedDate.EditValue = entity.ReceivedDate;
            lookUpEditStore.EditValue = entity.StoreId;
            lookUpEditSupplier.EditValue = entity.StakeholderId;
            RefreshPOLookup(entity.POId ?? 0);
            lookUpEditPO.EditValue = entity.POId;
            textEditInvoiceNo.Text = entity.InvoiceNo ?? "";
            textEditVoucherNo.Text = entity.VoucherNo ?? "";
            memoEditDescrp.Text = entity.Description ?? "";
            _loadingHeader = false;

            LoadDetails(id);
            _ucAttachments?.LoadFor("MaterialReceiveList", _id);

            UpdateNavigatorCaption();
            SetDirty(false);
            SetEditLock(_readOnly);
        }

        /// <summary>يفتح السجل المحدَّد بعرض فقط (بلا حفظ أو استيراد من أمر شراء) — نقطة الدخول المستخدمة من
        /// btnOpen في ucMaterialReceive، بديلاً عن الفتح الكامل للتعديل (bbiEdit).</summary>
        public void OpenReadOnly(int id)
        {
            _readOnly = true;
            LoadRecord(id);
            bbiNew.Enabled = false;
        }

        /// <summary>يقفل/يحرِّر حقول الترويسة (بما فيها أمر الشراء المرجعي) وجدول الأصناف وزر الحفظ معاً —
        /// يُستدعى من LoadRecord في كل مرة (كي يبقى القفل قائماً أثناء التنقل بين السجلات في وضع العرض
        /// فقط) وعند الدخول لوضع العرض فقط أول مرة. قفل lookUpEditPO ضروري وظيفياً هنا لا شكلياً فقط —
        /// تغييره مباشرة (بلا زر btnPO) يُطلق OnPOLookupChanged الذي يستورد بنوداً جديدة فوراً.</summary>
        private void SetEditLock(bool locked)
        {
            lookUpEditStore.Properties.ReadOnly = locked;
            lookUpEditSupplier.Properties.ReadOnly = locked;
            dateEditReceivedDate.Properties.ReadOnly = locked;
            textEditInvoiceNo.Properties.ReadOnly = locked;
            textEditVoucherNo.Properties.ReadOnly = locked;
            memoEditDescrp.Properties.ReadOnly = locked;
            lookUpEditPO.Properties.ReadOnly = locked;
            btnPO.Enabled = !locked;

            gv.OptionsBehavior.Editable = !locked;
            colDeleteItem.Visible = !locked;

            bbiSave.Enabled = !locked;
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.MaterialReceiveDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<MaterialReceiveDetails> source)
        {
            PopulatePOQtyDisplay(source);
            _details = new BindingList<MaterialReceiveDetails>(source);
            gc.DataSource = _details;
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

            _loadingHeader = true; // مسح الحقول عند "جديد" لا يجب أن يُطلق الاستيراد التلقائي لبنود أمر الشراء
            textEditNum.Text = "جديد";
            dateEditReceivedDate.EditValue = DateTime.Today;
            lookUpEditStore.EditValue = null;
            lookUpEditSupplier.EditValue = null;
            RefreshPOLookup();
            lookUpEditPO.EditValue = null;
            textEditInvoiceNo.Text = "";
            textEditVoucherNo.Text = "";
            memoEditDescrp.Text = "";
            _loadingHeader = false;

            BindDetails(new List<MaterialReceiveDetails>());
            _ucAttachments?.LoadFor("MaterialReceiveList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditStore.Focus();
        }

        /// <summary>btnPO → يفتح نافذة اختيار أمر شراء (frmPurchaseOrderSelect)، مقيَّدة بأوامر الشراء
        /// المعتمدة التي ما زال لديها بند واحد على الأقل لم يُستلم بالكامل بعد (PurchaseOrderReceiveProgress)
        /// — ثم يستورد بنودها مباشرة إلى جدول الأصناف المستلمة.</summary>
        private void SelectAndImportFromPO()
        {
            using var frm = new frmPurchaseOrderSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedPO == null) return;

            RefreshPOLookup(frm.SelectedPO.Id);
            lookUpEditPO.EditValue = frm.SelectedPO.Id; // يُطلق OnPOLookupChanged الذي يستدعي ImportFromPO تلقائياً
        }

        /// <summary>يُطلَق عند تغيّر أمر الشراء المرجعي في lookUpEditPO — سواء اختاره المستخدم مباشرة من
        /// القائمة أو عبر SelectAndImportFromPO — فيعبّئ باقي الحقول والجدول تلقائياً من أمر الشراء. يُستثنى
        /// فقط أثناء LoadRecord/NewRecord (انظر _loadingHeader) حتى لا يُعاد استيراد بنود عند مجرد فتح/تصفح
        /// سجل محفوظ مسبقاً.</summary>
        private void OnPOLookupChanged(object? sender, EventArgs e)
        {
            SetDirty();
            if (_loadingHeader) return;
            if (lookUpEditPO.EditValue is int poId && poId > 0) ImportFromPO();
        }

        /// <summary>يجلب بنود أمر الشراء المختار في lookUpEditPO إلى جدول الأصناف المستلمة، ويعبّئ
        /// المخزن/المورد/الوصف من أمر الشراء مباشرة (تعبئة تلقائية كاملة للترويسة). تغيّر أمر الشراء
        /// يستبدل محتوى الجدول بالكامل ببنود الأمر الجديد بدل الإضافة فوق بنود أمر سابق — حتى لا يختلط
        /// استلام أمرين مختلفين في نفس السند؛ أي سطر محفوظ مسبقاً (Id > 0) يُضاف إلى _deletedDetailIds كي
        /// يُحذف فعلياً من القاعدة عند الحفظ. يستخدم PurchaseOrderReceiveProgress.GetRemainingDetails لجلب
        /// الكمية المتبقية الفعلية فقط (بعد خصم ما استُلم سابقًا عبر أي سند استلام آخر لنفس أمر الشراء).</summary>
        private void ImportFromPO()
        {
            if (lookUpEditPO.EditValue is not int poId || poId <= 0)
            {
                XtraMessageBox.Show("يرجى اختيار أمر الشراء أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var po = dc.PurchaseOrderList.Find(poId);
            if (po == null) return;

            lookUpEditStore.EditValue = po.StoreId;
            lookUpEditSupplier.EditValue = po.StakeholderId;
            memoEditDescrp.Text = po.Description ?? "";

            foreach (var oldRow in _details)
                if (oldRow.Id > 0) _deletedDetailIds.Add(oldRow.Id);

            var lines = PurchaseOrderReceiveProgress.GetRemainingDetails(dc, poId).ToList();

            var newDetails = lines.Select(line => new MaterialReceiveDetails
            {
                PODetailId = line.Id,
                ItemId = line.ItemId,
                Description = line.Description,
                UnitId = line.UnitId,
                Qty = line.Qty,
                POQty = line.Qty, // الكمية المتبقية في أمر الشراء وقت الاستيراد = نفس السقف الأقصى المسموح لهذا السطر الجديد
                UnitPrice = line.UnitPrice,
                TotalPrice = (line.Qty ?? 0) * (line.UnitPrice ?? 0),
                Note = line.Note
            }).ToList();

            BindDetails(newDetails);

            if (newDetails.Count == 0)
                XtraMessageBox.Show("لا توجد بنود لاستيرادها من أمر الشراء المحدد (تم استلام كل البنود بالكامل).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetDirty();
        }

        /// <summary>يعبّئ عمود "كمية أمر الشراء" للقراءة فقط (MaterialReceiveDetails.POQty) بالكمية المتبقية
        /// (غير المستلمة بعد) في بند أمر الشراء المرتبط لكل سطر محفوظ مسبقاً — نفس آلية PopulatePRQtyDisplay
        /// في frmPurchaseOrderAddEdit: الكمية الأصلية في بند أمر الشراء ناقص ما استلمته أذون استلام أخرى لنفس
        /// PODetailId، مع إرجاع كمية هذا السطر نفسه (إن كان محفوظاً مسبقاً) كي لا يُحتسب ضد نفسه عند التعديل.</summary>
        private void PopulatePOQtyDisplay(List<MaterialReceiveDetails> details)
        {
            var poDetailIds = details.Where(d => d.PODetailId is > 0).Select(d => d.PODetailId!.Value).Distinct().ToList();
            if (poDetailIds.Count == 0) return;

            var poQtyById = dc.PurchaseOrderDetails
                .GetBy($"Id IN ({string.Join(",", poDetailIds)})")
                .ToDictionary(d => d.Id, d => d.Qty ?? 0);

            var otherReceivesByPoDetailId = dc.MaterialReceiveDetails
                .GetBy($"PODetailId IN ({string.Join(",", poDetailIds)}) AND IsDelete = 0")
                .ToList();

            foreach (var d in details)
            {
                if (d.PODetailId is not > 0 || !poQtyById.TryGetValue(d.PODetailId.Value, out var origQty)) continue;

                var receivedByOthers = otherReceivesByPoDetailId
                    .Where(o => o.PODetailId == d.PODetailId && (d.Id == 0 || o.Id != d.Id))
                    .Sum(o => o.Qty ?? 0);

                d.POQty = Math.Max(0, origQty - receivedByOthers);
            }
        }

        /// <summary>يمنع فورياً (قبل مغادرة الخلية) كتابة كمية بعمود colQty تتجاوز ما تبقى فعلياً من بند أمر
        /// الشراء المرتبط — نفس نمط GridViewPO_ValidatingEditor في frmPurchaseOrderAddEdit.</summary>
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gv.FocusedColumn != colQty) return;
            if (gv.GetFocusedRow() is not MaterialReceiveDetails row) return;
            if (row.PODetailId is not > 0) return;
            if (!decimal.TryParse(e.Value?.ToString(), out var newQty) || newQty <= 0) return;

            var max = row.POQty ?? 0;
            if (newQty > max)
            {
                e.Valid = false;
                gv.SetColumnError(colQty, $"الكمية أكبر من المتبقي في أمر الشراء ({max:N2})");
            }
        }

        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _id : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gv.CloseEditor();
            gv.UpdateCurrentRow();

            try
            {
                var entity = BuildHeaderEntity();
                entity.Amount = _details.Sum(d => d.TotalPrice ?? 0);
                bool isNew = _id == 0;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (isNew)
                    {
                        entity.Num = GetNextNumber(entity.ReceivedDate ?? DateTime.Today);
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedMachine = Session.Machine;
                        entity.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        entity.IsDelete = false;
                        _id = dc.MaterialReceiveList.Add(entity, tx);
                    }
                    else
                    {
                        var existing = dc.MaterialReceiveList.Find(_id);
                        entity.Num = existing?.Num;
                        entity.UpdateDate = DateTime.Now;
                        entity.UpdateMachine = Session.Machine;
                        entity.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        entity.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync
                        dc.MaterialReceiveList.Edit(_id, entity, tx);
                    }

                    SaveDetails(_id, tx);
                });

                if (isNew) textEditNum.Text = MaterialReceivePrinter.FormatReceiveNumber(entity.Num, entity.ReceivedDate);
                _rowVersion = entity.RowVersion;

                // إذا كان الاستلام مرتبطاً بأمر شراء ناتج عن طلب شراء، أعد حساب حالة توريد ذلك الطلب
                // (لم يبدأ / جزئي / مكتمل) بناءً على الكميات المستلمة فعلياً حتى الآن.
                var prId = entity.POId is int poId ? dc.PurchaseOrderList.Find(poId)?.PRId : null;
                if (prId is > 0) PurchaseRequestDeliveryStatus.Recompute(dc, prId.Value);

                SetDirty(false);
                _anySaved = true;

                LoadList();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("MaterialReceiveList", _id);

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
            var helper = dc.MaterialReceiveDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<MaterialReceiveDetails>();
            var toEdit = new List<MaterialReceiveDetails>();
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
            var row = gv.GetFocusedRow() as MaterialReceiveDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل أنت متأكد من رغبتك في حذف هذا السطر؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gv.DeleteSelectedRows();
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

        /// <summary>يعبّئ الوحدة/الوصف تلقائياً عند اختيار صنف يدوياً، ويعيد حساب إجمالي السطر عند تغيّر
        /// الكمية أو سعر الوحدة.</summary>
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gv.GetRow(e.RowHandle) is not MaterialReceiveDetails row) return;

            if (e.Column == colItem)
            {
                var itemId = e.Value as int?;
                var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
                row.Description = item?.Name;
                row.UnitId = item?.UnitId;
            }

            if (e.Column == colQty || e.Column == colUnitPrice || e.Column == colItem)
                row.TotalPrice = (row.Qty ?? 0) * (row.UnitPrice ?? 0);

            gv.RefreshRow(e.RowHandle);
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
                MaterialReceivePrinter.FormatReceiveNumber(r.Num, r.ReceivedDate).Contains(term, StringComparison.OrdinalIgnoreCase));
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
                XtraMessageBox.Show("يرجى حفظ إذن الاستلام قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isDirty)
            {
                XtraMessageBox.Show("توجد تغييرات غير محفوظة. يرجى الحفظ قبل الطباعة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { MaterialReceivePrinter.Print(_id); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The four fields marked with a green background in the Designer are the record's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditStore as DevExpress.XtraEditors.BaseEdit, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value),
            (dateEditReceivedDate as DevExpress.XtraEditors.BaseEdit, dateEditReceivedDate.EditValue != null && dateEditReceivedDate.EditValue != DBNull.Value),
            (memoEditDescrp as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditDescrp.Text)),
            (lookUpEditPO as DevExpress.XtraEditors.BaseEdit, lookUpEditPO.EditValue != null && lookUpEditPO.EditValue != DBNull.Value),
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

            // يُفحص فقط عند إنشاء مستند جديد — تعديل مستند محفوظ أصلاً لا يُعاد حجبه لمجرد تغيّر
            // صلاحيات المخزن لاحقاً (نفس مبدأ المخازن الشقيقة الأخرى).
            if (_id == 0 && lookUpEditStore.EditValue is int storeId && !InventoryStorePermissions.CanReceive(dc, storeId))
            {
                XtraMessageBox.Show("ليس لديك صلاحية استلام مواد في هذا المخزن.", "غير مصرَّح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditStore.Focus();
                return false;
            }
            if (lookUpEditSupplier.EditValue == null || lookUpEditSupplier.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى اختيار المورد.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditSupplier.Focus();
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة صنف واحد على الأقل في جدول الأصناف المستلمة.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gc.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gc.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تحديد كمية صحيحة لكل سطر في الجدول.", "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gc.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private MaterialReceiveList BuildHeaderEntity()
        {
            return new MaterialReceiveList
            {
                StoreId = lookUpEditStore.EditValue as int?,
                StakeholderId = lookUpEditSupplier.EditValue as int?,
                ReceivedDate = DateTimeHelper.WithCurrentTime(dateEditReceivedDate.EditValue as DateTime?),
                InvoiceNo = textEditInvoiceNo.Text.Trim(),
                VoucherNo = textEditVoucherNo.Text.Trim(),
                POId = lookUpEditPO.EditValue as int?,
                Description = memoEditDescrp.Text?.Trim()
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number within the calendar year of the voucher's own ReceivedDate — the
        /// series resets to 1 every year (see MaterialReceivePrinter.FormatReceiveNumber for the display format).</summary>
        private int GetNextNumber(DateTime receivedDate)
        {
            return dc.MaterialReceiveList
                .GetBy("IsDelete = 0 AND YEAR(ReceivedDate) = @year", new { year = receivedDate.Year })
                .Select(r => r.Num ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"إذن استلام مواد رقم [{MaterialReceivePrinter.FormatReceiveNumber(_list[_currentIndex].Num, _list[_currentIndex].ReceivedDate)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة إذن استلام مواد جديد";

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
        private void FrmMaterialReceiveAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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

            // يُقرأ من ucMaterialReceive.OpenAddEdit لتحديث القائمة بعد أي حفظ ناجح فقط
            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
