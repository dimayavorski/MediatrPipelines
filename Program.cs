using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using MideiatrPipelinesApi;
using MideiatrPipelinesApi.Behaviors;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()
    .AddOpenBehavior(typeof(LoggerBehaviour<,>))
    .AddOpenBehavior(typeof(ValidationBehaviour<,>)));
    //.AddBehavior<IPipelineBehavior<CreateWeatherForecastCommand, WeatherForecast>, ValidationBehaviour<CreateWeatherForecastCommand, WeatherForecast>>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
