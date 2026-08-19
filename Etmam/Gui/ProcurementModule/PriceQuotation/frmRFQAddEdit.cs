using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for the outbound RFQ envelope (see Core.RFQList): header (incl. contract
    /// terms) + item "ask" lines (no pricing) imported from a Purchase Request with a quantity ceiling
    /// enforced by RFQAllocationService + a checklist of invited vendors (RFQVendorList). Each vendor's
    /// own priced response is registered separately (still frmPriceQuotationAddEdit, against this RFQ —
    /// see PriceQuotationRequestList.RFQId) and is not part of this form. Mirrors
    /// frmPriceQuotationAddEdit's overall shape but has no supplier/price fields of its own: this form
    /// is "the ask", not any one vendor's reply. No approval workflow — toolbar is New/Navigate/Save
    /// only, matching frmPriceQuotationAddEdit.
    ///
    /// Import currently supports one source Purchase Request per RFQ (like frmPriceQuotationAddEdit) —
    /// combining lines from several different PRs into one RFQ (the Workbench multi-select flow from
    /// the methodology doc) is not built yet; each PR line is still linked individually via
    /// PRRFQLineLink so the many-to-many/quantity-cap rule already holds for this simpler flow.</summary>

    public partial class frmRFQAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _rfqId = 0;                                    // 0 = New, >0 = Edit
        private byte[]? _rowVersion;                                // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<RFQList> _list = new();                        // Navigator cache
        private int _currentIndex = -1;

        private BindingList<RFQDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<ItemsList> _itemsCache = new();
        private List<StakeholdersList> _vendorsCache = new();
        private ucAttachmentAddEdit? _ucAttachments;

        // ── Constructor ───────────────────────────────────────────────────────
        public frmRFQAddEdit(int id = 0, int fromPRId = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
            SetupVendorChecklist();
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
                if (fromPRId > 0) ImportFromPR(fromPRId);
            }
        }
        // ── Setup ─────────────────────────────────────────────────────────────
        private void WireEvents()
        {
            bbiNew.ItemClick += (s, e) => SafeAction(NewRecord);
            bbiSave.ItemClick += (s, e) => SafeAction(() => SaveRecord());

            bbiFirst.ItemClick += (s, e) => NavigateFirst();
            bbiPrev.ItemClick += (s, e) => NavigatePrev();
            bbiNext.ItemClick += (s, e) => NavigateNext();
            bbiLast.ItemClick += (s, e) => NavigateLast();
            bbiRegisterQuotation.ItemClick += (s, e) => SafeAction(RegisterVendorQuotation);
            bbiTechnicalEvaluation.ItemClick += (s, e) => SafeAction(OpenTechnicalEvaluation);
            bbiAwardRecommendation.ItemClick += (s, e) => SafeAction(OpenAwardRecommendation);
            bbiNegotiation.ItemClick += (s, e) => SafeAction(OpenNegotiation);

            lookUpEditPrj.EditValueChanged += OnHeaderChanged;
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;
            comboBoxEditRequestType.EditValueChanged += OnHeaderChanged;
            comboBoxEditPriority.EditValueChanged += OnHeaderChanged;
            dateEditIssueDate.EditValueChanged += OnHeaderChanged;
            dateEditRequiredDate.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged += OnHeaderChanged;

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

            clbVendors.ItemCheck += (s, e) => SetDirty();

            gridView.KeyDown += GridView_KeyDown;
            gridView.ValidatingEditor += GridView_ValidatingEditor;

            btnPurchaseRequest.Click += (s, e) => SafeAction(QuickAddPurchaseRequest);

            this.FormClosing += FrmRFQAddEdit_FormClosing;
        }

        private void QuickAddPurchaseRequest()
        {
            using var frm = new frmPurchaseRequestSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedPR == null) return;

            RefreshPurchaseRequestLookup(frm.SelectedPR.Id);
            lookUpEditPurchaseRequest.EditValue = frm.SelectedPR.Id;
        }

        /// <summary>Opens frmPriceQuotationAddEdit pre-scoped to this RFQ (Use Case: RegisterVendorQuotation)
        /// — its supplier lookup is restricted there to only this RFQ's invited vendors, and its item lines
        /// are imported from this RFQ's own ask lines. Requires the RFQ to already be saved (an unsaved RFQ
        /// has no Id yet for the quotation to reference, and no invited vendors persisted either).</summary>
        private void RegisterVendorQuotation()
        {
            if (_rfqId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ طلب عروض الأسعار أولاً قبل تسجيل ردود الموردين عليه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmPriceQuotationAddEdit(fromRFQId: _rfqId);
            frm.ShowDialog(this);
        }

        /// <summary>Opens frmTechnicalEvaluationAddEdit pre-filtered to this RFQ's own vendor quotations
        /// — the reviewer still picks which specific quotation to evaluate from that filtered list.</summary>
        private void OpenTechnicalEvaluation()
        {
            if (_rfqId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ طلب عروض الأسعار أولاً قبل تقييم ردود الموردين عليه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmTechnicalEvaluationAddEdit(fromRFQId: _rfqId);
            frm.ShowDialog(this);
        }

        /// <summary>Opens frmAwardRecommendationAddEdit pre-filtered to this RFQ, so the recommender
        /// picks the winning vendor from this envelope's own quotations only.</summary>
        private void OpenAwardRecommendation()
        {
            if (_rfqId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ طلب عروض الأسعار أولاً قبل التوصية بترسيته.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmAwardRecommendationAddEdit(fromRFQId: _rfqId);
            frm.ShowDialog(this);
        }

        /// <summary>Opens frmNegotiationAddEdit pre-filtered to this RFQ's own vendor quotations.</summary>
        private void OpenNegotiation()
        {
            if (_rfqId <= 0)
            {
                XtraMessageBox.Show("يرجى حفظ طلب عروض الأسعار أولاً قبل التفاوض على ردود الموردين عليه.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmNegotiationAddEdit(fromRFQId: _rfqId);
            frm.ShowDialog(this);
        }

        private void SetupLookups()
        {
            lookUpEditPrj.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";
            lookUpEditPrj.Properties.NullText = "-- اختر المشروع --";

            RefreshPurchaseRequestLookup();
        }

        /// <summary>يعرض طلبات الشراء المعتمدة فقط، بنفس معيار frmPurchaseRequestSelect — بند طلب مطابق تماماً
        /// (كمية متاحة صفر لكل بنوده حسب RFQAllocationService) لن يفيد استيراده، لكن العرض هنا يبقى مبنياً على
        /// حالة الاعتماد فقط؛ الفلترة الدقيقة على مستوى البند تتم عند الاستيراد الفعلي (ImportFromPR).</summary>
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
                new LookUpColumnInfo("FormattedNum", "رقم الطلب"),
                new LookUpColumnInfo("Purpose", "الغرض")
            });
            lookUpEditPurchaseRequest.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            lookUpEditPurchaseRequest.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
        }

        private void SetupGrid()
        {
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            _itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            repositoryItemLookUpEditItem.DataSource = _itemsCache;
            repositoryItemLookUpEditItem.ValueMember = "Id";
            repositoryItemLookUpEditItem.DisplayMember = "Code";
            repositoryItemLookUpEditItem.NullText = "";

            repositoryItemLookUpEditUnit.DataSource = dc.Units.GetBy("IsDelete = 0");
            repositoryItemLookUpEditUnit.ValueMember = "Id";
            repositoryItemLookUpEditUnit.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditUnit.NullText = "";

            colAvailable.OptionsColumn.AllowEdit = false;
            colAvailable.OptionsColumn.AllowFocus = false;

            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            gridView.CellValueChanged += GridView_CellValueChanged;

            BindDetails(new List<RFQDetails>());
        }

        private void SetupVendorChecklist()
        {
            _vendorsCache = dc.StakeholdersList
                .GetBy("IsDelete = 0 AND IsVendor = 1")
                .OrderBy(v => v.Name)
                .ToList();

            clbVendors.Items.Clear();
            foreach (var v in _vendorsCache)
                clbVendors.Items.Add(v.Id, v.Name ?? $"#{v.Id}");
        }

        private void SetupAttachments()
        {
            _ucAttachments = new ucAttachmentAddEdit();
            var page = new DevExpress.XtraBars.Navigation.NavigationPage();
            page.Controls.Add(_ucAttachments);
            _ucAttachments.Dock = DockStyle.Fill;
            navigationFrame1.Pages.Add(page);
            navigationFrame1.SelectedPage = page;
            _ucAttachments.SaveRequired += SaveAndReturnId;
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.RFQList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.IssueDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.RFQList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // مسح أي تلوين "سالمون" متبقٍّ من محاولة حفظ فاشلة سابقة قبل تحميل سجل مختلف/جديد.
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _rfqId = id;
            _rowVersion = rec.RowVersion;
            _isDirty = false; // pause dirty tracking while filling fields

            textEditNum.Text = FormatNumber(rec.Num);
            textEditStatus.Text = RFQStatus.ToDisplay(rec.Status);
            lookUpEditPrj.EditValue = rec.PrjId;
            RefreshPurchaseRequestLookup(rec.PRId ?? 0);
            lookUpEditPurchaseRequest.EditValue = rec.PRId;
            comboBoxEditRequestType.EditValue = rec.RequestType;
            comboBoxEditPriority.EditValue = rec.Priority ?? "عادي";
            dateEditIssueDate.EditValue = rec.IssueDate;
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
            LoadVendors(id);
            _ucAttachments?.LoadFor("RFQList", _rfqId);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int rfqId)
        {
            _deletedDetailIds.Clear();
            var list = dc.RFQDetails
                .GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            if (list.Count > 0)
            {
                var idsCsv = string.Join(",", list.Select(d => d.Id));
                var linkByDetailId = dc.PRRFQLineLink
                    .GetBy($"RFQDetailId IN ({idsCsv}) AND IsDelete = 0")
                    .Where(l => l.RFQDetailId.HasValue)
                    .ToDictionary(l => l.RFQDetailId!.Value);

                foreach (var d in list)
                {
                    if (!linkByDetailId.TryGetValue(d.Id, out var link) || link.PRLineId is not > 0) continue;

                    d.SourcePRLineId = link.PRLineId;
                    d.AvailableAtImport = RFQAllocationService.GetAvailableQuantity(dc, link.PRLineId.Value, excludeRfqId: rfqId);
                }
            }

            BindDetails(list);
        }

        private void LoadVendors(int rfqId)
        {
            var invited = dc.RFQVendorList
                .GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId })
                .Select(v => v.StakeholderId ?? 0)
                .ToHashSet();

            SetCheckedVendorIds(invited);
        }

        private void BindDetails(List<RFQDetails> source)
        {
            _details = new BindingList<RFQDetails>(source);
            gridControl.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Vendor Checklist Helpers ──────────────────────────────────────────
        private List<int> GetCheckedVendorIds() =>
            clbVendors.Items.Cast<CheckedListBoxItem>()
                .Where(i => i.CheckState == CheckState.Checked)
                .Select(i => (int)i.Value)
                .ToList();

        private void SetCheckedVendorIds(IEnumerable<int> ids)
        {
            var set = new HashSet<int>(ids);
            foreach (CheckedListBoxItem item in clbVendors.Items)
                item.CheckState = set.Contains((int)item.Value) ? CheckState.Checked : CheckState.Unchecked;
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _rfqId = 0;
            _rowVersion = null;
            _deletedDetailIds.Clear();
            _isDirty = false; // pause dirty tracking while filling defaults

            textEditNum.Text = "جديد";
            textEditStatus.Text = RFQStatus.ToDisplay(RFQStatus.Draft);
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
            lookUpEditPurchaseRequest.EditValue = null;
            comboBoxEditRequestType.EditValue = null;
            comboBoxEditPriority.EditValue = "عادي";
            dateEditIssueDate.EditValue = DateTime.Today;
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

            BindDetails(new List<RFQDetails>());
            SetCheckedVendorIds(Enumerable.Empty<int>());
            _ucAttachments?.LoadFor("RFQList", 0);

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditPrj.Focus();
        }

        /// <summary>Imports every line of the selected Purchase Request that still has quantity available
        /// (per RFQAllocationService — original Qty minus what's already ordered via a Purchase Order minus
        /// what's already linked to OTHER active RFQs), defaulting each imported line's ask Qty to that
        /// available ceiling. Lines with nothing left available are skipped entirely.</summary>
        private void ImportFromPR(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            RefreshPurchaseRequestLookup(prId);
            lookUpEditPurchaseRequest.EditValue = prId;
            lookUpEditPrj.EditValue = pr.PrjId;
            memoEditPurpose.EditValue = pr.Purpose;

            var prLines = dc.PurchaseRequestDetails
                .GetBy("PRId = @id AND IsDelete = 0", new { id = prId })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            var lines = new List<RFQDetails>();
            foreach (var l in prLines)
            {
                var available = RFQAllocationService.GetAvailableQuantity(dc, l.Id, excludeRfqId: _rfqId);
                if (available <= 0) continue;

                lines.Add(new RFQDetails
                {
                    SourcePRLineId = l.Id,
                    AvailableAtImport = available,
                    ItemId = l.ItemId,
                    Description = l.Description,
                    Qty = available,
                    UnitId = l.UnitId,
                    Note = l.Note
                });
            }

            if (lines.Count == 0)
            {
                XtraMessageBox.Show("لا توجد بنود متاحة للاستيراد من طلب الشراء المحدد — كل بنوده إما مُطلَبة بالكامل عبر أوامر شراء أو مرتبطة بالفعل بطلبات عروض أسعار أخرى.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BindDetails(lines);
            SetDirty();
        }

        private void LookUpEditPurchaseRequest_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            RevalidateField(lookUpEditPurchaseRequest, lookUpEditPurchaseRequest.EditValue != null && lookUpEditPurchaseRequest.EditValue != DBNull.Value);

            if (_rfqId != 0 || _details.Count > 0) return;
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
            return SaveRecord(silent: true) ? _rfqId : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            try
            {
                // Re-validate against the live allocation ceiling before writing anything — the grid's
                // own ValidatingEditor already stops most cases at entry time, but data can have moved
                // between load and save (another user placed a PO or another RFQ against the same PR
                // line in the meantime), so this is the authoritative check, not just a UI nicety.
                var allocations = _details
                    .Where(d => d.SourcePRLineId is > 0)
                    .Select(d => (PRLineId: d.SourcePRLineId!.Value, LinkedQuantity: d.Qty ?? 0));
                RFQAllocationService.ValidateAllocations(dc, allocations, excludeRfqId: _rfqId);

                RFQList? newRfq = null;
                RFQList? savedRfq = null;

                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_rfqId == 0)
                    {
                        var rfq = BuildHeaderEntity();
                        rfq.Num = GetNextNumber(tx);
                        rfq.Status = RFQStatus.Draft;
                        rfq.CreatedDate = DateTime.Now;
                        rfq.CreatedMachine = Session.Machine;
                        rfq.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rfq.IsDelete = false;

                        _rfqId = dc.RFQList.Add(rfq, tx);
                        newRfq = rfq;
                        savedRfq = rfq;
                        AuditService.LogCreate(tx, "RFQList", _rfqId, rfq);
                    }
                    else
                    {
                        var rfq = BuildHeaderEntity();
                        var existing = dc.RFQList.Find(_rfqId);
                        rfq.Num = existing?.Num;
                        rfq.Status = existing?.Status;
                        rfq.UpdateDate = DateTime.Now;
                        rfq.UpdateMachine = Session.Machine;
                        rfq.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rfq.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync

                        dc.RFQList.Edit(_rfqId, rfq, tx);
                        savedRfq = rfq;
                        AuditService.LogUpdate(tx, "RFQList", _rfqId, existing, rfq);
                    }

                    SaveDetails(_rfqId, tx);
                    SaveVendors(_rfqId, tx);
                });

                if (newRfq != null) textEditNum.Text = FormatNumber(newRfq.Num);
                _rowVersion = savedRfq?.RowVersion;
                textEditStatus.Text = RFQStatus.ToDisplay(savedRfq?.Status);

                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _rfqId);
                UpdateNavigatorCaption();

                _ucAttachments?.LoadFor("RFQList", _rfqId);

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
            catch (InvalidOperationException ex)
            {
                XtraMessageBox.Show(ex.Message, "تحقق من البيانات",
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

        private void SaveDetails(int rfqId, SqlTransaction tx)
        {
            var helper = dc.RFQDetails;

            if (_deletedDetailIds.Count > 0)
            {
                foreach (var deletedId in _deletedDetailIds)
                    dc.PRRFQLineLink.DeleteBy("RFQDetailId = @id", new { id = deletedId }, tx);

                helper.DeleteRange(_deletedDetailIds, tx);
            }
            _deletedDetailIds.Clear();

            var toAdd = new List<RFQDetails>();
            var toEdit = new List<RFQDetails>();
            foreach (var item in _details)
            {
                item.RFQId = rfqId;

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

            if (toAdd.Count > 0)
            {
                helper.AddRange(toAdd, tx); // fills each item's .Id in place
                foreach (var detail in toAdd)
                {
                    if (detail.SourcePRLineId is not > 0) continue;
                    dc.PRRFQLineLink.Add(new PRRFQLineLink
                    {
                        PRLineId = detail.SourcePRLineId,
                        RFQDetailId = detail.Id,
                        LinkedQuantity = detail.Qty,
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false
                    }, tx);
                }
            }

            if (toEdit.Count > 0)
            {
                helper.EditRange(toEdit, tx);
                foreach (var detail in toEdit)
                {
                    var existingLink = dc.PRRFQLineLink
                        .GetBy("RFQDetailId = @id AND IsDelete = 0", new { id = detail.Id })
                        .FirstOrDefault();

                    if (detail.SourcePRLineId is > 0)
                    {
                        if (existingLink != null)
                        {
                            existingLink.PRLineId = detail.SourcePRLineId;
                            existingLink.LinkedQuantity = detail.Qty;
                            existingLink.UpdateDate = DateTime.Now;
                            existingLink.UpdateMachine = Session.Machine;
                            existingLink.UpdateBy = Session.CurrentUser?.Id ?? 1;
                            dc.PRRFQLineLink.Edit(existingLink.Id, existingLink, tx);
                        }
                        else
                        {
                            dc.PRRFQLineLink.Add(new PRRFQLineLink
                            {
                                PRLineId = detail.SourcePRLineId,
                                RFQDetailId = detail.Id,
                                LinkedQuantity = detail.Qty,
                                CreatedDate = DateTime.Now,
                                CreatedMachine = Session.Machine,
                                CreatedBy = Session.CurrentUser?.Id ?? 1,
                                IsDelete = false
                            }, tx);
                        }
                    }
                    else if (existingLink != null)
                    {
                        dc.PRRFQLineLink.Delete(existingLink.Id, tx);
                    }
                }
            }
        }

        private void SaveVendors(int rfqId, SqlTransaction tx)
        {
            var checkedIds = GetCheckedVendorIds();
            var existing = dc.RFQVendorList.GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId });
            var existingStakeholderIds = existing.Select(v => v.StakeholderId ?? 0).ToHashSet();

            var toAdd = checkedIds
                .Where(vendorId => !existingStakeholderIds.Contains(vendorId))
                .Select(vendorId => new RFQVendorList
                {
                    RFQId = rfqId,
                    StakeholderId = vendorId,
                    InvitedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedMachine = Session.Machine,
                    CreatedBy = Session.CurrentUser?.Id ?? 1,
                    IsDelete = false
                })
                .ToList();
            if (toAdd.Count > 0) dc.RFQVendorList.AddRange(toAdd, tx);

            var checkedSet = checkedIds.ToHashSet();
            var toRemove = existing.Where(v => !checkedSet.Contains(v.StakeholderId ?? 0)).Select(v => v.Id).ToList();
            if (toRemove.Count > 0) dc.RFQVendorList.DeleteRange(toRemove, tx);
        }

        // ── Detail Row Operations ─────────────────────────────────────────────
        private void DeleteFocusedDetailRow()
        {
            var row = gridView.GetFocusedRow() as RFQDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedDetailIds.Add(row.Id);
            gridView.DeleteSelectedRows();
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

        /// <summary>Blocks (before leaving the cell) entering a Qty greater than what's actually available
        /// from the linked Purchase Request line — same pattern as
        /// frmPurchaseOrderAddEdit.GridViewPO_ValidatingEditor. Manually-added lines (no PR source) have no
        /// ceiling.</summary>
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView.FocusedColumn != colQty) return;
            if (gridView.GetFocusedRow() is not RFQDetails row) return;
            if (row.SourcePRLineId is not > 0) return;
            if (!decimal.TryParse(e.Value?.ToString(), out var newQty) || newQty <= 0) return;

            var max = row.AvailableAtImport ?? 0;
            if (newQty > max)
            {
                e.Valid = false;
                gridView.SetColumnError(colQty, $"الكمية أكبر من المتاح فعلياً من طلب الشراء ({max:N2})");
            }
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView.GetRow(e.RowHandle) is not RFQDetails row) return;

            if (e.Column == colItem)
            {
                var itemId = e.Value as int?;
                var item = itemId.HasValue ? _itemsCache.FirstOrDefault(i => i.Id == itemId.Value) : null;
                row.UnitId = item?.UnitId;
                row.Description = item?.Name;
                gridView.RefreshRow(e.RowHandle);
            }
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

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>lookUpEditPurchaseRequest is the only field marked with a green background in the
        /// Designer. lookUpEditPrj, dateEditIssueDate and comboBoxEditRequestType aren't green-marked,
        /// so their existing checks below stay separate/untouched. clbVendors (invited vendors) is a
        /// CheckedListBoxControl — not a BaseEdit and not green-marked — so it has no required-field
        /// check here (nor did it before this change).</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditPurchaseRequest as DevExpress.XtraEditors.BaseEdit, lookUpEditPurchaseRequest.EditValue != null && lookUpEditPurchaseRequest.EditValue != DBNull.Value),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

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
            if (dateEditIssueDate.EditValue == null || dateEditIssueDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ الإصدار.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditIssueDate.Focus();
                return false;
            }
            if (comboBoxEditRequestType.EditValue == null || comboBoxEditRequestType.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد نوع الطلب.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEditRequestType.Focus();
                return false;
            }
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
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private RFQList BuildHeaderEntity()
        {
            return new RFQList
            {
                PrjId = lookUpEditPrj.EditValue as int?,
                PRId = lookUpEditPurchaseRequest.EditValue as int?,
                IssueDate = dateEditIssueDate.EditValue as DateTime?,
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
        private int GetNextNumber(SqlTransaction tx) =>
            NumberingService.GetNextNumber(tx, "RFQList", null, () =>
                dc.RFQList
                    .GetBy("IsDelete = 0")
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private static string FormatNumber(int? num) => num.HasValue ? $"RFQ{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"طلب عروض أسعار (RFQ)  [{FormatNumber(_list[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل طلب عروض أسعار — سجل جديد";

            bbiFirst.Enabled = _currentIndex > 0;
            bbiPrev.Enabled = _currentIndex > 0;
            bbiNext.Enabled = _currentIndex < _list.Count - 1;
            bbiLast.Enabled = _currentIndex < _list.Count - 1;
            bbiRegisterQuotation.Enabled = _rfqId > 0;
            bbiTechnicalEvaluation.Enabled = _rfqId > 0;
            bbiAwardRecommendation.Enabled = _rfqId > 0;
            bbiNegotiation.Enabled = _rfqId > 0;
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

        private void FrmRFQAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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