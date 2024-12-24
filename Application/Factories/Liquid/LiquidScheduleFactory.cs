using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Liquid
{
    public class LiquidScheduleFactory : IScheduleFactory
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.LIQUID;
        }

        public BaseSchedule CreateSchedule(CreateScheduleCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
