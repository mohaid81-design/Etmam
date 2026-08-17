namespace Core.Tables
{
    /// <summary>
    /// Lightweight wrapper used to populate the project drop-down in the main form's status bar.
    /// Overrides ToString() so DevExpress ComboBox shows the project name correctly.
    /// </summary>
    public class ProjectComboItem
    {
        public int? Id { get; }
        public string DisplayName { get; }

        public ProjectComboItem(int? id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        public override string ToString() => DisplayName;
    }
}
