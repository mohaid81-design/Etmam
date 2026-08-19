using System.Collections.Generic;

namespace Data
{
    /// <summary>Lets each module that plugs into WorkflowEngine (Purchase Request, Purchase Order, any
    /// future procedure) register how to describe its own records — a display number and a one-line
    /// subject — for use in WorkflowEngine's WhatsApp notification messages. Keeps WorkflowEngine itself
    /// entity-agnostic (see [[workflow-engine-feature]]) instead of hardcoding per-module table lookups
    /// inside the generic engine. Registered once at app startup — see Etmam.Program.Main.</summary>
    public static class WorkflowEntityDescriptors
    {
        public delegate (string Number, string Subject) Describer(DataContext dc, int entityRecordId);

        /// <summary>Extra, entity-specific side effect to run once a workflow instance finishes fully
        /// Approved (no further step) — e.g. Purchase Request's registration below pings every user
        /// holding PermNames.PurchaseOrder via WhatsApp. Optional per entity; most entities register
        /// only a Describer and no callback here.</summary>
        public delegate void ApprovedCallback(DataContext dc, int entityRecordId);

        private static readonly Dictionary<string, Describer> _registry = new();
        private static readonly Dictionary<string, ApprovedCallback> _approvedRegistry = new();

        public static void Register(string entityName, Describer describer) => _registry[entityName] = describer;

        public static void RegisterOnFullyApproved(string entityName, ApprovedCallback callback) => _approvedRegistry[entityName] = callback;

        /// <summary>Falls back to the raw record id with no subject if nothing is registered for
        /// entityName, or if the registered describer throws (e.g. record no longer exists) — a
        /// notification is never worth failing the workflow transition that triggered it over.</summary>
        public static (string Number, string Subject) Describe(DataContext dc, string entityName, int entityRecordId)
        {
            if (_registry.TryGetValue(entityName, out var describer))
            {
                try { return describer(dc, entityRecordId); }
                catch { /* fall through to generic */ }
            }

            return (entityRecordId.ToString(), "");
        }

        /// <summary>Invoked by WorkflowEngine.SendTransitionNotifications the moment an instance finishes
        /// fully Approved. No-op if entityName has no callback registered; swallows any exception the
        /// callback throws for the same reason Describe does above — a notification hook must never fail
        /// the (already-persisted) workflow transition that triggered it.</summary>
        public static void NotifyFullyApproved(DataContext dc, string entityName, int entityRecordId)
        {
            if (_approvedRegistry.TryGetValue(entityName, out var callback))
            {
                try { callback(dc, entityRecordId); }
                catch { /* never fail the transition over a notification hook */ }
            }
        }
    }
}
