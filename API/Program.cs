using Application.Commands.Schedule;
using Application.Factories.Bulk;
using Application.Factories.Liquid;
using Application.Factories;
using Application.Handlers.Schedule;
using Application.Resolvers;
using Application.Validations.Schedule.Bulk;
using Application.Validations.Schedule.Liquid;
using FluentValidation;
using Application.Template.Bulk;
using Application.Template;
using Domain.Enumerator.Schedule;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ScheduleValidatorResolver>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleImportValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleExportValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, LiquidScheduleValidator>();

builder.Services.AddSingleton<IScheduleFactory, BulkScheduleFactory>();
builder.Services.AddSingleton<IScheduleFactory, LiquidScheduleFactory>();

builder.Services.AddSingleton<ISpecializedScheduleFactory, BulkScheduleImportFactory>();
builder.Services.AddSingleton<ISpecializedScheduleFactory, BulkScheduleExportFactory>();

builder.Services.AddSingleton<ScheduleFactoryResolver>();
builder.Services.AddSingleton<SpecializedScheduleFactoryResolver>();

builder.Services.AddSingleton<BulkScheduleTemplate>();

builder.Services.AddSingleton(provider => new Dictionary<ScheduleTypeEnumerator, ScheduleTemplate>
{
    { ScheduleTypeEnumerator.BULK, provider.GetRequiredService<BulkScheduleTemplate>() }
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateScheduleCommandHandler).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
