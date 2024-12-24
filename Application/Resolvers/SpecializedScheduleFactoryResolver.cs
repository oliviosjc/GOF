using Application.Commands.Schedule;
using Application.Factories;
using Domain.Entities.Schedule;

namespace Application.Resolvers
{
    public class SpecializedScheduleFactoryResolver
    {
        private readonly IEnumerable<ISpecializedScheduleFactory> _factories;

        public SpecializedScheduleFactoryResolver(IEnumerable<ISpecializedScheduleFactory> factories)
        {
            _factories = factories;
        }

        public BaseSchedule Resolve(BaseSchedule baseSchedule, CreateScheduleCommand command)
        {
            var factory = _factories.FirstOrDefault(f => f.CanHandle(command));
            if (factory == null)
                throw new InvalidOperationException("Nenhuma fábrica especializada disponível para lidar com o comando.");

            return factory.CreateSpecializedSchedule(baseSchedule, command);
        }
    }

}
