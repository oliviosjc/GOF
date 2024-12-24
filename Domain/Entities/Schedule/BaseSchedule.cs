using Domain.Entities.Base;
using Domain.Entities.Window.Time;

namespace Domain.Entities.Schedule
{
    public abstract class BaseSchedule : BaseEntity
    {
        public string InvoiceKey { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;

        public WindowTime WindowTime { get; set; } = null!;
    }
}
