namespace Core
{
    public static class Session
    {
        public static UsersList CurrentUser { get; set; } = new UsersList { Id = 1, UserName = "Admin", Role = "Admin", FullName = "مدير النظام", IsActive = true };
        public static string Machine { get; set; } = System.Environment.MachineName;

        // ── Project Selection ─────────────────────────────────────────────────

        private static int? _selectedProjectId;
        private static string? _selectedProjectName;

        public static int? SelectedProjectId
        {
            get => _selectedProjectId;
            set
            {
                if (_selectedProjectId == value) return;
                _selectedProjectId = value;
                ProjectChanged?.Invoke(value);
            }
        }

        public static string? SelectedProjectName
        {
            get => _selectedProjectName;
            set => _selectedProjectName = value;
        }

        /// <summary>
        /// Raised whenever the user changes the active project.
        /// All open modules should subscribe and reload their data.
        /// Parameter: the new project ID (null = no project selected).
        /// </summary>
        public static event Action<int?>? ProjectChanged;

        /// <summary>
        /// True when the current user's project access is limited to exactly one project.
        /// Set once at login/project-list load. When true, project-scoped list screens
        /// should skip PrjId filtering and load all elements by default.
        /// </summary>
        public static bool IsSingleProjectUser { get; set; }
    }
}
