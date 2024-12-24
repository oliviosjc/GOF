using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Bulk
{
    public class BulkScheduleImportValidator
        : AbstractValidator<CreateScheduleCommand>
    {
        public BulkScheduleImportValidator()
        {
            
        }
    }
}
