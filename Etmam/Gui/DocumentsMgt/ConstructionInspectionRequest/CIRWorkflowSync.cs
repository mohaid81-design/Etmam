using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace Etmam
{
    /// <summary>
    /// Bridges Construction Inspection Requests (CIR) to the generic workflow engine
    /// (Data/WorkflowEngine.cs) — mirrors PurchaseRequestWorkflowSync's own bridging role, scaled down
    /// to CIR's single need: a مدير المشروع (Project Manager) approval gate that frmCIRAddEdit.btnApproved
    /// starts/acts on, and that frmCIRAddEdit.BtnSend_ItemClick checks before emailing the CIR to the
    /// consultant. Like Purchase Requests, CIR procedures can be scoped by project
    /// (WorkflowDefinitionList.ProjectId) and/or discipline (WorkflowDefinitionDisciplineList).
    /// </summary>
    public static class CIRWorkflowSync
    {
        public const string EntityName = "ConstructionInspectionRequestList";

        /// <summary>Active, non-deleted procedures usable for this CIR — matched by Category =
        /// EntityName, narrowed by the CIR's own project against each candidate's ProjectId (null =
        /// every project) and WorkflowDefinitionDisciplineList rows (none = "عام", every discipline —
        /// same convention as PurchaseRequestWorkflowSync.GetAvailableProcedures). The caller
        /// (frmCIRAddEdit.BtnApproved_ItemClick) uses this to decide whether to prompt: one result
        /// starts directly, more than one shows frmWorkflowDefinitionSelect.</summary>
        public static List<WorkflowDefinitionList> GetAvailableProcedures(DataContext dc, ConstructionInspectionRequestList cir)
        {
            var candidates = dc.WorkflowDefinitionList
                .GetBy("IsDelete = 0 AND IsActive = 1 AND Category = @cat", new { cat = EntityName })
                .Where(d => d.ProjectId == null || d.ProjectId == cir.PrjId)
                .ToList();

            if (candidates.Count == 0) return candidates;

            var defIds = candidates.Select(d => d.Id).ToList();
            var disciplinesByDef = dc.WorkflowDefinitionDisciplineList
                .GetBy($"WorkflowDefinitionId IN ({string.Join(",", defIds)})")
                .GroupBy(l => l.WorkflowDefinitionId)
                .ToDictionary(g => g.Key, g => g.Select(l => l.DisciplineId).ToHashSet());

            return candidates.Where(d =>
                !disciplinesByDef.TryGetValue(d.Id, out var set) || set.Count == 0   // "عام"
                || (cir.DisciplineId.HasValue && set.Contains(cir.DisciplineId.Value))
            ).ToList();
        }

        /// <summary>Starts the given procedure for this CIR (the caller has already resolved which one
        /// — see GetAvailableProcedures). Throws (with an Arabic message safe to show directly to the
        /// user) if this CIR already has an active instance.</summary>
        public static void SendForApproval(DataContext dc, ConstructionInspectionRequestList cir, int workflowDefinitionId)
        {
            if (GetActiveInstance(dc, cir.Id) != null)
                throw new InvalidOperationException("يوجد بالفعل إجراء اعتماد جارٍ لهذا الطلب.");

            WorkflowEngine.StartWorkflow(workflowDefinitionId, EntityName, cir.Id, Session.CurrentUser?.Id ?? 1);
        }

        /// <summary>The CIR's currently running (InProgress) workflow instance, if any.</summary>
        public static WorkflowInstanceList? GetActiveInstance(DataContext dc, int cirId) =>
            dc.WorkflowInstanceList
              .GetBy("EntityName = @n AND EntityRecordId = @id AND Status = 'InProgress'",
                     new { n = EntityName, id = cirId })
              .FirstOrDefault();

        /// <summary>The CIR's most recent workflow instance regardless of status — used to tell whether
        /// مدير المشروع has ever completed approval (Approved), independently of whether one happens to
        /// be InProgress right now (e.g. a إعادة إصدار/Reissue starts a fresh instance on the new
        /// revision, which must be approved again before it can be sent).</summary>
        public static WorkflowInstanceList? GetLatestInstance(DataContext dc, int cirId) =>
            dc.WorkflowInstanceList
              .GetBy("EntityName = @n AND EntityRecordId = @id", new { n = EntityName, id = cirId })
              .OrderByDescending(i => i.Id)
              .FirstOrDefault();

        /// <summary>True once مدير المشروع has approved this CIR's own (latest) workflow instance — the
        /// gate frmCIRAddEdit.BtnSend_ItemClick checks before emailing it to the consultant.</summary>
        public static bool IsApproved(DataContext dc, int cirId) =>
            GetLatestInstance(dc, cirId)?.Status == "Approved";

        /// <summary>Display name of the step a running instance is currently sitting at.</summary>
        public static string? GetCurrentStepName(DataContext dc, WorkflowInstanceList instance) =>
            dc.WorkflowStepList
              .GetBy("WorkflowDefinitionId = @id AND StepOrder = @order",
                     new { id = instance.WorkflowDefinitionId, order = instance.CurrentStepOrder })
              .FirstOrDefault()?.Name;
    }
}
