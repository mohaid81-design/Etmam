using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the material-issue-return voucher print report — shared by
    /// frmMaterialIssueReturnAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class MaterialIssueReturnPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مرتجع الصرف بصيغة "MIR2600001" (سنتان من ReturnDate + تسلسل يتجدد كل سنة — انظر
        // frmMaterialIssueReturnAddEdit.GetNextNumber) — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmMaterialIssueReturnAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatReturnNumber(int? num, DateTime? returnDate) =>
            num.HasValue && returnDate.HasValue ? $"MIR{returnDate.Value:yy}{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.MaterialIssueReturnList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/المشروع/رقم المستند المنسَّق) — التقرير مربوط بها عبر
            // ExpressionBindings. لا يوجد مشروع مباشر على مرتجع الصرف نفسه، فيُشتق من مشروع المخزن المختار.
            var store = dc.StoreList.Find(doc.StoreId ?? 0);
            doc.StoreName = store?.Name;
            doc.ProjectName = store?.PrjId is > 0 ? dc.ProjectsList.Find(store.PrjId.Value)?.Name : null;
            doc.FormattedNum = FormatReturnNumber(doc.Num, doc.ReturnDate);

            var details = dc.MaterialIssueReturnDetails
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

            var rpt = new rptMaterialIssueReturn { DataSource = new List<MaterialIssueReturnList> { doc } };
            var rptDetails = new rptMaterialIssueReturnSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
