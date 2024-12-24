using Application.Commands.Schedule;
using Domain.Entities.Schedule;
using Domain.Entities.Schedule.Bulk;
using Domain.Enumerator.Schedule;

namespace Application.Factories.Bulk
{
    public class BulkScheduleImportFactory : ISpecializedScheduleFactory
    {
        public bool CanHandle(CreateScheduleCommand command)
        {
            return command.Type == ScheduleTypeEnumerator.BULK && command.Operation == ScheduleOperationEnumerator.IMPORT;
        }

        public BaseSchedule CreateSpecializedSchedule(BaseSchedule baseSchedule, CreateScheduleCommand command)
        {
            if(baseSchedule is not BulkSchedule)
                throw new InvalidOperationException("BaseSchedule deve ser do tipo BulkSchedule.");

            return new BulkScheduleImport
            {

            };
        }
    }
}
