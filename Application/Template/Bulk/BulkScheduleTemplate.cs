using Application.Commands.Schedule;
using Application.Resolvers;
using Domain.Entities.Schedule;

namespace Application.Template.Bulk
{
    public class BulkScheduleTemplate : ScheduleTemplate
    {
        private readonly ScheduleValidatorResolver _validatorResolver;
        private readonly ScheduleFactoryResolver _factoryResolver;

        public BulkScheduleTemplate(
            ScheduleValidatorResolver validatorResolver,
            ScheduleFactoryResolver factoryResolver)
        {
            _validatorResolver = validatorResolver;
            _factoryResolver = factoryResolver;
        }

        protected override void ValidateCommand(CreateScheduleCommand command)
        {
            _validatorResolver.Validate(command);
        }

        protected override BaseSchedule CreateSchedule(CreateScheduleCommand command)
        {
            return _factoryResolver.Resolve(command);
        }

        protected override void ExecuteAdditionalSteps(BaseSchedule schedule, CreateScheduleCommand command)
        {
            Console.WriteLine("Passos adicionais para BulkSchedule executados.");
        }

        protected override void LinkWindowTime(BaseSchedule schedule, Guid windowTimeId)
        {
            Console.WriteLine("Realizar busca de janela e verificações.");
        }
    }

}
