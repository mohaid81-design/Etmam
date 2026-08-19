using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Shared "Approve" logic for BOQList, used by both ucBOQEditor (acting on the currently loaded
    /// BOQ) and ucBOQList (acting on the focused grid row) so the permission check, status flip, and
    /// audit log aren't duplicated in two places.
    /// </summary>
    public static class BOQWorkflow
    {
        /// <summary>Locks and approves the given BOQ. Caller is responsible for confirming with the
        /// user and validating the item data beforehand.</summary>
        public static void Approve(DataContext dc, int boqId)
        {
            DataContext.RunInTransaction(tx =>
            {
                var existing = dc.BOQList.Find(boqId);
                if (existing == null) return;

                var updated = new BOQList
                {
                    Id = existing.Id,
                    PrjId = existing.PrjId,
                    BOQCode = existing.BOQCode,
                    BOQName = existing.BOQName,
                    Revision = existing.Revision,
                    Discipline = existing.Discipline,
                    ContractId = existing.ContractId,
                    Status = BOQStatus.Approved,
                    TotalAmount = existing.TotalAmount,
                    CreatedDate = existing.CreatedDate,
                    CreatedMachine = existing.CreatedMachine,
                    CreatedBy = existing.CreatedBy,
                    UpdateDate = DateTime.Now,
                    UpdateMachine = Session.Machine,
                    UpdateBy = Session.CurrentUser?.Id ?? 1,
                    IsDelete = existing.IsDelete,
                    RowVersion = existing.RowVersion, // expected version — see SqlDataHelper<T>.EditAsync
                };

                dc.BOQList.Edit(boqId, updated, tx);
                AuditService.LogUpdate(tx, "BOQList", boqId, existing, updated);
            });
        }
    }
}
