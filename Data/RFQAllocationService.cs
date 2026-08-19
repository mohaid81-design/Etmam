using Core;

namespace Data
{
    /// <summary>
    /// Enforces the RFQ line-allocation rule from the methodology doc's Procurement Workbench section:
    /// the sum of quantity committed from one Purchase Request line to RFQs must never exceed that
    /// line's own available quantity. "Available" has two competing claims on the same PR line's Qty —
    /// what's already been placed on a Purchase Order (PurchaseOrderDetails.PRDetailId) and what's
    /// already linked to OTHER active RFQs (PRRFQLineLink) — both must be subtracted, not just one.
    /// Used by CreateRFQFromPRLines and by the UI's live "max allowed" validation while building an
    /// RFQ's line grid, so both enforce the identical rule instead of drifting apart.
    /// </summary>
    public static class RFQAllocationService
    {
        /// <param name="excludeRfqId">When editing an existing RFQ, its own prior links against this PR
        /// line must not count against itself — pass that RFQ's Id to exclude it from the "linked to
        /// other RFQs" total.</param>
        public static decimal GetAvailableQuantity(DataContext dc, int prLineId, int excludeRfqId = 0)
        {
            var prLine = dc.PurchaseRequestDetails.Find(prLineId);
            if (prLine == null) return 0;

            var orderedViaPO = dc.PurchaseOrderDetails
                .GetBy("PRDetailId = @id AND IsDelete = 0", new { id = prLineId })
                .Sum(d => d.Qty ?? 0);

            var linkedToOtherRfqs = GetActiveLinksExcluding(dc, prLineId, excludeRfqId)
                .Sum(l => l.LinkedQuantity ?? 0);

            return Math.Max(0, (prLine.Qty ?? 0) - orderedViaPO - linkedToOtherRfqs);
        }

        /// <summary>Validates a proposed set of (PRLineId, LinkedQuantity) allocations for one RFQ
        /// (new or being edited) against each line's available quantity, and throws with a clear Arabic
        /// message naming the first offending line if any allocation exceeds it. Callers should call
        /// this before writing PRRFQLineLink rows — it does not itself write anything.</summary>
        public static void ValidateAllocations(DataContext dc, IEnumerable<(int PRLineId, decimal LinkedQuantity)> allocations, int excludeRfqId = 0)
        {
            // Several proposed lines can target the same PR line (e.g. split across two RFQ rows by
            // mistake) — their LinkedQuantity must be validated together, not one at a time, otherwise
            // each individual check could pass while their sum still exceeds what's available.
            foreach (var group in allocations.GroupBy(a => a.PRLineId))
            {
                var requested = group.Sum(a => a.LinkedQuantity);
                if (requested <= 0) continue;

                var available = GetAvailableQuantity(dc, group.Key, excludeRfqId);
                if (requested > available)
                {
                    var prLine = dc.PurchaseRequestDetails.Find(group.Key);
                    throw new InvalidOperationException(
                        $"الكمية المطلوبة ({requested:N2}) لبند طلب الشراء \"{prLine?.Description}\" " +
                        $"تتجاوز الكمية المتاحة فعليًا ({available:N2}).");
                }
            }
        }

        private static IEnumerable<PRRFQLineLink> GetActiveLinksExcluding(DataContext dc, int prLineId, int excludeRfqId)
        {
            var links = dc.PRRFQLineLink.GetBy("PRLineId = @id AND IsDelete = 0", new { id = prLineId });
            foreach (var link in links)
            {
                if (link.RFQDetailId is not > 0) continue;
                var rfqDetail = dc.RFQDetails.Find(link.RFQDetailId.Value);
                if (rfqDetail?.RFQId is not > 0) continue;
                if (rfqDetail.RFQId.Value == excludeRfqId) continue;

                var rfq = dc.RFQList.Find(rfqDetail.RFQId.Value);
                if (rfq == null || rfq.IsDelete || rfq.Status == RFQStatus.Cancelled) continue;

                yield return link;
            }
        }
    }
}
