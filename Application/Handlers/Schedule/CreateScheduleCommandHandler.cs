using Application.Commands.Schedule;
using Application.Response;
using Application.Template;
using Domain.Enumerator.Schedule;
using MediatR;

namespace Application.Handlers.Schedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ValidationResponse>
    {
        private readonly Dictionary<ScheduleTypeEnumerator, ScheduleTemplate> _templates;

        public CreateScheduleCommandHandler(Dictionary<ScheduleTypeEnumerator, ScheduleTemplate> templates)
        {
            _templates = templates;
        }

        public Task<ValidationResponse> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_templates.TryGetValue(request.Type, out var template))
                    throw new InvalidOperationException($"Nenhum template encontrado para o tipo {request.Type}.");

                return Task.FromResult(template.Execute(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
