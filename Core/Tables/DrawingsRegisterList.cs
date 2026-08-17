using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DrawingsRegisterList : IBaseEntity
    {
        public int Id { get; set; }
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
        public int? Num { get; set; }
        public int? Rev { get; set; }
        public DateTime? PreparedDate { get; set; }
        public int? Type { get; set; }
        public string? Category { get; set; }
        public int? SubCategory { get; set; }
        public string? Description { get; set; }
        public int? Building { get; set; }
        public string? Floor { get; set; }
        public string? DocName { get; set; }
        public int? DrawingIssuer { get; set; }
        public int? PrjId { get; set; }
        public int? OverallStatus { get; set; }
        public string? SubmittedDate { get; set; }
        public string? CSTReturnedDate { get; set; }
        public string? CSTReviewComment { get; set; }
        public string? CSTReviewStatus { get; set; }
    }
}
