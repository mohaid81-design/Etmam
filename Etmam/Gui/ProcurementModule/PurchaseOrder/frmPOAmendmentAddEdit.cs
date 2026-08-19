using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Data;
using DevExpress.XtraEditors;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for one amendment to an already-Approved Purchase Order (see
    /// Core.POAmendmentList) — only Approved POs are offered in the lookup, matching the doc's rule that
    /// any change after approval goes through an amendment, never a direct PO edit. PreviousValue is
    /// computed from POAmendmentService.GetCurrentValue (the PO's OriginalValue plus every previously
    /// APPROVED amendment), never user-entered; RevisedValue is derived live as PreviousValue +
    /// AmendmentValue. Once an amendment is itself Approved it becomes read-only, same as the PO it
    /// amends. No approval workflow of its own yet — toolbar is New/Navigate/Save only.</summary>
    public partial class frmPOAmendmentAddEdit : DevExpress.XtraEditors.XtraForm
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private int _id = 0;
        private byte[]? _rowVersion;
        private int _poId = 0;
        private bool _isLocked = false;
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<POAmendmentList> _list = new();
        private int _currentIndex = -1;

        private BindingList<POAmendmentDetails> _details = new();
        private List<int> _deletedDetailIds = new();
        private List<PurchaseOrderDetails> _poLinesCache = new();

        public frmPOAmendmentAddEdit(int id = 0, int fromPOId = 0)
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
                if (fromPOId > 0) lookUpEditPO.EditValue = fromPOId;
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

            lookUpEditPO.EditValueChanged += LookUpEditPO_EditValueChanged;
            lookUpEditPO.EditValueChanged += (s, e) => RevalidateField(lookUpEditPO, IsFilled(lookUpEditPO));
            dateEditAmendmentDate.EditValueChanged += OnHeaderChanged;
            textEditAmendmentValue.EditValueChanged += (s, e) => { OnHeaderChanged(s, e); RecalculateRevisedValue(); };
            textEditAmendmentValue.EditValueChanged += (s, e) => RevalidateField(textEditAmendmentValue, decimal.TryParse(textEditAmendmentValue.Text, out _));
            memoEditReason.EditValueChanged += OnHeaderChanged;
            comboBoxEditStatus.EditValueChanged += OnHeaderChanged;

            gridView.KeyDown += GridView_KeyDown;

            this.FormClosing += FrmPOAmendmentAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            var pos = dc.PurchaseOrderList.GetBy("IsDelete = 0 AND OverallStatus = @a", new { a = PurchaseOrderStatus.Approved });
            foreach (var po in pos)
                po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

            lookUpEditPO.Properties.DataSource = pos;
            lookUpEditPO.Properties.ValueMember = "Id";
            lookUpEditPO.Properties.DisplayMember = "FormattedNum";
            lookUpEditPO.Properties.NullText = "-- اختر أمر شراء معتمد --";
        }

        private void SetupGrid()
        {
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            repositoryItemLookUpEditPOLine.ValueMember = "Id";
            repositoryItemLookUpEditPOLine.DisplayMember = "Description";
            repositoryItemLookUpEditPOLine.NullText = "";

            repositoryItemButtonEditDeleteItem.ButtonClick += (s, e) => DeleteFocusedDetailRow();

            BindDetails(new List<POAmendmentDetails>());
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.POAmendmentList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.POAmendmentList.Find(id);
            if (rec == null)
            {
                XtraMessageBox.Show("لم يتم العثور على السجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _id = id;
            _rowVersion = rec.RowVersion;
            _poId = rec.POId ?? 0;
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = FormatNumber(rec.Num);
            lookUpEditPO.EditValue = rec.POId;
            RefreshPOLinesCache(_poId);
            dateEditAmendmentDate.EditValue = rec.AmendmentDate;
            textEditPreviousValue.Text = rec.PreviousValue?.ToString("N2") ?? "";
            textEditAmendmentValue.Text = rec.AmendmentValue?.ToString("N2") ?? "";
            textEditRevisedValue.Text = rec.RevisedValue?.ToString("N2") ?? "";
            memoEditReason.EditValue = rec.Reason;
            comboBoxEditStatus.EditValue = rec.Status ?? POAmendmentStatus.Draft;

            LoadDetails(id);

            _isLocked = !POAmendmentService.IsEditable(rec);
            ApplyLockState();

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        private void LoadDetails(int id)
        {
            _deletedDetailIds.Clear();
            var list = dc.POAmendmentDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            BindDetails(list);
        }

        private void BindDetails(List<POAmendmentDetails> source)
        {
            _details = new BindingList<POAmendmentDetails>(source);
            gridControl.DataSource = _details;
            _details.ListChanged += (s, e) => SetDirty();
        }

        private void ApplyLockState()
        {
            lookUpEditPO.Enabled = !_isLocked;
            dateEditAmendmentDate.Enabled = !_isLocked;
            textEditAmendmentValue.Enabled = !_isLocked;
            memoEditReason.Enabled = !_isLocked;
            comboBoxEditStatus.Enabled = !_isLocked;
            gridView.OptionsBehavior.Editable = !_isLocked;
            bbiSave.Enabled = !_isLocked;

            labelControlLockNotice.Visible = _isLocked;
            labelControlLockNotice.Text = _isLocked
                ? "هذا التعديل معتمد بالفعل — للقراءة فقط."
                : "";
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            _id = 0;
            _rowVersion = null;
            _poId = 0;
            _isLocked = false;
            _deletedDetailIds.Clear();
            _isDirty = false;

            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            textEditNum.Text = "جديد";
            lookUpEditPO.EditValue = null;
            dateEditAmendmentDate.EditValue = DateTime.Today;
            textEditPreviousValue.Text = "";
            textEditAmendmentValue.Text = "";
            textEditRevisedValue.Text = "";
            memoEditReason.EditValue = string.Empty;
            comboBoxEditStatus.EditValue = POAmendmentStatus.Draft;

            BindDetails(new List<POAmendmentDetails>());
            ApplyLockState();

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditPO.Focus();
        }

        private void LookUpEditPO_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);
            _poId = lookUpEditPO.EditValue as int? ?? 0;
            RefreshPOLinesCache(_poId);

            if (_id != 0 || _poId <= 0) return; // only pre-fill "previous value" on a brand-new record

            var current = POAmendmentService.GetCurrentValue(dc, _poId);
            textEditPreviousValue.Text = current.ToString("N2");
            RecalculateRevisedValue();
        }

        private void RefreshPOLinesCache(int poId)
        {
            _poLinesCache = poId > 0
                ? dc.PurchaseOrderDetails.GetBy("ParentId = @id AND IsDelete = 0", new { id = poId })
                : new List<PurchaseOrderDetails>();
            repositoryItemLookUpEditPOLine.DataSource = _poLinesCache;
        }

        private void RecalculateRevisedValue()
        {
            var previous = decimal.TryParse(textEditPreviousValue.Text, out var p) ? p : 0;
            var amendment = decimal.TryParse(textEditAmendmentValue.Text, out var a) ? a : 0;
            textEditRevisedValue.Text = (previous + amendment).ToString("N2");
        }

        private bool SaveRecord(bool silent = false)
        {
            if (_isLocked)
            {
                XtraMessageBox.Show("هذا التعديل معتمد بالفعل — لا يمكن تعديله.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidateHeader()) return false;

            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            try
            {
                POAmendmentList? newRec = null;
                POAmendmentList? savedRec = null;

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

                        _id = dc.POAmendmentList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "POAmendmentList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.POAmendmentList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion;

                        dc.POAmendmentList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "POAmendmentList", _id, existing, rec);
                    }

                    SaveDetails(_id, tx);
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
                    XtraMessageBox.Show("تم حفظ تعديل أمر الشراء بنجاح ✓", "حفظ",
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
            var helper = dc.POAmendmentDetails;

            if (_deletedDetailIds.Count > 0) helper.DeleteRange(_deletedDetailIds, tx);
            _deletedDetailIds.Clear();

            var toAdd = new List<POAmendmentDetails>();
            var toEdit = new List<POAmendmentDetails>();
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
            var row = gridView.GetFocusedRow() as POAmendmentDetails;
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

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateFirst()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = 0;
            LoadRecord(_list[_currentIndex].Id);
        }

        private void NavigatePrev()
        {
            if (_list.Count == 0 || _currentIndex <= 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex--;
            LoadRecord(_list[_currentIndex].Id);
        }

        private void NavigateNext()
        {
            if (_list.Count == 0 || _currentIndex >= _list.Count - 1) return;
            if (!ConfirmNavigation()) return;
            _currentIndex++;
            LoadRecord(_list[_currentIndex].Id);
        }

        private void NavigateLast()
        {
            if (_list.Count == 0) return;
            if (!ConfirmNavigation()) return;
            _currentIndex = _list.Count - 1;
            LoadRecord(_list[_currentIndex].Id);
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        private static bool IsFilled(DevExpress.XtraEditors.BaseEdit control) =>
            control.EditValue != null && control.EditValue != DBNull.Value;

        /// <summary>The two fields marked with a green background in the Designer are the header's
        /// required fields. textEditAmendmentValue's isFilled reuses the form's own pre-existing
        /// decimal-parseable check (a positive or negative amendment value is fine — see the
        /// message below), not a plain emptiness check. Checked together on Save; any that are empty
        /// turn salmon and the first one gets focus.</summary>
        private IEnumerable<(DevExpress.XtraEditors.BaseEdit control, bool isFilled)> RequiredFieldChecks() => new[]
        {
            (lookUpEditPO as DevExpress.XtraEditors.BaseEdit, IsFilled(lookUpEditPO)),
            (textEditAmendmentValue as DevExpress.XtraEditors.BaseEdit, decimal.TryParse(textEditAmendmentValue.Text, out _)),
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
            if (dateEditAmendmentDate.EditValue == null || dateEditAmendmentDate.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("يرجى تحديد تاريخ التعديل.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEditAmendmentDate.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(memoEditReason.Text))
            {
                XtraMessageBox.Show("يرجى كتابة سبب التعديل.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                memoEditReason.Focus();
                return false;
            }
            return true;
        }

        // ── Entity Builder ────────────────────────────────────────────────────
        private POAmendmentList BuildHeaderEntity()
        {
            return new POAmendmentList
            {
                POId = _poId > 0 ? _poId : null,
                AmendmentDate = dateEditAmendmentDate.EditValue as DateTime?,
                PreviousValue = decimal.TryParse(textEditPreviousValue.Text, out var prev) ? prev : null,
                AmendmentValue = decimal.TryParse(textEditAmendmentValue.Text, out var amt) ? amt : null,
                RevisedValue = decimal.TryParse(textEditRevisedValue.Text, out var rev) ? rev : null,
                Reason = memoEditReason.Text?.Trim(),
                Status = comboBoxEditStatus.EditValue?.ToString() ?? POAmendmentStatus.Draft
            };
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private int GetNextNumber(SqlTransaction tx) =>
            NumberingService.GetNextNumber(tx, "POAmendmentList", null, () =>
                dc.POAmendmentList
                    .GetBy("IsDelete = 0")
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private static string FormatNumber(int? num) => num.HasValue ? $"AMD{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"تعديل أمر شراء  [{FormatNumber(_list[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل — تعديل أمر شراء جديد";

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
            try { action(); }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ غير متوقع:\n{ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPOAmendmentAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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
