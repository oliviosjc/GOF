using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Schedule.Bulk;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Bulk
{
    public class BulkScheduleFactory : IScheduleFactory
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.BULK;
        }

        public BaseSchedule CreateSchedule(CreateScheduleCommand command)
        {
            return new BulkSchedule
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "user",
                ExternalTerminalId = 16,
            };
        }
    }
}
