using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core;

namespace Etmam
{
    /// <summary>
    /// Generates print-ready HTML reports for all Document Management modules.
    /// Renders to a temporary file and opens the default browser for printing.
    /// </summary>
    public static class PrintHelper
    {
        // ── Public entry points ───────────────────────────────────────────────

        public static void PrintTransmittals(IEnumerable<DrawingsSubmittalList> records, string projectName = "")
        {
            var cols = new[]
            {
                ("الرقم",            (Func<DrawingsSubmittalList, string>)(r => r.Num?.ToString() ?? "")),
                ("الإصدار",          r => r.Rev?.ToString() ?? ""),
                ("الموضوع",          r => r.Description ?? ""),
                ("النوع",            r => r.Type ?? ""),
                ("الحالة",           r => r.Status ?? ""),
                ("المُرسِل",        r => r.IssuedBy ?? ""),
                ("المراجع",          r => r.ReviewedBy ?? ""),
                ("نتيجة المراجعة",   r => r.CSTReviewStatus ?? ""),
                ("تاريخ الإصدار",    r => FormatDate(r.PreparedDate)),
                ("تاريخ الاستلام",   r => r.CSTDateReceived ?? ""),
                ("تاريخ الإعادة",    r => r.CSTDateReturned ?? ""),
            };
            ShowReport("سجل الإرساليات - Transmittal Register", projectName, records, cols);
        }

        public static void PrintMAR(IEnumerable<DrawingsSubmittalList> records, string projectName = "")
        {
            var cols = new[]
            {
                ("الرقم",             (Func<DrawingsSubmittalList, string>)(r => r.Num?.ToString() ?? "")),
                ("الإصدار",           r => r.Rev?.ToString() ?? ""),
                ("اسم المادة / المورد", r => r.Description ?? ""),
                ("التخصص",            r => r.Category ?? ""),
                ("مقدم الطلب",        r => r.IssuedBy ?? ""),
                ("حالة الاعتماد",     r => r.CSTReviewStatus ?? ""),
                ("تاريخ التقديم",     r => FormatDate(r.PreparedDate)),
                ("تاريخ الاستلام",    r => r.CSTDateReceived ?? ""),
                ("تاريخ الإعادة",     r => r.CSTDateReturned ?? ""),
                ("ملاحظات",           r => r.CSTReviewComment ?? ""),
            };
            ShowReport("سجل طلبات اعتماد المواد - MAR Register", projectName, records, cols);
        }

        public static void PrintMIR(IEnumerable<DrawingsSubmittalList> records, string projectName = "")
        {
            var cols = new[]
            {
                ("الرقم",              (Func<DrawingsSubmittalList, string>)(r => r.Num?.ToString() ?? "")),
                ("الإصدار",            r => r.Rev?.ToString() ?? ""),
                ("وصف المواد الموردة", r => r.Description ?? ""),
                ("التخصص",             r => r.Category ?? ""),
                ("مقدم الطلب",         r => r.IssuedBy ?? ""),
                ("نتيجة الفحص",        r => r.CSTReviewStatus ?? ""),
                ("تاريخ التوريد",      r => FormatDate(r.PreparedDate)),
                ("تاريخ الاستلام",     r => r.CSTDateReceived ?? ""),
                ("تاريخ الإعادة",      r => r.CSTDateReturned ?? ""),
                ("ملاحظات",            r => r.CSTReviewComment ?? ""),
            };
            ShowReport("سجل طلبات فحص المواد - MIR Register", projectName, records, cols);
        }

        public static void PrintCIR(IEnumerable<DrawingsSubmittalList> records, string projectName = "")
        {
            var cols = new[]
            {
                ("الرقم",                    (Func<DrawingsSubmittalList, string>)(r => r.Num?.ToString() ?? "")),
                ("الإصدار",                  r => r.Rev?.ToString() ?? ""),
                ("وصف العمل المطلوب فحصه",   r => r.Description ?? ""),
                ("التخصص",                   r => r.Category ?? ""),
                ("مقدم الطلب",               r => r.IssuedBy ?? ""),
                ("نتيجة الفحص",              r => r.CSTReviewStatus ?? ""),
                ("تاريخ الفحص",              r => FormatDate(r.PreparedDate)),
                ("تاريخ الاستلام",           r => r.CSTDateReceived ?? ""),
                ("تاريخ الإعادة",            r => r.CSTDateReturned ?? ""),
                ("ملاحظات",                  r => r.CSTReviewComment ?? ""),
            };
            ShowReport("سجل طلبات الفحص الإنشائي - CIR Register", projectName, records, cols);
        }

