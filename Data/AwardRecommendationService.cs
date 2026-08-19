using Core;

namespace Data
{
    /// <summary>
    /// Computes the two "facts" an Award Recommendation must snapshot rather than let the recommender
    /// simply assert — IsLowestBid and TechnicalStatus (see Core.AwardRecommendationList's own summary).
    /// Both are re-derived by frmAwardRecommendationAddEdit every time the recommended quotation changes
    /// or the record is saved, so they can never drift from what the underlying data actually says.
    /// </summary>
    public static class AwardRecommendationService
    {
        /// <summary>True iff no other active (non-deleted) quotation for the same RFQ has a lower
        /// Amount than the given one. A quotation with no RFQ (RFQId null, the legacy standalone flow)
        /// has nothing to compare against, so it's trivially "lowest".</summary>
        public static bool ComputeIsLowestBid(DataContext dc, int quotationId)
        {
            var quotation = dc.PriceQuotationRequestList.Find(quotationId);
            if (quotation?.RFQId is not > 0) return true;

            var siblingAmounts = dc.PriceQuotationRequestList
                .GetBy("RFQId = @id AND IsDelete = 0", new { id = quotation.RFQId.Value })
                .Select(q => q.Amount ?? 0);

            var ownAmount = quotation.Amount ?? 0;
            return siblingAmounts.All(a => a >= ownAmount);
        }

        /// <summary>The recommended quotation's most recent technical evaluation verdict (by
        /// EvaluationDate, falling back to Id), or null if it was never evaluated.</summary>
        public static string? GetLatestTechnicalStatus(DataContext dc, int quotationId)
        {
            return dc.TechnicalEvaluationList
                .GetBy("PriceQuotationRequestId = @id AND IsDelete = 0", new { id = quotationId })
                .OrderByDescending(e => e.EvaluationDate)
                .ThenByDescending(e => e.Id)
                .FirstOrDefault()
                ?.Status;
        }
    }
}
