using Application.Commands.Schedule;
using Application.Factories;
using Domain.Entities.Schedule;
using Domain.Enumerator.Schedule;

namespace Application.Resolvers
{
    public class ScheduleFactoryResolver
    {
        private readonly IEnumerable<IScheduleFactory> _baseFactories;
        private readonly SpecializedScheduleFactoryResolver _specializedResolver;

        public ScheduleFactoryResolver(IEnumerable<IScheduleFactory> baseFactories, SpecializedScheduleFactoryResolver specializedResolver)
        {
            _baseFactories = baseFactories;
            _specializedResolver = specializedResolver;
        }

        public BaseSchedule Resolve(CreateScheduleCommand command)
        {
            var baseFactory = _baseFactories.FirstOrDefault(f => f.CanHandle(command));
            if (baseFactory == null)
                throw new InvalidOperationException("Nenhuma fábrica base disponível para lidar com o comando.");

            var baseSchedule = baseFactory.CreateSchedule(command);

            return command.Operation is ScheduleOperationEnumerator.IMPORT or ScheduleOperationEnumerator.EXPORT
                ? _specializedResolver.Resolve(baseSchedule, command)
                : baseSchedule;
        }
    }

}
