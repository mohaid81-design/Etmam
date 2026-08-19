using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for recommending which vendor an RFQ should be awarded to (see
    /// Core.AwardRecommendationList) — header-only, no line items. IsLowestBid and TechnicalStatus are
    /// never entered by the user; they're recomputed from the actual data every time the recommended
    /// quotation changes and again right before save (AwardRecommendationService), so the recommendation
    /// can't silently drift from what the underlying quotations/evaluation actually say. A quotation
    /// whose latest technical evaluation is Rejected cannot be recommended at all — the methodology doc's
    /// override-policy escape hatch for that isn't implemented, so today it's an absolute block. No
    /// approval workflow of its own yet (see AwardRecommendationList.WorkflowInstanceId) — toolbar is
    /// New/Navigate/Save only, matching frmPriceQuotationAddEdit.</summary>

    public partial class frmAwardRecommendationAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;
        private int _quotationId = 0;
        private bool _isLowestBid = true;
        private string? _technicalStatus;
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<AwardRecommendationList> _list = new();
        private int _currentIndex = -1;

        public frmAwardRecommendationAddEdit(int id = 0, int fromRFQId = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            Loadlist();

            if (id > 0)
            {
                _currentIndex = _list.FindIndex(r => r.Id == id);
                LoadRecord(id);
            }
            else
            {
                NewRecord();
                if (fromRFQId > 0)
                {
                    lookUpEditRFQ.EditValue = fromRFQId;
                    RefreshQuotationLookup(fromRFQId);
                }
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

            lookUpEditRFQ.EditValueChanged += (s, e) =>
            {
                OnHeaderChanged(s, e);
                RefreshQuotationLookup(lookUpEditRFQ.EditValue as int? ?? 0);
            };
            lookUpEditQuotation.EditValueChanged += LookUpEditQuotation_EditValueChanged;
            lookUpEditQuotation.EditValueChanged += (s, e) => RevalidateField(lookUpEditQuotation, IsQuotationFilled());
            textEditRecommendedAmount.EditValueChanged += OnHeaderChanged;
            memoEditRecommendationReason.EditValueChanged += OnHeaderChanged;
            memoEditDeviationJustification.EditValueChanged += OnHeaderChanged;
            comboBoxEditBudgetStatus.EditValueChanged += OnHeaderChanged;
            comboBoxEditStatus.EditValueChanged += OnHeaderChanged;

            this.FormClosing += FrmAwardRecommendationAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            lookUpEditRFQ.Properties.DataSource = dc.RFQList.GetBy("IsDelete = 0");
            lookUpEditRFQ.Properties.ValueMember = "Id";
            lookUpEditRFQ.Properties.DisplayMember = "Num";
            lookUpEditRFQ.Properties.NullText = "-- اختر RFQ --";

            RefreshQuotationLookup(0);
        }

        private void RefreshQuotationLookup(int rfqId)
        {
            var quotations = rfqId > 0
                ? dc.PriceQuotationRequestList.GetBy("RFQId = @id AND IsDelete = 0", new { id = rfqId })
                : dc.PriceQuotationRequestList.GetBy("IsDelete = 0");

            foreach (var q in quotations)
            {
                var supplierName = q.StakeholderId is int sid ? dc.StakeholdersList.Find(sid)?.Name : null;
                q.SupplierName = $"{supplierName ?? "—"}  |  عرض رقم {q.Num}  |  الإجمالي {q.Amount:N2}";
            }

            lookUpEditQuotation.Properties.DataSource = quotations;
            lookUpEditQuotation.Properties.ValueMember = "Id";
            lookUpEditQuotation.Properties.DisplayMember = "SupplierName";
            lookUpEditQuotation.Properties.NullText = "-- اختر عرض المورد الموصى به --";
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.AwardRecommendationList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.AwardRecommendationList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _id = id;
            _rowVersion = rec.RowVersion;
            _quotationId = rec.PriceQuotationRequestId ?? 0;
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = FormatNumber(rec.Num);
            lookUpEditRFQ.EditValue = rec.RFQId;
            RefreshQuotationLookup(rec.RFQId ?? 0);
            lookUpEditQuotation.EditValue = rec.PriceQuotationRequestId;
            textEditRecommendedAmount.Text = rec.RecommendedAmount?.ToString("N2") ?? "";
            memoEditRecommendationReason.EditValue = rec.RecommendationReason;
            memoEditDeviationJustification.EditValue = rec.DeviationJustification;
            comboBoxEditBudgetStatus.EditValue = rec.BudgetStatus;
            comboBoxEditStatus.EditValue = rec.Status ?? AwardRecommendationStatus.Draft;

            RefreshComputedFields();

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _quotationId = 0;
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = "جديد";
            lookUpEditRFQ.EditValue = null;
            RefreshQuotationLookup(0);
            lookUpEditQuotation.EditValue = null;
            textEditRecommendedAmount.Text = "";
            memoEditRecommendationReason.EditValue = string.Empty;
            memoEditDeviationJustification.EditValue = string.Empty;
            comboBoxEditBudgetStatus.EditValue = null;
            comboBoxEditStatus.EditValue = AwardRecommendationStatus.Draft;

            RefreshComputedFields();

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditRFQ.Focus();
        }

        /// <summary>Recomputes IsLowestBid/TechnicalStatus from the currently selected quotation and
        /// reflects them in the read-only display fields — called on quotation change and on load.
        /// Defaults RecommendedAmount to the quotation's own Amount only while it's still empty, so it
        /// never overwrites a value the recommender already typed (e.g. after a final negotiated price).</summary>
        private void LookUpEditQuotation_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            _quotationId = lookUpEditQuotation.EditValue as int? ?? 0;

            if (_quotationId > 0 && string.IsNullOrWhiteSpace(textEditRecommendedAmount.Text))
            {
                var quotation = dc.PriceQuotationRequestList.Find(_quotationId);
                textEditRecommendedAmount.Text = quotation?.Amount?.ToString("N2") ?? "";
            }

            RefreshComputedFields();
        }

        private void RefreshComputedFields()
        {
            if (_quotationId <= 0)
            {
                _isLowestBid = true;
                _technicalStatus = null;
                textEditIsLowestBid.Text = "—";
                textEditTechnicalStatus.Text = "—";
                memoEditDeviationJustification.Enabled = false;
                return;
            }

            _isLowestBid = AwardRecommendationService.ComputeIsLowestBid(dc, _quotationId);
            _technicalStatus = AwardRecommendationService.GetLatestTechnicalStatus(dc, _quotationId);

            textEditIsLowestBid.Text = _isLowestBid ? "نعم — أقل عرض" : "لا — ليس أقل عرض";
            textEditTechnicalStatus.Text = TechnicalEvaluationStatus.ToDisplay(_technicalStatus);
            memoEditDeviationJustification.Enabled = !_isLowestBid;
            if (_isLowestBid) memoEditDeviationJustification.EditValue = string.Empty;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            try
            {
                // Re-derive right before writing, not just at selection time — the underlying
                // quotation amounts or its technical evaluation could have changed since this record
                // was opened (e.g. another user re-evaluated it or registered a cheaper quote meanwhile).
                RefreshComputedFields();
                if (_technicalStatus == TechnicalEvaluationStatus.Rejected)
                {
                    XtraMessageBox.Show(
                        "لا يمكن ترسية عرض مرفوض فنياً — التقييم الفني الحالي لهذا العرض \"مرفوض فنياً\".",
                        "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!_isLowestBid && string.IsNullOrWhiteSpace(memoEditDeviationJustification.Text))
                {
                    XtraMessageBox.Show(
                        "هذا العرض ليس الأقل سعراً — يرجى كتابة مبرر الانحراف عن أقل سعر.",
                        "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    memoEditDeviationJustification.Focus();
                    return false;
                }

                AwardRecommendationList? newRec = null;
                AwardRecommendationList? savedRec = null;

                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_id == 0)
                    {
                        var rec = BuildHeaderEntity();
                        rec.Num = GetNextNumber(tx);
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;

                        _id = dc.AwardRecommendationList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "AwardRecommendationList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.AwardRecommendationList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion;

                        dc.AwardRecommendationList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "AwardRecommendationList", _id, existing, rec);
                    }
                });

                if (newRec != null) textEditNum.Text = FormatNumber(newRec.Num);
                _rowVersion = savedRec?.RowVersion;
                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ توصية الترسية بنجاح ✓", "حفظ",
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

        private bool IsQuotationFilled() => lookUpEditQuotation.EditValue != null && lookUpEditQuotation.EditValue != DBNull.Value;

        /// <summary>The one field marked with a green background in the Designer (lookUpEditQuotation)
        /// is the record's required field. Checked together on Save; if empty it turns salmon and gets
        /// focus, matching the pattern used across the other Add/Edit forms.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditQuotation as DevExpress.XtraEditors.BaseEdit, IsQuotationFilled()),
        };

        private static void SetRequiredFieldState(DevExpress.XtraEditors.BaseEdit control, bool isFilled)
        {
            control.Properties.Appearance.BackColor = isFilled ? Color.LightGreen : Color.Salmon;
            control.Properties.Appearance.Options.UseBackColor = true;
            control.Invalidate();
        }

        /// <summary>Live revert-to-green as the user selects — called from the required field's
        /// EditValueChanged, independent of the next Save attempt.</summary>
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

            XtraMessageBox.Show("يرجى اختيار عرض المورد الموصى بترسيته.", "تحقق من البيانات",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (!ValidateRequiredFields()) return false;
            if (!decimal.TryParse(textEditRecommendedAmount.Text, out var amount) || amount <= 0)
            {
                XtraMessageBox.Show("يرجى إدخال قيمة الترسية الموصى بها.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditRecommendedAmount.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(memoEditRecommendationReason.Text))
            {
                XtraMessageBox.Show("يرجى كتابة سبب التوصية بالترسية.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                memoEditRecommendationReason.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private AwardRecommendationList BuildHeaderEntity()
        {
            return new AwardRecommendationList
            {
                RFQId = lookUpEditRFQ.EditValue as int?,
                PriceQuotationRequestId = _quotationId > 0 ? _quotationId : null,
                RecommendedAmount = decimal.TryParse(textEditRecommendedAmount.Text, out var amt) ? amt : null,
                RecommendationReason = memoEditRecommendationReason.Text?.Trim(),
                IsLowestBid = _isLowestBid,
                DeviationJustification = !_isLowestBid ? memoEditDeviationJustification.Text?.Trim() : null,
                TechnicalStatus = _technicalStatus,
                BudgetStatus = comboBoxEditBudgetStatus.EditValue?.ToString(),
                Status = comboBoxEditStatus.EditValue?.ToString() ?? AwardRecommendationStatus.Draft
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetNextNumber(SqlTransaction tx) =>
            NumberingService.GetNextNumber(tx, "AwardRecommendationList", null, () =>
                dc.AwardRecommendationList
                    .GetBy("IsDelete = 0")
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private static string FormatNumber(int? num) => num.HasValue ? $"AW{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"توصية ترسية  [{FormatNumber(_list[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل توصية ترسية — سجل جديد";

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

        private void FrmAwardRecommendationAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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
