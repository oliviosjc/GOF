using Domain.Entities.Window.Time;
using Domain.Entities.Window.Time.Bulk;
using Domain.Entities.Window.Time.Liquid;
using Infra.Repositories.Interfaces;

namespace Infra.Repositories
{
    public class WindowTimeRepository : IWindowTimeRepository
    {
        private readonly Dictionary<Guid, WindowTime> _windowTimes;

        public WindowTimeRepository()
        {
            _windowTimes = new Dictionary<Guid, WindowTime>
        {
            {
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                new BulkWindowTime
                {
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddHours(1),
                    BulkCapacity = 100
                }
            },
            {
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                new LiquidWindowTime
                {
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddHours(2),
                    MaxTemperature = 30,
                    MinTemperature = -10
                }
            }
        };
        }

        public WindowTime GetWindowTimeById(Guid id)
        {
            _windowTimes.TryGetValue(id, out var windowTime);

            if (windowTime is null)
                throw new Exception("Window time does not exists with this Id!");

            return windowTime;
        }
    }
}
