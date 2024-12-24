using Application.Commands.Schedule;
using Domain.Entities.Schedule;

namespace Application.Factories
{
    public interface ISpecializedScheduleFactory
    {
        bool CanHandle(CreateScheduleCommand command);
        BaseSchedule CreateSpecializedSchedule(BaseSchedule baseSchedule, CreateScheduleCommand command);
    }

}
