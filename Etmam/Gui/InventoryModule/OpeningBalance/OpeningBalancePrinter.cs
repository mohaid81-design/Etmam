using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the opening-balance voucher print report — shared by
    /// frmOpeningBalanceAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class OpeningBalancePrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم الرصيد الافتتاحي بصيغة "MOB00001" — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmOpeningBalanceAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatBalanceNumber(int? num) => num.HasValue ? $"MOB{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.OpeningBalanceList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/رقم المستند المنسَّق) — التقرير مربوط بها عبر ExpressionBindings.
            doc.StoreName = dc.StoreList.Find(doc.StoreId ?? 0)?.Name;
            doc.FormattedNum = FormatBalanceNumber(doc.Num);

            var details = dc.OpeningBalanceDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);

            for (int i = 0; i < details.Count; i++)
            {
                var d = details[i];
                d.ItemNo = i + 1;
                d.UnitAbbreviation = d.UnitId is > 0 && units.TryGetValue(d.UnitId.Value, out var u) ? u.Abbreviation : null;
            }

            var rpt = new rptOpeningBalance { DataSource = new List<OpeningBalanceList> { doc } };
            var rptDetails = new rptOpeningBalanceSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
