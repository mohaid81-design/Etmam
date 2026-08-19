using System.ComponentModel;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Data.SqlClient;

namespace Etmam
{
    /// <summary>Editor for a single Bill of Quantities: header (read-only, set at creation via
    /// frmBOQNew) + a grouped grid of line items (sections = groups, items = rows).</summary>
    public partial class ucBOQEditor : DevExpress.XtraEditors.XtraUserControl
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        private int _boqId = 0;
        private BOQList _header = new();
        private byte[]? _rowVersion;
        private bool _isLocked;
        private bool _loading;
        private decimal _totalAtLoad;
        private int _tempSectionSeq = -1;

        private readonly BindingList<BOQSectionDetails> _sections = new();
        private readonly BindingList<BOQItemDetails> _items = new();
        private readonly List<int> _deletedSectionIds = new();
        private readonly List<int> _deletedItemIds = new();
        private int? _currentSectionId;

        public ucBOQEditor()
        {
            InitializeComponent();
            if (DesignMode) return;

            ConfigureGrid();
            grdBOQItems.DataSource = _items;
            _items.ListChanged += (s, e) => { if (!_loading) RecalculateSummary(); };
            WireEvents();

            LoadBOQ(null);
        }

        // ── Grid setup ───────────────────────────────────────────────────────
        private void ConfigureGrid()
        {
            colParent.Caption = "القسم";
            colParent.OptionsColumn.AllowEdit = false;
            colParent.GroupIndex = 0;

            colItemNo.OptionsColumn.AllowEdit = false;

            gvBOQItems.OptionsView.ShowFooter = true;
            gvBOQItems.OptionsBehavior.Editable = true;
        }

        private void WireEvents()
        {
            gvBOQItems.FocusedRowChanged += (s, e) =>
            {
                if (gvBOQItems.GetFocusedRow() is BOQItemDetails row && row.SectionId.HasValue)
                    _currentSectionId = row.SectionId;
            };

            gvBOQItems.CellValueChanged += (s, e) =>
            {
                if (e.Column == colQuantity || e.Column == colUnitRate)
                {
                    if (gvBOQItems.GetRow(e.RowHandle) is BOQItemDetails row)
                    {
                        row.Total = (row.Quantity ?? 0) * (row.UnitRate ?? 0);
                        gvBOQItems.RefreshRow(e.RowHandle);
                    }
                }
                RecalculateSummary();
            };
        }

        // ── Load ─────────────────────────────────────────────────────────────
        /// <summary>Loads an existing BOQ (boqId != null) or starts a new, empty draft (boqId ==
        /// null). readOnly forces the locked/approved presentation regardless of Status (used by
        /// ucBOQList's "View").</summary>
        public void LoadBOQ(int? boqId, int? projectId = null, bool readOnly = false)
        {
            _loading = true;
            ShowState(loading: true);
            try
            {
                _sections.Clear();
                _items.Clear();
                _deletedSectionIds.Clear();
                _deletedItemIds.Clear();
                _currentSectionId = null;

                if (boqId.HasValue)
                {
                    _boqId = boqId.Value;
                    var header = dc.BOQList.Find(_boqId) ?? throw new InvalidOperationException("تعذر إيجاد جدول الكميات المطلوب.");
                    _header = header;
                    _rowVersion = header.RowVersion;

                    var sections = dc.BOQSectionDetails.GetBy("BOQId = @id AND IsDelete = 0", new { id = _boqId })
                        .OrderBy(s => s.SeqNo ?? 0).ToList();
                    var items = dc.BOQItemDetails.GetBy("BOQId = @id AND IsDelete = 0", new { id = _boqId })
                        .OrderBy(i => i.SeqNo ?? 0).ToList();

                    var sectionsById = sections.ToDictionary(s => s.Id);
                    foreach (var item in items)
                        if (item.SectionId.HasValue && sectionsById.TryGetValue(item.SectionId.Value, out var sec))
                            item.Section = sec;

                    foreach (var s in sections) _sections.Add(s);
                    foreach (var i in items) _items.Add(i);
                }
                else
                {
                    _boqId = 0;
                    _header = new BOQList
                    {
                        PrjId = projectId ?? Session.SelectedProjectId,
                        Status = BOQStatus.Draft,
                        Revision = "R0",
                    };
                    _rowVersion = null;
                }

                BindHeader();

                _totalAtLoad = _header.TotalAmount ?? _items.Sum(i => i.Total ?? 0);
                if (readOnly || _header.Status == BOQStatus.Approved) LockForApproved();
                else UnlockForEditing();

                RecalculateSummary();
                ShowState(loading: false, empty: boqId.HasValue && _items.Count == 0);
            }
            catch (Exception ex)
            {
                ShowState(loading: false, error: true, errorMessage: ex.Message);
            }
            finally
            {
                _loading = false;
            }
        }

