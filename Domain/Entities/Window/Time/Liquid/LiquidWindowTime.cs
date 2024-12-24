namespace Domain.Entities.Window.Time.Liquid
{
    public class LiquidWindowTime : WindowTime
    {
        public double MaxTemperature { get; set; } = default;
        public double MinTemperature { get; set; } = default;
    }
}
