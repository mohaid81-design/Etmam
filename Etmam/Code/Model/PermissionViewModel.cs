namespace Etmam
{
    public class PermissionViewModel
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool PermsStatus { get; set; }
    }
}
