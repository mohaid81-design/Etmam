using System.IO;
using Core;
using Data;
using DevExpress.Pdf;
using DevExpress.XtraReports.UI;
using Etmam;

namespace Etmam
{
    /// <summary>Builds and previews the purchase-order print report (rptPurchaseOrder) — shared by
    /// frmPurchaseOrderAddEdit's print button and ucPurchaseOrder's grid quick-print column, so both stay
    /// in sync. Mirrors PurchaseRequestPrinter's structure/conventions.</summary>
    public static class PurchaseOrderPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        /// <summary>Previews the PO report — merged with its PDF/image attachments as extra pages when it
        /// has any (see BuildMergedPrintout), or the plain interactive report preview otherwise. Other
        /// attachment types (Office docs, DWG, archives) are never merged — they stay reachable from the
        /// المرفقات tab exactly as before; this only changes what "طباعة" itself produces.</summary>
        public static void Print(int poId)
        {
            var rpt = BuildReport(poId);
            if (rpt == null) return;

            var mergeableAttachments = dc.AttachmentList
                .GetBy("EntityName = @n AND EntityRecordId = @id AND IsDelete = 0", new { n = "PurchaseOrderList", id = poId })
                .Where(a => IsMergeableExtension(a.FileExtension))
                .OrderBy(a => a.UploadDate ?? DateTime.MinValue)
                .ThenBy(a => a.Id)
                .ToList();

            if (mergeableAttachments.Count == 0)
            {
                rpt.ShowPreviewDialog();
                return;
            }

            string mergedPath = BuildMergedPrintout(rpt, mergeableAttachments, poId);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName        = mergedPath,
                UseShellExecute = true
            });
        }

        /// <summary>Prints the "سجل أوامر الشراء" register report for the rows currently shown in
        /// ucPurchaseOrder's grid (respecting whatever project filter is applied there) — one row per
        /// purchase order, not a per-order detail print like <see cref="Print"/>. FormattedNum/StatusDisplay
        /// are trusted as already set (ucPurchaseOrder.LoadData populates both on every row before it ever
        /// reaches the grid); only ProjectName/StoreName/SupplierName are re-resolved here, same as
        /// PurchaseRequestPrinter.PrintLog's ProjectName/StoreName/DisciplineName.</summary>
        public static void PrintLog(List<PurchaseOrderList> records)
        {
            var projects = dc.ProjectsList.GetBy("IsDelete = 0").ToDictionary(p => p.Id);
            var stores = dc.StoreList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);
            var suppliers = dc.StakeholdersList.GetBy("IsDelete = 0").ToDictionary(s => s.Id);

            foreach (var po in records)
            {
                po.ProjectName = po.PrjId is > 0 && projects.TryGetValue(po.PrjId.Value, out var prj) ? prj.Name : null;
                po.StoreName = po.StoreId is > 0 && stores.TryGetValue(po.StoreId.Value, out var store) ? store.Name : null;
                po.SupplierName = po.StakeholderId is > 0 && suppliers.TryGetValue(po.StakeholderId.Value, out var sup) ? sup.Name : null;
            }

            var rpt = new rprPurchaseOrderLog { DataSource = records };
            rpt.xrPrintDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
            rpt.ShowPreviewDialog();
        }

        private static bool IsMergeableExtension(string? ext) =>
            ext?.ToLowerInvariant() is "pdf" or "jpg" or "jpeg" or "png";

        /// <summary>Exports rpt to PDF, then appends each PDF/image attachment as extra pages — PDFs are
        /// appended as-is, images are dropped onto a throwaway single-picture XtraReport exported to PDF
        /// first (far more reliable than drawing directly onto a hand-built PDF page via PdfDocumentProcessor's
        /// lower-level graphics API). Saves the combined document to a temp file and returns its path.</summary>
        private static string BuildMergedPrintout(rptPurchaseOrder rpt, List<AttachmentList> attachments, int poId)
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
            string tempPath = Path.Combine(tempDir, $"PO_{poId}_{Guid.NewGuid():N}.pdf");
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

        private static rptPurchaseOrder? BuildReport(int poId)
        {
            var po = dc.PurchaseOrderList.Find(poId);
            if (po == null) return null;

            // حقول عرض غير مخزَّنة (اسم المشروع/موقع التسليم/الرقم المنسّق) — التقرير مربوط بها عبر
            // ExpressionBindings
            po.ProjectName = dc.ProjectsList.Find(po.PrjId ?? 0)?.Name;
            po.StoreName = dc.StoreList.Find(po.StoreId ?? 0)?.Name;
            po.FormattedNum = PurchaseOrderNumberFormatter.FormatPONumber(po.Num, po.OrderDate);

            var vendor = po.StakeholderId is > 0 ? dc.StakeholdersList.Find(po.StakeholderId.Value) : null;
            var linkedPr = po.PRId is > 0 ? dc.PurchaseRequestList.Find(po.PRId.Value) : null;
            var linkedQuotation = po.QuotationId is > 0 ? dc.PriceQuotationList.Find(po.QuotationId.Value) : null;

            var details = dc.PurchaseOrderDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id = poId })
                .OrderBy(d => d.Id)
                .ToList();

            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            foreach (var d in details)
            {
                d.UnitAbbreviation = d.UnitId is > 0 && units.TryGetValue(d.UnitId.Value, out var u) ? u.Abbreviation : null;

                // xrDescription يعرض "اسم الصنف - المورد/المصنع"، أو اسم الصنف وحده إن لم يُقترح مورد/مصنع لهذا البند
                if (!string.IsNullOrWhiteSpace(d.SupplierManufacturer))
                    d.Description = $"{d.Description} - {d.SupplierManufacturer}";
            }

            var rpt = new rptPurchaseOrder { DataSource = new List<PurchaseOrderList> { po } };
            var rptDetails = new rptPurchaseOrderSubReport { DataSource = details };
            rpt.xrItemsSubreport.ReportSource = rptDetails;

            // حقول القيمة غير المرتبطة (بلا ExpressionBinding في التصميم) — تُملأ هنا مباشرةً بدل الربط،
            // إذ مصدرها إما جدول آخر (المورد/طلب الشراء) أو قيمة محسوبة (الإجمالي/الضريبة)
            rpt.xrVendorNameValue.Text = vendor?.Name;
            rpt.xrVendorPhoneValue.Text = vendor?.PhoneNumber;
            rpt.xrVendorTaxNumberValue.Text = vendor?.TaxNumber;
            rpt.xrQuotationNumberValue.Text = linkedQuotation?.Num?.ToString();
            rpt.xrPurchaseOrderNumberValue.Text = po.FormattedNum;
            rpt.xrPurchaseOrderDateValue.Text = po.OrderDate?.ToString("yyyy-MM-dd");
            rpt.xrPurchaseOrderTypeValue.Text = po.PurchaseMethod;
            rpt.xrPurchaseRequestNumberValue.Text = linkedPr != null
                ? PurchaseRequestPrinter.FormatPRNumber(linkedPr.Num, linkedPr.RequestDate)
                : null;
            rpt.xrPurpose.Text = po.Description;
            rpt.xrTermsAndConditionsValue.Text = BuildTermsText(po);

            decimal subtotal = details.Sum(d => d.TotalPrice ?? 0);
            decimal grandTotal = details.Sum(d => d.TotalWithTax ?? d.TotalPrice ?? 0);
            rpt.xrSubtotalValue.Text = subtotal.ToString("N2");
            rpt.xrVatValue.Text = (grandTotal - subtotal).ToString("N2");
            rpt.xrGrandTotalValue.Text = grandTotal.ToString("N2");

            var sigBoxes = new[] { rpt.xrPurchasingManagerSignatureBox, rpt.xrCostEstimationEngineerSignatureBox, rpt.xrProjectsManagerSignatureBox, rpt.xrOperationsExecutiveSignatureBox };
            var instance = dc.WorkflowInstanceList
                .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = "PurchaseOrderList", id = poId })
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
                    // أمر الشراء المرفوض يُلغي جميع التواقيع على المطبوعة — بما فيها توقيع المُصدِر (لا معنى
                    // لتصديق مستند مرفوض) — ويبقى الصندوق الوحيد المملوء هو صندوق الخطوة التي رفضت، بختم
                    // "مرفوض" الأحمر وسبب الرفض بدل صورة توقيع.
                    string? rejectedStepName = snapshotSteps.TryGetValue(rejection.WorkflowStepId, out var rejSnapStep)
                        ? rejSnapStep.Name
                        : liveSteps.TryGetValue(rejection.WorkflowStepId, out var rejLiveStep) ? rejLiveStep.Name : null;

                    int? rejectedBoxIndex = ResolveSignatureBoxIndex(rejectedStepName);
                    if (rejectedBoxIndex is not null)
                        sigBoxes[rejectedBoxIndex.Value].Image = CreateRejectionStampImage(rejection.Comment);
                }
                else
                {
                    // xrPurchasingOfficerSignatureBox ("مسؤول المشتريات (إصدار)") sits outside the 4-step
                    // approval chain entirely — the seeded "أمر الشراء" procedure starts directly at "مدير
                    // المشتريات" approval, with no separate issuance step — so it's filled from the PO's own
                    // preparer, not from WorkflowInstanceHistoryList like the other four.
                    var issuerSignature = dc.UsersList.Find(po.CreatedBy)?.Signature;
                    if (issuerSignature is { Length: > 0 })
                        rpt.xrPurchasingOfficerSignatureBox.Image = Image.FromStream(new MemoryStream(issuerSignature));

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

        /// <summary>Composes the "الشروط والأحكام" block from the header's individual contract-term fields
        /// (rptPurchaseOrder has no single matching column — the report was originally copy-pasted from
        /// rptPurchaseRequest with a leftover [Purpose] binding that doesn't exist on PurchaseOrderList).
        /// Skips any term left blank on the header.</summary>
        private static string BuildTermsText(PurchaseOrderList po)
        {
            var lines = new List<string>();

            if (!string.IsNullOrWhiteSpace(po.PaymentTerms)) lines.Add($"شروط الدفع: {po.PaymentTerms}");
            if (!string.IsNullOrWhiteSpace(po.ExecutionDuration)) lines.Add($"مدة التنفيذ/ التوريد: {po.ExecutionDuration}");
            if (po.DailyPenaltyRate is > 0)
            {
                var max = po.DailyPenaltyMaxPercent is > 0 ? $" (بحد أقصى {po.DailyPenaltyMaxPercent}%)" : "";
                lines.Add($"غرامة التأخير: {po.DailyPenaltyRate}% لكل يوم تأخير{max}");
            }
            if (po.PerformanceBondPercent is > 0) lines.Add($"ضمان حسن الأداء: {po.PerformanceBondPercent}%");
            if (!string.IsNullOrWhiteSpace(po.WarrantyDuration)) lines.Add($"مدة الضمان/ الصيانة: {po.WarrantyDuration}");
            if (!string.IsNullOrWhiteSpace(po.ContractTermsOther)) lines.Add(po.ContractTermsOther!);

            return string.Join("\r\n", lines);
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

        /// <summary>Maps a workflow step's free-text name to one of the report's 4 approval-chain signature
        /// boxes (sigBoxes above; xrPurchasingOfficerSignatureBox is handled separately as the issuer, not
        /// here) by role keyword — one-to-one with the 4 steps the "أمر الشراء" procedure actually seeds in
        /// DatabaseInitializer: "اعتماد مدير المشتريات" → 0, "مراجعة مهندس التقديرات والتكلفة" → 1,
        /// "اعتماد مدير المشروعات" → 2, "اعتماد الرئيس التنفيذي للعمليات" → 3. A step name matching none of
        /// these keywords (e.g. a custom project/discipline-specific procedure variant) simply contributes
        /// no signature.</summary>
        private static int? ResolveSignatureBoxIndex(string? stepName)
        {
            if (string.IsNullOrWhiteSpace(stepName)) return null;

            if (stepName.Contains("مشتريات")) return 0;              // مدير المشتريات
            if (stepName.Contains("تكلفة") || stepName.Contains("تكاليف") || stepName.Contains("تقدير"))
                return 1;                                            // مهندس التقديرات والتكلفة
            if (stepName.Contains("مشروعات")) return 2;              // مدير المشروعات
            if (stepName.Contains("تنفيذي")) return 3;               // الرئيس التنفيذي للعمليات

            return null;
        }
    }
}
