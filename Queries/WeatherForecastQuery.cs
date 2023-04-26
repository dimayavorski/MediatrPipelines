using System;
using MediatR;

namespace MideiatrPipelinesApi.Queries
{
	public record WeatherForecastQuery(): IRequest<IEnumerable<WeatherForecast>>;	
	
}

