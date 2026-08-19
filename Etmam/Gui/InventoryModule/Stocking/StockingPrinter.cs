using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the stock-count voucher print report — shared by
    /// frmStockingAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class StockingPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مستند الجرد بصيغة "STK00001" — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmStockingAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatStockingNumber(int? num) => num.HasValue ? $"STK{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.StockingList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/رقم المستند المنسَّق) — التقرير مربوط بها عبر ExpressionBindings.
            doc.StoreName = dc.StoreList.Find(doc.StoreId ?? 0)?.Name;
            doc.FormattedNum = FormatStockingNumber(doc.Num);

            var details = dc.StockingDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);

            for (int i = 0; i < details.Count; i++)
            {
                var d = details[i];
                d.ItemNo = i + 1;
                d.UnitAbbr = d.UnitId is > 0 && units.TryGetValue(d.UnitId.Value, out var u) ? u.Abbreviation : null;
                // نفس حساب RecalculateRow في frmStockingAddEdit — الفرق غير مخزَّن أصلاً.
                d.Difference = (d.Qty ?? 0) - (d.SystemQty ?? 0);
            }

            var rpt = new rptStocking { DataSource = new List<StockingList> { doc } };
            var rptDetails = new rptStockingSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
