using System;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>Creates a new revision of a Construction Inspection Request (same Num/Project/
    /// Discipline, Rev+1, review fields reset to pending) and marks the current row as superseded —
    /// shared by frmCIRAddEdit's btnReIssue toolbar button and ucCIR's per-row colReissue grid
    /// button, so the "new revision" business rule lives in exactly one place.</summary>
    public static class CIRReissuer
    {
        private static DataContext DC => DataContext.Shared;

        /// <summary>Returns the new record's Id, or 0 if the record isn't eligible (not yet saved).</summary>
        public static int Reissue(ConstructionInspectionRequestList record)
        {
            if (record.Id <= 0) return 0;

            int maxRev = DC.ConstructionInspectionRequestList
                .GetBy("IsDelete = 0 AND Num = @num AND PrjId = @PrjId AND DisciplineId = @DisciplineId",
                    new { num = record.Num, PrjId = record.PrjId, DisciplineId = record.DisciplineId })
                .Max(r => r.Rev ?? 0);

            var newRecord = new ConstructionInspectionRequestList
            {
                Num = record.Num,
                RegisterNo = record.RegisterNo,
                Rev = maxRev + 1,
                PreparedDate = DateTime.Today,
                DisciplineId = record.DisciplineId,
                SecondaryDisciplineId = record.SecondaryDisciplineId,
                Description = record.Description,
                BOQRef = record.BOQRef,
                DWGRef = record.DWGRef,
                MSRef = record.MSRef,
                SpecRef = record.SpecRef,
                Location = record.Location,
                RequestedDate = record.RequestedDate,
                RequestedTime = record.RequestedTime,
                PrjId = record.PrjId,
                OverallStatus = CIRStatus.Submitted,
                SubmittedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                CSTReviewStatus = CIRStatus.ReviewPending,
                CSTReviewComment = null,
                CSTReturnedDate = null,
                CreatedBy = Session.CurrentUser?.Id ?? 0,
                CreatedDate = DateTime.Now,
                CreatedMachine = Session.Machine
            };

            int oldId = record.Id;
            int newId = DC.ConstructionInspectionRequestList.Add(newRecord);

            // Mark the old revision as superseded
            record.OverallStatus = CIRStatus.Reissued;
            DC.ConstructionInspectionRequestList.Edit(oldId, record);

            return newId;
        }
    }
}
