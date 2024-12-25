using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Schedule.Bulk;
using Domain.Entities.Window.Time.Bulk;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Bulk
{
    public class BulkScheduleImportFactory : ISpecializedScheduleFactory<BulkWindowTimeImport>
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.BULK && command.Operation == ScheduleOperationEnumerator.IMPORT;
        }

        public BaseSchedule<BulkWindowTimeImport> CreateSpecializedSchedule(CreateScheduleCommand command)
        {
            return new BulkScheduleImport
            {
            };
        }
    }
}