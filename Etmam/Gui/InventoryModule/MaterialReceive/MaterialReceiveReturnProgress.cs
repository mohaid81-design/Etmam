using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Tracks how much of each Material Receive line has already been returned to the supplier (via
    /// PurchaseReturnDetails.RVDetailId), so frmMaterialReceiveSelect only offers a receive voucher — and
    /// lets the user return material against it — as long as at least one line still has quantity not yet
    /// returned. Mirrors PurchaseOrderReceiveProgress one step further down the chain (Receive-vs-Return).
    /// </summary>
    public static class MaterialReceiveReturnProgress
    {
        /// <summary>Remaining (not yet returned) quantity per receive line — keyed by MaterialReceiveDetails.Id.
        /// Values may be zero or negative before any "already committed by this same document" add-back;
        /// callers editing an existing return should add that back themselves (see frmPurchaseReturnAddEdit).</summary>
        public static Dictionary<int, decimal> ComputeRemainingByDetailId(DataContext dc, int receiveId)
        {
            var result = new Dictionary<int, decimal>();

            var lines = dc.MaterialReceiveDetails.GetBy("ParentId = @id AND IsDelete = 0", new { id = receiveId });
            if (lines.Count == 0) return result;

            var lineIds = string.Join(",", lines.Select(l => l.Id));
            var returnedByRvDetailId = dc.PurchaseReturnDetails
                .GetBy($"RVDetailId IN ({lineIds}) AND IsDelete = 0")
                .GroupBy(d => d.RVDetailId ?? 0)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Qty ?? 0));

            foreach (var line in lines)
                result[line.Id] = (line.Qty ?? 0) - returnedByRvDetailId.GetValueOrDefault(line.Id);

            return result;
        }

        /// <summary>True if at least one line of this receive voucher still has quantity not yet returned to
        /// the supplier via any (non-deleted) Purchase Return.</summary>
        public static bool HasRemainingItems(DataContext dc, int receiveId) =>
            ComputeRemainingByDetailId(dc, receiveId).Values.Any(v => v > 0);
    }
}
