using Domain.Entities.Schedule;

namespace Application.Response
{
    public class ValidationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public BaseSchedule? Schedule { get; set; }

        public void AddError(string errorMessage)
        {
            IsSuccess = false;
            Errors.Add(errorMessage);
        }
    }
}
