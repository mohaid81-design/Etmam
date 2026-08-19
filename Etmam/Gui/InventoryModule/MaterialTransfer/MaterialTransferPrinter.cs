using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the material-transfer voucher print report — shared by
    /// frmMaterialTransferAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class MaterialTransferPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مستند التحويل بصيغة "MTV2600001" (سنتان من TransferDate + تسلسل يتجدد كل سنة — انظر
        // frmMaterialTransferAddEdit.GetNextNumber) — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmMaterialTransferAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatTransferNumber(int? num, DateTime? transferDate) =>
            num.HasValue && transferDate.HasValue ? $"MTV{transferDate.Value:yy}{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.MaterialTransferList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن المصدر/الوجهة/رقم المستند المنسَّق) — التقرير مربوط بها
            // عبر ExpressionBindings.
            doc.StoreName = dc.StoreList.Find(doc.FromStoreId ?? 0)?.Name;
            doc.ToStoreName = dc.StoreList.Find(doc.ToStoreId ?? 0)?.Name;
            doc.FormattedNum = FormatTransferNumber(doc.Num, doc.TransferDate);

            var details = dc.MaterialTransferDetails
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

            var rpt = new rptMaterialTransfer { DataSource = new List<MaterialTransferList> { doc } };
            var rptDetails = new rptMaterialTransferSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
