using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;

namespace Application.Factories
{
    public interface ISpecializedScheduleFactory<TWindowTime> where TWindowTime : WindowTime
    {
        bool CanHandle(CreateScheduleCommand command);
        BaseSchedule<TWindowTime> CreateSpecializedSchedule(CreateScheduleCommand command);
    }
}
