using Application.Commands.Schedule;
using Application.Factories;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;

namespace Application.Resolvers
{
    public class SpecializedScheduleFactoryResolver<TWindowTime> where TWindowTime : WindowTime
    {
        private readonly IEnumerable<ISpecializedScheduleFactory<TWindowTime>> _factories;

        public SpecializedScheduleFactoryResolver(IEnumerable<ISpecializedScheduleFactory<TWindowTime>> factories)
        {
            _factories = factories;
        }

        public BaseSchedule<TWindowTime> Resolve(CreateScheduleCommand command)
        {
            var factory = _factories.OfType<ISpecializedScheduleFactory<TWindowTime>>()
                                    .FirstOrDefault(f => f.CanHandle(command));

            return factory is null
                ? throw new InvalidOperationException("Nenhuma fábrica especializada disponível para lidar com o comando.")
                : factory.CreateSpecializedSchedule(command);
        }
    }
}