        public static void PrintDrawings(IEnumerable<DrawingsRegisterList> records, string projectName = "")
        {
            var cols = new[]
            {
                ("رقم المخطط",     (Func<DrawingsRegisterList, string>)(r => r.Num?.ToString() ?? "")),
                ("الإصدار",        r => r.Rev?.ToString() ?? ""),
                ("اسم المخطط",     r => r.DocName ?? ""),
                ("الوصف",          r => r.Description ?? ""),
                ("النوع",          r => MapDrawingType(r.Type)),
                ("التخصص",         r => r.Category ?? ""),
                ("الغرض",          r => r.Floor ?? ""),
                ("حالة الاعتماد",  r => r.CSTReviewStatus ?? ""),
                ("تاريخ الإصدار",  r => FormatDate(r.PreparedDate)),
            };
            ShowReport("سجل المخططات - Drawing Register", projectName, records, cols);
        }

        // ── Core builder ──────────────────────────────────────────────────────

        private static void ShowReport<T>(
            string title,
            string projectName,
            IEnumerable<T> records,
            (string Header, Func<T, string> Value)[] cols)
        {
            string html = BuildHtml(title, projectName, records, cols);
            string tempFile = Path.Combine(Path.GetTempPath(), $"EtmamReport_{Guid.NewGuid():N}.html");
            File.WriteAllText(tempFile, html, Encoding.UTF8);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName  = tempFile,
                UseShellExecute = true
            });
        }

        private static string BuildHtml<T>(
            string title,
            string projectName,
            IEnumerable<T> records,
            (string Header, Func<T, string> Value)[] cols)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='ar' dir='rtl'>");
            sb.AppendLine("<head>");
            sb.AppendLine("  <meta charset='UTF-8'>");
            sb.AppendLine($"  <title>{title}</title>");
            sb.AppendLine("  <style>");
            sb.AppendLine(@"
    @import url('https://fonts.googleapis.com/css2?family=Cairo:wght@400;600;700&display=swap');
    * { box-sizing: border-box; margin: 0; padding: 0; }
    body {
        font-family: 'Cairo', 'Segoe UI', Tahoma, sans-serif;
        font-size: 11px;
        color: #1a1a2e;
        background: #f8f9fb;
        direction: rtl;
    }
    .page {
        max-width: 1100px;
        margin: 20px auto;
        background: #fff;
        border: 1px solid #dde1e8;
        border-radius: 8px;
        overflow: hidden;
        box-shadow: 0 2px 12px rgba(0,0,0,.08);
    }
    .header {
        background: linear-gradient(135deg, #1e4682 0%, #2a5ca8 100%);
        color: #fff;
        padding: 18px 24px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .header h1 { font-size: 16px; font-weight: 700; letter-spacing: .3px; }
    .header .meta { font-size: 10px; opacity: .85; text-align: left; }
    .content { padding: 16px 20px; }
    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 10px;
    }
    thead tr { background: #1e4682; color: #fff; }
    thead th {
        padding: 8px 6px;
        font-size: 10px;
        font-weight: 700;
        text-align: center;
        border: 1px solid #2a5ca8;
        white-space: nowrap;
    }
    tbody tr:nth-child(even) { background: #f4f6fb; }
    tbody tr:hover { background: #e8eef8; }
    tbody td {
        padding: 6px 6px;
        font-size: 10px;
        border: 1px solid #dde1e8;
        text-align: center;
        vertical-align: middle;
    }
    tbody td:nth-child(3) { text-align: right; }
    .status-approved        { color: #1a7a3a; font-weight: 700; }
    .status-rejected        { color: #c0392b; font-weight: 700; }
    .status-under-review    { color: #d97706; font-weight: 700; }
    .status-comments        { color: #1e4682; font-weight: 700; }
    .footer {
        background: #f4f6fb;
        border-top: 1px solid #dde1e8;
        padding: 8px 20px;
        font-size: 9px;
        color: #6b7280;
        display: flex;
        justify-content: space-between;
    }
    @media print {
        body { background: #fff; font-size: 9px; }
        .page { box-shadow: none; border: none; margin: 0; max-width: 100%; }
        .header { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
        thead tr { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
        tbody tr:nth-child(even) { -webkit-print-color-adjust: exact; print-color-adjust: exact; }
    }
            ");
            sb.AppendLine("  </style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<div class='page'>");

            // ── Header ─────────────────────────────────────────────────────
            sb.AppendLine("  <div class='header'>");
            sb.AppendLine($"    <h1>{title}</h1>");
            sb.AppendLine($"    <div class='meta'>");
            if (!string.IsNullOrWhiteSpace(projectName))
                sb.AppendLine($"      <div>المشروع: {EscapeHtml(projectName)}</div>");
            sb.AppendLine($"      <div>تاريخ الطباعة: {DateTime.Now:yyyy/MM/dd HH:mm}</div>");
            sb.AppendLine($"    </div>");
            sb.AppendLine("  </div>");

            // ── Table ──────────────────────────────────────────────────────
            sb.AppendLine("  <div class='content'>");
            sb.AppendLine("    <table>");
            sb.AppendLine("      <thead><tr>");
            sb.AppendLine("        <th>#</th>");
            foreach (var col in cols)
                sb.AppendLine($"        <th>{EscapeHtml(col.Header)}</th>");
            sb.AppendLine("      </tr></thead>");
            sb.AppendLine("      <tbody>");

            int row = 0;
            foreach (var rec in records)
            {
                row++;
                sb.AppendLine("        <tr>");
                sb.AppendLine($"          <td>{row}</td>");
                foreach (var col in cols)
                {
                    string val  = col.Value(rec);
                    string cls  = GetStatusCssClass(val);
                    string tdCls = cls.Length > 0 ? $" class='{cls}'" : "";
                    sb.AppendLine($"          <td{tdCls}>{EscapeHtml(val)}</td>");
                }
                sb.AppendLine("        </tr>");
            }

            sb.AppendLine("      </tbody>");
            sb.AppendLine("    </table>");
            sb.AppendLine("  </div>");

            // ── Footer ─────────────────────────────────────────────────────
            sb.AppendLine("  <div class='footer'>");
            sb.AppendLine($"    <span>إجمالي السجلات: {row}</span>");
            sb.AppendLine($"    <span>نظام إتمام - Etmam PMS</span>");
            sb.AppendLine($"    <span>{DateTime.Now:yyyy/MM/dd}</span>");
            sb.AppendLine("  </div>");

            sb.AppendLine("</div>");
            sb.AppendLine("<script>window.onload = function() { window.print(); }</script>");
            sb.AppendLine("</body></html>");

            return sb.ToString();
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static string FormatDate(DateTime? d) =>
            d.HasValue ? d.Value.ToString("yyyy/MM/dd") : "";

        private static string EscapeHtml(string s) =>
            s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

        private static string GetStatusCssClass(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return "";
            var s = status.ToLowerInvariant();
            if (s.Contains("approved") && !s.Contains("comment")) return "status-approved";
            if (s.Contains("pass"))      return "status-approved";
            if (s.Contains("reject"))   return "status-rejected";
            if (s.Contains("fail"))     return "status-rejected";
            if (s.Contains("comment"))  return "status-comments";
            if (s.Contains("review") || s.Contains("inspection") || s.Contains("hold") || s.Contains("resubmit"))
                return "status-under-review";
            return "";
        }

        private static string MapDrawingType(int? type) => type switch
        {
            1 => "إنشائي",
            2 => "معماري",
            3 => "ميكانيكا",
            4 => "كهرباء",
            _ => "أخرى"
        };
    }
}
