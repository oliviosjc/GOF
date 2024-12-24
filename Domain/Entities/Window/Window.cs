using Domain.Entities.Base;

namespace Domain.Entities.Window
{
    public class Window : BaseEntity
    {
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}
