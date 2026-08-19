using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class UserStoreAccess
    {
        [Key] public int Id { get; set; }
        public int UserID { get; set; }
        public int StoreId { get; set; }
        public bool PermsStatus { get; set; }

        // Granular per-action grants (see Etmam.InventoryStorePermissions) — a user may be able to
        // view a store's documents without being allowed to create every transaction type against it.
        public bool CanReceive { get; set; }
        public bool CanIssue { get; set; }
        public bool CanTransfer { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }

        [ForeignKey(nameof(Update))]
        public int UpdateBy { get; set; }
        public UsersList? Update { get; set; }
    }
}
