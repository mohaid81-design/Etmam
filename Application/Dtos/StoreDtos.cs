namespace Application.Dtos
{
    public sealed class StoreDto
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public int? PrjId { get; set; }
        public string? ProjectName { get; set; }
    }

    public class StoreSaveRequest
    {
        public int? Code { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public int? PrjId { get; set; }
    }

    public sealed class StoreCreateRequest : StoreSaveRequest
    {
    }

    public sealed class StoreUpdateRequest : StoreSaveRequest
    {
    }
}
