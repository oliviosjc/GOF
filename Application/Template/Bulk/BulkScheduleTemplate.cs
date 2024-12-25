using Application.Commands.Schedule;
using Application.Resolvers;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time.Bulk;

namespace Application.Template.Bulk
{
    public class BulkScheduleTemplate : ScheduleTemplate<BulkWindowTime>
    {
        private readonly ScheduleValidatorResolver _validatorResolver;
        private readonly ScheduleFactoryResolver<BulkWindowTime> _factoryResolver;

        public BulkScheduleTemplate(ScheduleValidatorResolver validatorResolver, ScheduleFactoryResolver<BulkWindowTime> factoryResolver)
        {
            _validatorResolver = validatorResolver;
            _factoryResolver = factoryResolver;
        }

        protected override void ValidateCommand(CreateScheduleCommand command)
        {
            _validatorResolver.Validate(command);
        }

        protected override BaseSchedule<BulkWindowTime> CreateSchedule(CreateScheduleCommand command)
        {
            return _factoryResolver.Resolve(command);
        }

        protected override void LinkWindowTime(BaseSchedule<BulkWindowTime> schedule, Guid windowTimeId)
        {
            Console.WriteLine("Realizar busca de janela e verificações.");
        }

        protected override void ExecuteAdditionalSteps(BaseSchedule<BulkWindowTime> schedule, CreateScheduleCommand command)
        {
            Console.WriteLine("Passos adicionais para BulkSchedule executados.");
        }
    }
}
