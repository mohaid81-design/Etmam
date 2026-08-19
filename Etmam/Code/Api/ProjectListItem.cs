using System.Text.Json.Serialization;

namespace Etmam
{
    /// <summary>
    /// Client-side shape for ucProjectsList.cs's grid — its column FieldNames were fixed by the
    /// existing Designer (ProjectCode/ProjectName/ContractValue/StartDate/LastUpdateDate), which
    /// don't match Application.Dtos.ProjectDto's wire names (Num/Name/ContractAmount/ContractDate/
    /// UpdateDate), so this maps the same GET /api/projects response onto the grid's names via
    /// JsonPropertyName rather than renaming the grid's columns or the API's DTO.
    /// </summary>
    public sealed class ProjectListItem
    {
        public int Id { get; set; }

        [JsonPropertyName("num")]
        public string? ProjectCode { get; set; }

        [JsonPropertyName("name")]
        public string? ProjectName { get; set; }

        public string? ClientName { get; set; }
        public string? ConsultantName { get; set; }

        [JsonPropertyName("contractAmount")]
        public decimal? ContractValue { get; set; }

        [JsonPropertyName("contractDate")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("updateDate")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
