using System.ComponentModel;
using Core;
using Data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Etmam
{
    public partial class ucBOQList : DevExpress.XtraEditors.XtraUserControl
    {
        private static Data.DataContext dc => Data.DataContext.Shared;
        private readonly BindingList<BOQListRow> _rows = new();

        public ucBOQList()
        {
            InitializeComponent();
            if (DesignMode) return;

            grdBOQ.DataSource = _rows;
            LoadList();
        }

        private void LoadList()
        {
            ShowState(loading: true);
            var handle = ShowOverlay();
            try
            {
                var grantedProjects = PermissionService.GrantedProjectIds(dc);
                var boqs = dc.BOQList.GetBy("IsDelete = 0")
                    .Where(b => b.PrjId == null || grantedProjects.Contains(b.PrjId.Value))
                    .OrderByDescending(b => b.UpdateDate ?? b.CreatedDate)
                    .ToList();

                var projectIds = boqs.Where(b => b.PrjId.HasValue).Select(b => b.PrjId!.Value).Distinct().ToList();
                var projects = projectIds.Count > 0
                    ? dc.ProjectsList.GetBy("IsDelete = 0").Where(p => projectIds.Contains(p.Id)).ToDictionary(p => p.Id)
                    : new Dictionary<int, ProjectsList>();

                _rows.Clear();
                foreach (var b in boqs)
                {
                    projects.TryGetValue(b.PrjId ?? -1, out var project);
                    _rows.Add(new BOQListRow
                    {
                        Id = b.Id,
                        BOQCode = b.BOQCode,
                        BOQName = b.BOQName,
                        ProjectName = project?.Name,
                        Revision = b.Revision,
                        Discipline = b.Discipline,
                        ContractValue = b.TotalAmount,
                        EstimatedCost = b.TotalAmount,
                        Status = b.Status,
                        ApprovalDate = b.Status == BOQStatus.Approved ? b.UpdateDate : null,
                        LastModifiedDate = b.UpdateDate ?? b.CreatedDate,
                    });
                }

                sbiRecordCount.Caption = $"عدد السجلات: {_rows.Count}";
                sbiLastRefresh.Caption = $"آخر تحديث: {DateTime.Now:HH:mm}";
                ShowState(loading: false, empty: _rows.Count == 0);
            }
            catch (Exception ex)
            {
                ShowState(loading: false, error: true, errorMessage: ex.Message);
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void ShowState(bool loading, bool empty = false, bool error = false, string? errorMessage = null)
        {
            pnlLoadingState.Visible = loading;
            pnlEmptyState.Visible = !loading && empty && !error;
            pnlErrorState.Visible = !loading && error;
            grdBOQ.Visible = !loading && !empty && !error;
            if (errorMessage != null) lblErrorText.Text = errorMessage;
        }

        private BOQListRow? FocusedRow() => gvBOQ.GetFocusedRow() as BOQListRow;

        // ── Toolbar ───────────────────────────────────────────────────────────
        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => LoadList();
        private void btnRetry_Click(object sender, System.EventArgs e) => LoadList();

        private void bbiNewBOQ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var handle = ShowOverlay();
            frmBOQNew frm;
            try { frm = new frmBOQNew(); }
            finally { CloseOverlay(handle); }

            using (frm)
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                LoadList();
                OpenEditorTab(frm.CreatedBOQId, "جدول كميات جديد", readOnly: false);
            }
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = FocusedRow();
            if (row == null) return;
            OpenEditorTab(row.Id, row.BOQName ?? row.BOQCode ?? "جدول كميات", readOnly: false);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = FocusedRow();
            if (row == null) return;
            OpenEditorTab(row.Id, row.BOQName ?? row.BOQCode ?? "جدول كميات", readOnly: true);
        }

        private void OpenEditorTab(int boqId, string caption, bool readOnly)
        {
            var mainForm = FindForm() as frmMainPage;
            if (mainForm == null) return;

            // uc.LoadBOQ يُحمِّل بيانات جدول الكميات من قاعدة البيانات مباشرة داخل factory أدناه، والتي
            // يستدعيها OpenTab بشكل متزامن قبل عرض التاب — المؤشر هنا يغطي تلك اللحظة.
            var handle = ShowOverlay();
            try
            {
                mainForm.OpenTab(caption, $"BOQEditor:{boqId}", "BOQEditor", () =>
                {
                    var uc = new ucBOQEditor();
                    uc.LoadBOQ(boqId, readOnly: readOnly);
                    return uc;
                });
            }
            finally
            {
                CloseOverlay(handle);
            }
        }

        private void bbiCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = FocusedRow();
            if (row == null) return;

            if (XtraMessageBox.Show($"هل تريد نسخ جدول الكميات [{row.BOQName}] كمسودة جديدة؟", "تأكيد النسخ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var copyHandle = ShowOverlay();
            try
            {
                int newId = 0;
                Data.DataContext.RunInTransaction(tx =>
                {
                    var source = dc.BOQList.Find(row.Id) ?? throw new InvalidOperationException("تعذر إيجاد جدول الكميات المصدر.");

                    var copy = new BOQList
                    {
                        PrjId = source.PrjId,
                        BOQName = $"{source.BOQName} (نسخة)",
                        Revision = "R0",
                        Discipline = source.Discipline,
                        ContractId = source.ContractId,
                        Status = BOQStatus.Draft,
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false,
                    };
                    copy.BOQCode = GenerateBOQCode(tx);
                    newId = dc.BOQList.Add(copy, tx);
                    AuditService.LogCreate(tx, "BOQList", newId, copy);

                    var sourceSections = dc.BOQSectionDetails.GetBy("BOQId = @id AND IsDelete = 0", new { id = row.Id });
                    var sectionIdMap = new Dictionary<int, int>();
                    foreach (var s in sourceSections)
                    {
                        var newSection = new BOQSectionDetails
                        {
                            BOQId = newId,
                            SectionNo = s.SectionNo,
                            SectionName = s.SectionName,
                            SeqNo = s.SeqNo,
                            CreatedDate = DateTime.Now,
                            CreatedMachine = Session.Machine,
                            CreatedBy = Session.CurrentUser?.Id ?? 1,
                            IsDelete = false,
                        };
                        var newSectionId = dc.BOQSectionDetails.Add(newSection, tx);
                        sectionIdMap[s.Id] = newSectionId;
                    }

                    var sourceItems = dc.BOQItemDetails.GetBy("BOQId = @id AND IsDelete = 0", new { id = row.Id });
                    var newItems = sourceItems.Select(i => new BOQItemDetails
                    {
                        BOQId = newId,
                        SectionId = i.SectionId.HasValue && sectionIdMap.TryGetValue(i.SectionId.Value, out var sid) ? sid : null,
                        ItemNo = i.ItemNo,
                        DescriptionAr = i.DescriptionAr,
                        DescriptionEn = i.DescriptionEn,
                        Unit = i.Unit,
                        Quantity = i.Quantity,
                        UnitRate = i.UnitRate,
                        Total = i.Total,
                        CostCode = i.CostCode,
                        WBS = i.WBS,
                        CBS = i.CBS,
                        ResourceCode = i.ResourceCode,
                        Remarks = i.Remarks,
                        SeqNo = i.SeqNo,
                        CreatedDate = DateTime.Now,
                        CreatedMachine = Session.Machine,
                        CreatedBy = Session.CurrentUser?.Id ?? 1,
                        IsDelete = false,
                    }).ToList();
                    if (newItems.Count > 0) dc.BOQItemDetails.AddRange(newItems, tx);

                    copy.TotalAmount = newItems.Sum(i => i.Total ?? 0);
                    copy.Id = newId;
                    dc.BOQList.Edit(newId, copy, tx);
                });

                CloseOverlay(copyHandle);
                LoadList();
                OpenEditorTab(newId, "نسخة جدول كميات", readOnly: false);
            }
            catch (Exception ex)
            {
                CloseOverlay(copyHandle);
                XtraMessageBox.Show($"خطأ أثناء النسخ:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GenerateBOQCode(Microsoft.Data.SqlClient.SqlTransaction tx)
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

        private void bbiApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = FocusedRow();
            if (row == null) return;

            if (row.Status == BOQStatus.Approved)
            {
                XtraMessageBox.Show("جدول الكميات معتمد بالفعل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!PermissionService.HasPermission(PermNames.BOQ))
            {
                XtraMessageBox.Show("ليس لديك صلاحية اعتماد جدول الكميات.", "غير مصرَّح",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (XtraMessageBox.Show($"هل تريد اعتماد جدول الكميات [{row.BOQName}]؟ لن يمكن تعديله بعد الاعتماد.",
                "تأكيد الاعتماد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var approveHandle = ShowOverlay();
            try
            {
                BOQWorkflow.Approve(dc, row.Id);
                CloseOverlay(approveHandle);
                LoadList();
                XtraMessageBox.Show("تم اعتماد جدول الكميات ✓", "اعتماد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CloseOverlay(approveHandle);
                XtraMessageBox.Show($"خطأ أثناء الاعتماد:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"جداول_الكميات_{DateTime.Today:yyyy-MM-dd}.xlsx",
                DefaultExt = "xlsx",
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grdBOQ.ExportToXlsx(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = $"جداول_الكميات_{DateTime.Today:yyyy-MM-dd}.pdf",
                DefaultExt = "pdf",
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                grdBOQ.ExportToPdf(dlg.FileName);
                XtraMessageBox.Show("تم التصدير بنجاح ✓", "تصدير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ أثناء التصدير:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Out of scope for this pass (left as no-ops): Search/Clear/Save-Filter, New-Revision,
        // Import(from list), Compare, Archive, Print — see the BOQ editing plan's scope boundary.
        private void bbiImportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiNewRevision_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiCompare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }

        private void btnSearch_Click(object sender, System.EventArgs e) { }
        private void btnClearFilters_Click(object sender, System.EventArgs e) { }
        private void btnSaveFilter_Click(object sender, System.EventArgs e) { }

        // ── مؤشر الانتظار ──────────────────────────────────────────────────────
        private IOverlaySplashScreenHandle ShowOverlay() => SplashScreenManager.ShowOverlayForm(this);

        private void CloseOverlay(IOverlaySplashScreenHandle? handle)
        {
            if (handle != null) SplashScreenManager.CloseOverlayForm(handle);
        }

        private class BOQListRow
        {
            public int Id { get; set; }
            public string? BOQCode { get; set; }
            public string? BOQName { get; set; }
            public string? ProjectName { get; set; }
            public string? Revision { get; set; }
            public string? Discipline { get; set; }
            public decimal? ContractValue { get; set; }
            public decimal? EstimatedCost { get; set; }
            public decimal? ProgressPercent { get; set; }
            public string? Status { get; set; }
            public string? ApprovedBy { get; set; }
            public DateTime? ApprovalDate { get; set; }
            public DateTime? LastModifiedDate { get; set; }
        }
    }
}
