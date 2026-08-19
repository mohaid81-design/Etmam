using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Tracks how much of each Purchase Order line has already been received (via
    /// MaterialReceiveDetails.PODetailId), so frmPurchaseOrderSelect only offers a PO — and lets the user
    /// create another receive voucher against it — as long as at least one line still has quantity that
    /// hasn't been received yet. A PO with every line fully received drops out of the picker. Mirrors
    /// PurchaseRequestOrderProgress's PR-vs-PO logic one step further down the chain (PO-vs-Receive).
    /// </summary>
    public static class PurchaseOrderReceiveProgress
    {
        /// <summary>True if at least one line of this PO still has quantity not yet received via any
        /// (non-deleted) Material Receive voucher.</summary>
        public static bool HasRemainingItems(DataContext dc, int poId) =>
            GetRemainingDetails(dc, poId).Count > 0;

        /// <summary>
        /// Returns this PO's lines that still have un-received quantity. Each returned line's Qty is
        /// overwritten with the *remaining* (not yet received) quantity rather than the originally
        /// ordered one, so callers can use it directly without double-counting quantity already received
        /// on an earlier voucher.
        /// </summary>
        public static List<PurchaseOrderDetails> GetRemainingDetails(DataContext dc, int poId)
        {
            var poLines = dc.PurchaseOrderDetails.GetBy("ParentId = @id AND IsDelete = 0", new { id = poId });
            if (poLines.Count == 0) return new List<PurchaseOrderDetails>();

            var poLineIds = string.Join(",", poLines.Select(l => l.Id));
            var receivedByPoDetailId = dc.MaterialReceiveDetails
                .GetBy($"PODetailId IN ({poLineIds}) AND IsDelete = 0")
                .GroupBy(d => d.PODetailId ?? 0)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));

            var result = new List<PurchaseOrderDetails>();
            foreach (var line in poLines)
            {
                var received = receivedByPoDetailId.GetValueOrDefault(line.Id);
                var remaining = (line.Qty ?? 0) - received;
                if (remaining <= 0) continue;

                line.Qty = remaining;
                result.Add(line);
            }
            return result;
        }
    }
}
