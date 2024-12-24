using Domain.Entities.Base;

namespace Domain.Entities.Vehicle
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; } = string.Empty;
        public int AxesQuantity { get; set; } = default;
        public string VehicleType { get; set; } = string.Empty;
        public string BodyworkType { get; set; } = string.Empty;
    }
}
