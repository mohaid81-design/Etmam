using Core;
using Microsoft.Data.SqlClient;

namespace Data
{
    /// <summary>
    /// Enforces the two structural rules the methodology doc states for Negotiation rounds: each round
    /// is independent (a new round is always a new row, never an edit to a prior one — see
    /// IsLatestRound), and nothing follows a Best And Final Offer (see HasBAFO). Round numbers are
    /// assigned through NumberingService (scoped per quotation via its Id as the "period" key) instead
    /// of MAX(RoundNumber)+1, for the same concurrency reason document numbers use it.
    /// </summary>
    public static class NegotiationService
    {
        public static int GetNextRoundNumber(SqlTransaction tx, int quotationId) =>
            NumberingService.GetNextNumber(tx, "NegotiationRound", quotationId, () =>
                DataContext.Shared.NegotiationList
                    .GetBy("PriceQuotationRequestId = @id AND IsDelete = 0", new { id = quotationId })
                    .Select(n => n.RoundNumber ?? 0)
                    .DefaultIfEmpty(0)
                    .Max());

        /// <summary>The amount a NEW round for this quotation should show as "previous" — the latest
        /// existing round's NewAmount, or the quotation's own Amount if no round exists yet (round 1
        /// negotiates against the original submission).</summary>
        public static decimal? GetCurrentAmount(DataContext dc, int quotationId)
        {
            var latest = dc.NegotiationList
                .GetBy("PriceQuotationRequestId = @id AND IsDelete = 0", new { id = quotationId })
                .OrderByDescending(n => n.RoundNumber ?? 0)
                .FirstOrDefault();

            if (latest != null) return latest.NewAmount;

            return dc.PriceQuotationRequestList.Find(quotationId)?.Amount;
        }

        /// <summary>True iff no other active round for the same quotation has a higher RoundNumber —
        /// only the latest round may still be edited; anything earlier is read-only history.</summary>
        public static bool IsLatestRound(DataContext dc, int quotationId, int roundId)
        {
            var maxRoundNumber = dc.NegotiationList
                .GetBy("PriceQuotationRequestId = @id AND IsDelete = 0", new { id = quotationId })
                .Select(n => n.RoundNumber ?? 0)
                .DefaultIfEmpty(0)
                .Max();

            var thisRound = dc.NegotiationList.Find(roundId);
            return thisRound == null || (thisRound.RoundNumber ?? 0) >= maxRoundNumber;
        }

        /// <summary>True iff a round already marked IsBAFO exists for this quotation — nothing may be
        /// negotiated further once the vendor's best-and-final offer is on record.</summary>
        public static bool HasBAFO(DataContext dc, int quotationId, int excludeRoundId = 0) =>
            dc.NegotiationList
                .GetBy("PriceQuotationRequestId = @id AND IsDelete = 0 AND IsBAFO = 1", new { id = quotationId })
                .Any(n => n.Id != excludeRoundId);
    }
}
