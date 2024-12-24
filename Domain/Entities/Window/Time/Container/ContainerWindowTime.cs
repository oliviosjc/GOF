namespace Domain.Entities.Window.Time.Container
{
    public class ContainerWindowTime : WindowTime
    {
        public string ContainerType { get; set; } = string.Empty;
        public int MaxWeight { get; set; } = default;
    }
}
