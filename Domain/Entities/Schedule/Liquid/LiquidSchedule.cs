using Domain.Entities.Window.Time;

namespace Domain.Entities.Schedule.Liquid
{
    public class LiquidSchedule<TWindowTime> : BaseSchedule<TWindowTime> where TWindowTime : WindowTime
    {
    }
}
