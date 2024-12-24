using Application.Commands.Schedule;
using FluentValidation;
namespace Application.Validations.Schedule.Bulk
{
    public class BulkScheduleValidator : AbstractValidator<CreateScheduleCommand>
    {
        public BulkScheduleValidator()
        {
            RuleFor(x => x.InvoiceKey)
                .NotEmpty().WithMessage("Invoice key is required.");
        }
    }
}
