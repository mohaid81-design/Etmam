using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class UsersList : IBaseEntity
    {
        [Key] public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsFirstLogin { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public byte[]? Signature { get; set; }
    }
}
