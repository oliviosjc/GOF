using Domain.Entities.Window.Time;

namespace Infra.Repositories.Interfaces
{
    public interface IWindowTimeRepository
    {
        WindowTime GetWindowTimeById(Guid id);
    }
}
