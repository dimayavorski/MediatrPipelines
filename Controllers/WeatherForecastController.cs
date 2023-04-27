using MediatR;
using Microsoft.AspNetCore.Mvc;
using MideiatrPipelinesApi.Queries;

namespace MideiatrPipelinesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediatr)
    {
        _logger = logger;
        _mediatr = mediatr;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediatr.Send(new WeatherForecastQuery());
        return Ok(result);
    }
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Post(CreateWeatherForecastCommand command)
    {
        await _mediatr.Send(command);
        return Ok();
    }
}
