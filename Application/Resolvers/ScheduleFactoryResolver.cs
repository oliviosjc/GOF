using Application.Commands.Schedule;
using Application.Factories;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;
using Domain.Enumerator.Schedule;

namespace Application.Resolvers
{
    public class ScheduleFactoryResolver<TWindowTime> where TWindowTime : WindowTime
    {
        private readonly IEnumerable<IScheduleFactory<TWindowTime>> _baseFactories;
        private readonly SpecializedScheduleFactoryResolver<TWindowTime> _specializedResolver;

        public ScheduleFactoryResolver(IEnumerable<IScheduleFactory<TWindowTime>> baseFactories, 
            SpecializedScheduleFactoryResolver<TWindowTime> specializedResolver)
        {
            _baseFactories = baseFactories;
            _specializedResolver = specializedResolver;
        }

        public BaseSchedule<TWindowTime> Resolve(CreateScheduleCommand command)
        {
            var factory = _baseFactories.FirstOrDefault(f => f.CanHandle(command));

            if (factory == null)
                throw new InvalidOperationException($"Nenhuma fábrica base disponível para o tipo {typeof(TWindowTime).Name}.");

            return factory.CreateSchedule(command);
        }
    }
}
