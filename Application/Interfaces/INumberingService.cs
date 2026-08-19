namespace Application.Interfaces
{
    /// <summary>
    /// Web-side port of Data.NumberingService — a concurrency-safe "next document number"
    /// generator via sp_getapplock, so two users saving at the same instant can never be handed
    /// the same number. Must be called after the caller has opened a transaction via
    /// IApplicationDbContext.BeginTransactionAsync, and before that transaction commits, so the
    /// number reservation and the row that consumes it succeed or fail together.
    /// </summary>
    public interface INumberingService
    {
        /// <param name="entityName">Series name, e.g. "PurchaseRequestList".</param>
        /// <param name="period">Optional period key (e.g. calendar year) for series that reset
        /// periodically; null for a single running sequence.</param>
        /// <param name="computeExistingMaxAsync">Computes the current MAX(Num) actually present in
        /// the target table/period. Compared against the stored counter on every call so a counter
        /// that drifted (records deleted after being numbered, or numbered outside this service)
        /// self-corrects without a separate startup fixup.</param>
        Task<int> GetNextNumberAsync(string entityName, int? period, Func<Task<int>> computeExistingMaxAsync, CancellationToken ct = default);

        /// <summary>Rolls a series' counter back by one, but only if <paramref name="number"/> is
        /// still the most recently issued number for that series — a no-op otherwise. Call when
        /// hard-deleting a record that reserved a number but was never submitted, so the next
        /// GetNextNumberAsync call reissues it instead of leaving a permanent gap. Must run inside
        /// the same transaction as the delete.</summary>
        Task ReleaseIfLastAsync(string entityName, int? period, int number, CancellationToken ct = default);
    }
}
