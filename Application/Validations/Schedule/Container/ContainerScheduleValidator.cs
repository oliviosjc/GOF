using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Container
{
    public class ContainerScheduleValidator : AbstractValidator<CreateScheduleCommand>
    {
        public ContainerScheduleValidator()
        {
            RuleFor(x => x.Moviment)
                .NotEmpty().WithMessage("Movement type is required.");
        }
    }
}
