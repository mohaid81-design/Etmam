using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    // Not IBaseEntity: CreatedBy here is (and always has been) a free-text string ("System" from the
    // original seed) backed by an existing NVARCHAR column - changing it to IBaseEntity's `int CreatedBy`
    // would make SqlDataHelper try to Convert.ChangeType("System", typeof(int)) and throw on every
    // existing row. Soft-delete fields are added manually instead, matching everything else's shape.
    public class DrawingsIssuerList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }

        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
    }
}
