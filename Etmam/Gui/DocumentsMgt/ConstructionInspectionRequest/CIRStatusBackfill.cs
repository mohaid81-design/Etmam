using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    public class CIRStatusBackfillResult
    {
        public int Updated { get; set; }
        public int AlreadyCorrect { get; set; }
    }

    /// <summary>One-time data fix for CIR records saved before CIRStatus.MapReviewToOverallStatus
    /// existed, when a consultant reply of "مرفوض"/"يتطلب تعديل وإعادة تقديم" was collapsed back onto
    /// OverallStatus = Submitted instead of a status reflecting that reply. Only rows still sitting at
    /// Submitted are touched — Draft/Reissued/Closed rows already reflect a deliberate state unrelated
    /// to this bug and must not be recomputed from CSTReviewStatus.</summary>
    public static class CIRStatusBackfill
    {
        public static CIRStatusBackfillResult Run(DataContext dc)
        {
            var result = new CIRStatusBackfillResult();

            var records = dc.ConstructionInspectionRequestList
                .GetBy("IsDelete = 0 AND OverallStatus = @s", new { s = CIRStatus.Submitted })
                .ToList();

            foreach (var rec in records)
            {
                int correctStatus = CIRStatus.MapReviewToOverallStatus(rec.CSTReviewStatus);
                if (correctStatus == rec.OverallStatus)
                {
                    result.AlreadyCorrect++;
                    continue;
                }

                rec.OverallStatus = correctStatus;
                dc.ConstructionInspectionRequestList.Edit(rec.Id, rec);
                result.Updated++;
            }

            return result;
        }
    }
}
