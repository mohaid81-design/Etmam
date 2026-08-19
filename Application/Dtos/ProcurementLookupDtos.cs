namespace Application.Dtos
{
    // Read-only lookups needed by the Purchase Request form's dropdowns. No CRUD/management
    // screens for these in this slice - just enough to populate a picker.

    public sealed class CostCenterLookupDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }

    public sealed class BudgetLookupDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public sealed class DisciplineLookupDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class DepartmentLookupDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class StakeholderLookupDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
