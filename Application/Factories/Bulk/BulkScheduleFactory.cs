using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Schedule.Bulk;
using Domain.Entities.Window.Time.Bulk;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Bulk
{
    public class BulkScheduleFactory : IScheduleFactory<BulkWindowTime>
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.BULK;
        }

        public BaseSchedule<BulkWindowTime> CreateSchedule(CreateScheduleCommand command)
        {
            return new BulkSchedule<BulkWindowTime>
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "user",
            };
        }
    }
}