        private void BindHeader()
        {
            txtBOQCode.Text = _header.BOQCode ?? "(جديد)";
            txtBOQName.Text = _header.BOQName ?? "";
            txtRevision.Text = _header.Revision ?? "";
            txtDiscipline.Text = _header.Discipline ?? "";
            txtStatus.Text = _header.Status ?? BOQStatus.Draft;
            txtProject.Text = _header.PrjId.HasValue
                ? dc.ProjectsList.Find(_header.PrjId.Value)?.Name ?? ""
                : Session.SelectedProjectName ?? "";
        }

        private void ShowState(bool loading, bool empty = false, bool error = false, string? errorMessage = null)
        {
            pnlLoadingState.Visible = loading;
            pnlEmptyState.Visible = !loading && empty && !error;
            pnlErrorState.Visible = !loading && error;
            grdBOQItems.Visible = !loading && !empty && !error;
            if (errorMessage != null) lblErrorText.Text = errorMessage;
        }

        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            var handle = ShowOverlay();
            try { LoadBOQ(_boqId > 0 ? _boqId : (int?)null, _header.PrjId); }
            finally { CloseOverlay(handle); }
        }

        // ── Renumbering (sections get "1", "2"... ; items get "{section}.{n}") ────────────────
        private void RenumberAll()
        {
            int n = 1;
            foreach (var section in _sections.OrderBy(s => s.SeqNo ?? 0).ToList())
            {
                section.SeqNo = n;
                section.SectionNo = n.ToString();
                n++;

                var itemsInSection = _items.Where(i => i.SectionId == section.Id).OrderBy(i => i.SeqNo ?? 0).ToList();
                for (int i = 0; i < itemsInSection.Count; i++)
                {
                    itemsInSection[i].SeqNo = i + 1;
                    itemsInSection[i].ItemNo = $"{section.SectionNo}.{i + 1}";
                }
            }
            gvBOQItems.RefreshData();
            RecalculateSummary();
        }

        // ── Summary panel ────────────────────────────────────────────────────
        private void RecalculateSummary()
        {
            decimal totalQty = _items.Sum(i => i.Quantity ?? 0);
            decimal totalCost = _items.Sum(i => (i.Quantity ?? 0) * (i.UnitRate ?? 0));
            decimal avgRate = totalQty == 0 ? 0 : totalCost / totalQty;
            decimal variance = totalCost - _totalAtLoad;

            lblTotalQuantityValue.Text = totalQty.ToString("N2");
            lblTotalCostValue.Text = totalCost.ToString("N2");
            lblAverageRateValue.Text = avgRate.ToString("N2");
            lblCostVarianceValue.Text = variance.ToString("N2");
            lblItemCountValue.Text = _items.Count.ToString();
            lblGrandTotalValue.Text = totalCost.ToString("N2");
            sbiItemCount.Caption = $"عدد البنود: {_items.Count}";
        }

        // ── Lock/unlock (Approved BOQs, or "View" mode from ucBOQList) ────────
        private void LockForApproved()
        {
            _isLocked = true;
            gvBOQItems.OptionsBehavior.Editable = false;
            bbiAddItem.Enabled = false;
            bbiAddGroup.Enabled = false;
            bbiDelete.Enabled = false;
            bbiDuplicate.Enabled = false;
            bbiMoveUp.Enabled = false;
            bbiMoveDown.Enabled = false;
            bbiImport.Enabled = false;
            bbiSave.Enabled = false;
            bbiApprove.Enabled = false;
            lblStateBanner.Text = "جدول الكميات مقفل";
            pnlStateBanner.Visible = true;
        }

        private void UnlockForEditing()
        {
            _isLocked = false;
            gvBOQItems.OptionsBehavior.Editable = true;
            bbiAddItem.Enabled = true;
            bbiAddGroup.Enabled = true;
            bbiDelete.Enabled = true;
            bbiDuplicate.Enabled = true;
            bbiMoveUp.Enabled = true;
            bbiMoveDown.Enabled = true;
            bbiImport.Enabled = true;
            bbiSave.Enabled = true;
            bbiApprove.Enabled = true;
            pnlStateBanner.Visible = false;
        }

        // ── Toolbar: structure ──────────────────────────────────────────────
        private void bbiAddGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked) return;
            var name = XtraInputBox.Show("اسم المجموعة (القسم):", "إضافة مجموعة", "");
            if (string.IsNullOrWhiteSpace(name)) return;

            var section = new BOQSectionDetails
            {
                Id = _tempSectionSeq--,
                BOQId = _boqId,
                SectionName = name.Trim(),
                SeqNo = int.MaxValue,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine,
                CreatedBy = Session.CurrentUser?.Id ?? 1,
                IsDelete = false,
            };
            _sections.Add(section);
            _currentSectionId = section.Id;
            RenumberAll();

            XtraMessageBox.Show("تمت إضافة المجموعة. استخدم زر \"إضافة بند\" لإضافة بنود إليها.",
                "تمت الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbiAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked) return;
            if (_sections.Count == 0)
            {
                XtraMessageBox.Show("أضف مجموعة (قسم) أولاً قبل إضافة بند.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sectionId = _currentSectionId ?? _sections[_sections.Count - 1].Id;
            var section = _sections.FirstOrDefault(s => s.Id == sectionId) ?? _sections[_sections.Count - 1];

            var item = new BOQItemDetails
            {
                BOQId = _boqId,
                SectionId = section.Id,
                Section = section,
                Unit = string.Empty,
                Quantity = 0,
                UnitRate = 0,
                Total = 0,
                SeqNo = int.MaxValue,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine,
                CreatedBy = Session.CurrentUser?.Id ?? 1,
                IsDelete = false,
            };
            _items.Add(item);
            RenumberAll();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked) return;
            var row = gvBOQItems.GetFocusedRow() as BOQItemDetails;
            if (row == null) return;

            if (XtraMessageBox.Show("هل تريد حذف هذا البند؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (row.Id > 0) _deletedItemIds.Add(row.Id);
            _items.Remove(row);
            RenumberAll();
        }

        private void bbiDuplicate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked) return;
            var row = gvBOQItems.GetFocusedRow() as BOQItemDetails;
            if (row == null) return;

            var clone = new BOQItemDetails
            {
                BOQId = row.BOQId,
                SectionId = row.SectionId,
                Section = row.Section,
                DescriptionAr = row.DescriptionAr,
                DescriptionEn = row.DescriptionEn,
                Unit = row.Unit,
                Quantity = row.Quantity,
                UnitRate = row.UnitRate,
                Total = row.Total,
                CostCode = row.CostCode,
                WBS = row.WBS,
                CBS = row.CBS,
                ResourceCode = row.ResourceCode,
                Remarks = row.Remarks,
                SeqNo = int.MaxValue,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine,
                CreatedBy = Session.CurrentUser?.Id ?? 1,
                IsDelete = false,
            };

            var idx = _items.IndexOf(row);
            _items.Insert(idx + 1, clone);
            RenumberAll();
        }

        private void MoveItem(int direction)
        {
            if (_isLocked) return;
            var row = gvBOQItems.GetFocusedRow() as BOQItemDetails;
            if (row == null) return;

            var siblings = _items.Where(i => i.SectionId == row.SectionId).OrderBy(i => i.SeqNo ?? 0).ToList();
            var idx = siblings.IndexOf(row);
            var swapIdx = idx + direction;
            if (idx < 0 || swapIdx < 0 || swapIdx >= siblings.Count) return;

            var other = siblings[swapIdx];
            (row.SeqNo, other.SeqNo) = (other.SeqNo, row.SeqNo);
            RenumberAll();
        }

        private void bbiMoveUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => MoveItem(-1);
        private void bbiMoveDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => MoveItem(1);

        private void bbiExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => gvBOQItems.ExpandAllGroups();
        private void bbiCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => gvBOQItems.CollapseAllGroups();

        // ── Toolbar: validate / import / export ──────────────────────────────
        private List<string> ValidateItems()
        {
            var issues = new List<string>();
            foreach (var item in _items)
            {
                var label = string.IsNullOrWhiteSpace(item.ItemNo) ? "(بند بلا رقم)" : item.ItemNo;
                if (string.IsNullOrWhiteSpace(item.DescriptionAr))
                    issues.Add($"البند {label}: الوصف بالعربي مطلوب.");
                if (item.Quantity is < 0)
                    issues.Add($"البند {label}: الكمية لا يمكن أن تكون سالبة.");
                if (item.UnitRate is < 0)
                    issues.Add($"البند {label}: سعر الوحدة لا يمكن أن يكون سالباً.");
            }

            var duplicates = _items.Where(i => !string.IsNullOrWhiteSpace(i.ItemNo))
                .GroupBy(i => i.ItemNo).Where(g => g.Count() > 1);
            foreach (var g in duplicates)
                issues.Add($"رقم البند {g.Key} مكرر.");

            return issues;
        }

        private void bbiValidate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var issues = ValidateItems();
            if (issues.Count == 0)
                XtraMessageBox.Show("لا توجد أخطاء ✓", "التحقق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show(string.Join("\n", issues), $"تم العثور على {issues.Count} ملاحظة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bbiImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked) return;

            using var wizard = new frmBOQImportWizard();
            if (wizard.ShowDialog(this) != DialogResult.OK) return;
            if (wizard.ImportedItems.Count == 0) return;

            var importSection = _sections.FirstOrDefault(s => s.Id == _currentSectionId)
                ?? _sections.FirstOrDefault(s => s.SectionName == "مستورد");

            if (importSection == null)
            {
                importSection = new BOQSectionDetails
                {
                    Id = _tempSectionSeq--,
                    BOQId = _boqId,
                    SectionName = "مستورد",
                    SeqNo = int.MaxValue,
                    CreatedDate = DateTime.Now,
                    CreatedMachine = Session.Machine,
                    CreatedBy = Session.CurrentUser?.Id ?? 1,
                    IsDelete = false,
                };
                _sections.Add(importSection);
            }

            foreach (var item in wizard.ImportedItems)
            {
                item.BOQId = _boqId;
                item.SectionId = importSection.Id;
                item.Section = importSection;
                item.SeqNo = int.MaxValue;
                item.CreatedDate = DateTime.Now;
                item.CreatedMachine = Session.Machine;
                item.CreatedBy = Session.CurrentUser?.Id ?? 1;
                item.IsDelete = false;
                _items.Add(item);
            }

            RenumberAll();
            XtraMessageBox.Show($"تم استيراد {wizard.ImportedItems.Count} بند. لا تنسَ حفظ جدول الكميات.",
                "استيراد", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"{(_header.BOQCode ?? "BOQ")}_{DateTime.Today:yyyy-MM-dd}.xlsx",
                DefaultExt = "xlsx",
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grdBOQItems.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Toolbar: save / approve ──────────────────────────────────────────
        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLocked)
            {
                XtraMessageBox.Show("جدول الكميات معتمد ومقفل للتعديل.", "غير مسموح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(_header.BOQName))
            {
                XtraMessageBox.Show(
                    "لا يمكن حفظ جدول كميات بلا اسم أو مشروع. أنشئ جدول كميات جديداً من شاشة \"جدول الكميات\" (زر جدول جديد).",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_header.PrjId == null)
            {
                XtraMessageBox.Show("لا يوجد مشروع مرتبط بجدول الكميات هذا.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var issues = ValidateItems();
            if (issues.Count > 0)
            {
                if (XtraMessageBox.Show(
                    $"توجد {issues.Count} ملاحظة على البنود. هل تريد المتابعة رغم ذلك؟\n\n{string.Join("\n", issues.Take(10))}",
                    "ملاحظات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }

            foreach (var item in _items)
                item.Total = (item.Quantity ?? 0) * (item.UnitRate ?? 0);

            var handle = ShowOverlay();
            try
            {
                Data.DataContext.RunInTransaction(tx =>
                {
                    var oldHeader = _boqId > 0 ? dc.BOQList.Find(_boqId) : null;

                    _header.TotalAmount = _items.Sum(i => i.Total ?? 0);

                    if (_boqId == 0)
                    {
                        _header.BOQCode = GenerateBOQCode(tx);
                        _header.Status = BOQStatus.Draft;
                        _header.CreatedDate = DateTime.Now;
                        _header.CreatedMachine = Session.Machine;
                        _header.CreatedBy = Session.CurrentUser?.Id ?? 1;
                        _header.IsDelete = false;

                        _boqId = dc.BOQList.Add(_header, tx);
                        _header.Id = _boqId;
                        AuditService.LogCreate(tx, "BOQList", _boqId, _header);
                    }
                    else
                    {
                        _header.Id = _boqId;
                        _header.UpdateDate = DateTime.Now;
                        _header.UpdateMachine = Session.Machine;
                        _header.UpdateBy = Session.CurrentUser?.Id ?? 1;
                        _header.RowVersion = _rowVersion;

                        dc.BOQList.Edit(_boqId, _header, tx);
                        AuditService.LogUpdate(tx, "BOQList", _boqId, oldHeader, _header);
                    }

                    SaveSectionsAndItems(tx);
                });

                _rowVersion = dc.BOQList.Find(_boqId)?.RowVersion;
                txtBOQCode.Text = _header.BOQCode;
                txtStatus.Text = _header.Status;
                lblLastSavedValue.Text = DateTime.Now.ToString("HH:mm");
                sbiLastSaved.Caption = $"آخر حفظ: {DateTime.Now:yyyy-MM-dd HH:mm}";

                XtraMessageBox.Show("تم حفظ جدول الكميات بنجاح ✓", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Data.ConcurrencyConflictException ex)
            {
                XtraMessageBox.Show(ex.Message, "تعارض في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الحفظ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private string GenerateBOQCode(SqlTransaction tx)
        {
            int year = DateTime.Now.Year;
            var prefix = $"BOQ-{year}-";

            int seq = NumberingService.GetNextNumber(tx, "BOQList", year, () =>
                dc.BOQList.GetAll()
                    .Where(b => !b.IsDelete && b.BOQCode != null && b.BOQCode.StartsWith(prefix))
                    .Select(b => int.TryParse(b.BOQCode!.Substring(prefix.Length), out var n) ? n : 0)
                    .DefaultIfEmpty(0)
                    .Max());

            return $"{prefix}{seq:0000}";
        }

        /// <summary>Inserts/updates/deletes sections then items, remapping items that reference a
        /// newly-inserted (temporary, negative) section id to the section's real database id.</summary>
        private void SaveSectionsAndItems(SqlTransaction tx)
        {
            if (_deletedSectionIds.Count > 0)
            {
                dc.BOQSectionDetails.DeleteRange(_deletedSectionIds, tx);
                _deletedSectionIds.Clear();
            }

            var newSections = _sections.Where(s => s.Id <= 0).ToList();
            var tempIdToSection = newSections.ToDictionary(s => s.Id);
            foreach (var s in newSections)
            {
                s.BOQId = _boqId;
                s.CreatedDate = DateTime.Now;
                s.CreatedMachine = Session.Machine;
                s.CreatedBy = Session.CurrentUser?.Id ?? 1;
                s.IsDelete = false;
            }
            if (newSections.Count > 0) dc.BOQSectionDetails.AddRange(newSections, tx); // mutates s.Id in place

            var existingSections = _sections.Where(s => s.Id > 0 && !newSections.Contains(s)).ToList();
            foreach (var s in existingSections)
            {
                s.BOQId = _boqId;
                s.UpdateDate = DateTime.Now;
                s.UpdateMachine = Session.Machine;
                s.UpdateBy = Session.CurrentUser?.Id ?? 1;
            }
            if (existingSections.Count > 0) dc.BOQSectionDetails.EditRange(existingSections, tx);

            foreach (var item in _items)
                if (item.SectionId.HasValue && tempIdToSection.TryGetValue(item.SectionId.Value, out var section))
                    item.SectionId = section.Id;

            if (_deletedItemIds.Count > 0)
            {
                dc.BOQItemDetails.DeleteRange(_deletedItemIds, tx);
                _deletedItemIds.Clear();
            }

            var newItems = _items.Where(i => i.Id <= 0).ToList();
            foreach (var i in newItems)
            {
                i.BOQId = _boqId;
                i.CreatedDate = DateTime.Now;
                i.CreatedMachine = Session.Machine;
                i.CreatedBy = Session.CurrentUser?.Id ?? 1;
                i.IsDelete = false;
            }
            if (newItems.Count > 0) dc.BOQItemDetails.AddRange(newItems, tx);

            var existingItems = _items.Where(i => i.Id > 0 && !newItems.Contains(i)).ToList();
            foreach (var i in existingItems)
            {
                i.BOQId = _boqId;
                i.UpdateDate = DateTime.Now;
                i.UpdateMachine = Session.Machine;
                i.UpdateBy = Session.CurrentUser?.Id ?? 1;
            }
            if (existingItems.Count > 0) dc.BOQItemDetails.EditRange(existingItems, tx);
        }

        private void bbiApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_boqId <= 0)
            {
                XtraMessageBox.Show("يجب حفظ جدول الكميات أولاً قبل الاعتماد.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_header.Status == BOQStatus.Approved)
            {
                XtraMessageBox.Show("جدول الكميات معتمد بالفعل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!PermissionService.HasPermission(PermNames.BOQ))
            {
                XtraMessageBox.Show("ليس لديك صلاحية اعتماد جدول الكميات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var issues = ValidateItems();
            if (issues.Count > 0)
            {
                XtraMessageBox.Show($"لا يمكن الاعتماد قبل معالجة الملاحظات التالية:\n\n{string.Join("\n", issues)}",
                    "تعذر الاعتماد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("هل تريد اعتماد جدول الكميات؟ لن يمكن تعديله بعد الاعتماد.", "تأكيد الاعتماد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var handle = ShowOverlay();
            try
            {
                BOQWorkflow.Approve(dc, _boqId);
                _header.Status = BOQStatus.Approved;
                _rowVersion = dc.BOQList.Find(_boqId)?.RowVersion;
                txtStatus.Text = _header.Status;
                LockForApproved();
                XtraMessageBox.Show("تم اعتماد جدول الكميات ✓", "اعتماد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء الاعتماد:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }
    }
}
