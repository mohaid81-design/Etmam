using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class StakeholdersCategory
    {
       [Key] public int? Id { get; set; }
        public string? MainCategory { get; set; }
        public string? SubCategory { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }


    }
}
