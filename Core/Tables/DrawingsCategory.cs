using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class DrawingsCategory : IBaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Abb { get; set; }

        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
    }
}
