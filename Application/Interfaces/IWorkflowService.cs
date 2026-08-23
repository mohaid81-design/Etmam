using Core;

namespace Application.Interfaces
{
    /// <summary>
    /// Web-side port of Data/WorkflowEngine.cs - starts an instance of a WorkflowDefinitionList
    /// against any business record, and advances it step by step as assigned users approve or
    /// reject, writing to the SAME WorkflowInstanceList/WorkflowInstanceStepList/... tables the
    /// desktop client's engine uses. An instance started from the desktop can be approved from the
    /// web and vice versa - both sides converge on the same rows, no sync needed.
    ///
    /// WhatsApp transition notifications ARE ported (see WorkflowService.SendTransitionNotificationsAsync,
    /// wired into ActAsync via IWhatsAppNotifier) - the only documented gap is one extra hook
    /// (WorkflowEntityDescriptors.NotifyFullyApproved's PurchaseRequestList "fully approved -> notify
    /// who can raise a PO"), not notifications in general.
    /// </summary>
    public interface IWorkflowService
    {
        /// <summary>Snapshots the procedure's current steps/assignees into
        /// WorkflowInstanceStepList/WorkflowInstanceStepAssigneeList and starts the instance at its
        /// first step - so an admin editing the procedure later never retroactively changes how an
        /// already-running approval behaves.</summary>
        Task<int> StartWorkflowAsync(int workflowDefinitionId, string entityName, int entityRecordId, int startedByUserId, CancellationToken ct = default);

        Task<bool> CanUserActAsync(int instanceId, int userId, CancellationToken ct = default);

        /// <summary>Approves or rejects the instance's current step. action must be "Approved" or
        /// "Rejected". Advances to the next step (or completes the instance) on Approved; ends the
        /// instance immediately on Rejected.</summary>
        Task ActAsync(int instanceId, int userId, string action, string? comment, CancellationToken ct = default);

        /// <summary>Sends the instance back to an earlier (or current) step - see
        /// WorkflowEngine.ReturnToStep's two scenarios (mid-flight vs. reopening a finished
        /// Approved instance).</summary>
        Task ReturnToStepAsync(int instanceId, int userId, int targetStepOrder, string comment, bool requireCurrentStepAssignee, CancellationToken ct = default);

        Task<WorkflowInstanceList?> GetActiveInstanceAsync(string entityName, int entityRecordId, CancellationToken ct = default);

        /// <summary>Most recent instance regardless of status - unlike GetActiveInstanceAsync, also
        /// finds a finished (Approved/Rejected) instance.</summary>
        Task<WorkflowInstanceList?> GetLatestInstanceAsync(string entityName, int entityRecordId, CancellationToken ct = default);

        Task<string?> GetCurrentStepNameAsync(WorkflowInstanceList instance, CancellationToken ct = default);

        /// <summary>Every InProgress instance whose CURRENT step this user may act on - snapshot-first
        /// per instance, live-fallback for any instance with no snapshot rows (started before
        /// snapshotting existed). Batched rather than per-instance queries, matching
        /// Data/WorkflowEngine.GetPendingForUser's approach.</summary>
        Task<List<WorkflowInstanceList>> GetPendingForUserAsync(int userId, CancellationToken ct = default);
    }
}
