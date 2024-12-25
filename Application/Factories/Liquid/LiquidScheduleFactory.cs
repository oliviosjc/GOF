using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time.Liquid;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Liquid
{
    public class LiquidScheduleFactory : IScheduleFactory<LiquidWindowTime>
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.LIQUID;
        }

        public BaseSchedule<LiquidWindowTime> CreateSchedule(CreateScheduleCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
