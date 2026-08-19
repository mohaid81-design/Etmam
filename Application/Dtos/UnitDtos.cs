namespace Application.Dtos
{
    public sealed class UnitDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Abbreviation { get; set; }
        public string? Category { get; set; }
    }

    public class UnitSaveRequest
    {
        public string? Description { get; set; }
        public string? Abbreviation { get; set; }
        public string? Category { get; set; }
    }

    public sealed class UnitCreateRequest : UnitSaveRequest
    {
    }

    public sealed class UnitUpdateRequest : UnitSaveRequest
    {
    }
}
