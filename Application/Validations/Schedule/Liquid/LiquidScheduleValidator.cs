using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Liquid
{
    public class LiquidScheduleValidator : AbstractValidator<CreateScheduleCommand>
    {
        public LiquidScheduleValidator()
        {
            RuleFor(x => x.InvoiceKey)
                .NotEmpty().WithMessage("Invoice key is required.");
        }
    }
}
