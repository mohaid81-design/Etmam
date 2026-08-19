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
    /// <summary>Add/Edit form for the Technical Evaluation of one vendor's quotation (see
    /// Core.TechnicalEvaluationList) — pick an RFQ (optional filter) then one of its vendor quotations,
    /// mark each line compliant/non-compliant with a comment, and set an overall status (Approved /
    /// ApprovedWithComments / ClarificationRequired / Rejected). Commercial columns (unit price/total)
    /// are only populated and shown when the current user holds PermNames.ViewCommercialPrices — for a
    /// Technical Reviewer without that permission, the data itself is never fetched into these rows, not
    /// just hidden, per the methodology doc's technical/commercial separation requirement. No approval
    /// workflow of its own — toolbar is New/Navigate/Save only, matching frmPriceQuotationAddEdit.</summary>
    public partial class frmTechnicalEvaluationAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _id = 0;                                      // 0 = New, >0 = Edit
        private byte[]? _rowVersion;
        private int _quotationId = 0;
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<TechnicalEvaluationList> _list = new();       // Navigator cache
        private int _currentIndex = -1;

        private BindingList<TechnicalEvaluationDetails> _details = new();
        private List<int> _deletedDetailIds = new();

        private readonly bool _canViewCommercial = PermissionService.HasPermission(PermNames.ViewCommercialPrices);

        // ── Constructor ───────────────────────────────────────────────────────
        /// <param name="fromRFQId">Pre-filters the RFQ lookup so the quotation picker only lists vendors
        /// invited to this envelope — used when opened from frmRFQAddEdit.</param>
        /// <param name="fromQuotationId">Opens a new evaluation directly against this quotation.</param>
        public frmTechnicalEvaluationAddEdit(int id = 0, int fromQuotationId = 0, int fromRFQId = 0)
        {
            InitializeComponent();
            if (DesignMode) return;

            WireEvents();
            SetupLookups();
            SetupGrid();
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
                if (fromQuotationId > 0)
                {
                    lookUpEditQuotation.EditValue = fromQuotationId;
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
            dateEditEvaluationDate.EditValueChanged += OnHeaderChanged;
            comboBoxEditStatus.EditValueChanged += OnHeaderChanged;
            memoEditOverallComment.EditValueChanged += OnHeaderChanged;

            gridView.KeyDown += GridView_KeyDown;

            this.FormClosing += FrmTechnicalEvaluationAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            lookUpEditRFQ.Properties.DataSource = dc.RFQList.GetBy("IsDelete = 0");
            lookUpEditRFQ.Properties.ValueMember = "Id";
            lookUpEditRFQ.Properties.DisplayMember = "Num";
            lookUpEditRFQ.Properties.NullText = "-- كل طلبات RFQ --";

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

        private void SetupGrid()
        {
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            colUnitPrice.Visible = _canViewCommercial;
            colTotalPrice.Visible = _canViewCommercial;

            BindDetails(new List<TechnicalEvaluationDetails>());
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.TechnicalEvaluationList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.EvaluationDate)
                .ThenByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.TechnicalEvaluationList.Find(id);
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

            lookUpEditRFQ.EditValue = rec.RFQId;
            RefreshQuotationLookup(rec.RFQId ?? 0);
            lookUpEditQuotation.EditValue = rec.PriceQuotationRequestId;
            dateEditEvaluationDate.EditValue = rec.EvaluationDate;
            comboBoxEditStatus.EditValue = rec.Status;
            memoEditOverallComment.EditValue = rec.OverallComment;

            LoadDetails(id);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.TechnicalEvaluationDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            PopulateQuotationLineDisplay(list);
            BindDetails(list);
        }

        /// <summary>Refreshes each row's display-only fields (item/qty/unit and, only when the current
        /// user holds ViewCommercialPrices, unit price/total) from the quotation line it evaluates — the
        /// join table (PriceQuotationRequestDetails) is authoritative, this is never persisted here.</summary>
        private void PopulateQuotationLineDisplay(List<TechnicalEvaluationDetails> list)
        {
            var qLineIds = list.Where(d => d.PriceQuotationRequestDetailId is > 0)
                .Select(d => d.PriceQuotationRequestDetailId!.Value).ToList();
            if (qLineIds.Count == 0) return;

            var qLinesById = dc.PriceQuotationRequestDetails
                .GetBy($"Id IN ({string.Join(",", qLineIds)})")
                .ToDictionary(l => l.Id);
            var unitsCache = dc.Units.GetBy("IsDelete = 0").ToList();
            var itemsCache = dc.ItemsList.GetBy("IsDelete = 0").ToList();

            foreach (var d in list)
            {
                if (d.PriceQuotationRequestDetailId is not > 0 ||
                    !qLinesById.TryGetValue(d.PriceQuotationRequestDetailId.Value, out var qLine)) continue;

                d.ItemDisplay = qLine.Description ?? itemsCache.FirstOrDefault(i => i.Id == qLine.ItemId)?.Name;
                d.Qty = qLine.Qty;
                d.UnitDisplay = unitsCache.FirstOrDefault(u => u.Id == qLine.UnitId)?.Abbreviation;

                if (_canViewCommercial)
                {
                    d.UnitPrice = qLine.UnitPrice;
                    d.TotalPrice = qLine.TotalWithTax ?? qLine.TotalPrice;
                }
            }
        }

        private void BindDetails(List<TechnicalEvaluationDetails> source)
        {
            _details = new BindingList<TechnicalEvaluationDetails>(source);
            gridControl.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _quotationId = 0;
            _deletedDetailIds.Clear();
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            lookUpEditRFQ.EditValue = null;
            RefreshQuotationLookup(0);
            lookUpEditQuotation.EditValue = null;
            dateEditEvaluationDate.EditValue = DateTime.Today;
            comboBoxEditStatus.EditValue = null;
            memoEditOverallComment.EditValue = string.Empty;

            BindDetails(new List<TechnicalEvaluationDetails>());

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditQuotation.Focus();
        }

        /// <summary>Populates the grid with one row per line of the selected quotation, seeded compliant
        /// by default (the reviewer un-checks what doesn't meet spec) — only on a brand-new evaluation
        /// with no lines yet, so re-selecting the quotation on an existing evaluation never wipes out
        /// verdicts already recorded.</summary>
        private void LookUpEditQuotation_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);

            _quotationId = lookUpEditQuotation.EditValue as int? ?? 0;
            if (_quotationId <= 0) return;
            if (_id != 0 || _details.Count > 0) return;

            var lines = dc.PriceQuotationRequestDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id = _quotationId })
                .OrderBy(l => l.Id)
                .ToList();

            var details = lines.Select(l => new TechnicalEvaluationDetails
            {
                PriceQuotationRequestDetailId = l.Id,
                IsCompliant = true
            }).ToList();

            PopulateQuotationLineDisplay(details);
            BindDetails(details);
            SetDirty();
        }

        private int SaveAndReturnId()
        {
            if (!ValidateHeader()) return 0;
            return SaveRecord(silent: true) ? _id : 0;
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            try
            {
                TechnicalEvaluationList? newRec = null;
                TechnicalEvaluationList? savedRec = null;

                Data.DataContext.RunInTransaction(tx =>
                {
                    if (_id == 0)
                    {
                        var rec = BuildHeaderEntity();
                        rec.CreatedDate = DateTime.Now;
                        rec.CreatedMachine = Session.Machine;
                        rec.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        rec.IsDelete = false;

                        _id = dc.TechnicalEvaluationList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "TechnicalEvaluationList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.TechnicalEvaluationList.Find(_id);
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion;

                        dc.TechnicalEvaluationList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "TechnicalEvaluationList", _id, existing, rec);
                    }

                    SaveDetails(_id, tx);
                });

                _rowVersion = savedRec?.RowVersion;
                SetDirty(false);
                _anySaved = true;

                Loadlist();
                _currentIndex = _list.FindIndex(r => r.Id == _id);
                UpdateNavigatorCaption();

                if (!silent)
                {
                    XtraMessageBox.Show("تم حفظ التقييم الفني بنجاح ✓", "حفظ",
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
            var helper = dc.TechnicalEvaluationDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<TechnicalEvaluationDetails>();
            var toEdit = new List<TechnicalEvaluationDetails>();
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
            var row = gridView.GetFocusedRow() as TechnicalEvaluationDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند من التقييم؟", "تأكيد",
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

            XtraMessageBox.Show("يرجى اختيار عرض المورد المراد تقييمه فنياً.", "تحقق من البيانات",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firstInvalid.Focus();
            return false;
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool ValidateHeader()
        {
            if (!ValidateRequiredFields()) return false;
            if (dateEditEvaluationDate.EditValue == null || dateEditEvaluationDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ التقييم.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditEvaluationDate.Focus();
                return false;
            }
            var status = comboBoxEditStatus.EditValue?.ToString();
            if (string.IsNullOrEmpty(status))
            {
                XtraMessageBox.Show("يرجى تحديد نتيجة التقييم الفني.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxEditStatus.Focus();
                return false;
            }
            if (_details.Count == 0)
            {
                XtraMessageBox.Show("لا توجد بنود للتقييم — يرجى اختيار عرض مورد يحتوي على بنود.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Mirrors the doc's mandatory-justification pattern for a deviation (see Award
            // Recommendation) — a Rejected/ClarificationRequired verdict needs a stated reason, not
            // just a status flip, so anyone reading the evaluation later knows why.
            if ((status == TechnicalEvaluationStatus.Rejected || status == TechnicalEvaluationStatus.ClarificationRequired)
                && string.IsNullOrWhiteSpace(memoEditOverallComment.Text))
            {
                XtraMessageBox.Show("يرجى كتابة سبب الرفض/طلب التوضيح في الملاحظة العامة.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                memoEditOverallComment.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private TechnicalEvaluationList BuildHeaderEntity()
        {
            var quotation = _quotationId > 0 ? dc.PriceQuotationRequestList.Find(_quotationId) : null;

            return new TechnicalEvaluationList
            {
                RFQId = quotation?.RFQId,
                PriceQuotationRequestId = _quotationId > 0 ? _quotationId : null,
                EvaluationDate = dateEditEvaluationDate.EditValue as DateTime?,
                EvaluatedBy = Session.CurrentUser?.Id,
                Status = comboBoxEditStatus.EditValue?.ToString(),
                OverallComment = memoEditOverallComment.Text?.Trim()
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"التقييم الفني  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل تقييم فني — سجل جديد";

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

        private void FrmTechnicalEvaluationAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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
