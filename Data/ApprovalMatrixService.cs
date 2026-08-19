using Core;

namespace Data
{
    /// <summary>
    /// Resolves which WorkflowDefinition should run the approval for a document, from configured
    /// ApprovalMatrixList + ApprovalLimitList rows (EntityName, Project, Amount, EffectiveDate) instead
    /// of a hard-coded procedure name or a manual admin picker — see the methodology doc's Approval
    /// Matrix section. Returns null when nothing is configured (or nothing matches), so every caller
    /// falls back to its own pre-existing procedure-selection behavior — this is purely additive and
    /// changes nothing until an admin actually sets up a matrix.
    /// </summary>
    public static class ApprovalMatrixService
    {
        public static int? ResolveWorkflowDefinitionId(DataContext dc, string entityName, int? projectId, decimal amount, DateTime asOfDate)
        {
            // A project-specific matrix (ProjectId set and matching) takes precedence over a general
            // one (ProjectId null, applies to every project) for the same EntityName.
            var matrices = dc.ApprovalMatrixList
                .GetBy("EntityName = @n AND IsActive = 1 AND IsDelete = 0", new { n = entityName })
                .Where(m => m.ProjectId == null || m.ProjectId == projectId)
                .OrderByDescending(m => m.ProjectId.HasValue)
                .ToList();

            foreach (var matrix in matrices)
            {
                var limit = dc.ApprovalLimitList
                    .GetBy("MatrixId = @id AND IsActive = 1 AND IsDelete = 0", new { id = matrix.Id })
                    .Where(l => amount >= (l.MinAmount ?? 0))
                    .Where(l => l.MaxAmount == null || amount < l.MaxAmount.Value)
                    .Where(l => l.EffectiveFrom == null || l.EffectiveFrom.Value <= asOfDate)
                    .Where(l => l.EffectiveTo == null || l.EffectiveTo.Value >= asOfDate)
                    .OrderBy(l => l.MinAmount ?? 0)
                    .FirstOrDefault();

                if (limit?.WorkflowDefinitionId is > 0) return limit.WorkflowDefinitionId;
            }

            return null;
        }
    }
}
