using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// One negotiation round against a single vendor's quotation (see the methodology doc's Negotiation
    /// section: "Original / Round 01 / Round 02 / ... / BAFO", each round independent and never edited
    /// once superseded). RoundNumber 0 is the implicit baseline (the quotation as originally submitted,
    /// before any negotiation) — the first real row created here is always RoundNumber 1. Once a later
    /// round exists for the same quotation, an earlier round becomes read-only (see
    /// NegotiationService.IsLatestRound) rather than being edited in place; a new round is always a new
    /// row. IsBAFO marks the round as the vendor's Best And Final Offer — once set for a quotation, no
    /// further round can be added against it.
    /// </summary>
    public class NegotiationList : IBaseEntity
    {
        [Key] public int Id { get; set; }

        // Convenience/traceability back to the RFQ envelope — not itself load-bearing.
        public int? RFQId { get; set; }

        [ForeignKey(nameof(PriceQuotationRequest))]
        public int? PriceQuotationRequestId { get; set; }
        public PriceQuotationRequestList? PriceQuotationRequest { get; set; }

        // 1, 2, 3, ... — concurrency-safe via NumberingService (see NegotiationService), never MAX+1.
        public int? RoundNumber { get; set; }

        public DateTime? NegotiationDate { get; set; }

        // Snapshot of what came before this round (the prior round's NewAmount, or the quotation's own
        // original Amount for round 1) — captured at creation time so this round's own record never
        // depends on a later row for its own history to make sense.
        public decimal? PreviousAmount { get; set; }
        public decimal? NewAmount { get; set; }

        public bool IsBAFO { get; set; }
        public string? Notes { get; set; }

        [NotMapped] public string? RoundLabel { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }

        // Optimistic-concurrency token (SQL Server ROWVERSION) — see SqlDataHelper<T> and
        // DatabaseInitializer.GetSqlType.
        public byte[]? RowVersion { get; set; }
    }
}
