using Application.Commands.Schedule;
using Application.Response;
using Application.Template;
using Domain.Entities.Window.Time;
using Domain.Enumerator.Schedule;
using MediatR;

namespace Application.Handlers.Schedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ValidationResponse>
    {
        private readonly Dictionary<(ScheduleTypeEnumerator Type, ScheduleOperationEnumerator Operation), object> _templates;

        public CreateScheduleCommandHandler(Dictionary<(ScheduleTypeEnumerator Type, ScheduleOperationEnumerator Operation), object> templates)
        {
            _templates = templates;
        }

        public Task<ValidationResponse> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_templates.TryGetValue((request.Type, request.Operation), out var template))
                    throw new InvalidOperationException($"Nenhum template encontrado para o tipo {request.Type} e operação {request.Operation}.");

                var executeMethod = template.GetType()
                    .GetMethod(nameof(ScheduleTemplate<WindowTime>.Execute))
                    ?? throw new InvalidOperationException("Método 'Execute' não encontrado no template.");

                var result = executeMethod.Invoke(template, new object[] { request });

                return Task.FromResult((ValidationResponse)result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar o comando: {ex.Message}", ex);
            }
        }
    }
}
