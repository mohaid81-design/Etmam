using System;

namespace Core
{
    public class ActionLogs
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty; // Login, Logout
        public string ActionLocation { get; set; } = string.Empty;
        public DateTime? ActionDate { get; set; } = DateTime.Now;
        public string MachineName { get; set; } = Environment.MachineName;
    }
}
