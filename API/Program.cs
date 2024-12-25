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
using Domain.Entities.Window.Time.Bulk;
using Domain.Entities.Window.Time.Liquid;
using Domain.Entities.Window.Time;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validators
builder.Services.AddSingleton<ScheduleValidatorResolver>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleImportValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, BulkScheduleExportValidator>();
builder.Services.AddSingleton<IValidator<CreateScheduleCommand>, LiquidScheduleValidator>();

// Base Factories
builder.Services.AddSingleton<IScheduleFactory<BulkWindowTime>, BulkScheduleFactory>();
builder.Services.AddSingleton<IScheduleFactory<LiquidWindowTime>, LiquidScheduleFactory>();

// Base Factory Resolvers
builder.Services.AddSingleton<ScheduleFactoryResolver<BulkWindowTime>>();
builder.Services.AddSingleton<ScheduleFactoryResolver<LiquidWindowTime>>();

// Specialized Factories
builder.Services.AddSingleton<ISpecializedScheduleFactory<BulkWindowTimeExport>, BulkScheduleExportFactory>();
builder.Services.AddSingleton<ISpecializedScheduleFactory<BulkWindowTimeImport>, BulkScheduleImportFactory>();

// Specialized Factory Resolver
builder.Services.AddSingleton(typeof(SpecializedScheduleFactoryResolver<>), typeof(SpecializedScheduleFactoryResolver<>));

// Templates
builder.Services.AddSingleton<BulkScheduleTemplate>();
builder.Services.AddSingleton<BulkScheduleImportTemplate>();

// Dictionary de Templates
builder.Services.AddSingleton(provider => new Dictionary<(ScheduleTypeEnumerator Type, ScheduleOperationEnumerator Operation), object>
{
    { (ScheduleTypeEnumerator.BULK, ScheduleOperationEnumerator.IMPORT), provider.GetRequiredService<BulkScheduleImportTemplate>() }
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