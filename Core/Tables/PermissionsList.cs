using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class PermissionsList
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentID { get; set; }
        public int? SortID { get; set; }

    }
}
