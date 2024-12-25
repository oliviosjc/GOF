using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;

namespace Application.Factories
{
    public interface IScheduleFactory<TWindowTime> where TWindowTime : WindowTime
    {
        bool CanHandle(CreateScheduleCommand command);
        BaseSchedule<TWindowTime> CreateSchedule(CreateScheduleCommand command);
    }
}
