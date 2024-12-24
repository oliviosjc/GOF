using Application.Commands.Schedule;
using FluentValidation;

namespace Application.Validations.Schedule.Liquid
{
    public class LiquidScheduleExportValidator
        : AbstractValidator<CreateScheduleCommand>
    {
        public LiquidScheduleExportValidator()
        {
            
        }
    }
}
