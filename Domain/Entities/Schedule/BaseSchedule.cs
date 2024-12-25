using Domain.Entities.Base;
using Domain.Entities.Window.Time;

namespace Domain.Entities.Schedule
{
    public abstract class BaseSchedule<TWindowTime> 
        : BaseEntity where TWindowTime : WindowTime
    {
        public string InvoiceKey { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public TWindowTime ScheduleWindowTime { get; set; } = null!;
    }
}
