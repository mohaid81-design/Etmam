namespace Etmam
{
    /// <summary>
    /// Shared by ucProjectsMgt.cs and ucProjectsList.cs — a project can't be deleted while it's
    /// referenced by any transaction across the modules below.
    /// </summary>
    public static class ProjectValidationHelper
    {
        public static bool HasTransactions(int prjId)
        {
            var dc = Data.DataContext.Shared;
            var p = new { prjId };

            return dc.PurchaseRequestList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.PurchaseOrderList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.BudgetList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.CostCenterList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.MaterialApprovalRequestList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.DrawingsSubmittalList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.DrawingsRegisterList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.ScheduleList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.PurchaseReturnList.Exists("PrjId = @prjId AND IsDelete = 0", p)
                || dc.DailyReport.Exists("PrjId = @prjId AND IsDelete = 0", p);
        }
    }
}
