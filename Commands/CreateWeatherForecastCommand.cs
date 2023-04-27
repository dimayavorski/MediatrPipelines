using System;
using FluentValidation;
using MediatR;
using MideiatrPipelinesApi;

namespace MideiatrPipelinesApi
{
	public class CreateWeatherForecastCommand: IRequest<WeatherForecast>
	{

			public int TemperatureC { get; set; }

			public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

			public string? Summary { get; set; }
	}
}

public class WeathForecastValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public WeathForecastValidator()
    {
        RuleFor(e => e.TemperatureC).LessThan(100);
    }
}

