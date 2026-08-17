using System;

namespace Core
{
    public interface IDailyReportEntity : IBaseEntity
    {
        int? DailyReportId { get; set; }
    }
}
