namespace Application.Interfaces
{
    /// <summary>
    /// Web-side port of Data/WorkflowEntityDescriptors.cs's Describer delegate/registry (registered on
    /// desktop via Etmam.Program.RegisterWorkflowEntityDescriptors). Lets WorkflowService's notification
    /// text name a record's own display number and one-line subject without the (entity-agnostic)
    /// engine needing to know about Purchase Requests/Orders/CIR specifically - one implementation per
    /// EntityName, resolved by IWorkflowService via DI instead of a static dictionary.
    /// </summary>
    public interface IWorkflowEntityDescriber
    {
        /// <summary>Matches WorkflowInstanceList.EntityName exactly (e.g. "PurchaseRequestList").</summary>
        string EntityName { get; }

        /// <summary>Falls back to (id.ToString(), "") if the record no longer exists or anything else
        /// goes wrong - see WorkflowEntityDescriptors.Describe's own note: a notification is never
        /// worth failing the workflow transition that triggered it over.</summary>
        Task<(string Number, string Subject)> DescribeAsync(int entityRecordId, CancellationToken ct = default);
    }
}
