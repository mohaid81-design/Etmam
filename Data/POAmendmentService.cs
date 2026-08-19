using Core;

namespace Data
{
    /// <summary>
    /// Computes the "current effective value" of an approved Purchase Order for a new amendment to
    /// negotiate against, and enforces that an approved amendment (like an approved PO itself) becomes
    /// read-only — see the methodology doc's PO Amendments section.
    /// </summary>
    public static class POAmendmentService
    {
        /// <summary>The PO's value right now — the most recent APPROVED amendment's RevisedValue, or
        /// the PO's own OriginalValue/Amount if it has no approved amendments yet.</summary>
        public static decimal GetCurrentValue(DataContext dc, int poId)
        {
            var latestApproved = dc.POAmendmentList
                .GetBy("POId = @id AND IsDelete = 0 AND Status = @s", new { id = poId, s = POAmendmentStatus.Approved })
                .OrderByDescending(a => a.Id)
                .FirstOrDefault();

            if (latestApproved != null) return latestApproved.RevisedValue ?? 0;

            var po = dc.PurchaseOrderList.Find(poId);
            return po?.OriginalValue ?? po?.Amount ?? 0;
        }

        /// <summary>An amendment is editable only while it hasn't been approved yet — an approved
        /// amendment is locked, exactly like an approved PO.</summary>
        public static bool IsEditable(POAmendmentList amendment) =>
            amendment.Status != POAmendmentStatus.Approved;
    }
}
