using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Tracks how much of each Purchase Request line has already been placed on a Purchase Order
    /// (via PurchaseOrderDetails.PRDetailId), so frmPurchaseOrderAddEdit can offer a PR in its lookup —
    /// and let the user raise another PO against it — as long as at least one line still has quantity
    /// that hasn't been ordered yet. A PR with every line fully ordered drops out of the lookup.
    /// </summary>
    public static class PurchaseRequestOrderProgress
    {
        /// <summary>True if at least one line of this PR still has quantity not yet placed on any
        /// (non-deleted) Purchase Order.</summary>
        public static bool HasRemainingItems(DataContext dc, int prId) =>
            GetRemainingDetails(dc, prId).Count > 0;

        /// <summary>
        /// Returns this PR's lines that still have un-ordered quantity. Each returned line's Qty is
        /// overwritten with the *remaining* (not yet ordered) quantity rather than the originally
        /// requested one, so callers (e.g. frmPurchaseOrderAddEdit.ImportFromPR) can use it directly
        /// without double-counting quantity already committed to an earlier Purchase Order.
        /// </summary>
        public static List<PurchaseRequestDetails> GetRemainingDetails(DataContext dc, int prId)
        {
            var prLines = dc.PurchaseRequestDetails.GetBy("PRId = @id AND IsDelete = 0", new { id = prId });
            if (prLines.Count == 0) return new List<PurchaseRequestDetails>();

            var prLineIds = string.Join(",", prLines.Select(l => l.Id));
            var orderedDetails = dc.PurchaseOrderDetails.GetBy($"PRDetailId IN ({prLineIds}) AND IsDelete = 0");

            // بنود أمر الشراء المرفوض تبقى IsDelete=0 (الرفض لا يحذفها — انظر PurchaseOrderWorkflowSync.
            // Reconcile) فتُستبعد من "المطلوب فعلاً": أمر مرفوض لم يُنفَّذ، فكميته يجب أن تبقى متبقية
            // قابلة لإعادة الطلب عبر أمر شراء جديد، لا أن تُحتسب مغطاة به.
            var poIds = orderedDetails.Where(p => p.ParentId is > 0).Select(p => p.ParentId!.Value).Distinct().ToList();
            var rejectedPoIds = poIds.Count > 0
                ? dc.PurchaseOrderList
                    .GetBy($"Id IN ({string.Join(",", poIds)}) AND OverallStatus = @status", new { status = PurchaseOrderStatus.Rejected })
                    .Select(po => po.Id).ToHashSet()
                : new HashSet<int>();

            var orderedByPrDetailId = orderedDetails
                .Where(p => !(p.ParentId is > 0 && rejectedPoIds.Contains(p.ParentId.Value)))
                .GroupBy(p => p.PRDetailId ?? 0)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.Qty ?? 0));

            var result = new List<PurchaseRequestDetails>();
            foreach (var line in prLines)
            {
                var ordered = orderedByPrDetailId.GetValueOrDefault(line.Id);
                var remaining = (line.Qty ?? 0) - ordered;
                if (remaining <= 0) continue;

                line.Qty = remaining;
                result.Add(line);
            }
            return result;
        }

        /// <summary>Purely-derived "حالة أمر الشراء" display text — deliberately NOT written back onto
        /// PurchaseRequestList.OverallStatus (that column stays the approval workflow's alone: Draft/
        /// PendingApproval/Approved/Rejected/Closed — see PurchaseRequestStatus). This is a second,
        /// independent dimension shown in its own grid column (ucPurchaseRequests.colPurchaseOrderStatus)
        /// so the approval state and the fulfillment state never collide in the same column/value again.
        /// Based purely on whether any Purchase Order actually exists for this PR's lines — not on the
        /// PR's current approval status — so a newly-created PR reads "لم يبدأ" immediately, and a PR that
        /// was later Closed/Rejected after already being partially/fully ordered keeps showing that history
        /// instead of going blank. While a linked PO is itself mid-approval (PendingApproval), names that
        /// PO's current workflow step (e.g. "تحت إجراء اعتماد مدير المشتريات") instead of the generic
        /// partial/full text — same "step name beats generic status" idea as
        /// PurchaseOrderWorkflowSync.GetStatusDisplay.</summary>
        public static string GetPurchaseOrderStatusDisplay(DataContext dc, PurchaseRequestList pr)
        {
            var linkedPOs = dc.PurchaseOrderList.GetBy("PRId = @id AND IsDelete = 0", new { id = pr.Id });
            var pendingPO = linkedPOs.FirstOrDefault(po => po.OverallStatus == PurchaseOrderStatus.PendingApproval);
            if (pendingPO != null)
            {
                var instance = PurchaseOrderWorkflowSync.GetActiveInstance(dc, pendingPO.Id);
                var stepName = instance != null ? PurchaseOrderWorkflowSync.GetCurrentStepName(dc, instance) : null;
                if (!string.IsNullOrWhiteSpace(stepName))
                    return $"تحت إجراء {stepName}";
            }

            var prLines = dc.PurchaseRequestDetails.GetBy("PRId = @id AND IsDelete = 0", new { id = pr.Id });
            if (prLines.Count == 0) return "لم يبدأ";

            // أوامر الشراء المرفوضة تبقى بنودها IsDelete=0 (الرفض لا يحذفها) فتُستبعد صراحةً من الكمية
            // "المصدرة" أدناه، وإلا ظهر الطلب خطأً كمُصدَر جزئياً/كلياً بسبب أمر مرفوض لا قيمة فعلية له.
            var rejectedPoIds = linkedPOs.Where(po => po.OverallStatus == PurchaseOrderStatus.Rejected)
                .Select(po => po.Id).ToHashSet();

            var prLineIds = string.Join(",", prLines.Select(l => l.Id));
            var totalOrdered = dc.PurchaseOrderDetails
                .GetBy($"PRDetailId IN ({prLineIds}) AND IsDelete = 0")
                .Where(p => !(p.ParentId is > 0 && rejectedPoIds.Contains(p.ParentId.Value)))
                .Sum(p => p.Qty ?? 0);

            if (totalOrdered <= 0)
            {
                // لا يوجد أمر شراء صالح (غير مرفوض) بعد — إن كانت كل أوامر هذا الطلب مرفوضة، نعرض ذلك
                // صراحةً بدل "لم يبدأ" العامة كي لا يبدو الطلب وكأنه لم يُحاوَل تنفيذه إطلاقاً.
                if (linkedPOs.Count > 0 && rejectedPoIds.Count == linkedPOs.Count)
                    return "أمر الشراء: مرفوض ✗";
                return "لم يبدأ";
            }

            return HasRemainingItems(dc, pr.Id)
                ? "تم إصدار أمر شراء جزئي"
                : "تم إصدار أمر شراء كلي ✓";
        }

        /// <summary>
        /// Grid-load version of GetPurchaseOrderStatusDisplay(): the per-row version issues up to 5
        /// separate queries per PR (linked POs, the pending PO's workflow instance/step, PR lines,
        /// ordered quantities), so a list of N PRs costs up to 5*N round trips. This computes the same
        /// display text for every PR in the batch against a handful of IN(...) queries fetched once (see
        /// ucPurchaseRequests.LoadData). Returns each PR's display text, keyed by Id.
        /// </summary>
        public static Dictionary<int, string> GetPurchaseOrderStatusDisplayBulk(DataContext dc, List<PurchaseRequestList> prs)
        {
            var result = new Dictionary<int, string>();
            if (prs.Count == 0) return result;

            var prIds = prs.Select(p => p.Id).ToList();
            var prIdsCsv = string.Join(",", prIds);

            var allPOs = dc.PurchaseOrderList.GetBy($"PRId IN ({prIdsCsv}) AND IsDelete = 0");
            var posByPrId = allPOs.Where(po => po.PRId.HasValue)
                .GroupBy(po => po.PRId!.Value)
                .ToDictionary(g => g.Key, g => g.ToList());

            // أوامر الشراء المرفوضة تبقى بنودها IsDelete=0 فتُستبعد من الكمية "المصدرة" أدناه — نفس منطق
            // GetPurchaseOrderStatusDisplay (النسخة غير المُجمَّعة) أعلاه.
            var rejectedPoIds = allPOs.Where(po => po.OverallStatus == PurchaseOrderStatus.Rejected)
                .Select(po => po.Id).ToHashSet();

            var pendingPoIds = allPOs.Where(po => po.OverallStatus == PurchaseOrderStatus.PendingApproval)
                .Select(po => po.Id).ToList();

            var activeInstanceByPoId = new Dictionary<int, WorkflowInstanceList>();
            var stepNameByDefAndOrder = new Dictionary<(int, int), string>();
            if (pendingPoIds.Count > 0)
            {
                var poIdsCsv = string.Join(",", pendingPoIds);
                var instances = dc.WorkflowInstanceList
                    .GetBy($"EntityName = @n AND EntityRecordId IN ({poIdsCsv}) AND Status = 'InProgress'",
                           new { n = "PurchaseOrderList" });
                activeInstanceByPoId = instances.GroupBy(i => i.EntityRecordId).ToDictionary(g => g.Key, g => g.First());

                var defIds = instances.Select(i => i.WorkflowDefinitionId).Distinct().ToList();
                if (defIds.Count > 0)
                {
                    stepNameByDefAndOrder = dc.WorkflowStepList
                        .GetBy($"WorkflowDefinitionId IN ({string.Join(",", defIds)})")
                        .ToDictionary(s => (s.WorkflowDefinitionId, s.StepOrder), s => s.Name ?? "");
                }
            }

            var prLines = dc.PurchaseRequestDetails.GetBy($"PRId IN ({prIdsCsv}) AND IsDelete = 0");
            var linesByPrId = prLines.Where(l => l.PRId.HasValue)
                .GroupBy(l => l.PRId!.Value)
                .ToDictionary(g => g.Key, g => g.ToList());

            var lineIds = prLines.Select(l => l.Id).ToList();
            var orderedByPrDetailId = new Dictionary<int, decimal>();
            if (lineIds.Count > 0)
            {
                var lineIdsCsv = string.Join(",", lineIds);
                orderedByPrDetailId = dc.PurchaseOrderDetails
                    .GetBy($"PRDetailId IN ({lineIdsCsv}) AND IsDelete = 0")
                    .Where(p => !(p.ParentId is > 0 && rejectedPoIds.Contains(p.ParentId.Value)))
                    .GroupBy(p => p.PRDetailId ?? 0)
                    .ToDictionary(g => g.Key, g => g.Sum(p => p.Qty ?? 0));
            }

            foreach (var pr in prs)
            {
                var linkedPOs = posByPrId.GetValueOrDefault(pr.Id) ?? new List<PurchaseOrderList>();
                var pendingPO = linkedPOs.FirstOrDefault(po => po.OverallStatus == PurchaseOrderStatus.PendingApproval);
                if (pendingPO != null && activeInstanceByPoId.TryGetValue(pendingPO.Id, out var instance))
                {
                    var stepName = stepNameByDefAndOrder.GetValueOrDefault((instance.WorkflowDefinitionId, instance.CurrentStepOrder));
                    if (!string.IsNullOrWhiteSpace(stepName))
                    {
                        result[pr.Id] = $"تحت إجراء {stepName}";
                        continue;
                    }
                }

                var lines = linesByPrId.GetValueOrDefault(pr.Id) ?? new List<PurchaseRequestDetails>();
                if (lines.Count == 0) { result[pr.Id] = "لم يبدأ"; continue; }

                var totalOrdered = lines.Sum(l => orderedByPrDetailId.GetValueOrDefault(l.Id));
                if (totalOrdered <= 0)
                {
                    result[pr.Id] = linkedPOs.Count > 0 && linkedPOs.All(po => rejectedPoIds.Contains(po.Id))
                        ? "أمر الشراء: مرفوض ✗"
                        : "لم يبدأ";
                    continue;
                }

                var hasRemaining = lines.Any(l => (l.Qty ?? 0) - orderedByPrDetailId.GetValueOrDefault(l.Id) > 0);
                result[pr.Id] = hasRemaining ? "تم إصدار أمر شراء جزئي" : "تم إصدار أمر شراء كلي ✓";
            }

            return result;
        }
    }
}
