namespace Application.Dtos
{
    public sealed class ItemCategoryDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public int? LvlId { get; set; }
        public int? SortId { get; set; }
        public bool IsFixed { get; set; }
    }

    public class ItemCategorySaveRequest
    {
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public int? SortId { get; set; }
    }

    public sealed class ItemCategoryCreateRequest : ItemCategorySaveRequest
    {
    }

    public sealed class ItemCategoryUpdateRequest : ItemCategorySaveRequest
    {
    }
}
