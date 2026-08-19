using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the purchase-return voucher print report — shared by
    /// frmPurchaseReturnAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class PurchaseReturnPrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مرتجع المشتريات بصيغة "PRV2600001" (سنتان من ReturnDate + تسلسل يتجدد كل سنة — انظر
        // frmPurchaseReturnAddEdit.GetNextCode) — Code كيان نصي (وليس عدداً صحيحاً مباشراً مثل بقية
        // المستندات)، فيُحلَّل رقمياً أولاً بدل الاعتماد على تنسيق ثابت العرض. عام كي يُستخدم أيضاً في
        // textEditNum بـ frmPurchaseReturnAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatReturnNumber(string? code, DateTime? returnDate) =>
            int.TryParse(code, out var num) && returnDate.HasValue ? $"PRV{returnDate.Value:yy}{num:D5}" : code ?? "";

        public static void Print(int id)
        {
            var doc = dc.PurchaseReturnList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/المشروع/المورد/رقم المستند المنسَّق) — التقرير مربوط بها
            // عبر ExpressionBindings.
            doc.StoreName = dc.StoreList.Find(doc.StoreId ?? 0)?.Name;
            doc.ProjectName = doc.PrjId is > 0 ? dc.ProjectsList.Find(doc.PrjId.Value)?.Name : null;
            doc.SupplierName = doc.StakeholderId is > 0 ? dc.StakeholdersList.Find(doc.StakeholderId.Value)?.Name : null;
            doc.FormattedNum = FormatReturnNumber(doc.Code, doc.ReturnDate);

            var details = dc.PurchaseReturnDetails
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

            var rpt = new rptPurchaseReturn { DataSource = new List<PurchaseReturnList> { doc } };
            var rptDetails = new rptPurchaseReturnSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
