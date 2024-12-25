using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;

namespace Application.Response
{
    public class ValidationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public BaseSchedule<WindowTime> Schedule { get; set; } = null!;

        public void AddError(string errorMessage)
        {
            IsSuccess = false;
            Errors.Add(errorMessage);
        }
    }
}
