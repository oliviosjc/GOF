using Application.Commands.Schedule;
using Application.Validations.Schedule.Bulk;
using Domain.Enumerator.Schedule;
using FluentValidation;

namespace Application.Resolvers
{
    public class ScheduleValidatorResolver
    {
        private readonly Dictionary<(ScheduleTypeEnumerator, ScheduleOperationEnumerator?), IValidator<CreateScheduleCommand>> _validators;
        public ScheduleValidatorResolver()
        {
            _validators = new Dictionary<(ScheduleTypeEnumerator, ScheduleOperationEnumerator?), IValidator<CreateScheduleCommand>>
            {
            { (ScheduleTypeEnumerator.BULK, null), new BulkScheduleValidator() },
            { (ScheduleTypeEnumerator.BULK, ScheduleOperationEnumerator.IMPORT), new BulkScheduleImportValidator() },
            { (ScheduleTypeEnumerator.BULK, ScheduleOperationEnumerator.EXPORT), new BulkScheduleExportValidator() },
        };
        }

        public void Validate(CreateScheduleCommand command)
        {
            var key = (command.Type, command.Operation);
            if (!_validators.TryGetValue(key, out var validator))
                throw new InvalidOperationException($"Nenhum validador encontrado para Type: {command.Type} e" +
                    $" Operation: {command.Operation}");

            var result = validator.Validate(command);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
