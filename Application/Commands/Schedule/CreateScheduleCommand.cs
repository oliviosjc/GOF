using Application.Response;
using Domain.Entities.Vehicle;
using Domain.Enumerator.Schedule;
using MediatR;

namespace Application.Commands.Schedule
{
    public class CreateScheduleCommand : IRequest<ValidationResponse>
    {
        public string TruckdriverName { get; set; } = string.Empty;
        public string TruckdriverDocument { get; set; } = string.Empty;
        public List<Vehicle> Vehicles { get; set; } = new();
        public string InvoiceKey { get; set; } = string.Empty;
        public ScheduleOperationEnumerator Operation { get; set; }
        public ContainerScheduleMovimentEnumerator? Moviment { get; set; }
        public string? NCM { get; set; }
        public string? IMO { get; set; }
        public string? ISO { get; set; }
        public bool IsReefer { get; set; }
        public double? ReeferTemperature { get; set; }
        public int? ContainerSize { get; set; }
        public double? MaxWeight { get; set; }
        public Guid WindowTimeId { get; set; }
        public ScheduleTypeEnumerator Type { get; set; }
    }
}
