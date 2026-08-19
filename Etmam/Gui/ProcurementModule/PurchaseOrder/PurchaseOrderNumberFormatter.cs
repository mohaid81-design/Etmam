namespace Etmam
{
    /// <summary>Shared PO-number formatter — "PO{yy}{seq:D5}" e.g. "PO2600001", where yy is the 2-digit
    /// year of PurchaseOrderList.OrderDate and seq resets to 1 every calendar year (see
    /// frmPurchaseOrderAddEdit.GetNextNumber for the per-year sequence assignment). Replaces the previously
    /// duplicated private FormatPONumber copies across frmPurchaseOrderAddEdit, frmMaterialReceiveAddEdit,
    /// MaterialReceivePrinter, frmPurchaseOrderSelect and ucMyWorkflowTasks.</summary>
    public static class PurchaseOrderNumberFormatter
    {
        public static string FormatPONumber(int? num, DateTime? orderDate) =>
            num.HasValue && orderDate.HasValue ? $"PO{orderDate.Value:yy}{num.Value:D5}" : "جديد";
    }
}
