using Application.Commands.Schedule;
using Application.Resolvers;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time.Bulk;

namespace Application.Template.Bulk
{
    public class BulkScheduleImportTemplate : ScheduleTemplate<BulkWindowTimeImport>
    {
        private readonly ScheduleValidatorResolver _validatorResolver;
        private readonly SpecializedScheduleFactoryResolver<BulkWindowTimeImport> _factoryResolver;

        public BulkScheduleImportTemplate(ScheduleValidatorResolver validatorResolver,
            SpecializedScheduleFactoryResolver<BulkWindowTimeImport> factoryResolver)
        {
            _validatorResolver = validatorResolver;
            _factoryResolver = factoryResolver;
        }

        protected override BaseSchedule<BulkWindowTimeImport> CreateSchedule(CreateScheduleCommand command)
        {
            return _factoryResolver.Resolve(command);
        }

        protected override void ExecuteAdditionalSteps(BaseSchedule<BulkWindowTimeImport> schedule, CreateScheduleCommand command)
        {
            Console.WriteLine("Passos adicionais para BulkSchedule executados.");
        }

        protected override void LinkWindowTime(BaseSchedule<BulkWindowTimeImport> schedule, Guid windowTimeId)
        {
            Console.WriteLine("Realizar busca de janela e verificações.");
        }

        protected override void ValidateCommand(CreateScheduleCommand command)
        {
            _validatorResolver.Validate(command);
        }
    }
}
