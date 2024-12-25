using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Schedule.Bulk;
using Domain.Entities.Window.Time.Bulk;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Bulk
{
    public class BulkScheduleExportFactory : ISpecializedScheduleFactory<BulkWindowTimeExport>
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.BULK && command.Operation == ScheduleOperationEnumerator.EXPORT;
        }

        public BaseSchedule<BulkWindowTimeExport> CreateSpecializedSchedule(CreateScheduleCommand command)
        {
            return new BulkScheduleExport
            {
            };
        }
    }
}