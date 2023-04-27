using System;
using LanguageExt.Common;
using MediatR;

namespace MideiatrPipelinesApi.Commands.Handlers
{
	public class CreateWeatherForecastHandler: IRequestHandler<CreateWeatherForecastCommand, WeatherForecast>
	{
		public CreateWeatherForecastHandler()
		{
		}

        public async Task<WeatherForecast> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new WeatherForecast());
        }
    }
}

