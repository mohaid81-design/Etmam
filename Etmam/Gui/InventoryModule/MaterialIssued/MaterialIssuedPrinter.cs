using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the material-issue voucher print report — shared by
    /// frmMaterialIssuedAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class MaterialIssuedPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مستند الصرف بصيغة "MIV2600001" (سنتان من IssuedDate + تسلسل يتجدد كل سنة — انظر
        // frmMaterialIssuedAddEdit.GetNextNumber) — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmMaterialIssuedAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatIssuedNumber(int? num, DateTime? issuedDate) =>
            num.HasValue && issuedDate.HasValue ? $"MIV{issuedDate.Value:yy}{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.MaterialIssuedList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/المشروع/رقم المستند المنسَّق) — التقرير مربوط بها عبر
            // ExpressionBindings. لا يوجد مشروع مباشر على إذن الصرف نفسه، فيُشتق من مشروع المخزن المختار.
            var store = dc.StoreList.Find(doc.StoreId ?? 0);
            doc.StoreName = store?.Name;
            doc.ProjectName = store?.PrjId is > 0 ? dc.ProjectsList.Find(store.PrjId.Value)?.Name : null;
            doc.FormattedNum = FormatIssuedNumber(doc.Num, doc.IssuedDate);

            var details = dc.MaterialIssuedDetails
                .GetBy("ParentId = @id AND IsDelete = 0", new { id })
                .OrderBy(d => d.Id)
                .ToList();

            var units = dc.Units.GetBy("IsDelete = 0").ToDictionary(u => u.Id);
            var budgets = dc.BudgetList.GetBy("IsDelete = 0").ToDictionary(b => b.Id);

            for (int i = 0; i < details.Count; i++)
            {
                var d = details[i];
                d.ItemNo = i + 1;
                d.UnitAbbreviation = d.UnitId is > 0 && units.TryGetValue(d.UnitId.Value, out var u) ? u.Abbreviation : null;
                d.BudgetDescription = d.BdgId is > 0 && budgets.TryGetValue(d.BdgId.Value, out var b) ? b.Description : null;
            }

            var rpt = new rptMaterialIssued { DataSource = new List<MaterialIssuedList> { doc } };
            var rptDetails = new rptMaterialIssuedSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
