namespace Etmam
{
    public class AccessViewModel
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool PermsStatus { get; set; }
    }
}
