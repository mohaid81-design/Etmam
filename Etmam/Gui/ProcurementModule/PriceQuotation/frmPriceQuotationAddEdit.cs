using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for the outbound Request For Quotation ("طلب عرض سعر") sent to a supplier:
    /// header (incl. contract terms) + item details grid. Mirrors frmPurchaseOrderAddEdit's structure
    /// (closest analog: supplier + source Purchase Request + contract terms + priced item grid), but has
    /// no approval workflow — the toolbar only has New/Navigate/Save/Print.</summary>
    public partial class frmPriceQuotationAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _id = 0;                                              // 0 = New, >0 = Edit
        private byte[]? _rowVersion;                                      // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<PriceQuotationRequestList> _list = new();            // Navigator cache
        private int _currentIndex = -1;

        // The RFQ envelope (see Core.RFQList) this quotation answers, if any — 0 for a standalone
        // quotation with no RFQ envelope (the legacy flow, still fully supported). Set either by
        // ImportFromRFQ (new record opened against a specific RFQ) or restored from the loaded
        // record's own RFQId (LoadRecord), and always carried into BuildHeaderEntity so it survives
        // every subsequent edit instead of only applying at creation time.
        private int _rfqId = 0;

        private BindingList<PriceQuotationRequestDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        // ── Constructor ───────────────────────────────────────────────────────
        /// <param name="fromRFQId">Opens a new quotation registering a vendor's response against this
        /// RFQ envelope (see Core.RFQList) — lines are imported from RFQDetails (the "ask", no price)
        /// instead of straight from a Purchase Request, and the supplier lookup is restricted to that
        /// RFQ's invited vendors (RFQVendorList). Ignored if <paramref name="id"/> is set or if
        /// <paramref name="fromPRId"/> is also given (fromRFQId takes precedence for new records).</param>
        public frmPriceQuotationAddEdit(int id = 0, int fromPRId = 0, int fromRFQId = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupAttachments();
            Loadlist();

            if (id > 0)
            {
                _currentIndex = _list.FindIndex(r => r.Id == id);
                LoadRecord(id);
            }
            else
            {
                NewRecord();
                if (fromRFQId > 0) ImportFromRFQ(fromRFQId);
                else if (fromPRId > 0) ImportFromPR(fromPRId);
            }
        }

        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());
            bbiPrint.ItemClick += (s, e) => PrintRecord();
            btnPrintRFQ.ItemClick += (s, e) => PrintRecord();

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return && barEditItem1.EditValue != null)
                    FetchBySearch();
            };

            // Header dirty tracking
            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditPrj.EditValueChanged += OnHeaderChanged;
            lookUpEditStore.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(lookUpEditStore, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value); };
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;
            lookUpEditSupplier.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(lookUpEditSupplier, lookUpEditSupplier.EditValue != null && lookUpEditSupplier.EditValue != DBNull.Value); };
            comboBoxEditRequestType.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(comboBoxEditRequestType, comboBoxEditRequestType.EditValue != null && comboBoxEditRequestType.EditValue != DBNull.Value); };
            comboBoxEditPriority.EditValueChanged += OnHeaderChanged;
            dateEditRequestDate.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(dateEditRequestDate, dateEditRequestDate.EditValue != null); };
            dateEditRequiredDate.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(memoEditPurpose, !string.IsNullOrWhiteSpace(memoEditPurpose.Text)); };

            comboBoxEditPaymentTerms.EditValueChanged += OnHeaderChanged;
            textEditExecutionDuration.EditValueChanged += OnHeaderChanged;
            comboBoxEditExecutionDurationUnit.EditValueChanged += OnHeaderChanged;
            textEditWarrantyDuration.EditValueChanged += OnHeaderChanged;
            comboBoxEditWarrantyDurationUnit.EditValueChanged += OnHeaderChanged;
            textEditQuotationValidityPeriod.EditValueChanged += OnHeaderChanged;
            comboBoxEditQuotationValidityUnit.EditValueChanged += OnHeaderChanged;
            textEditDailyPenaltyRate.EditValueChanged += OnHeaderChanged;
            textEditDailyPenaltyMaxPercent.EditValueChanged += OnHeaderChanged;
            textEditPerformanceBondPercent.EditValueChanged += OnHeaderChanged;
            memoEditOtherConditions.EditValueChanged += OnHeaderChanged;

            radioButtonPerformanceBondNone.CheckedChanged += (s, e) => OnPerformanceBondModeChanged();
            radioButtonPerformanceBondPercent.CheckedChanged += (s, e) => OnPerformanceBondModeChanged();

            gridViewPO.KeyDown += GridView_KeyDown;

            btnSupplier.Click += (s, e) => SafeAction(QuickAddSupplier);
            btnPurchaseRequest.Click += (s, e) => SafeAction(QuickAddPurchaseRequest);

            this.FormClosing += FrmPriceQuotationAddEdit_FormClosing;
        }

        // ── Selection-List Buttons ───────────────────────────────────────────────
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

        private void SetupLookups()
        {
            lookUpEditPrj.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- اختر المشروع --";

            lookUpEditStore.Properties.DataSource = dc.StoreList.GetBy("IsDelete = 0");
            lookUpEditStore.Properties.ValueMember = "Id";
            lookUpEditStore.Properties.DisplayMember = "Name";
            lookUpEditStore.Properties.NullText = "-- اختر موقع التسليم --";

            lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.Properties.ValueMember = "Id";
            lookUpEditSupplier.Properties.DisplayMember = "Name";
            lookUpEditSupplier.Properties.NullText = "-- اختر المورد --";
            lookUpEditSupplier.Enabled = true; // الديزاينر يعطّله افتراضياً؛ الاختيار هنا حصراً عبر btnSupplier

            RefreshPurchaseRequestLookup();
        }

        /// <summary>يعرض طلبات الشراء المعتمدة فقط — بخلاف أمر الشراء، طلب عرض السعر لا يستهلك كمية
        /// الطلب (قد تُرسَل عدة طلبات عروض أسعار لموردين مختلفين على نفس طلب الشراء للمقارنة بينها).</summary>
        private void RefreshPurchaseRequestLookup(int includePrId = 0)
        {
            var prs = dc.PurchaseRequestList
                .GetBy("IsDelete = 0 AND OverallStatus = @a", new { a = PurchaseRequestStatus.Approved })
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
            gridViewPO.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            SetupDetailColumnEditors();
            BindDetails(new List<PriceQuotationRequestDetails>());
        }

        private void SetupDetailColumnEditors()
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

            // الحقول التالية تركها الديزاينر بلا FieldName مضبوط
            colDiscountPercent.FieldName = "DiscountPercent";
            colTaxPercent.FieldName = "TaxPercent";
            colTotalWithTax.FieldName = "TotalWithTax";

            colTotalWithTax.OptionsColumn.AllowEdit = false;
            colTotalWithTax.OptionsColumn.AllowFocus = false;
            colTotalPrice.OptionsColumn.AllowEdit = false;
            colTotalPrice.OptionsColumn.AllowFocus = false;

            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            gridViewPO.CellValueChanged += GridViewItems_CellValueChanged;
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
        private void Loadlist()
        {
            _list = dc.PriceQuotationRequestList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.RequestDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.PriceQuotationRequestList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف/جديد.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _id = id;
            _rowVersion = rec.RowVersion;
            _rfqId = rec.RFQId ?? 0;
            _isDirty = false; // pause dirty tracking while filling fields

            textEditNum.Text = FormatNumber(rec.Num);
            lookUpEditPrj.EditValue = rec.PrjId;
            lookUpEditStore.EditValue = rec.StoreId;
            RefreshPurchaseRequestLookup(rec.PRId ?? 0);
            lookUpEditPurchaseRequest.EditValue = rec.PRId;
            if (_rfqId > 0) RestrictSupplierLookupToInvitedVendors(_rfqId);
            else lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.EditValue = rec.StakeholderId;
            comboBoxEditRequestType.EditValue = rec.RequestType;
            comboBoxEditPriority.EditValue = rec.Priority ?? "عادي";
            dateEditRequestDate.EditValue = rec.RequestDate;
            dateEditRequiredDate.EditValue = rec.RequiredDate;
            memoEditPurpose.EditValue = rec.Purpose;

            comboBoxEditPaymentTerms.EditValue = rec.PaymentTerms;
            textEditExecutionDuration.EditValue = rec.ExecutionDuration?.ToString();
            comboBoxEditExecutionDurationUnit.EditValue = rec.ExecutionDurationUnit;
            textEditWarrantyDuration.EditValue = rec.WarrantyDuration?.ToString();
            comboBoxEditWarrantyDurationUnit.EditValue = rec.WarrantyDurationUnit;
            textEditQuotationValidityPeriod.EditValue = rec.QuotationValidityPeriod?.ToString();
            comboBoxEditQuotationValidityUnit.EditValue = rec.QuotationValidityUnit;
            textEditDailyPenaltyRate.EditValue = rec.DailyPenaltyRate?.ToString();
            textEditDailyPenaltyMaxPercent.EditValue = rec.DailyPenaltyMaxPercent?.ToString();
            memoEditOtherConditions.EditValue = rec.OtherConditions;

            if (rec.PerformanceBondPercent is > 0)
            {
                radioButtonPerformanceBondPercent.Checked = true;
                textEditPerformanceBondPercent.EditValue = rec.PerformanceBondPercent.Value.ToString();
            }
            else
            {
                radioButtonPerformanceBondNone.Checked = true;
                textEditPerformanceBondPercent.EditValue = "";
            }

            LoadDetails(id);
            _ucAttachments?.LoadFor("PriceQuotationRequestList", _id);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.PriceQuotationRequestDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<PriceQuotationRequestDetails> source)
        {
            _details = new BindingList<PriceQuotationRequestDetails>(source);
            gridControlPO.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _id = 0;
            _rowVersion = null;
            _rfqId = 0;
            _deletedDetailIds.Clear();
            _isDirty = false; // pause dirty tracking while filling defaults

            textEditNum.Text = "جديد";
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
            lookUpEditStore.EditValue = null;
            lookUpEditPurchaseRequest.EditValue = null;
            lookUpEditSupplier.Properties.DataSource = dc.StakeholdersList.GetBy("IsDelete = 0");
            lookUpEditSupplier.EditValue = null;
            comboBoxEditRequestType.EditValue = null;
            comboBoxEditPriority.EditValue = "عادي";
            dateEditRequestDate.EditValue = DateTime.Today;
            dateEditRequiredDate.EditValue = null;
            memoEditPurpose.EditValue = string.Empty;

            comboBoxEditPaymentTerms.EditValue = null;
            textEditExecutionDuration.EditValue = string.Empty;
            comboBoxEditExecutionDurationUnit.EditValue = null;
            textEditWarrantyDuration.EditValue = string.Empty;
            comboBoxEditWarrantyDurationUnit.EditValue = null;
            textEditQuotationValidityPeriod.EditValue = string.Empty;
            comboBoxEditQuotationValidityUnit.EditValue = null;
            textEditDailyPenaltyRate.EditValue = string.Empty;
            textEditDailyPenaltyMaxPercent.EditValue = string.Empty;
            memoEditOtherConditions.EditValue = string.Empty;
            radioButtonPerformanceBondNone.Checked = true;
            textEditPerformanceBondPercent.EditValue = string.Empty;

            BindDetails(new List<PriceQuotationRequestDetails>());
            _ucAttachments?.LoadFor("PriceQuotationRequestList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditPrj.Focus();
        }

        /// <summary>Fills the header and item grid from a Purchase Request's data — used when the user picks a
        /// PR on a new, empty record. Imports every line as-is (no "remaining quantity" filtering, unlike
        /// Purchase Orders): an RFQ doesn't consume the PR's quantity, it's only for comparing supplier quotes.</summary>
        private void ImportFromPR(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            RefreshPurchaseRequestLookup(prId);
            lookUpEditPurchaseRequest.EditValue = prId;
            lookUpEditPrj.EditValue = pr.PrjId;
            lookUpEditStore.EditValue = pr.StoreId;
            memoEditPurpose.EditValue = pr.Purpose;

            var lines = dc.PurchaseRequestDetails
                .GetBy("PRId = @id AND IsDelete = 0", new { id = prId })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .Select(l => new PriceQuotationRequestDetails
                {
                    PRDetailsId = l.Id,
                    ItemId = l.ItemId,
                    Description = l.Description,
                    Qty = l.Qty,
                    UnitId = l.UnitId,
                    Note = l.Note
                }).ToList();

            BindDetails(lines);
            SetDirty();
        }

        /// <summary>Fills the header (project/PR/purpose/contract terms — all copied from the RFQ envelope,
        /// since every invited vendor is quoting against the same ask) and imports one line per RFQDetails
        /// ask line (no price — the vendor's actual unit prices are typed in afterward), setting each line's
        /// PRDetailsId from the ask line's own PR-line source (PRRFQLineLink) when one exists, so PO-import
        /// traceability keeps working exactly as before even for RFQ-sourced quotations. Also restricts the
        /// supplier lookup to this RFQ's invited vendors (RFQVendorList) — see RestrictSupplierLookupToInvitedVendors.</summary>
        private void ImportFromRFQ(int rfqId)
        {
            var rfq = dc.RFQList.Find(rfqId);
            if (rfq == null) return;

            _rfqId = rfqId;

            lookUpEditPrj.EditValue = rfq.PrjId;
            RefreshPurchaseRequestLookup(rfq.PRId ?? 0);
            lookUpEditPurchaseRequest.EditValue = rfq.PRId;
            memoEditPurpose.EditValue = rfq.Purpose;
            comboBoxEditPriority.EditValue = rfq.Priority ?? "عادي";
            comboBoxEditRequestType.EditValue = rfq.RequestType;
            dateEditRequiredDate.EditValue = rfq.RequiredDate;

            comboBoxEditPaymentTerms.EditValue = rfq.PaymentTerms;
            textEditExecutionDuration.EditValue = rfq.ExecutionDuration?.ToString();
            comboBoxEditExecutionDurationUnit.EditValue = rfq.ExecutionDurationUnit;
            textEditWarrantyDuration.EditValue = rfq.WarrantyDuration?.ToString();
            comboBoxEditWarrantyDurationUnit.EditValue = rfq.WarrantyDurationUnit;
            textEditQuotationValidityPeriod.EditValue = rfq.QuotationValidityPeriod?.ToString();
            comboBoxEditQuotationValidityUnit.EditValue = rfq.QuotationValidityUnit;
            textEditDailyPenaltyRate.EditValue = rfq.DailyPenaltyRate?.ToString();
            textEditDailyPenaltyMaxPercent.EditValue = rfq.DailyPenaltyMaxPercent?.ToString();
            memoEditOtherConditions.EditValue = rfq.OtherConditions;
            if (rfq.PerformanceBondPercent is > 0)
            {
                radioButtonPerformanceBondPercent.Checked = true;
                textEditPerformanceBondPercent.EditValue = rfq.PerformanceBondPercent.Value.ToString();
            }
            else
            {
                radioButtonPerformanceBondNone.Checked = true;
            }

            RestrictSupplierLookupToInvitedVendors(rfqId);

            var rfqLines = dc.RFQDetails
                .GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            var linkByRfqDetailId = dc.PRRFQLineLink
                .GetBy($"RFQDetailId IN ({string.Join(",", rfqLines.Select(l => l.Id))}) AND IsDelete = 0")
                .Where(l => l.RFQDetailId.HasValue)
                .ToDictionary(l => l.RFQDetailId!.Value);

            var lines = rfqLines.Select(l => new PriceQuotationRequestDetails
            {
                RFQDetailId = l.Id,
                PRDetailsId = linkByRfqDetailId.TryGetValue(l.Id, out var link) ? link.PRLineId : null,
                ItemId = l.ItemId,
                Description = l.Description,
                Qty = l.Qty,
                UnitId = l.UnitId,
                Note = l.Note
            }).ToList();

            BindDetails(lines);
            SetDirty();
        }

        /// <summary>Restricts the supplier lookup to vendors actually invited to this RFQ (RFQVendorList) —
        /// prevents registering a "response" from a vendor who was never asked for a quote against this
        /// specific envelope. Called both when starting a new quotation against an RFQ (ImportFromRFQ) and
        /// when reopening an existing quotation that already carries an RFQId (LoadRecord).</summary>
        private void RestrictSupplierLookupToInvitedVendors(int rfqId)
        {
            var invitedIds = dc.RFQVendorList
                .GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId })
                .Select(v => v.StakeholderId ?? 0)
                .ToHashSet();

            var vendors = dc.StakeholdersList
                .GetBy("IsDelete = 0")
                .Where(v => invitedIds.Contains(v.Id))
                .ToList();

            lookUpEditSupplier.Properties.DataSource = vendors;
        }

        private void LookUpEditPurchaseRequest_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            RevalidateField(lookUpEditPurchaseRequest, lookUpEditPurchaseRequest.EditValue != null && lookUpEditPurchaseRequest.EditValue != DBNull.Value);

            // نقترح استيراد بنود الطلب فقط عند اختيار طلب على سجل جديد فارغ من البنود، لتفادي الكتابة
            // فوق تعديلات المستخدم اليدوية على سجل قائم بالفعل.
            if (_id != 0 || _details.Count > 0) return;
            if (lookUpEditPurchaseRequest.EditValue is not int prId || prId <= 0) return;

            if (XtraMessageBox.Show("هل تريد استيراد بنود طلب الشراء المحدد إلى هذا الطلب؟", "استيراد البنود",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ImportFromPR(prId);
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

            gridViewPO.CloseEditor();
            gridViewPO.UpdateCurrentRow();
            RecalculateAllTotals();

            try
            {
                decimal amount = _details.Sum(d => d.TotalWithTax ?? d.TotalPrice ?? 0);
                PriceQuotationRequestList? newRec = null;
                PriceQuotationRequestList? savedRec = null;

                // Header + detail lines commit or roll back together instead of each detail row
                // being saved independently.
                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_id == 0)
                    {
                        var rec = BuildHeaderEntity();
                        rec.Num = GetNextNumber(tx);
                        rec.Amount = amount;
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;

                        _id = dc.PriceQuotationRequestList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "PriceQuotationRequestList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.PriceQuotationRequestList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.Amount = amount;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync

                        dc.PriceQuotationRequestList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "PriceQuotationRequestList", _id, existing, rec);
                    }

                    SaveDetails(_id, tx);
                });

                if (newRec != null) textEditNum.Text = FormatNumber(newRec.Num);
                _rowVersion = savedRec?.RowVersion;

                RefreshPurchaseRequestLookup(lookUpEditPurchaseRequest.EditValue as int? ?? 0);
                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("PriceQuotationRequestList", _id);

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

        private void SaveDetails(int id, SqlTransaction tx)
        {
            var helper = dc.PriceQuotationRequestDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<PriceQuotationRequestDetails>();
            var toEdit = new List<PriceQuotationRequestDetails>();
            foreach (var item in _details)
            {
                item.ParentId = id;

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
            var row = gridViewPO.GetFocusedRow() as PriceQuotationRequestDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridViewPO.DeleteSelectedRows();
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

        /// <summary>Auto-fills unit/description on item pick, and recomputes the line's pre-tax total whenever
        /// Qty / UnitPrice / DiscountPercent changes.</summary>
        private void GridViewItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridViewPO.GetRow(e.RowHandle) is not PriceQuotationRequestDetails row) return;

            if (e.Column == colItem)
            {
                var itemId = e.Value as int?;
                var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
                row.UnitId = item?.UnitId;
                row.Description = item?.Name;
            }

            if (e.Column == colQty || e.Column == colUnitPrice || e.Column == colDiscountPercent || e.Column == colItem)
                RecalculateLineTotal(row);

            gridViewPO.RefreshRow(e.RowHandle);
        }

        private static void RecalculateLineTotal(PriceQuotationRequestDetails row)
        {
            decimal gross = (row.Qty ?? 0) * (row.UnitPrice ?? 0);
            decimal discount = gross * (row.DiscountPercent ?? 0) / 100m;
            row.TotalPrice = Math.Round(gross - discount, 2);
        }

        private void RecalculateAllTotals()
        {
            foreach (var row in _details) RecalculateLineTotal(row);
        }

        private void OnPerformanceBondModeChanged()
        {
            textEditPerformanceBondPercent.Enabled = radioButtonPerformanceBondPercent.Checked;
            if (radioButtonPerformanceBondNone.Checked) textEditPerformanceBondPercent.EditValue = "";
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
            string searchTerm = barEditItem1.EditValue?.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(searchTerm)) return;

            var found = _list.FirstOrDefault(r =>
                r.Num?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true);

            if (found == null)
            {
                XtraMessageBox.Show($"لم يُعثر على نتائج للبحث: [{searchTerm}]", "بحث",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                XtraMessageBox.Show("يرجى حفظ طلب عرض السعر قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // لا يوجد بعد تقرير طباعة مخصص لطلب عرض السعر — يحتاج تصميم تقرير DevExpress منفصل
            // (نفس الفجوة الموثّقة حالياً في أمر الشراء، انظر frmPurchaseOrderAddEdit.PrintRecord).
            XtraMessageBox.Show("طباعة طلب عرض السعر غير متاحة حالياً.", "تنبيه",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>The six fields marked with a green background in the Designer are the header's
        /// required fields. Checked together on Save; any that are empty turn salmon and the first
        /// one gets focus, instead of one message box per missing field. lookUpEditPrj is validated
        /// separately below since it isn't green-marked (it's disabled — auto-filled from the session's
        /// selected project). colQty in the detail grid is also green-marked but isn't a BaseEdit, so
        /// it stays covered by the existing per-row Qty check further below instead.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditPurchaseRequest as DevExpress.XtraEditors.BaseEdit, lookUpEditPurchaseRequest.EditValue != null && lookUpEditPurchaseRequest.EditValue != DBNull.Value),
            (memoEditPurpose as DevExpress.XtraEditors.BaseEdit, !string.IsNullOrWhiteSpace(memoEditPurpose.Text)),
            (lookUpEditSupplier as DevExpress.XtraEditors.BaseEdit, lookUpEditSupplier.EditValue != null && lookUpEditSupplier.EditValue != DBNull.Value),
            (dateEditRequestDate as DevExpress.XtraEditors.BaseEdit, dateEditRequestDate.EditValue != null),
            (lookUpEditStore as DevExpress.XtraEditors.BaseEdit, lookUpEditStore.EditValue != null && lookUpEditStore.EditValue != DBNull.Value),
            (comboBoxEditRequestType as DevExpress.XtraEditors.BaseEdit, comboBoxEditRequestType.EditValue != null && comboBoxEditRequestType.EditValue != DBNull.Value),
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
            if (lookUpEditPrj.EditValue == null || lookUpEditPrj.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى اختيار المشروع / الإدارة.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEditPrj.Focus();
                return false;
            }
            if (!ValidateRequiredFields()) return false;
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("يرجى إضافة بند واحد على الأقل في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControlPO.Focus();
                return false;
            }
            if (_details.Any(d => d.ItemId is null or 0))
            {
                XtraMessageBox.Show("يرجى اختيار الصنف لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControlPO.Focus();
                return false;
            }
            if (_details.Any(d => d.Qty is null or <= 0))
            {
                XtraMessageBox.Show("يرجى تحديد الكمية لكل بند في جدول البنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControlPO.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private PriceQuotationRequestList BuildHeaderEntity()
        {
            return new PriceQuotationRequestList
            {
                RFQId = _rfqId > 0 ? _rfqId : null,
                PrjId = lookUpEditPrj.EditValue as int?,
                StoreId = lookUpEditStore.EditValue as int?,
                StakeholderId = lookUpEditSupplier.EditValue as int?,
                PRId = lookUpEditPurchaseRequest.EditValue as int?,
                RequestDate = dateEditRequestDate.EditValue as DateTime?,
                RequiredDate = dateEditRequiredDate.EditValue as DateTime?,
                Purpose = memoEditPurpose.Text?.Trim(),
                Priority = comboBoxEditPriority.EditValue?.ToString() ?? "عادي",
                RequestType = comboBoxEditRequestType.EditValue?.ToString(),

                PaymentTerms = comboBoxEditPaymentTerms.EditValue?.ToString(),
                ExecutionDuration = ParseDecimal(textEditExecutionDuration.Text),
                ExecutionDurationUnit = comboBoxEditExecutionDurationUnit.EditValue?.ToString(),
                WarrantyDuration = ParseDecimal(textEditWarrantyDuration.Text),
                WarrantyDurationUnit = comboBoxEditWarrantyDurationUnit.EditValue?.ToString(),
                QuotationValidityPeriod = ParseDecimal(textEditQuotationValidityPeriod.Text),
                QuotationValidityUnit = comboBoxEditQuotationValidityUnit.EditValue?.ToString(),
                DailyPenaltyRate = ParseDecimal(textEditDailyPenaltyRate.Text),
                DailyPenaltyMaxPercent = ParseDecimal(textEditDailyPenaltyMaxPercent.Text),
                PerformanceBondPercent = radioButtonPerformanceBondPercent.Checked ? ParseDecimal(textEditPerformanceBondPercent.Text) : null,
                OtherConditions = memoEditOtherConditions.Text?.Trim()
            };
        }

        private static decimal? ParseDecimal(string? text) =>
            decimal.TryParse(text, out var v) ? v : null;

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Delegates to NumberingService (concurrency-safe via sp_getapplock on the save
        /// transaction) instead of computing MAX(Num)+1 here, which two users saving at the same
        /// instant could race.</summary>
        private int GetNextNumber(SqlTransaction tx) =>
            NumberingService.GetNextNumber(tx, "PriceQuotationRequestList", null, () =>
                dc.PriceQuotationRequestList
                    .GetBy("IsDelete = 0")
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private static string FormatNumber(int? num) => num.HasValue ? $"RFQ{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"طلب عرض سعر  [{FormatNumber(_list[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل طلب عرض سعر — سجل جديد";

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
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FrmPriceQuotationAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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
