namespace Application.Dtos
{
    // Simple single-table lookup masters under Etmam/Gui/General/Masters/* - grouped in one file
    // since each is a handful of fields with no logic beyond CRUD + a "used elsewhere" delete guard
    // (see Application/Services/DisciplinesService.cs etc.). Read DTOs deliberately mirror their
    // Core entity's property names exactly (Id/Name/Code/IsActive/<parent>Id), same reasoning as
    // ProjectDto - the WinForms client's ApiClient methods deserialize straight into the Core.Tables
    // entity type (e.g. List<DisciplinesList>), reusing existing grid bindings instead of a parallel
    // client-side POCO per entity.

    public sealed class DisciplineDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public class DisciplineSaveRequest
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class DisciplineCreateRequest : DisciplineSaveRequest { }
    public sealed class DisciplineUpdateRequest : DisciplineSaveRequest { }

    public sealed class BuildingDto
    {
        public int Id { get; set; }
        public int? PrjId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }

    public class BuildingSaveRequest
    {
        public int? PrjId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class BuildingCreateRequest : BuildingSaveRequest { }
    public sealed class BuildingUpdateRequest : BuildingSaveRequest { }

    public sealed class FloorDto
    {
        public int Id { get; set; }
        public int? BuildingId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }

    public class FloorSaveRequest
    {
        public int? BuildingId { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class FloorCreateRequest : FloorSaveRequest { }
    public sealed class FloorUpdateRequest : FloorSaveRequest { }

    public sealed class SecondaryDisciplineDto
    {
        public int Id { get; set; }
        public int? DisciplineId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SecondaryDisciplineSaveRequest
    {
        public int? DisciplineId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class SecondaryDisciplineCreateRequest : SecondaryDisciplineSaveRequest { }
    public sealed class SecondaryDisciplineUpdateRequest : SecondaryDisciplineSaveRequest { }

    public sealed class InspectionActivityDto
    {
        public int Id { get; set; }
        public int? SecondaryDisciplineId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public class InspectionActivitySaveRequest
    {
        public int? SecondaryDisciplineId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }

    public sealed class InspectionActivityCreateRequest : InspectionActivitySaveRequest { }
    public sealed class InspectionActivityUpdateRequest : InspectionActivitySaveRequest { }
}
