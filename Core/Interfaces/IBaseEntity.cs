using System;

namespace Core
{
    /// <summary>
    /// Base interface for all system entities to ensure consistent audit fields and ID management.
    /// </summary>
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime? CreatedDate { get; set; }
        string? CreatedMachine { get; set; }
        int CreatedBy { get; set; }

        DateTime? UpdateDate { get; set; }
        string? UpdateMachine { get; set; }
        int UpdateBy { get; set; }

        bool IsDelete { get; set; }
        DateTime? DeletionDate { get; set; }
        string? DeletionMachine { get; set; }
        int DeletionBy { get; set; }
    }
}
