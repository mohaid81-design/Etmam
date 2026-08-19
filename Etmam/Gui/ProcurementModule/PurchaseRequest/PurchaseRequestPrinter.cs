using System.IO;
using System.Text.RegularExpressions;
using Core;
using Data;
using DevExpress.Pdf;
using DevExpress.XtraReports.UI;
using Etmam;

namespace Etmam
{
    /// <summary>Builds and previews the purchase-request print report — shared by frmPurchaseRequestAddEdit's
    /// print button and ucPurchaseRequests' grid quick-print column, so both stay in sync.</summary>
    public static class PurchaseRequestPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // الترقيم يتجدد سنوياً استناداً إلى سنة تاريخ الطلب (RequestDate) — انظر GetNextNumber في
        // frmPurchaseRequestAddEdit، حيث Num يخزّن التسلسل ضمن السنة فقط، وبادئة السنة تُشتق هنا وقت العرض.
        public static string FormatPRNumber(int? num, DateTime? requestDate) =>
            num.HasValue && requestDate.HasValue ? $"PR{requestDate.Value:yy}{num.Value:D5}" : "جديد";

        /// <summary>Previews the PR report — merged with its PDF/image attachments as extra pages when it
        /// has any (see BuildMergedPrintout), or the plain interactive report preview otherwise. Other
        /// attachment types (Office docs, DWG, archives) are never merged — they stay reachable from the
        /// المرفقات tab exactly as before; this only changes what "طباعة" itself produces.</summary>
        public static void Print(int prId)
        {
            var rpt = BuildReport(prId);
            if (rpt == null) return;

            var mergeableAttachments = dc.AttachmentList
                .GetBy("EntityName = @n AND EntityRecordId = @id AND IsDelete = 0", new { n = "PurchaseRequestList", id = prId })
                .Where(a => IsMergeableExtension(a.FileExtension))
                .OrderBy(a => a.UploadDate ?? DateTime.MinValue)
                .ThenBy(a => a.Id)
                .ToList();

            if (mergeableAttachments.Count == 0)
            {
                rpt.ShowPreviewDialog();
                return;
            }

            string mergedPath = BuildMergedPrintout(rpt, mergeableAttachments, prId);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName        = mergedPath,
                UseShellExecute = true
            });
        }

        private static bool IsMergeableExtension(string? ext) =>
            ext?.ToLowerInvariant() is "pdf" or "jpg" or "jpeg" or "png";

        /// <summary>Exports rpt to PDF, then appends each PDF/image attachment as extra pages — PDFs are
        /// appended as-is, images are dropped onto a throwaway single-picture XtraReport exported to PDF
        /// first (far more reliable than drawing directly onto a hand-built PDF page via PdfDocumentProcessor's
        /// lower-level graphics API). Saves the combined document to a temp file and returns its path.</summary>
        private static string BuildMergedPrintout(rptPurchaseRequest rpt, List<AttachmentList> attachments, int prId)
        {
            using var reportStream = new MemoryStream();
            rpt.ExportToPdf(reportStream);
            reportStream.Position = 0;

            using var processor = new PdfDocumentProcessor();
            processor.LoadDocument(reportStream);

            foreach (var att in attachments)
            {
                var data = GetAttachmentBytes(att);
                if (data == null) continue;

                bool isPdf = (att.FileExtension ?? "").ToLowerInvariant() == "pdf";
                byte[] pdfBytes = isPdf ? data : ImageToPdfBytes(data);

                using var attStream = new MemoryStream(pdfBytes);
                processor.AppendDocument(attStream);
            }

            string tempDir = Path.Combine(Path.GetTempPath(), "EtmamPrintouts");
            Directory.CreateDirectory(tempDir);
            string tempPath = Path.Combine(tempDir, $"PR_{prId}_{Guid.NewGuid():N}.pdf");
            processor.SaveDocument(tempPath);
            return tempPath;
        }

        /// <summary>Renders an image as a single full-page PDF via a throwaway one-picture XtraReport, so
        /// it can just be appended into the merged document like any other PDF.</summary>
        private static byte[] ImageToPdfBytes(byte[] imageData)
        {
            using var imgStream = new MemoryStream(imageData);
            using var image = Image.FromStream(imgStream);

            bool landscape = image.Width > image.Height;
            var report = new XtraReport
            {
                ReportUnit = ReportUnit.Millimeters,
                PaperKind  = DevExpress.Drawing.Printing.DXPaperKind.A4,
                PageWidthF  = landscape ? 297F : 210F,
                PageHeightF = landscape ? 210F : 297F,
                Margins = new DevExpress.Drawing.DXMargins(10F, 10F, 10F, 10F),
            };

            var detail = new DetailBand { HeightF = report.PageHeightF - 20F };
            var picture = new XRPictureBox
            {
                LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F),
                SizeF   = new SizeF(report.PageWidthF - 20F, detail.HeightF),
                Sizing  = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage,
                Image   = image,
            };
            detail.Controls.Add(picture);
            report.Bands.Add(detail);

            using var pdfStream = new MemoryStream();
            report.ExportToPdf(pdfStream);
            return pdfStream.ToArray();
        }

        /// <summary>Returns an attachment's raw bytes regardless of which storage mode it used — the
        /// database-blob FileData (preferred, all uploads since the disk-storage migration) or the legacy
        /// on-disk StoredPath — or null if neither yields actual bytes (e.g. a legacy row whose file went
        /// missing from disk).</summary>
        private static byte[]? GetAttachmentBytes(AttachmentList att) =>
            att.FileData is { Length: > 0 } data ? data
            : att.StoredPath is { Length: > 0 } path && File.Exists(path) ? File.ReadAllBytes(path)
            : null;

        /// <summary>Prints the "سجل طلبات الشراء" register report for the rows currently shown in
        /// ucPurchaseRequests' grid (respecting whatever project filter is applied there) — one row per
        /// purchase request, not a per-request detail print like <see cref="Print"/>.</summary>
        public static void PrintLog(List<PurchaseRequestList> records)
        {
            var projects = dc.ProjectsList.GetBy("IsDelete = 0").ToDictionary(p => p.Id);
            var departments = dc.DepartmentsList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);
            var disciplines = dc.DisciplinesList.GetBy("IsDelete = 0").ToDictionary(d => d.Id);

            foreach (var pr in records)
            {
                pr.ProjectName = pr.DeptId is > 0 && departments.TryGetValue(pr.DeptId.Value, out var dept) ? dept.Name
                    : pr.PrjId is > 0 && projects.TryGetValue(pr.PrjId.Value, out var prj) ? prj.Name : null;
                pr.StoreName = pr.StoreId is > 0 && stores.TryGetValue(pr.StoreId.Value, out var store) ? store.Name : null;
                pr.DisciplineName = pr.DisciplineId is > 0 && disciplines.TryGetValue(pr.DisciplineId.Value, out var disc) ? disc.Name : null;
            }

            var rpt = new rprPurchaseRequestLog { DataSource = records };
            rpt.xrPrintDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            rpt.ShowPreviewDialog();
        }

        /// <summary>Saves a NEW revision of this (approved) PR's PDF — "{FormattedNum}_R{n}.pdf", n picked
        /// as one past the highest revision already on disk — plus syncs attachment revisions, into
        /// "{rootFolder}\{FormattedNum}\". Called whenever the PR's own approved content actually changes:
        /// the workflow's final approval step (frmPurchaseRequestAddEdit.ActOnWorkflowStep) and saving an
        /// edit to an already-Approved PR (frmPurchaseRequestAddEdit.SaveRecord). Use SyncAttachments
        /// instead for attachment-only add/delete events, which don't warrant a new PR-level revision.
        /// rootFolder comes from Data.PurchaseRequestExportSettings (SettingsForm). No UI-facing
        /// dialogs — runs as a silent side effect.
        ///
        /// Never touches or deletes a previous revision's files — the configured export path may not even
        /// grant delete rights (e.g. a write-once archive share), and governance requires every past
        /// revision to stay inspectable, not just the latest.</summary>
        public static void ExportApprovedCopy(int prId, string rootFolder)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            var rpt = BuildReport(prId);
            if (rpt == null) return;

            var folderName = FormatPRNumber(pr.Num, pr.RequestDate);
            var destFolder = Path.Combine(rootFolder, folderName);
            Directory.CreateDirectory(destFolder);

            int pdfRevision = NextRevision(destFolder, $"^{Regex.Escape(folderName)}_R(\\d+)\\.pdf$");
            rpt.ExportToPdf(Path.Combine(destFolder, $"{folderName}_R{pdfRevision}.pdf"));

            CopyAttachmentRevisions(prId, destFolder);
        }

        /// <summary>Copies any attachment file(s) not yet captured under this PR's export folder, without
        /// touching the PR's own PDF — called when an attachment is merely added/removed on an already-
        /// Approved PR (ucAttachmentAddEdit.AttachmentsChanged), which shouldn't by itself bump the PR-level
        /// PDF revision. Does nothing if no export path is configured or the PR was never exported (no
        /// point creating the folder before the PR is actually Approved).</summary>
        public static void SyncAttachments(int prId, string rootFolder)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            var folderName = FormatPRNumber(pr.Num, pr.RequestDate);
            var destFolder = Path.Combine(rootFolder, folderName);
            if (!Directory.Exists(destFolder)) return; // PR hasn't been through an initial export yet

            CopyAttachmentRevisions(prId, destFolder);
        }

        /// <summary>Assigns each attachment ever recorded against this PR (including soft-deleted ones —
        /// their file may already be gone from AttachmentStorage by the time this runs, but a copy was
        /// already made here while it was still active) a revision number per distinct file name, in
        /// upload order: the first "Invoice.pdf" is R0, a later delete-then-reupload of another
        /// "Invoice.pdf" is R1, etc. — governance trail for same-named replacements. Already-copied
        /// revisions are recognized by filename and skipped, never re-copied or overwritten.</summary>
        private static void CopyAttachmentRevisions(int prId, string destFolder)
        {
            var allAttachments = dc.AttachmentList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = "PurchaseRequestList", id = prId })
                .OrderBy(a => a.UploadDate ?? DateTime.MinValue)
                .ThenBy(a => a.Id)
                .ToList();

            foreach (var group in allAttachments.GroupBy(a => a.FileName ?? "مرفق"))
            {
                var baseName = Path.GetFileNameWithoutExtension(group.Key);
                var ext = Path.GetExtension(group.Key);
                int rev = 0;

                foreach (var att in group) // already in upload order from the query above
                {
                    var destPath = Path.Combine(destFolder, $"{baseName}_R{rev}{ext}");
                    if (!File.Exists(destPath))
                    {
                        var bytes = GetAttachmentBytes(att);
                        if (bytes != null) File.WriteAllBytes(destPath, bytes);
                    }

                    rev++;
                }
            }
        }

        /// <summary>Scans <paramref name="folder"/> for file names matching <paramref name="pattern"/>
        /// (must contain exactly one capturing group for the revision number) and returns one past the
        /// highest revision found, or 0 if none exist yet.</summary>
        private static int NextRevision(string folder, string pattern)
        {
            var regex = new Regex(pattern);
            int max = -1;

            foreach (var file in Directory.GetFiles(folder))
            {
                var m = regex.Match(Path.GetFileName(file));
                if (m.Success && int.TryParse(m.Groups[1].Value, out int rev) && rev > max)
                    max = rev;
            }

            return max + 1;
        }

        /// <summary>Same scan as NextRevision, against an already-fetched list of file names (from
        /// SharePointUploader.ListFileNames) instead of Directory.GetFiles.</summary>
        private static int NextRevisionFromNames(List<string> names, string pattern)
        {
            var regex = new Regex(pattern);
            int max = -1;

            foreach (var name in names)
            {
                var m = regex.Match(name);
                if (m.Success && int.TryParse(m.Groups[1].Value, out int rev) && rev > max)
                    max = rev;
            }

            return max + 1;
        }

        /// <summary>Uploads a NEW revision of this (approved) PR's PDF plus its attachments to the
        /// configured SharePoint Online library (see Data.SharePointExportSettings) — the online,
        /// multi-user-shared counterpart to ExportApprovedCopy's local folder: reachable identically from
        /// any user/machine, unlike a local folder path which is per-Windows-user. No-op if the feature
        /// isn't enabled. Same "{FormattedNum}/{FormattedNum}_R{n}.pdf" naming/foldering convention as the
        /// local export, with the revision number computed against files actually listed in that
        /// SharePoint folder instead of local disk. Throws on failure — the caller (frmPurchaseRequestAddEdit.
        /// ExportApprovedCopyIfConfigured) already catches and warns without rolling back the approval
        /// that already succeeded, same as the local export.</summary>
        public static void ExportApprovedCopyToSharePoint(int prId)
        {
            if (!Data.SharePointExportSettings.IsEnabled(dc)) return;

            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            var rpt = BuildReport(prId);
            if (rpt == null) return;

            var folderName = FormatPRNumber(pr.Num, pr.RequestDate);

            var existingNames = Data.SharePointUploader.ListFileNames(dc, folderName, out var listError);
            if (listError != null) throw new InvalidOperationException(listError);

            int pdfRevision = NextRevisionFromNames(existingNames, $"^{Regex.Escape(folderName)}_R(\\d+)\\.pdf$");

            using var ms = new MemoryStream();
            rpt.ExportToPdf(ms);

            if (!Data.SharePointUploader.TryUpload(dc, $"{folderName}/{folderName}_R{pdfRevision}.pdf", ms.ToArray(), out var pdfError))
                throw new InvalidOperationException(pdfError);

            UploadAttachmentRevisionsToSharePoint(prId, folderName, existingNames);
        }

        /// <summary>SharePoint counterpart to SyncAttachments — uploads any attachment revision(s) not
        /// yet present in the PR's SharePoint folder, without touching the PR's own PDF (mirrors
        /// SyncAttachments' "attachment-only change doesn't bump the PDF revision" reasoning). No-op if
        /// the feature isn't enabled, or if this PR was never exported to SharePoint yet (no point
        /// creating the folder before ExportApprovedCopyToSharePoint's first run).</summary>
        public static void SyncAttachmentsToSharePoint(int prId)
        {
            if (!Data.SharePointExportSettings.IsEnabled(dc)) return;

            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return;

            var folderName = FormatPRNumber(pr.Num, pr.RequestDate);
            var existingNames = Data.SharePointUploader.ListFileNames(dc, folderName, out var listError);
            if (listError != null) throw new InvalidOperationException(listError);
            if (existingNames.Count == 0) return; // لم يُصدَّر هذا الطلب إلى SharePoint بعد

            UploadAttachmentRevisionsToSharePoint(prId, folderName, existingNames);
        }

        /// <summary>SharePoint counterpart to CopyAttachmentRevisions — same per-filename revision
        /// numbering (first upload of a name is R0, a later same-named replacement is R1, etc.), against
        /// files already listed in the SharePoint folder instead of local disk. A single attachment's
        /// upload failing doesn't stop the rest — each is independent, same governance-trail reasoning as
        /// the local copy.</summary>
        private static void UploadAttachmentRevisionsToSharePoint(int prId, string folderName, List<string> existingNames)
        {
            var allAttachments = dc.AttachmentList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = "PurchaseRequestList", id = prId })
                .OrderBy(a => a.UploadDate ?? DateTime.MinValue)
                .ThenBy(a => a.Id)
                .ToList();

            foreach (var group in allAttachments.GroupBy(a => a.FileName ?? "مرفق"))
            {
                var baseName = Path.GetFileNameWithoutExtension(group.Key);
                var ext = Path.GetExtension(group.Key);
                int rev = 0;

                foreach (var att in group) // already in upload order from the query above
                {
                    var destName = $"{baseName}_R{rev}{ext}";
                    if (!existingNames.Contains(destName))
                    {
                        var bytes = GetAttachmentBytes(att);
                        if (bytes != null)
                            Data.SharePointUploader.TryUpload(dc, $"{folderName}/{destName}", bytes, out _);
                    }

                    rev++;
                }
            }
        }

        private static rptPurchaseRequest? BuildReport(int prId)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null) return null;

            // حقول عرض غير مخزَّنة (اسم المشروع/الإدارة/المخزن/رقم الطلب المنسّق) — التقرير مربوط بها عبر ExpressionBindings
            pr.ProjectName = pr.DeptId is > 0
                ? dc.DepartmentsList.Find(pr.DeptId.Value)?.Name
                : dc.ProjectsList.Find(pr.PrjId ?? 0)?.Name;
            pr.StoreName = dc.StoreList.Find(pr.StoreId ?? 0)?.Name;
            pr.DisciplineName = dc.DisciplinesList.Find(pr.DisciplineId ?? 0)?.Name;
            pr.FormattedNum = FormatPRNumber(pr.Num, pr.RequestDate);

            var details = dc.PurchaseRequestDetails
                .GetBy("PRId = @id AND IsDelete = 0", new { id = prId })
                .OrderBy(d => d.SortId ?? int.MaxValue)
                .ThenBy(d => d.Id)
                .ToList();

            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            foreach (var d in details)
            {
                d.UnitAbbreviation = d.UnitId is > 0 && units.TryGetValue(d.UnitId.Value, out var u) ? u.Abbreviation : null;

                // xrDescription يعرض "اسم الصنف - المورد/المصنع"، أو اسم الصنف وحده إن لم يُدخَل مورد/مصنع مقترح
                if (!string.IsNullOrWhiteSpace(d.SupplierManufacturer))
                    d.Description = $"{d.Description} - {d.SupplierManufacturer}";
            }

            var rpt = new rptPurchaseRequest { DataSource = new List<PurchaseRequestList> { pr } };
            var rptDetails = new rptPurchaseRequestSubReport { DataSource = details };
            rpt.xrItemsSubreport.ReportSource = rptDetails;

            var sigBoxes = new[] { rpt.xrPurchasingOfficerSignatureBox, rpt.xrConcernedDepartmentSignatureBox, rpt.xrProjectManagerSignatureBox, rpt.xrCostEngineerSignatureBox, rpt.xrApprovalManagerSignatureBox };
            var instance = dc.WorkflowInstanceList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = "PurchaseRequestList", id = prId })
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            if (instance != null)
            {
                // Post-snapshot history entries (see WorkflowEngine.StartWorkflow/Act) record WorkflowStepId
                // against this instance's own frozen WorkflowInstanceStepList row, not the live WorkflowStepList
                // — check that first, falling back to the live dictionary for pre-snapshot entries.
                var snapshotSteps = dc.WorkflowInstanceStepList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id })
                    .ToDictionary(s => s.Id);

                var liveSteps = dc.WorkflowStepList
                    .GetBy("WorkflowDefinitionId = @id", new { id = instance.WorkflowDefinitionId })
                    .ToDictionary(s => s.Id);

                var allHistory = dc.WorkflowInstanceHistoryList
                    .GetBy("WorkflowInstanceId = @id", new { id = instance.Id });

                // رفض الإجراء نهائي (WorkflowEngine.Act يمنع أي تصرف لاحق على إجراء "Rejected") — صف واحد
                // "Rejected" كحد أقصى لكل إجراء.
                var rejection = allHistory
                    .Where(h => h.Action == "Rejected")
                    .OrderByDescending(h => h.Id)
                    .FirstOrDefault();

                if (rejection != null)
                {
                    // طلب الشراء المرفوض يُلغي جميع التواقيع على المطبوعة — يبقى الصندوق الوحيد المملوء هو
                    // صندوق الخطوة التي رفضت، بختم "مرفوض" الأحمر وسبب الرفض بدل صورة توقيع.
                    string? rejectedStepName = snapshotSteps.TryGetValue(rejection.WorkflowStepId, out var rejSnapStep)
                        ? rejSnapStep.Name
                        : liveSteps.TryGetValue(rejection.WorkflowStepId, out var rejLiveStep) ? rejLiveStep.Name : null;

                    int? rejectedBoxIndex = ResolveSignatureBoxIndex(rejectedStepName);
                    if (rejectedBoxIndex is not null)
                        sigBoxes[rejectedBoxIndex.Value].Image = CreateRejectionStampImage(rejection.Comment);
                }
                else
                {
                    // آخر "إعادة إلى خطوة سابقة" (إن وجدت) تُلغي أي توقيع سابق سُجّل لخطوة عند/بعد الخطوة
                    // المستهدَفة قبل لحظة الإعادة — أما التوقيعات المسجّلة بعد الإعادة (اعتماد جديد) فتبقى سارية.
                    var lastReturn = allHistory
                        .Where(h => h.Action == "ReturnedToStep")
                        .OrderByDescending(h => h.ActionDate ?? DateTime.MinValue)
                        .ThenByDescending(h => h.Id)
                        .FirstOrDefault();

                    foreach (var approval in allHistory.Where(h => h.Action == "Approved"))
                    {
                        string? stepName = null;
                        int? stepOrder = null;
                        if (snapshotSteps.TryGetValue(approval.WorkflowStepId, out var snapStep))
                        {
                            stepName = snapStep.Name;
                            stepOrder = snapStep.StepOrder;
                        }
                        else if (liveSteps.TryGetValue(approval.WorkflowStepId, out var liveStep))
                        {
                            stepName = liveStep.Name;
                            stepOrder = liveStep.StepOrder;
                        }

                        if (lastReturn != null && stepOrder is not null && stepOrder >= lastReturn.TargetStepOrder
                            && (approval.ActionDate ?? DateTime.MinValue) <= (lastReturn.ActionDate ?? DateTime.MinValue))
                            continue; // ألغتها إعادة لاحقة إلى مرحلة عند/قبل هذه الخطوة، ولم تُعتمد مجدداً بعدها

                        int? boxIndex = ResolveSignatureBoxIndex(stepName);
                        if (boxIndex is null) continue; // لا خطوة بهذا الدور ضمن هذا الإجراء — يبقى الصندوق فارغاً

                        var signature = dc.UsersList.Find(approval.ActionBy)?.Signature;
                        if (signature is { Length: > 0 })
                            sigBoxes[boxIndex.Value].Image = Image.FromStream(new MemoryStream(signature));
                    }
                }
            }

            return rpt;
        }

        /// <summary>Draws a "مرفوض" (rejected) stamp — bold red title plus the rejection comment underneath
        /// in black — onto a bitmap sized to match a signature box's aspect ratio, since XRPictureBox has no
        /// text property of its own to overlay a stamp with. Rendered at print-friendly resolution; the
        /// box's own Sizing = StretchImage fits it into the actual (smaller, millimeter-sized) box.</summary>
        private static Bitmap CreateRejectionStampImage(string? reason)
        {
            const int width = 420, height = 228;
            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.Clear(Color.White);

                using var titleFont = new Font("Calibri", 34, FontStyle.Bold);
                using var reasonFont = new Font("Calibri", 22, FontStyle.Bold);
                using var redBrush = new SolidBrush(Color.Red);
                using var blackBrush = new SolidBrush(Color.Black);
                using var titleFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                using var reasonFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                };

                g.DrawString("مرفوض", titleFont, redBrush, new RectangleF(0, 8, width, 70), titleFormat);

                if (!string.IsNullOrWhiteSpace(reason))
                    g.DrawString(reason, reasonFont, blackBrush, new RectangleF(10, 90, width - 20, height - 100), reasonFormat);
            }

            return bmp;
        }

        /// <summary>Maps a workflow step's free-text name to one of the report's 5 fixed signature boxes
        /// by role keyword, so the box a signature lands in tracks the step's ROLE rather than its
        /// position in the procedure — a procedure missing e.g. the discipline-engineer step must leave
        /// that box empty instead of shifting every later signer's box up by one. Relies on the naming
        /// convention seeded in DatabaseInitializer for "طلب الشراء" (and expected of any project/discipline-
        /// specific variant an admin configures via "إدارة الإجراءات"); a step name matching none of these
        /// keywords simply contributes no signature. "مشروعات" is checked before the bare "مشروع" pattern
        /// since "مدير المشروعات" would otherwise also match the project-manager keyword.</summary>
        private static int? ResolveSignatureBoxIndex(string? stepName)
        {
            if (string.IsNullOrWhiteSpace(stepName)) return null;

            if (stepName.Contains("مخازن")) return 0;               // مسؤول المخازن
            if (stepName.Contains("تخصص")) return 1;                // مهندس التخصص
            if (stepName.Contains("مشروعات")) return 4;              // مدير المشروعات/الإدارة
            if (stepName.Contains("مشروع")) return 2;                // مدير المشروع/القسم
            if (stepName.Contains("تكاليف") || stepName.Contains("تكلفة") || stepName.Contains("تقدير"))
                return 3;                                            // مهندس التكاليف

            return null;
        }
    }
}
