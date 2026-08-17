namespace Core
{
    public class DrawingsSubmittalList : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string? DeletionMachine { get; set; }
        public int DeletionBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateMachine { get; set; }
        public int UpdateBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedMachine { get; set; }
        public int? Num { get; set; }
        public int? Rev { get; set; }
        public DateTime? PreparedDate { get; set; }
        public string? Abb { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public string? Purpose { get; set; }
        public string? Description { get; set; }
        public int? PrjId { get; set; }
        public string? Status { get; set; }
        public string? IssuedBy { get; set; }
        public string? ReviewedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public string? CSTDateReceived { get; set; }
        public string? CSTDateReturned { get; set; }
        public string? CSTReviewComment { get; set; }
        public string? CSTReviewStatus { get; set; }
    }
}
