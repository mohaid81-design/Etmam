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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Add/Edit form for a saved price-quotation comparison: pick a Purchase Request, pick which
    /// of its quotations (PriceQuotationRequestList rows sharing the same PRId) to compare, and the grid
    /// fills automatically — one row per PR item, one unit-price/total column pair per selected quotation,
    /// cheapest total highlighted. The selection is persisted (PriceQuotationCompareList/Details) so the
    /// same comparison can be reopened later via New/Navigate like any other record in the app.</summary>
    public partial class frmPriceQuotationCompareAddEdit : DevExpress.XtraEditors.XtraForm
    {
        // ── DataContext Shortcut ──────────────────────────────────────────────
        private static Data.DataContext dc => Data.DataContext.Shared;

        // ── State ─────────────────────────────────────────────────────────────
        private int _id = 0;                                              // 0 = New, >0 = Edit
        private byte[]? _rowVersion;                                      // concurrency token captured on load, see SqlDataHelper<T>
        private bool _isDirty = false;
        private bool _anySaved = false;
        private List<PriceQuotationCompareList> _list = new();            // Navigator cache
        private int _currentIndex = -1;

        private List<PriceQuotationRequestList> _quotationsForPR = new(); // Quotations available for the selected PR
        private List<string> _totalColumnFieldNames = new();              // Comparison grid's "الإجمالي" columns, for lowest-price highlighting

        // ── Constructor ───────────────────────────────────────────────────────
        public frmPriceQuotationCompareAddEdit(int id = 0, int fromPRId = 0)
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
                if (fromPRId > 0)
                {
                    RefreshPurchaseRequestLookup(fromPRId);
                    lookUpEditPurchaseRequest.EditValue = fromPRId;
                }
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

            btnPurchaseRequest.Click += (s, e) => SafeAction(QuickAddPurchaseRequest);
            // الحقل المطلوب الوحيد (خلفية خضراء) — يُعاد للأخضر تلقائياً فور تعبئته إن كان قد تحوّل
            // لسالمون بسبب محاولة حفظ فاشلة (انظر ValidateRequiredFields).
            lookUpEditPurchaseRequest.EditValueChanged += (s, e) => RevalidateField(lookUpEditPurchaseRequest, lookUpEditPurchaseRequest.EditValue != null && lookUpEditPurchaseRequest.EditValue != DBNull.Value);
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;

            comboBoxEditRequestType.EditValueChanged += OnHeaderChanged;
            memoEditPurpose.EditValueChanged += OnHeaderChanged;

            clbQuotations.MouseUp += (s, e) => RebuildAndMarkDirty();
            clbQuotations.KeyUp += (s, e) => RebuildAndMarkDirty();

            gridView1.RowCellStyle += GridView1_RowCellStyle;

            this.FormClosing += FrmPriceQuotationCompareAddEdit_FormClosing;
        }

        private void SetupLookups()
        {
            lookUpEditPrj.Properties.DataSource = dc.ProjectsList.GetBy("IsDelete = 0");
            lookUpEditPrj.Properties.ValueMember = "Id";
            lookUpEditPrj.Properties.DisplayMember = "Name";

            RefreshPurchaseRequestLookup();
        }

        /// <summary>يعرض طلبات الشراء المعتمدة فقط، وهي وحدها التي قد تُرسَل عليها طلبات عروض أسعار للمقارنة.</summary>
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
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
        }

        // ── Selection-List Button ─────────────────────────────────────────────
        private void QuickAddPurchaseRequest()
        {
            using var frm = new frmPurchaseRequestSelect();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.SelectedPR == null) return;

            RefreshPurchaseRequestLookup(frm.SelectedPR.Id);
            lookUpEditPurchaseRequest.EditValue = frm.SelectedPR.Id;
        }

        private void LookUpEditPurchaseRequest_EditValueChanged(object? sender, EventArgs e)
        {
            OnHeaderChanged(sender, e);

            if (lookUpEditPurchaseRequest.EditValue is int prId && prId > 0)
            {
                var pr = dc.PurchaseRequestList.Find(prId);
                lookUpEditPrj.EditValue = pr?.PrjId;
                if (string.IsNullOrWhiteSpace(memoEditPurpose.Text))
                    memoEditPurpose.EditValue = pr?.Purpose;

                LoadQuotationsForPR(prId, null);
            }
            else
            {
                lookUpEditPrj.EditValue = null;
                _quotationsForPR.Clear();
                clbQuotations.Items.Clear();
                RebuildComparisonGrid();
            }
        }

        /// <summary>يملأ قائمة عروض الأسعار المرتبطة بطلب الشراء المحدد، مع تحديد العروض التي كانت
        /// محفوظة مسبقاً ضمن هذه المقارنة (عند التحميل) أو بلا تحديد (عند اختيار طلب جديد).</summary>
        private void LoadQuotationsForPR(int prId, List<int>? presetSelectedIds)
        {
            _quotationsForPR = dc.PriceQuotationRequestList
                .GetBy("PRId = @id AND IsDelete = 0", new { id = prId })
                .OrderBy(q => q.Id)
                .ToList();

            clbQuotations.Items.Clear();
            foreach (var q in _quotationsForPR)
            {
                var supplierName = q.StakeholderId is int sid ? dc.StakeholdersList.Find(sid)?.Name : null;
                var rfqLabel = q.RFQId is > 0 ? $"RFQ{dc.RFQList.Find(q.RFQId.Value)?.Num:D5}   |   " : "";
                string label = $"{rfqLabel}{supplierName ?? "—"}   |   عرض رقم {q.Num}   |   الإجمالي {q.Amount:N2}";
                clbQuotations.Items.Add(q.Id, label);
            }

            if (presetSelectedIds is { Count: > 0 })
            {
                foreach (CheckedListBoxItem item in clbQuotations.Items)
                    item.CheckState = presetSelectedIds.Contains((int)item.Value) ? CheckState.Checked : CheckState.Unchecked;
            }

            RebuildComparisonGrid();
        }

        private void RebuildAndMarkDirty()
        {
            RebuildComparisonGrid();
            SetDirty();
        }

        private List<int> ReadCheckedQuotationIds()
        {
            var ids = new List<int>();
            foreach (CheckedListBoxItem item in clbQuotations.Items)
                if (item.CheckState == CheckState.Checked)
                    ids.Add((int)item.Value);
            return ids;
        }

        // ── Comparison Grid ───────────────────────────────────────────────────
        /// <summary>يبني جدول المقارنة ديناميكياً: صف لكل بند من بنود طلب الشراء، وعمودا (سعر الوحدة/الإجمالي)
        /// لكل عرض سعر محدَّد من القائمة، بالإضافة إلى صف إجمالي ختامي. يُنفَّذ عند كل تغيير في التحديد.</summary>
        private void RebuildComparisonGrid()
        {
            _totalColumnFieldNames = new List<string>();

            var prId = lookUpEditPurchaseRequest.EditValue as int?;
            var checkedIds = ReadCheckedQuotationIds();

            if (prId is not int pid || pid <= 0 || checkedIds.Count == 0)
            {
                gridView1.Columns.Clear();
                gridControl1.DataSource = null;
                return;
            }

            var prLines = dc.PurchaseRequestDetails
                .GetBy("PRId = @id AND IsDelete = 0", new { id = pid })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            var selectedQuotations = _quotationsForPR.Where(q => checkedIds.Contains(q.Id)).ToList();
            var unitsCache = dc.Units.GetBy("IsDelete = 0").ToList();

            var detailsByQuotation = selectedQuotations.ToDictionary(
                q => q.Id,
                q => dc.PriceQuotationRequestDetails.GetBy("ParentId = @id AND IsDelete = 0", new { id = q.Id }).ToList());

            var dt = new DataTable();
            dt.Columns.Add("البند", typeof(string));
            dt.Columns.Add("الكمية", typeof(decimal));
            dt.Columns.Add("الوحدة", typeof(string));

            var unitColOf = new Dictionary<int, string>();
            var totalColOf = new Dictionary<int, string>();

            foreach (var q in selectedQuotations)
            {
                var supplierName = q.StakeholderId is int sid ? dc.StakeholdersList.Find(sid)?.Name : null;
                string baseName = supplierName ?? $"مورد #{q.Id}";
                string unitCol = $"{baseName} - سعر الوحدة (#{q.Num})";
                string totalCol = $"{baseName} - الإجمالي (#{q.Num})";

                dt.Columns.Add(unitCol, typeof(decimal));
                dt.Columns.Add(totalCol, typeof(decimal));
                unitColOf[q.Id] = unitCol;
                totalColOf[q.Id] = totalCol;
                _totalColumnFieldNames.Add(totalCol);
            }

            foreach (var line in prLines)
            {
                var row = dt.NewRow();
                row["البند"] = line.Description ?? dc.ItemsList.Find(line.ItemId ?? 0)?.Name ?? "-";
                row["الكمية"] = line.Qty ?? 0;
                row["الوحدة"] = unitsCache.FirstOrDefault(u => u.Id == line.UnitId)?.Abbreviation ?? "";

                foreach (var q in selectedQuotations)
                {
                    var detail = detailsByQuotation[q.Id].FirstOrDefault(d => d.PRDetailsId == line.Id);
                    row[unitColOf[q.Id]] = (object?)detail?.UnitPrice ?? DBNull.Value;
                    row[totalColOf[q.Id]] = (object?)(detail?.TotalWithTax ?? detail?.TotalPrice) ?? DBNull.Value;
                }

                dt.Rows.Add(row);
            }

            var totalsRow = dt.NewRow();
            totalsRow["البند"] = "الإجمالي الكلي";
            totalsRow["الكمية"] = DBNull.Value;
            totalsRow["الوحدة"] = DBNull.Value;
            foreach (var q in selectedQuotations)
            {
                totalsRow[unitColOf[q.Id]] = DBNull.Value;
                totalsRow[totalColOf[q.Id]] = detailsByQuotation[q.Id].Sum(d => d.TotalWithTax ?? d.TotalPrice ?? 0);
            }
            dt.Rows.Add(totalsRow);

            gridView1.Columns.Clear();
            gridControl1.DataSource = dt;
            StyleComparisonColumns();
        }

        private void StyleComparisonColumns()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.OptionsColumn.AllowEdit = false;

                if (col.ColumnType == typeof(decimal))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n2";
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }

            gridView1.BestFitColumns();
        }

        /// <summary>يبرز بالأخضر أرخص عرض (أقل إجمالي) في كل صف من صفوف المقارنة.</summary>
        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (_totalColumnFieldNames.Count < 2 || !_totalColumnFieldNames.Contains(e.Column.FieldName)) return;

            decimal? min = null;
            foreach (var colName in _totalColumnFieldNames)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, colName) is decimal d)
                    if (min == null || d < min) min = d;
            }

            if (min.HasValue && min.Value > 0 &&
                gridView1.GetRowCellValue(e.RowHandle, e.Column) is decimal cellVal && cellVal == min.Value)
            {
                e.Appearance.BackColor = Color.FromArgb(198, 239, 206);
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        // ── Data Loading ──────────────────────────────────────────────────────
        private void Loadlist()
        {
            _list = dc.PriceQuotationCompareList
                .GetBy("IsDelete = 0")
                .OrderByDescending(r => r.Id)
                .ToList();
        }

        private void LoadRecord(int id)
        {
            var rec = dc.PriceQuotationCompareList.Find(id);
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
            _isDirty = false; // pause dirty tracking while filling fields

            textEditNum.Text = FormatNumber(rec.Num);
            lookUpEditPrj.EditValue = rec.PrjId;
            comboBoxEditRequestType.EditValue = rec.RequestType;
            memoEditPurpose.EditValue = rec.Purpose;

            RefreshPurchaseRequestLookup(rec.PRId ?? 0);
            lookUpEditPurchaseRequest.EditValueChanged -= LookUpEditPurchaseRequest_EditValueChanged;
            lookUpEditPurchaseRequest.EditValue = rec.PRId;
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;

            var selectedIds = dc.PriceQuotationCompareDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .Select(d => d.PriceQuotationRequestId ?? 0)
                .ToList();

            LoadQuotationsForPR(rec.PRId ?? 0, selectedIds);

            UpdateNavigatorCaption();
            SetDirty(false);
        }

        // ── Record Operations (New / Save) ───────────────────────────────────
        private void NewRecord()
        {
            foreach (var (control, _) in RequiredFieldChecks())
                SetRequiredFieldState(control, true);

            _id = 0;
            _rowVersion = null;
            _isDirty = false; // pause dirty tracking while filling defaults

            textEditNum.Text = "جديد";
            lookUpEditPrj.EditValue = Session.SelectedProjectId;
            comboBoxEditRequestType.EditValue = null;
            memoEditPurpose.EditValue = string.Empty;

            lookUpEditPurchaseRequest.EditValueChanged -= LookUpEditPurchaseRequest_EditValueChanged;
            lookUpEditPurchaseRequest.EditValue = null;
            lookUpEditPurchaseRequest.EditValueChanged += LookUpEditPurchaseRequest_EditValueChanged;

            _quotationsForPR.Clear();
            clbQuotations.Items.Clear();
            RebuildComparisonGrid();

            _currentIndex = -1;
            UpdateNavigatorCaption();
            SetDirty(false);

            lookUpEditPurchaseRequest.Focus();
        }

        private bool SaveRecord(bool silent = false)
        {
            if (!ValidateHeader()) return false;

            try
            {
                PriceQuotationCompareList? newRec = null;
                PriceQuotationCompareList? savedRec = null;

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

                        _id = dc.PriceQuotationCompareList.Add(rec, tx);
                        newRec = rec;
                        savedRec = rec;
                        AuditService.LogCreate(tx, "PriceQuotationCompareList", _id, rec);
                    }
                    else
                    {
                        var rec = BuildHeaderEntity();
                        var existing = dc.PriceQuotationCompareList.Find(_id);
                        rec.Num = existing?.Num;
                        rec.UpdateDate = DateTime.Now;
                        rec.UpdateMachine = Session.Machine;
                        rec.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        rec.RowVersion = _rowVersion; // expected version — see SqlDataHelper<T>.EditAsync

                        dc.PriceQuotationCompareList.Edit(_id, rec, tx);
                        savedRec = rec;
                        AuditService.LogUpdate(tx, "PriceQuotationCompareList", _id, existing, rec);
                    }

                    SaveSelectedQuotations(_id, tx);
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
                    XtraMessageBox.Show("تم حفظ المقارنة بنجاح ✓", "حفظ",
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

        private void SaveSelectedQuotations(int id, SqlTransaction tx)
        {
            dc.PriceQuotationCompareDetails.DeleteBy("ParentId = @id", new { id }, tx);

            var rows = ReadCheckedQuotationIds().Select(quotationId => new PriceQuotationCompareDetails
            {
                ParentId = id,
                PriceQuotationRequestId = quotationId,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine,
                CreatedBy = Session.CurrentUser?.Id ?? 1,
                IsDelete = false
            }).ToList();

            if (rows.Count > 0) dc.PriceQuotationCompareDetails.AddRange(rows, tx);
        }

        private PriceQuotationCompareList BuildHeaderEntity()
        {
            return new PriceQuotationCompareList
            {
                PrjId = lookUpEditPrj.EditValue as int?,
                PRId = lookUpEditPurchaseRequest.EditValue as int?,
                RFQId = GetCommonRFQIdOfCheckedQuotations(),
                RequestType = comboBoxEditRequestType.EditValue?.ToString(),
                Purpose = memoEditPurpose.Text?.Trim()
            };
        }

        /// <summary>Returns the single RFQ envelope every currently-checked quotation shares (see
        /// Core.RFQList), or null when they come from mixed RFQs (or none at all) — purely for the saved
        /// comparison's own traceability, not used to filter or validate the selection itself.</summary>
        private int? GetCommonRFQIdOfCheckedQuotations()
        {
            var checkedIds = ReadCheckedQuotationIds().ToHashSet();
            var rfqIds = _quotationsForPR
                .Where(q => checkedIds.Contains(q.Id))
                .Select(q => q.RFQId)
                .Distinct()
                .ToList();

            return rfqIds.Count == 1 ? rfqIds[0] : null;
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
                XtraMessageBox.Show("يرجى حفظ المقارنة قبل الطباعة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // لا يوجد بعد تقرير طباعة مخصص لمقارنة عروض الأسعار — نفس الفجوة الموثّقة حالياً في
            // أمر الشراء وطلب عرض السعر (انظر frmPurchaseOrderAddEdit / frmPriceQuotationAddEdit).
            XtraMessageBox.Show("طباعة مقارنة عروض الأسعار غير متاحة حالياً.", "تنبيه",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Required-field validation (green = required, salmon = missing on failed save) ───────

        /// <summary>lookUpEditPurchaseRequest is the only field marked with a green background in the
        /// Designer. clbQuotations (checked quotations) is a separate business rule below since a
        /// CheckedListBoxControl isn't a BaseEdit and isn't green-marked anyway.</summary>
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
            if (!ValidateRequiredFields()) return false;
            if (ReadCheckedQuotationIds().Count == 0)
            {
                XtraMessageBox.Show("يرجى تحديد عرضي سعر على الأقل للمقارنة بينهما.", "تحقق من البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbQuotations.Focus();
                return false;
            }
            return true;
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        /// <summary>Delegates to NumberingService (concurrency-safe via sp_getapplock on the save
        /// transaction) instead of computing MAX(Num)+1 here, which two users saving at the same
        /// instant could race.</summary>
        private int GetNextNumber(SqlTransaction tx) =>
            NumberingService.GetNextNumber(tx, "PriceQuotationCompareList", null, () =>
                dc.PriceQuotationCompareList
                    .GetBy("IsDelete = 0")
                    .Select(r => r.Num ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        private static string FormatNumber(int? num) => num.HasValue ? $"CMP{num.Value:D5}" : "جديد";

        private void UpdateNavigatorCaption()
        {
            Text = _currentIndex >= 0 && _list.Count > 0
                ? $"مقارنة عروض أسعار  [{FormatNumber(_list[_currentIndex].Num)}]  |  {_currentIndex + 1} / {_list.Count}"
                : "إضافة / تعديل مقارنة عروض أسعار — سجل جديد";

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
        private void FrmPriceQuotationCompareAddEdit_FormClosing(object? sender, FormClosingEventArgs e)
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
