namespace Application.Dtos
{
    /// <summary>Metadata-only read shape — deliberately excludes the file bytes (Core.AttachmentList.FileData)
    /// so list responses stay light. Fetch the bytes via the dedicated download endpoint instead.</summary>
    public sealed class AttachmentDto
    {
        public int Id { get; set; }
        public string EntityName { get; set; } = "";
        public int EntityRecordId { get; set; }
        public string FileName { get; set; } = "";
        public string? FileExtension { get; set; }
        public int FileSizeKB { get; set; }
        public string? Comment { get; set; }
        public DateTime? UploadDate { get; set; }
        public string? UploadedBy { get; set; }
    }

    public sealed class AttachmentUpdateRequest
    {
        public string? Comment { get; set; }
    }
}
