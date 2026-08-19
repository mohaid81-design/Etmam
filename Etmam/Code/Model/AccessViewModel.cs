namespace Etmam
{
    public class AccessViewModel
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool PermsStatus { get; set; }

        // Store-tab-only granular action flags (see UserStoreAccess) — unused/always-false for the
        // permissions/projects/workflows tabs that share this same view-model class.
        public bool CanReceive { get; set; }
        public bool CanIssue { get; set; }
        public bool CanTransfer { get; set; }
    }
}
