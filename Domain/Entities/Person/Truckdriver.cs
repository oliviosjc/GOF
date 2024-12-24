using Domain.Entities.Base;

namespace Domain.Entities.Person
{
    public class Truckdriver : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
}
