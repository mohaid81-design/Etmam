namespace Etmam
{
    public class LocalUser
    {
        public static int? Id { get; set; }
        public static string? UserName { get; set; }
        public static string? FullName { get; set; }
        public static string? JobTitle { get; set; }
        public static string? Company { get; set; }
        public static string? CompanyName { get => Company; set => Company = value; }
        public static string? Role { get; set; }
        public static string? Machine { get; set; }
        public static int? SelectedProjectId { get; set; } = 1;
        
        // Legacy or additional IDs if needed by other modules
        public static int? CoId { get; set; }
        public static string? CoName { get; set; }

        public static void Clear()
        {
            Id = null;
            UserName = null;
            FullName = null;
            JobTitle = null;
            Company = null;
            Role = null;
            Machine = null;
            CoId = null;
            CoName = null;
        }
    }
}
