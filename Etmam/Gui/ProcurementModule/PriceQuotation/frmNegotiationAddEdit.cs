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

namespace Etmam
{
    /// <summary>Add/Edit form for one negotiation round against a vendor's quotation (see
    /// Core.NegotiationList) — "Original / Round 01 / Round 02 / ... / BAFO" per the methodology doc.
    /// A round already superseded by a later one is read-only (NegotiationService.IsLatestRound) — a new
    /// round is always a new record, never an edit to a prior one. Once a round is marked BAFO (Best And
    /// Final Offer), no further round can be started for that quotation. Round numbers are assigned via
    /// NumberingService at save time (scoped per quotation), not MAX+1. No approval workflow of its own —
    /// toolbar is New/Navigate/Save only.</summary>

    public partial class frmNegotiationAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;
        private int _quotationId = 0;
        private bool _isLocked = false;
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<NegotiationList> _list = new();
        private int _currentIndex = -1;

        public frmNegotiationAddEdit(int id = 0, int fromQuotationId = 0, int fromRFQId = 0)
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
                if (fromQuotationId > 0) lookUpEditQuotation.EditValue = fromQuotationId;
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
            dateEditNegotiationDate.EditValueChanged += OnHeaderChanged;
            // الحقول المطلوبة (خلفية خضراء) — تُعاد للأخضر تلقائياً فور تعبئتها إن كانت قد تحوّلت
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            textEditNewAmount.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RevalidateField(textEditNewAmount, decimal.TryParse(textEditNewAmount.Text, out var amt) && amt > 0); };
            checkEditIsBAFO.CheckedChanged += OnHeaderChanged;
            memoEditNotes.EditValueChanged += OnHeaderChanged;

            this.FormClosing += FrmNegotiationAddEdit_FormClosing;
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
                q.SupplierName = $"{supplierName ?? "—"}  |  عرض رقم {q.Num}";
            }

            lookUpEditQuotation.Properties.DataSource = quotations;
            lookUpEditQuotation.Properties.ValueMember = "Id";
            lookUpEditQuotation.Properties.DisplayMember = "SupplierName";
            lookUpEditQuotation.Properties.NullText = "-- اختر عرض المورد --";
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.NegotiationList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.NegotiationList.Find(id);
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
            _quotationId = rec.PriceQuotationRequestId ?? 0;
            _isDirty = false;

            lookUpEditRFQ.EditValue = rec.RFQId;
            RefreshQuotationLookup(rec.RFQId ?? 0);
            lookUpEditQuotation.EditValue = rec.PriceQuotationRequestId;
            textEditRound.Text = FormatRoundLabel(rec.RoundNumber, rec.IsBAFO);
            dateEditNegotiationDate.EditValue = rec.NegotiationDate;
            textEditPreviousAmount.Text = rec.PreviousAmount?.ToString("N2") ?? "";
            textEditNewAmount.Text = rec.NewAmount?.ToString("N2") ?? "";
            checkEditIsBAFO.Checked = rec.IsBAFO;
            memoEditNotes.EditValue = rec.Notes;

            _isLocked = _quotationId > 0 && !NegotiationService.IsLatestRound(dc, _quotationId, _id);
            ApplyLockState();

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void ApplyLockState()
        {
            lookUpEditRFQ.Enabled = !_isLocked;
            lookUpEditQuotation.Enabled = !_isLocked;
            dateEditNegotiationDate.Enabled = !_isLocked;
            textEditNewAmount.Enabled = !_isLocked;
            checkEditIsBAFO.Enabled = !_isLocked;
            memoEditNotes.Enabled = !_isLocked;
            bbiSave.Enabled = !_isLocked;

            labelControlLockNotice.Visible = _isLocked;
            labelControlLockNotice.Text = _isLocked
                ? "هذه الجولة سابقة وقد تجاوزتها جولة تالية — للقراءة فقط."
                : "";
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _id = 0;
            _rowVersion = null;
            _quotationId = 0;
            _isLocked = false;
            _isDirty = false;

            lookUpEditRFQ.EditValue = null;
            RefreshQuotationLookup(0);
            lookUpEditQuotation.EditValue = null;
            textEditRound.Text = "سيُحدَّد عند الحفظ";
            dateEditNegotiationDate.EditValue = DateTime.Today;
            textEditPreviousAmount.Text = "";
            textEditNewAmount.Text = "";
            checkEditIsBAFO.Checked = false;
            memoEditNotes.EditValue = string.Empty;

            ApplyLockState();

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditRFQ.Focus();
        }

        /// <summary>Previews the "previous amount" a new round would negotiate against (the quotation's
        /// current amount — either its original Amount, or its latest existing round's NewAmount) —
        /// display only; the real round number is assigned at save time by NumberingService, not here.</summary>
        private void LookUpEditQuotation_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            RevalidateField(lookUpEditQuotation, lookUpEditQuotation.EditValue != null && lookUpEditQuotation.EditValue != DBNull.Value);
            _quotationId = lookUpEditQuotation.EditValue as int? ?? 0;

            if (_id != 0) return; // editing an existing round — its own snapshot stays as loaded

            if (_quotationId <= 0)
            {
                textEditPreviousAmount.Text = "";
                return;
            }

            var current = NegotiationService.GetCurrentAmount(dc, _quotationId);
            textEditPreviousAmount.Text = current?.ToString("N2") ?? "";
        }

        private bool SaveRecord(bool silent = false)
        {
            if (_isLocked)
            {
                XtraMessageBox.Show("هذه جولة سابقة تجاوزتها جولة تالية — لا يمكن تعديلها.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidateHeader()) return false;

            try
            {
                if (_id == 0 && NegotiationService.HasBAFO(dc, _quotationId))
                {
                    XtraMessageBox.Show(
                        "هذا العرض لديه بالفعل عرض نهائي (BAFO) مسجَّل — لا يمكن إضافة جولة تفاوض تالية له.",
                        "تحقق من البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                NegotiationList? newRec = null;
                NegotiationList? savedRec = null;

                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_id == 0)
                    {
                        var rec = BuildHeaderEntity();
                        rec.RoundNumber = NegotiationService.GetNextRoundNumber(tx, _quotationId);
                        rec.PreviousAmount = NegotiationService.GetCurrentAmount(dc, _quotationId);
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;

                        _id = dc.NegotiationList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "NegotiationList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.NegotiationList.Find(_id);
                        rec.RoundNumber = existing?.RoundNumber;
                        rec.PreviousAmount = existing?.PreviousAmount;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion;

                        dc.NegotiationList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "NegotiationList", _id, existing, rec);
                    }
                });

                if (newRec != null) textEditRound.Text = FormatRoundLabel(newRec.RoundNumber, newRec.IsBAFO);
                textEditPreviousAmount.Text = savedRec?.PreviousAmount?.ToString("N2") ?? "";
                _rowVersion = savedRec?.RowVersion;
                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ جولة التفاوض بنجاح ✓", "حفظ",
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

        /// <summary>The two fields marked with a green background in the Designer — lookUpEditQuotation
        /// and textEditNewAmount (whose isFilled reuses the form's pre-existing "must be a positive
        /// amount" rule). dateEditNegotiationDate isn't green-marked, so its existing check below stays
        /// separate/untouched.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditQuotation as DevExpress.XtraEditors.BaseEdit, lookUpEditQuotation.EditValue != null && lookUpEditQuotation.EditValue != DBNull.Value),
            (textEditNewAmount as DevExpress.XtraEditors.BaseEdit, decimal.TryParse(textEditNewAmount.Text, out var newAmount) && newAmount > 0),
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
            if (dateEditNegotiationDate.EditValue == null || dateEditNegotiationDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ جولة التفاوض.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditNegotiationDate.Focus();
                return false;
            }
            if (!ValidateRequiredFields()) return false;
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private NegotiationList BuildHeaderEntity()
        {
            var quotation = _quotationId > 0 ? dc.PriceQuotationRequestList.Find(_quotationId) : null;

            return new NegotiationList
            {
                RFQId = quotation?.RFQId,
                PriceQuotationRequestId = _quotationId > 0 ? _quotationId : null,
                NegotiationDate = dateEditNegotiationDate.EditValue as DateTime?,
                NewAmount = decimal.TryParse(textEditNewAmount.Text, out var amt) ? amt : null,
                IsBAFO = checkEditIsBAFO.Checked,
                Notes = memoEditNotes.Text?.Trim()
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private static string FormatRoundLabel(int? roundNumber, bool isBAFO) =>
            isBAFO ? $"العرض النهائي (BAFO) — الجولة {roundNumber}"
            : roundNumber is > 0 ? $"الجولة {roundNumber}"
            : "—";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"جولة تفاوض  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل جولة تفاوض — سجل جديد";

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

        private void FrmNegotiationAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isDirty && !_isLocked)
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
