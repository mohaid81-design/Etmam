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
    /// <summary>Add/Edit form for Purchase Orders: header (incl. contract terms) + item details grid,
    /// with a simple single-step approval flow (Draft → PendingApproval → Approved/Rejected). A Purchase
    /// Order can only be raised against an approved Purchase Request that still has un-ordered lines
    /// (see PurchaseRequestOrderProgress) — standalone/direct orders are not allowed (ValidateHeader).</summary>
    public partial class frmPurchaseOrderAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _poId = 0;                                        // 0 = New, >0 = Edit
        private byte[]? _rowVersion;                                  // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;                                // Tracks unsaved changes
        private bool _anySaved = false;                               // At least one successful save (drives DialogResult on close)
        private List<PurchaseOrderList> _poList = new();               // Navigator cache
        private int _currentIndex = -1;                                // Current navigator position

        private BindingList<PurchaseOrderDetails> _details = new();    // Detail grid in-memory list
        private List<int> _deletedDetailIds = new();                   // Detail rows pending deletion on save
        private List<ItemsList> _itemsCache = new();                   // Items lookup cache for the detail grid
        private ucAttachmentAddEdit? _ucAttachments;                   // Embedded attachments panel ("المرفقات" تبويب)
        private MemoEdit? _logMemo;                                    // "سجل الموافقات" tab content
        private GridControl? _linkGrid;                                // "المستندات المرتبطة" tab: related Material Receives
        private GridView? _linkGridView;
        private LabelControl? _linkPrLabel;

        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditBdg = null!;

        // صلاحيات مستقلة لكل زر (انظر PermNames.POAdd وما يليها) — نفس نمط frmPurchaseRequestAddEdit.
        // اعتماد/رفض أمر الشراء (bbiApproval/bbiReject) يبقى خارج هذه المجموعة عمداً، محكوماً فقط بـ
        // WorkflowEngine.CanUserAct (انظر UpdateActionButtonStates).
        private bool _canAdd;
        private bool _canSave;
        private bool _canPrint;
        private bool _canSend;
        private bool _canDelete;
        private bool _canReturnForEdit;

        private bool _readOnly = false;                               // true عند الفتح عبر bbiOpen: عرض + اعتماد/رفض فقط، بلا تعديل بيانات

        // ── Constructor ───────────────────────────────────────────────────────
        public frmPurchaseOrderAddEdit(int id = 0, int fromPRId = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            _canAdd = PermissionService.HasPermission(PermNames.POAdd);
            _canSave = PermissionService.HasPermission(PermNames.POSave);
            _canPrint = PermissionService.HasPermission(PermNames.POPrint);
            _canSend = PermissionService.HasPermission(PermNames.POSend);
            _canDelete = PermissionService.HasPermission(PermNames.PODelete);
            _canReturnForEdit = PermissionService.HasPermission(PermNames.POReturnForEdit);

            bbiNew.Enabled = _canAdd;
            bbiPrint.Enabled = _canPrint;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupAttachments();
            SetupLogTab();
            SetupLinkTab();
            Loadlist();

            if (id > 0)
            {
                _currentIndex = _poList.FindIndex(r => r.Id == id);
                LoadRecord(id);
            }
            else
            {
                NewRecord();
                if (fromPRId > 0) ImportFromPR(fromPRId);
            }
        }

        // ── Public API ────────────────────────────────────────────────────────
        /// <summary>The PO currently shown (0 for an abandoned/never-saved new record) — read by the
        /// caller's FormClosed handler (see ucPurchaseOrder.OpenForAction) to refresh the list grid after
        /// this window closes.</summary>
        public int CurrentPoId => _poId;

        /// <summary>Opens the form on an existing PO for approval action only (bbiOpen في ucPurchaseOrder) —
        /// header/detail data is locked read-only; only viewing, printing, and the approve/reject menu
        /// remain usable. Mirrors frmPurchaseRequestAddEdit.OpenForAction.</summary>
        public void OpenForAction(int poId)
        {
            _readOnly = true;
            _currentIndex = _poList.FindIndex(r => r.Id == poId);
            LoadRecord(poId);
            bbiNew.Enabled = false;
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick += (s, e) => PrintRecord();

            bbiSendForApproval.ItemClick += (s, e) => SafeAction(SendForApproval);
            bbiApproval.ItemClick += (s, e) => SafeAction(() => ActOnCurrentStep("Approved"));
            bbiReject.ItemClick += (s, e) => SafeAction(() => ActOnCurrentStep("Rejected"));

            bbiReturnForEdit.ItemClick += (s, e) => SafeAction(() => ChangeStatus(PurchaseOrderStatus.Draft));
            bbiDelete.ItemClick += (s, e) => SafeAction(DeleteCurrentRecord);

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItemSearch.EditValue != null)
                    FetchBySearch();
            };

            // Header dirty tracking
            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditPrj.EditValueChanged += OnHeaderChanged;
            lookUpEditPrj.EditValueChanged += (s, e) => RevalidateField(lookUpEditPrj, IsFilled(lookUpEditPrj));
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;
            lookUpEditPurchaseRequest.EditValueChanged += (s, e) => RevalidateField(lookUpEditPurchaseRequest, IsFilled(lookUpEditPurchaseRequest));
            lookUpEditSupplier.EditValueChanged += OnHeaderChanged;
            lookUpEditSupplier.EditValueChanged += (s, e) => RevalidateField(lookUpEditSupplier, IsFilled(lookUpEditSupplier));
            lookUpEditDeliveryLocation.EditValueChanged += OnHeaderChanged;
            lookUpEditDeliveryLocation.EditValueChanged += (s, e) => RevalidateField(lookUpEditDeliveryLocation, IsFilled(lookUpEditDeliveryLocation));
            comboBoxEditPurchaseMethod.EditValueChanged += OnHeaderChanged;
            comboBoxEditPurchaseMethod.EditValueChanged += (s, e) => RevalidateField(comboBoxEditPurchaseMethod, IsFilled(comboBoxEditPurchaseMethod));
            comboBoxEditPriorityLevel.EditValueChanged += OnHeaderChanged;
            dateEditPreparationDate.EditValueChanged += OnHeaderChanged;
            dateEditPreparationDate.EditValueChanged += (s, e) => RevalidateField(dateEditPreparationDate, dateEditPreparationDate.EditValue != null);
            dateEditFinalDeliveryDate.EditValueChanged += OnHeaderChanged;
            memoEditDescrp.EditValueChanged += OnHeaderChanged;
            memoEditDescrp.EditValueChanged += (s, e) => RevalidateField(memoEditDescrp, !string.IsNullOrWhiteSpace(memoEditDescrp.Text));
            comboBoxEditPaymentTerms.EditValueChanged += OnHeaderChanged;
            textEditExecutionDuration.EditValueChanged += OnHeaderChanged;
            textEditWarrantyDuration.EditValueChanged += OnHeaderChanged;
            textEditDailyPenaltyRate.EditValueChanged += OnHeaderChanged;
            textEditDailyPenaltyMaxPercent.EditValueChanged += OnHeaderChanged;
            textEditPerformanceBondPercent.EditValueChanged += OnHeaderChanged;
            memoEditOtherCondtion.EditValueChanged += OnHeaderChanged;

            radioButton1.CheckedChanged += (s, e) => OnPerformanceBondModeChanged();
            radioButton2.CheckedChanged += (s, e) => OnPerformanceBondModeChanged();

            gridView.KeyDown += GridView_KeyDown;
            gridView.ValidatingEditor += GridViewPO_ValidatingEditor;

            btnSupplier.Click += (s, e) => SafeAction(QuickAddSupplier);
            btnPurchaseRequest.Click += (s, e) => SafeAction(QuickAddPurchaseRequest);
            btnProposal.Click += (s, e) => SafeAction(QuickAddProposal);

            this.FormClosing += FrmPurchaseOrderAddEdit_FormClosing;
        }

        // ── Selection-List Buttons ───────────────────────────────────────────────
        /// <summary>btnSupplier / btnPurchaseRequest / btnProposal all open a dedicated picker form — same
        /// list/search/select toolbar pattern as frmItemSelect (used by frmPurchaseRequestAddEdit to add
        /// items) — instead of the field's own small dropdown popup.</summary>
        private void QuickAddSupplier()
        {
            using var frm = new frmSupplierSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedSupplier == null) return;

            lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.EditValue = frm.SelectedSupplier.Id;
        }

        private void QuickAddPurchaseRequest()
        {
            using var frm = new frmPurchaseRequestSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedPR == null) return;

            RefreshPurchaseRequestLookup(frm.SelectedPR.Id);
            lookUpEditPurchaseRequest.EditValue = frm.SelectedPR.Id;
        }

        /// <summary>btnProposal: quotations are scoped to a Purchase Request (PriceQuotationList.PRId),
        /// so one must be selected first.</summary>
        private void QuickAddProposal()
        {
            if (lookUpEditPurchaseRequest.EditValue is not int prId || prId <= 0)
            {
                XtraMessageBox.Show("يرجى اختيار طلب الشراء أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmPriceQuotationSelect(prId);
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedQuotation == null) return;

            RefreshProposalLookup(frm.SelectedQuotation.Id);
            lookUpEdit1.EditValue = frm.SelectedQuotation.Id;
        }

        private void SetupLookups()
        {
            lookUpEditPrj.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- اختر المشروع --";

            lookUpEditDeliveryLocation.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditDeliveryLocation.Properties.ValueMember = "Id";
            lookUpEditDeliveryLocation.Properties.DisplayMember = "Name";
            lookUpEditDeliveryLocation.Properties.NullText = "-- اختر موقع التسليم --";

            lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.Properties.ValueMember = "Id";
            lookUpEditSupplier.Properties.DisplayMember = "Name";
            lookUpEditSupplier.Properties.NullText = "-- اختر المورد --";
            lookUpEditSupplier.Enabled = true; // الديزاينر يعطّله افتراضياً؛ الشكل الحالي يتطلب اختيار المورد يدوياً

            RefreshPurchaseRequestLookup();
            RefreshProposalLookup();
        }

        /// <summary>يعرض عروض الأسعار (PriceQuotationList) في حقل "رقم عرض السعر" — كان هذا الحقل
        /// (lookUpEdit1) بلا مصدر بيانات إطلاقاً قبل ربط btnProposal بنافذة الإضافة السريعة.
        /// includeId يبقي على عرض السعر المرتبط بالسجل الحالي ظاهراً حتى لو لم يعد ضمن نتيجة الاستعلام.</summary>
        private void RefreshProposalLookup(int includeId = 0)
        {
            var prId = lookUpEditPurchaseRequest.EditValue as int? ?? 0;
            var quotes = prId > 0
                ? dc.PriceQuotationList.GetBy("PRId = @id AND IsDelete = 0", new { id = prId }).ToList()
                : new List<PriceQuotationList>();

            if (includeId > 0 && quotes.All(q => q.Id != includeId))
            {
                var current = dc.PriceQuotationList.Find(includeId);
                if (current != null) quotes.Add(current);
            }

            lookUpEdit1.Properties.DataSource = quotes;
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.Properties.DisplayMember = "Num";
            lookUpEdit1.Properties.NullText = "-- اختر عرض السعر --";
            lookUpEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            lookUpEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
        }

        /// <summary>يعرض طلبات الشراء المعتمدة (أو التي تحوّل عليها أمر شراء سابق) والتي لا تزال تحتوي على
        /// بنود لم يُصدر لها أمر شراء بعد — انظر PurchaseRequestOrderProgress. هذا يسمح بإصدار أكثر من أمر
        /// شراء لنفس الطلب طالما بقيت له بنود غير مُغطاة، ويُسقطه من القائمة بمجرد اكتمال جميع بنوده.
        /// includePrId يضمن بقاء طلب الشراء المرتبط بالسجل الحالي ضمن القائمة حتى لو اكتملت كل بنوده
        /// (بسبب هذا الأمر نفسه)، وإلا لبدا حقل الاختيار فارغاً عند فتح/تصفح هذا الأمر.</summary>
        private void RefreshPurchaseRequestLookup(int includePrId = 0)
        {
            var prs = dc.PurchaseRequestList
                .GetBy("IsDelete = 0 AND OverallStatus = @a", new { a = PurchaseRequestStatus.Approved })
                .Where(pr => PurchaseRequestOrderProgress.HasRemainingItems(dc, pr.Id))
                .ToList();

            if (includePrId > 0 && prs.All(p => p.Id != includePrId))
            {
                var current = dc.PurchaseRequestList.Find(includePrId);
                if (current != null) prs.Add(current);
            }

            foreach (var pr in prs)
                pr.FormattedNum = PurchaseRequestPrinter.FormatPRNumber(pr.Num, pr.RequestDate);

            lookUpEditPurchaseRequest.Properties.DataSource = prs;
            lookUpEditPurchaseRequest.Properties.ValueMember = "Id";
            lookUpEditPurchaseRequest.Properties.DisplayMember = "FormattedNum";
            lookUpEditPurchaseRequest.Properties.NullText = "-- اختر طلب الشراء --";
            lookUpEditPurchaseRequest.Properties.Columns.Clear();
            lookUpEditPurchaseRequest.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormattedNum", "رقم الطلب"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Purpose", "الغرض")
            });
            lookUpEditPurchaseRequest.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            lookUpEditPurchaseRequest.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
        }

        private void SetupGrid()
        {
            //DesignSystem.ApplyGridStyle(gridControlItems, gridViewItems);
            // بنود أمر الشراء تُستورد حصراً من طلب الشراء المرتبط (ImportFromPR) — لا يُسمح بإضافة سطر يدوياً
            // بلا PRDetailId مقابل، حتى لا يُفلت بند من رقابة الكمية المتبقية (PurchaseRequestOrderProgress).
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            SetupDetailColumnEditors();
            BindDetails(new List<PurchaseOrderDetails>());
        }

        private void SetupDetailColumnEditors()
        {
            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            repositoryItemLookUpEditItem.DataSource = _itemsCache;
            repositoryItemLookUpEditItem.ValueMember = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText = "";
            colItem.ColumnEdit = repositoryItemLookUpEditItem;
            colItem.FieldName = "ItemId";

            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";
            colUnit.ColumnEdit = repositoryItemLookUpEditUnit;

            repositoryItemLookUpEditBdg = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            repositoryItemLookUpEditBdg.DataSource = dc.BudgetList.GetBy("IsDelete = 0");
            repositoryItemLookUpEditBdg.ValueMember = "Id";
            repositoryItemLookUpEditBdg.DisplayMember = "Description";
            repositoryItemLookUpEditBdg.NullText = "";
            gridControl.RepositoryItems.Add(repositoryItemLookUpEditBdg);
            colBdgId.ColumnEdit = repositoryItemLookUpEditBdg;
            colBdgId.FieldName = "BdgId";

            colPRDetailsId.FieldName = "PRDetailId";
            colPRDetailsId.OptionsColumn.AllowEdit = false;

            colDiscountPercent.FieldName = "DiscountPercent";
            colTaxPercent.FieldName = "TaxPercent";

            colTotalWithTax.FieldName = "TotalWithTax";
            colTotalWithTax.OptionsColumn.AllowEdit = false;
            colTotalWithTax.OptionsColumn.AllowFocus = false;

            colTotalPrice.OptionsColumn.AllowEdit = false;
            colTotalPrice.OptionsColumn.AllowFocus = false;

            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            gridView.CellValueChanged += GridViewItems_CellValueChanged;
        }

        /// <summary>Embeds the reusable attachment control into the "المرفقات" tab's navigation frame.</summary>
        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            SetupNavigationPage(_ucAttachments, navigationFrameAttachments);
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

        /// <summary>"سجل الموافقات" tab: a simple read-only status/approval history built from the header
        /// fields — see PurchaseOrderLog.</summary>
        private void SetupLogTab()
        {
            _logMemo = new MemoEdit { Dock = DockStyle.Fill, Properties = { ReadOnly = true } };
            xtraTabPageLog.Controls.Add(_logMemo);
        }

        /// <summary>"المستندات المرتبطة" tab: the source Purchase Request (if any) + Material Receives raised
        /// against this order.</summary>
        private void SetupLinkTab()
        {
            _linkPrLabel = new LabelControl { Dock = DockStyle.Top, Height = 26, Padding = new Padding(8, 6, 8, 0) };
            _linkGrid = new GridControl { Dock = DockStyle.Fill };
            _linkGridView = new GridView();
            _linkGrid.MainView = _linkGridView;
            _linkGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _linkGridView });

            var colNum = _linkGridView.Columns.AddVisible("FormattedNum", "رقم إذن الاستلام");
            var colDate = _linkGridView.Columns.AddVisible("ReceivedDate", "تاريخ الاستلام");
            colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            var colAmount = _linkGridView.Columns.AddVisible("Amount", "القيمة");
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.DisplayFormat.FormatString = "n2";
            //DesignSystem.ApplyGridStyle(_linkGrid, _linkGridView);
            _linkGridView.OptionsBehavior.Editable = false;

            xtraTabPageLink.Controls.Add(_linkGrid);
            xtraTabPageLink.Controls.Add(_linkPrLabel);
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _poList = dc.PurchaseOrderList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.OrderDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int poId)
        {
            var po = dc.PurchaseOrderList.Find(poId);
            if (po == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // يزامن حالة الأمر مع نتيجة آخر إجراء اعتماد منتهٍ (إن لم تُكتب بعد) قبل عرضها
            PurchaseOrderWorkflowSync.Reconcile(dc, po);

            _poId = poId;
            _rowVersion = po.RowVersion;
            _isDirty = false; // pause dirty tracking while filling fields

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditPoNumber.Text = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);
            lookUpEditPrj.EditValue = po.PrjId;
            RefreshPurchaseRequestLookup(po.PRId ?? 0);
            lookUpEditPurchaseRequest.EditValue = po.PRId;
            // بعد PRId مباشرة، إذ LookUpEditPurchaseRequest_EditValueChanged (المُفعَّل بالسطر أعلاه) يُفرِّغ
            // lookUpEdit1 ويُعيد بناء قائمته — تعيين عرض السعر المحفوظ لهذا الأمر يجب أن يأتي بعده لا قبله
            RefreshProposalLookup(po.QuotationId ?? 0);
            lookUpEdit1.EditValue = po.QuotationId;
            lookUpEditSupplier.EditValue = po.StakeholderId;
            lookUpEditDeliveryLocation.EditValue = po.StoreId;
            comboBoxEditPurchaseMethod.EditValue = po.PurchaseMethod;
            comboBoxEditPriorityLevel.EditValue = po.PriorityLevel ?? "عادي";
            dateEditPreparationDate.EditValue = po.OrderDate;
            dateEditFinalDeliveryDate.EditValue = po.DeliveryDate;
            memoEditDescrp.EditValue = po.Description;

            comboBoxEditPaymentTerms.EditValue = po.PaymentTerms;
            textEditExecutionDuration.EditValue = po.ExecutionDuration;
            textEditWarrantyDuration.EditValue = po.WarrantyDuration;
            textEditDailyPenaltyRate.EditValue = po.DailyPenaltyRate?.ToString();
            textEditDailyPenaltyMaxPercent.EditValue = po.DailyPenaltyMaxPercent?.ToString();
            memoEditOtherCondtion.EditValue = po.ContractTermsOther;

            if (po.PerformanceBondPercent is > 0)
            {
                radioButton2.Checked = true;
                textEditPerformanceBondPercent.EditValue = po.PerformanceBondPercent.Value.ToString();
            }
            else
            {
                radioButton1.Checked = true;
                textEditPerformanceBondPercent.EditValue = "";
            }

            LoadDetails(poId);
            _ucAttachments?.LoadFor("PurchaseOrderList", _poId);
            RefreshLogTab(po);
            RefreshLinkTab(po);

            UpdateNavigatorCaption();
            UpdateActionButtonStates();
            SetDirty(false);
        }

        private void LoadDetails(int poId)
        {
            _deletedDetailIds.Clear();
            var list = dc.PurchaseOrderDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id = poId })
                .OrderBy(d => d.Id)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<PurchaseOrderDetails> source)
        {
            PopulatePRQtyDisplay(source);
            _details = new BindingList<PurchaseOrderDetails>(source);
            gridControl.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        /// <summary>Fills the read-only "المتبقي من طلب الشراء" column (PurchaseOrderDetails.PRQty) with each
        /// line's REMAINING (not original) Purchase Request quantity: the PR line's own Qty minus whatever
        /// other Purchase Orders have already claimed against the same PRDetailId — but crediting back this
        /// row's own already-saved Qty first, so re-opening an existing order doesn't count a line against
        /// itself. This is also exactly the ceiling GridViewPO_ValidatingEditor enforces, computed once here
        /// per load/import instead of re-querying per keystroke (same convention as
        /// frmPurchaseReturnAddEdit's _remainingByRvDetailId/_originalQtyByRvDetailId).</summary>
        private void PopulatePRQtyDisplay(List<PurchaseOrderDetails> details)
        {
            var prDetailIds = details.Where(d => d.PRDetailId is > 0).Select(d => d.PRDetailId!.Value).Distinct().ToList();
            if (prDetailIds.Count == 0) return;

            var prQtyById = dc.PurchaseRequestDetails
                .GetBy($"Id IN ({string.Join(",", prDetailIds)})")
                .ToDictionary(d => d.Id, d => d.Qty ?? 0);

            var otherOrdersByPrDetailId = dc.PurchaseOrderDetails
                .GetBy($"PRDetailId IN ({string.Join(",", prDetailIds)}) AND IsDelete = 0")
                .ToList();

            foreach (var d in details)
            {
                if (d.PRDetailId is not > 0 || !prQtyById.TryGetValue(d.PRDetailId.Value, out var origQty)) continue;

                var orderedByOthers = otherOrdersByPrDetailId
                    .Where(o => o.PRDetailId == d.PRDetailId && (d.Id == 0 || o.Id != d.Id))
                    .Sum(o => o.Qty ?? 0);

                d.PRQty = Math.Max(0, origQty - orderedByOthers);
            }
        }

        /// <summary>يمنع فورياً (قبل مغادرة الخلية) كتابة كمية بعمود colQty تتجاوز ما تبقى فعلياً من بند طلب
        /// الشراء المرتبط — نفس نمط GridView_ValidatingEditor في frmPurchaseReturnAddEdit.</summary>
        private void GridViewPO_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView.FocusedColumn != colQty) return;
            if (gridView.GetFocusedRow() is not PurchaseOrderDetails row) return;
            if (row.PRDetailId is not > 0) return;
            if (!decimal.TryParse(e.Value?.ToString(), out var newQty) || newQty <= 0) return;

            // PRQty يمثّل بالفعل "الكمية المتبقية في طلب الشراء" (انظر PopulatePRQtyDisplay) — محسوبة عند
            // التحميل/الاستيراد، وهي نفسها الحد الأقصى المسموح به لهذا السطر.
            var max = row.PRQty ?? 0;
            if (newQty > max)
            {
                e.Valid = false;
                gridView.SetColumnError(colQty, $"الكمية أكبر من المتبقي في طلب الشراء ({max:N2})");
            }
        }

        private void RefreshLogTab(PurchaseOrderList po)
        {
            if (_logMemo == null) return;
            _logMemo.Text = PurchaseOrderLog.BuildLogText(dc, po);
        }

        private void RefreshLinkTab(PurchaseOrderList po)
        {
            if (_linkGrid == null || _linkPrLabel == null) return;

            var linkedPr = po.PRId is > 0 ? dc.PurchaseRequestList.Find(po.PRId.Value) : null;
            _linkPrLabel.Text = linkedPr != null
                ? $"مرتبط بطلب الشراء: {PurchaseRequestPrinter.FormatPRNumber(linkedPr.Num, linkedPr.RequestDate)}"
                : "غير مرتبط بطلب شراء (سجل سابق قبل إلزامية الربط)";

            var linkedReceives = dc.MaterialReceiveList
                .GetBy("POId = @id AND IsDelete = 0", new { id = po.Id })
                .OrderByDescending(r => r.ReceivedDate)
                .ToList();
            foreach (var mr in linkedReceives)
                mr.FormattedNum = MaterialReceivePrinter.FormatReceiveNumber(mr.Num, mr.ReceivedDate);

            _linkGrid.DataSource = linkedReceives;
        }

        // ── Record Operations (New / Save / Delete) ──────────────────────────
        private void NewRecord()
        {
            _poId = 0;
            _rowVersion = null;
            _deletedDetailIds.Clear();
            _isDirty = false; // pause dirty tracking while filling defaults

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditPoNumber.Text = "جديد";
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
            lookUpEditPurchaseRequest.EditValue = null;
            lookUpEditSupplier.EditValue = null;
            lookUpEditDeliveryLocation.EditValue = null;
            comboBoxEditPurchaseMethod.EditValue = null;
            comboBoxEditPriorityLevel.EditValue = "عادي";
            dateEditPreparationDate.EditValue = DateTime.Today;
            dateEditFinalDeliveryDate.EditValue = null;
            memoEditDescrp.EditValue = string.Empty;

            comboBoxEditPaymentTerms.EditValue = null;
            textEditExecutionDuration.EditValue = string.Empty;
            textEditWarrantyDuration.EditValue = string.Empty;
            textEditDailyPenaltyRate.EditValue = string.Empty;
            textEditDailyPenaltyMaxPercent.EditValue = string.Empty;
            memoEditOtherCondtion.EditValue = string.Empty;
            radioButton1.Checked = true;
            textEditPerformanceBondPercent.EditValue = string.Empty;

            BindDetails(new List<PurchaseOrderDetails>());
            _ucAttachments?.LoadFor("PurchaseOrderList", 0);
            if (_logMemo != null) _logMemo.Text = "";
            if (_linkPrLabel != null) _linkPrLabel.Text = "غير مرتبط بطلب شراء (سجل سابق قبل إلزامية الربط)";
            if (_linkGrid != null) _linkGrid.DataSource = null;

            _currentIndex = -1;
            UpdateNavigatorCaption();
            UpdateActionButtonStates();
            SetDirty(false);

            lookUpEditPrj.Focus();
        }

        /// <summary>Fills the header and detail grid from an approved Purchase Request's data — used both when
        /// converting a PR to a PO (frmPurchaseRequestAddEdit.ConvertToPO) and when the user manually picks a
        /// PR from lookUpEditPurchaseRequest on a new order. Only imports lines that still have quantity not
        /// yet placed on an earlier Purchase Order (see PurchaseRequestOrderProgress), so raising a second PO
        /// against a partially-ordered PR doesn't duplicate what was already ordered. Does not save; the user
        /// reviews before Save.</summary>
        private void ImportFromPR(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            RefreshPurchaseRequestLookup(prId);
            lookUpEditPurchaseRequest.EditValue = prId;
            lookUpEditPrj.EditValue = pr.PrjId;
            lookUpEditDeliveryLocation.EditValue = pr.StoreId;
            memoEditDescrp.EditValue = pr.Purpose;

            var remainingLines = PurchaseRequestOrderProgress.GetRemainingDetails(dc, prId)
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            if (remainingLines.Count == 0)
            {
                XtraMessageBox.Show("جميع بنود طلب الشراء هذا مرتبطة بالفعل بأوامر شراء سابقة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindDetails(new List<PurchaseOrderDetails>());
                SetDirty();
                return;
            }

            var lines = remainingLines.Select(l => new PurchaseOrderDetails
            {
                PRDetailId = l.Id,
                ItemId = l.ItemId,
                Description = l.Description,
                Qty = l.Qty, // بالفعل الكمية المتبقية غير المطلوبة سابقاً — انظر PurchaseRequestOrderProgress
                UnitId = l.UnitId,
                BdgId = l.BdgId,
                Note = l.Note,
                SupplierManufacturer = l.SupplierManufacturer
            }).ToList();

            BindDetails(lines);
            SetDirty();
        }

        private void LookUpEditPurchaseRequest_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);

            // عرض السعر المختار (لو وُجد) مرتبط بطلب الشراء السابق تحديده — يُفرَّغ عند تغيير الطلب لأنه
            // لم يعد مرتبطاً به، ثم تُحدَّث قائمة العروض لتقتصر على الطلب الجديد.
            lookUpEdit1.EditValue = null;
            RefreshProposalLookup();

            // نقترح استيراد بنود الطلب فقط عند اختيار طلب على أمر جديد فارغ من البنود، لتفادي الكتابة
            // فوق تعديلات المستخدم اليدوية على أمر قائم بالفعل.
            if (_poId != 0 || _details.Count > 0) return;
            if (lookUpEditPurchaseRequest.EditValue is not int prId || prId <= 0) return;

            if (XtraMessageBox.Show("هل تريد استيراد بنود طلب الشراء المحدد إلى هذا الأمر؟", "استيراد البنود",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ImportFromPR(prId);
            }
        }

        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _poId : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();
            RecalculateAllTotals();

            try
            {
                decimal amount = _details.Sum(d => d.TotalWithTax ?? d.TotalPrice ?? 0);
                PurchaseOrderList? newPo = null;
                PurchaseOrderList? savedPo = null;

                // Header + detail lines commit or roll back together — previously each detail row
                // was saved independently with its own swallowed try/catch, so a mid-save failure
                // could leave a header committed with only some of its lines saved.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_poId == 0)
                    {
                        var po = BuildHeaderEntity();
                        po.Num = GetNextNumber(tx, po.OrderDate ?? DateTime.Today);
                        po.Amount = amount;
                        po.CreatedDate = DateTime.Now;
                        po.CreatedMachine = Session.Machine;
                        po.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        po.IsDelete = false;
                        po.OverallStatus = PurchaseOrderStatus.Draft;

                        _poId = dc.PurchaseOrderList.Add(po, tx);
                        newPo = po;
                        savedPo = po;
                        AuditService.LogCreate(tx, "PurchaseOrderList", _poId, po);
                    }
                    else
                    {
                        var po = BuildHeaderEntity();
                        var existing = dc.PurchaseOrderList.Find(_poId);
                        po.Num = existing?.Num;
                        po.OverallStatus = existing?.OverallStatus;
                        po.ApprovedBy = existing?.ApprovedBy;
                        po.ApprovedDate = existing?.ApprovedDate;
                        po.RejectReason = existing?.RejectReason;
                        po.Amount = amount;
                        po.UpdateDate = DateTime.Now;
                        po.UpdateMachine = Session.Machine;
                        po.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        po.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync

                        dc.PurchaseOrderList.Edit(_poId, po, tx);
                        savedPo = po;
                        AuditService.LogUpdate(tx, "PurchaseOrderList", _poId, existing, po);
                    }

                    SaveDetails(_poId, tx);
                });

                if (newPo != null) textEditPoNumber.Text = PurchaseOrderNumberFormatter.FormatPONumber(newPo.Num, newPo.OrderDate);
                _rowVersion = savedPo?.RowVersion;

                RefreshPurchaseRequestLookup(lookUpEditPurchaseRequest.EditValue as int? ?? 0);
                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _poList.FindIndex(r => r.Id == _poId);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("PurchaseOrderList", _poId);

                var saved = dc.PurchaseOrderList.Find(_poId);
                if (saved != null)
                {
                    RefreshLogTab(saved);
                    RefreshLinkTab(saved);
                }
                UpdateActionButtonStates();

                if (!silent)
                {
                    XtraMessageBox.Show("تم الحفظ بنجاح ✓", "حفظ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Data.ConcurrencyConflictException ex)
            {
                XtraMessageBox.Show(ex.Message, "تعارض في الحفظ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveDetails(int poId, SqlTransaction tx)
        {
            var helper = dc.PurchaseOrderDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<PurchaseOrderDetails>();
            var toEdit = new List<PurchaseOrderDetails>();
            foreach (var item in _details)
            {
                item.ParentId = poId;

                if (item.Id == 0)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedMachine = Session.Machine;
                    item.CreatedBy = Session.CurrentUser?.Id ?? 1;
                    item.IsDelete = false;
                    toAdd.Add(item);
                }
                else
                {
                    item.UpdateDate = DateTime.Now;
                    item.UpdateMachine = Session.Machine;
                    item.UpdateBy = Session.CurrentUser?.Id ?? 1;
                    toEdit.Add(item);
                }
            }
            if (toAdd.Count > 0) helper.AddRange(toAdd, tx);
            if (toEdit.Count > 0) helper.EditRange(toEdit, tx);
        }

        // ── Detail Row Operations ─────────────────────────────────────────────
        private void DeleteFocusedDetailRow()
        {
            var row = gridView.GetFocusedRow() as PurchaseOrderDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridView.DeleteSelectedRows();
            SetDirty();
        }

        private void GridView_KeyDown(object? sender, KeyEventArgs e)
        {
            // لا يوجد اختصار لإضافة سطر يدوياً — البنود تُستورد حصراً من طلب الشراء (انظر SetupGrid).
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteFocusedDetailRow();
                e.Handled = true;
            }
        }

        /// <summary>Auto-fills unit/description on item pick, and recomputes the line's pre-tax total whenever
        /// Qty / UnitPrice / DiscountPercent changes.</summary>
        private void GridViewItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView.GetRow(e.RowHandle) is not PurchaseOrderDetails row) return;

            if (e.Column == colItem)
            {
                var itemId = e.Value as int?;
                var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
                row.UnitId = item?.UnitId;
                row.Description = item?.Name;
            }

            if (e.Column == colQty || e.Column == colUnitPrice || e.Column == colDiscountPercent || e.Column == colItem)
                RecalculateLineTotal(row);

            gridView.RefreshRow(e.RowHandle);
        }

        private static void RecalculateLineTotal(PurchaseOrderDetails row)
        {
            decimal gross = (row.Qty ?? 0) * (row.UnitPrice ?? 0);
            decimal discount = gross * (row.DiscountPercent ?? 0) / 100m;
            row.TotalPrice = Math.Round(gross - discount, 2);
        }

        private void RecalculateAllTotals()
        {
            foreach (var row in _details) RecalculateLineTotal(row);
        }

        // ── Status / Approval Actions ─────────────────────────────────────────
        /// <summary>Starts the "أمر الشراء" workflow procedure and flips the PO into the approval chain.</summary>
        private void SendForApproval()
        {
            if (_poId <= 0) { if (!SaveRecord()) return; }
            if (_isDirty) { if (!SaveRecord()) return; }

            try
            {
                var po = dc.PurchaseOrderList.Find(_poId);
                if (po == null) return;

                PurchaseOrderWorkflowSync.SendForApproval(dc, po);

                po.OverallStatus = PurchaseOrderStatus.PendingApproval;
                po.UpdateDate = DateTime.Now;
                po.UpdateMachine = Session.Machine;
                po.UpdateBy = Session.CurrentUser?.Id ?? 1;
                dc.PurchaseOrderList.Edit(_poId, po);
                SetDirty(false);

                XtraMessageBox.Show("✓ تم إرسال أمر الشراء للاعتماد", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecord(_poId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Approves/rejects the current step of this PO's active workflow instance, then reconciles the PO's own status.</summary>
        private void ActOnWorkflowStep(int instanceId, string action)
        {
            // فحص دفاعي إضافي (بالإضافة إلى إخفاء عناصر القائمة/تعطيل الأزرار أعلاه) — يمنع الاعتماد
            // الذاتي حتى لو وصل الاستدعاء لهذه الدالة من مسار آخر مستقبلاً.
            var poForCheck = dc.PurchaseOrderList.Find(_poId);
            if (poForCheck != null && SeparationOfDutiesHelper.BlocksSelfApproval(dc, poForCheck.CreatedBy))
            {
                XtraMessageBox.Show(SeparationOfDutiesHelper.SelfApprovalMessage, "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = action == "Approved" ? "اعتماد" : "رفض";
            var comment = XtraInputBox.Show($"ملاحظة ({title}) - اختياري:", title, "");
            if (comment == null) return; // user cancelled

            try
            {
                WorkflowEngine.Act(instanceId, Session.CurrentUser?.Id ?? 1, action, comment.ToString());

                var po = dc.PurchaseOrderList.Find(_poId);
                if (po != null) PurchaseOrderWorkflowSync.Reconcile(dc, po);

                XtraMessageBox.Show($"تم {title} بنجاح ✓", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecord(_poId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Used by bbiApproval/bbiReject: resolves this PO's active workflow instance and acts on its current step.</summary>
        private void ActOnCurrentStep(string action)
        {
            if (_poId <= 0) return;

            var instance = PurchaseOrderWorkflowSync.GetActiveInstance(dc, _poId);
            if (instance == null)
            {
                XtraMessageBox.Show("لا يوجد إجراء اعتماد جارٍ لهذا الأمر.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActOnWorkflowStep(instance.Id, action);
        }

        private void ChangeStatus(string newStatus)
        {
            try
            {
                var po = dc.PurchaseOrderList.Find(_poId);
                if (po == null) return;

                po.OverallStatus = newStatus;
                po.UpdateDate = DateTime.Now;
                po.UpdateMachine = Session.Machine;
                po.UpdateBy = Session.CurrentUser?.Id ?? 1;

                dc.PurchaseOrderList.Edit(_poId, po);
                SetDirty(false);

                XtraMessageBox.Show(
                    $"✓ تم تغيير الحالة إلى: {PurchaseOrderStatus.ToDisplay(newStatus)}",
                    "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRecord(_poId); // يُحدِّث تفعيل الأزرار ونص barStaticItemstepName بعد تغيّر الحالة
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCurrentRecord()
        {
            if (_poId <= 0)
            {
                XtraMessageBox.Show("لا يوجد سجل محفوظ لحذفه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var po = dc.PurchaseOrderList.Find(_poId);
            if (po?.OverallStatus == PurchaseOrderStatus.Approved)
            {
                XtraMessageBox.Show("لا يمكن حذف أمر شراء معتمد.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show(
                $"هل أنت متأكد من حذف أمر الشراء رقم [{textEditPoNumber.Text}]؟\nسيتم حذف جميع البنود المرتبطة.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                dc.DeletePurchaseOrder(_poId);
                Loadlist();

                if (_poList.Count > 0)
                {
                    _currentIndex = Math.Min(_currentIndex, _poList.Count - 1);
                    if (_currentIndex < 0) _currentIndex = 0;
                    LoadRecord(_poList[_currentIndex].Id);
                }
                else
                {
                    NewRecord();
                }

                XtraMessageBox.Show("✓ تم حذف أمر الشراء", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحذف:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Keeps every status-dependent action button (send/approve/reject) and the step-name static label
        /// (barStaticItemstepName) in sync with the PO's current OverallStatus / active workflow step, and
        /// locks header/grid editing once the order has left Draft status. Mirrors
        /// frmPurchaseRequestAddEdit.UpdateActionButtonStates.
        /// </summary>
        private void UpdateActionButtonStates()
        {
            var po = _poId > 0 ? dc.PurchaseOrderList.Find(_poId) : null;
            string? status = po?.OverallStatus;

            bool canAct = false;
            string stepText;

            if (po == null)
            {
                stepText = "سجل جديد غير محفوظ";
            }
            else if (status == PurchaseOrderStatus.PendingApproval)
            {
                var instance = PurchaseOrderWorkflowSync.GetActiveInstance(dc, _poId);
                if (instance == null)
                {
                    stepText = "تعذّر تحديد إجراء الاعتماد الجاري لهذا الأمر";
                }
                else
                {
                    var name = PurchaseOrderWorkflowSync.GetCurrentStepName(dc, instance) ?? "—";
                    canAct = WorkflowEngine.CanUserAct(instance.Id, Session.CurrentUser?.Id ?? 1)
                        && !SeparationOfDutiesHelper.BlocksSelfApproval(dc, po.CreatedBy);
                    stepText = canAct
                        ? $"الخطوة الحالية: {name}"
                        : SeparationOfDutiesHelper.BlocksSelfApproval(dc, po.CreatedBy)
                            ? $"الخطوة الحالية: {name} — لا يمكنك الاعتماد الذاتي"
                            : $"الخطوة الحالية: {name}";
                }
            }
            else
            {
                stepText = $"الحالة: {PurchaseOrderStatus.ToDisplay(status)}";
            }

            barStaticItemstepName.Caption = stepText;

            bbiApproval.Enabled = canAct;
            bbiReject.Enabled = canAct;

            bool isDraft = status is null or PurchaseOrderStatus.Draft;
            bbiSave.Enabled = isDraft && _canSave && !_readOnly;
            bbiSendForApproval.Enabled = isDraft && _poId > 0 && _canSend && !_readOnly;

            bbiReturnForEdit.Enabled = status == PurchaseOrderStatus.Rejected && _poId > 0 && _canReturnForEdit && !_readOnly;
            bbiDelete.Enabled = (isDraft || status == PurchaseOrderStatus.Rejected) && _poId > 0 && _canDelete && !_readOnly;

            SetHeaderReadOnly(_readOnly || !isDraft);
            gridView.OptionsBehavior.Editable = isDraft && !_readOnly;
            colDeleteItem.Visible = isDraft && !_readOnly;
        }

        private void SetHeaderReadOnly(bool readOnly)
        {
            lookUpEditPrj.Properties.ReadOnly = readOnly;
            lookUpEditPurchaseRequest.Properties.ReadOnly = readOnly;
            lookUpEditSupplier.Properties.ReadOnly = readOnly;
            lookUpEditDeliveryLocation.Properties.ReadOnly = readOnly;
            comboBoxEditPurchaseMethod.Properties.ReadOnly = readOnly;
            comboBoxEditPriorityLevel.Properties.ReadOnly = readOnly;
            dateEditPreparationDate.Properties.ReadOnly = readOnly;
            dateEditFinalDeliveryDate.Properties.ReadOnly = readOnly;
            memoEditDescrp.Properties.ReadOnly = readOnly;
            comboBoxEditPaymentTerms.Properties.ReadOnly = readOnly;
            textEditExecutionDuration.Properties.ReadOnly = readOnly;
            textEditWarrantyDuration.Properties.ReadOnly = readOnly;
            textEditDailyPenaltyRate.Properties.ReadOnly = readOnly;
            textEditDailyPenaltyMaxPercent.Properties.ReadOnly = readOnly;
            textEditPerformanceBondPercent.Properties.ReadOnly = readOnly;
            memoEditOtherCondtion.Properties.ReadOnly = readOnly;
            radioButton1.Enabled = !readOnly;
            radioButton2.Enabled = !readOnly;
        }

        private void OnPerformanceBondModeChanged()
        {
            textEditPerformanceBondPercent.Enabled = radioButton2.Checked;
            if (radioButton1.Checked) textEditPerformanceBondPercent.EditValue = "";
            SetDirty();
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_poList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            var handle = ShowOverlay();
            try { LoadRecord(_poList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigatePrev()
        {
            if (_poList.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            var handle = ShowOverlay();
            try { LoadRecord(_poList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateNext()
        {
            if (_poList.Count == 0 || _currentIndex >= _poList.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            var handle = ShowOverlay();
            try { LoadRecord(_poList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void NavigateLast()
        {
            if (_poList.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _poList.Count - 1;
            var handle = ShowOverlay();
            try { LoadRecord(_poList[_currentIndex].Id); }
            finally { CloseOverlay(handle); }
        }

        private void FetchBySearch()
        {
            string searchTerm = barEditItemSearch.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(searchTerm)) return;

            var found = _poList.FirstOrDefault(r =>
                r.Num?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true ||
                PurchaseOrderNumberFormatter.FormatPONumber(r.Num, r.OrderDate).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{searchTerm}]", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ConfirmNavigation()) return;
            _currentIndex = _poList.IndexOf(found);
            var handle = ShowOverlay();
            try { LoadRecord(found.Id); }
            finally { CloseOverlay(handle); }
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void PrintRecord()
        {
            if (!_canPrint)
            {
                XtraMessageBox.Show("ليس لديك صلاحية طباعة أمر الشراء.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_poId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ أمر الشراء قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var handle = ShowOverlay();
            try { PurchaseOrderPrinter.Print(_poId); }
            finally { CloseOverlay(handle); }
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        private static bool IsFilled(DevExpress.XtraEditors.BaseEdit control) =>
            control.EditValue != null && control.EditValue != DBNull.Value;

        /// <summary>The seven fields marked with a green background in the Designer are the header's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditPrj as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditPrj)),
            (lookUpEditPurchaseRequest as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditPurchaseRequest)),
            (lookUpEditSupplier as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditSupplier)),
            (lookUpEditDeliveryLocation as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditDeliveryLocation)),
            (comboBoxEditPurchaseMethod as DevExpress.XtraEditors.BaseEdit, IsFilled(comboBoxEditPurchaseMethod)),
            (dateEditPreparationDate as DevExpress.XtraEditors.BaseEdit, dateEditPreparationDate.EditValue != null),
            (memoEditDescrp as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditDescrp.Text)),
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
                XtraMessageBox.Show("يرجى إضافة بند واحد على الأقل في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تحديد الكمية لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            if (_details.Any(d => d.UnitPrice is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تسجيل سعر الوحدة لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private PurchaseOrderList BuildHeaderEntity()
        {
            return new PurchaseOrderList
            {
                PrjId = lookUpEditPrj.EditValue as int?,
                StoreId = lookUpEditDeliveryLocation.EditValue as int?,
                StakeholderId = lookUpEditSupplier.EditValue as int?,
                PRId = lookUpEditPurchaseRequest.EditValue as int?,
                QuotationId = lookUpEdit1.EditValue as int?,
                OrderDate = dateEditPreparationDate.EditValue as DateTime?,
                DeliveryDate = dateEditFinalDeliveryDate.EditValue as DateTime?,
                Description = memoEditDescrp.Text?.Trim(),
                PurchaseMethod = comboBoxEditPurchaseMethod.EditValue?.ToString(),
                PriorityLevel = comboBoxEditPriorityLevel.EditValue?.ToString() ?? "عادي",
                PaymentTerms = comboBoxEditPaymentTerms.EditValue?.ToString(),
                ExecutionDuration = textEditExecutionDuration.Text?.Trim(),
                WarrantyDuration = textEditWarrantyDuration.Text?.Trim(),
                DailyPenaltyRate = ParseDecimal(textEditDailyPenaltyRate.Text),
                DailyPenaltyMaxPercent = ParseDecimal(textEditDailyPenaltyMaxPercent.Text),
                PerformanceBondPercent = radioButton2.Checked ? ParseDecimal(textEditPerformanceBondPercent.Text) : null,
                ContractTermsOther = memoEditOtherCondtion.Text?.Trim()
            };
        }

        private static decimal? ParseDecimal(string? text) =>
            decimal.TryParse(text, out var v) ? v : null;

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Next sequential number within the calendar year of the PO's own OrderDate — the series
        /// resets to 1 every year (see PurchaseOrderNumberFormatter.FormatPONumber for the "PO{yy}{seq}" display format).</summary>
        /// <summary>Delegates to NumberingService (concurrency-safe via sp_getapplock on the save
        /// transaction) instead of computing MAX(Num)+1 here, which two users saving at the same
        /// instant could race.</summary>
        private int GetNextNumber(SqlTransaction tx, DateTime orderDate) =>
            NumberingService.GetNextNumber(tx, "PurchaseOrderList", orderDate.Year, () =>
                dc.PurchaseOrderList
                    .GetBy("IsDelete = 0 AND YEAR(OrderDate) = @year", new { year = orderDate.Year })
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _poList.Count > 0
                ? $"أمر الشراء  [{PurchaseOrderNumberFormatter.FormatPONumber(_poList[_currentIndex].Num, _poList[_currentIndex].OrderDate)}]  |  {_currentIndex + 1} / {_poList.Count}"
                : "إضافة / تعديل أمر شراء — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _poList.Count - 1;
            bbiLast.Enabled = _currentIndex < _poList.Count - 1;
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

        /// <summary>يعرض مؤشر انتظار (overlay) فوق النافذة أثناء تنفيذ action — نفس نمط ShowOverlay/
        /// CloseOverlay المعتمد في frmMARAddEdit/frmCIRAddEdit، إذ لا تصل أزرار هذه الشاشة (XtraForm عادية)
        /// إلى BaseRibbonForm.ExecuteAsync (خاص بنماذج Ribbon). يُغلَّف SafeAction نفسه بدل كل زر على حدة —
        /// يغطي bbiNew/bbiSave/bbiSendForApproval/bbiApproval/bbiReject/bbiReturnForEdit/bbiDelete وأزرار
        /// الإضافة السريعة الثلاثة، وكلها تمر عبره أصلاً.</summary>
        private void SafeAction(Action action)
        {
            var handle = ShowOverlay();
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        /// <summary>نفس مؤشر الانتظار أعلاه، لعمليات لا تمر عبر SafeAction (الطباعة/التنقل/البحث) — إذ
        /// معالجة الأخطاء فيها مختلفة (رسائل خاصة أو لا شيء) فلا تلائم غلاف SafeAction العام.</summary>
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        // ── Form Closing Guard ────────────────────────────────────────────────
        private void FrmPurchaseOrderAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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

            // يُقرأ من ucPurchaseOrder.OpenAddEdit لتحديث القائمة بعد أي حفظ ناجح فقط
            this.DialogResult = _anySaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
