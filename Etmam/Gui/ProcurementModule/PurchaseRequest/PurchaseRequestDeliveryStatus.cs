using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Canonical DeliveryStatus values for PurchaseRequestList ("حالة التوريد") and the rollup logic
    /// that computes it from actual receiving activity. Separate from PurchaseRequestStatus
    /// (OverallStatus / "حالة الطلب"), which tracks the approval workflow, not fulfillment.
    /// </summary>
    public static class PurchaseRequestDeliveryStatus
    {
        public const string NotStarted = "لم يبدأ";
        public const string Partial    = "جزئي";
        public const string Complete   = "مكتمل";

        /// <summary>
        /// Recomputes and persists a Purchase Request's DeliveryStatus from actual received quantities,
        /// traced precisely through PurchaseOrderDetails.PRDetailId → MaterialReceiveDetails.PODetailId
        /// (set when lines are imported via ImportFromPR / btnImportFromPO_Click). Call this after saving
        /// a Material Receive that was imported from a Purchase Order linked to a Purchase Request.
        /// </summary>
        public static void Recompute(DataContext dc, int prId)
        {
            var prLines = dc.PurchaseRequestDetails.GetBy("PRId = @id AND IsDelete = 0", new { id = prId });
            if (prLines.Count == 0) return;

            var prLineIds = string.Join(",", prLines.Select(l => l.Id));
            var poLines = dc.PurchaseOrderDetails.GetBy($"PRDetailId IN ({prLineIds}) AND IsDelete = 0");

            if (poLines.Count == 0)
            {
                SetStatus(dc, prId, NotStarted);
                return;
            }

            var poLineIds = string.Join(",", poLines.Select(l => l.Id));
            var receiveLines = dc.MaterialReceiveDetails.GetBy($"PODetailId IN ({poLineIds}) AND IsDelete = 0");

            var receivedByPoDetailId = receiveLines
                .GroupBy(r => r.PODetailId ?? 0)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Qty ?? 0));

            var receivedByPrDetailId = poLines
                .GroupBy(p => p.PRDetailId ?? 0)
                .ToDictionary(g => g.Key, g => g.Sum(p => receivedByPoDetailId.GetValueOrDefault(p.Id)));

            bool anyReceived = false;
            bool allComplete = true;
            foreach (var line in prLines)
            {
                var requested = line.Qty ?? 0;
                var received = receivedByPrDetailId.GetValueOrDefault(line.Id);
                if (received > 0) anyReceived = true;
                if (requested <= 0 || received < requested) allComplete = false;
            }

            SetStatus(dc, prId, allComplete ? Complete : anyReceived ? Partial : NotStarted);
        }

        private static void SetStatus(DataContext dc, int prId, string status)
        {
            var pr = dc.PurchaseRequestList.Find(prId);
            if (pr == null || pr.DeliveryStatus == status) return;

            pr.DeliveryStatus = status;
            dc.PurchaseRequestList.Edit(prId, pr);
        }
    }
}
