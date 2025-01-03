﻿using Application.Commands.Schedule;
using Application.Response;
using Domain.Entities.Schedule;
using Domain.Entities.Window.Time;
using FluentValidation;

namespace Application.Template
{
    public abstract class ScheduleTemplate<TWindowTime> where TWindowTime : WindowTime
    {
        public ValidationResponse Execute(CreateScheduleCommand command)
        {
            try
            {
                ValidateCommand(command);

                var schedule = CreateSchedule(command);

                LinkWindowTime(schedule, command.WindowTimeId);

                ExecuteAdditionalSteps(schedule, command);

                return new ValidationResponse
                {
                    IsSuccess = true,
                    Message = $"Agendamento do tipo {schedule.GetType().Name} criado com sucesso."
                };
            }
            catch (ValidationException ex)
            {
                return new ValidationResponse
                {
                    IsSuccess = false,
                    Message = $"Erro de validação: {string.Join(", ", ex.Errors.Select(e => e.ErrorMessage))}"
                };
            }
            catch (Exception ex)
            {
                return new ValidationResponse
                {
                    IsSuccess = false,
                    Message = $"Erro inesperado: {ex.Message}"
                };
            }
        }

        protected abstract void ValidateCommand(CreateScheduleCommand command);
        protected abstract BaseSchedule<TWindowTime> CreateSchedule(CreateScheduleCommand command);
        protected abstract void LinkWindowTime(BaseSchedule<TWindowTime> schedule, Guid windowTimeId);
        protected abstract void ExecuteAdditionalSteps(BaseSchedule<TWindowTime> schedule, CreateScheduleCommand command);
    }
}
