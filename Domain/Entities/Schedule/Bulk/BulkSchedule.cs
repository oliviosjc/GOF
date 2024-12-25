using Domain.Entities.Window.Time;

namespace Domain.Entities.Schedule.Bulk
{
    public class BulkSchedule<TWindowTime> : BaseSchedule<TWindowTime> where TWindowTime : WindowTime
    {
    }
}
