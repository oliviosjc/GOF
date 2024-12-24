using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Bulk
{
    public class BulkScheduleExportValidator
        : AbstractValidator<CreateScheduleCommand>
    {
        public BulkScheduleExportValidator()
        {
            
        }
    }
}
