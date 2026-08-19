namespace Core
{
    /// <summary>
    /// One physical drawing sheet included in a drawing approval request (DrawingsRegisterList),
    /// with its own independent consultant review decision.
    /// </summary>
    public class DrawingsRegisterDetails
    {
        public int? Id { get; set; }

        /// <summary>FK → DrawingsRegisterList.Id</summary>
        public int? ParentId { get; set; }

        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? DrawingNumber { get; set; }
        public int? Revision { get; set; }
        public string? Description { get; set; }
        public string? ConsultantDecision { get; set; }
        public bool? ReSubmittedRejectedItems { get; set; }
        public bool? SigningCompleted { get; set; }
        public string? ConsultantNotes { get; set; }
    }
}
