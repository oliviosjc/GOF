using Application.Commands.Schedule;
using Domain.Entities.Schedule;

namespace Application.Factories
{
    public interface IScheduleFactory
    {
        bool CanHandle(CreateScheduleCommand command);
        BaseSchedule CreateSchedule(CreateScheduleCommand command);
    }
}
