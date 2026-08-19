using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>Builds and previews the material-receive voucher print report — shared by
    /// frmMaterialReceiveAddEdit's print button (and any future grid quick-print) so both stay in sync.</summary>
    public static class MaterialReceivePrinter
    {
        private static Data.DataContext dc => Data.DataContext.Shared;

        // رقم مستند الوارد نفسه بصيغة "MRV2600001" (سنتان من ReceivedDate + تسلسل يتجدد كل سنة — انظر
        // frmMaterialReceiveAddEdit.GetNextNumber) — عام كي يُستخدم أيضاً في textEditNum بـ
        // frmMaterialReceiveAddEdit (نفس الصيغة المعروضة في الطباعة).
        public static string FormatReceiveNumber(int? num, DateTime? receivedDate) =>
            num.HasValue && receivedDate.HasValue ? $"MRV{receivedDate.Value:yy}{num.Value:D5}" : "";

        public static void Print(int id)
        {
            var doc = dc.MaterialReceiveList.Find(id);
            if (doc == null) return;

            // حقول عرض غير مخزَّنة (اسم المخزن/المورد/رقم المستند ورقم أمر الشراء المنسَّقان) — التقرير
            // مربوط بها عبر ExpressionBindings.
            doc.StoreName = dc.StoreList.Find(doc.StoreId ?? 0)?.Name;
            doc.SupplierName = doc.StakeholderId is > 0 ? dc.StakeholdersList.Find(doc.StakeholderId.Value)?.Name : null;
            var linkedPo = doc.POId is > 0 ? dc.PurchaseOrderList.Find(doc.POId.Value) : null;
            doc.FormattedPONum = linkedPo != null ? PurchaseOrderNumberFormatter.FormatPONumber(linkedPo.Num, linkedPo.OrderDate) : "";
            doc.FormattedNum = FormatReceiveNumber(doc.Num, doc.ReceivedDate);

            var details = dc.MaterialReceiveDetails
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

            var rpt = new rptMaterialReceive { DataSource = new List<MaterialReceiveList> { doc } };
            var rptDetails = new rptMaterialReceiveSubReport { DataSource = details };
            rpt.xrSubreport1.ReportSource = rptDetails;

            rpt.ShowPreviewDialog();
        }
    }
}
