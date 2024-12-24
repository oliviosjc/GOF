using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Liquid
{
    public class LiquidScheduleImportValidator
        : AbstractValidator<CreateScheduleCommand>
    {
        public LiquidScheduleImportValidator()
        {
            
        }
    }
}
