using System;
using System.Collections.Generic;
using Core;
using DevExpress.XtraReports.UI;

namespace Etmam
{
    /// <summary>يطبع نتائج تقارير المخزون الأربعة المحسوبة سلفاً (نفس الصفوف المعروضة حالياً في شبكة
    /// ucInventoryReports، بلا إعادة استعلام) عبر تقارير DevExpress مصمَّمة رسمياً — نفس نمط
    /// PurchaseRequestPrinter.Print: بناء DataSource ثم rpt.ShowPreviewDialog().</summary>
    public static class InventoryReportsPrinter
    {
        public static void PrintCurrentStockBalance(List<StockBalanceRow> rows, string filterSummary)
        {
            var rpt = new rptCurrentStockBalance { DataSource = rows };
            rpt.xrFilterSummary.Text = filterSummary;
            rpt.xrPrintDate.Text = $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}";
            rpt.ShowPreviewDialog();
        }

        public static void PrintItemStockCard(List<ItemStockCardRow> rows, string itemName, string storeName)
        {
            var rpt = new rptItemStockCard { DataSource = rows };
            rpt.xrFilterSummary.Text = $"الصنف: {itemName}  |  المخزن: {storeName}";
            rpt.xrPrintDate.Text = $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}";
            rpt.ShowPreviewDialog();
        }

        public static void PrintStockMovementPeriod(List<StockMovementPeriodRow> rows, DateTime fromDate, DateTime toDate, string filterSummary)
        {
            var rpt = new rptStockMovementPeriod { DataSource = rows };
            rpt.xrFilterSummary.Text = filterSummary;
            rpt.xrPrintDate.Text = $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}";
            rpt.ShowPreviewDialog();
        }

        public static void PrintStockingVariance(List<StockingDetails> rows, string filterSummary)
        {
            var rpt = new rptStockingVariance { DataSource = rows };
            rpt.xrFilterSummary.Text = filterSummary;
            rpt.xrPrintDate.Text = $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm}";
            rpt.ShowPreviewDialog();
        }
    }
}
