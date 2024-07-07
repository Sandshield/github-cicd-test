using Microsoft.AspNetCore.Mvc;
using WeatherApi.Attributes;
using WeatherApi.Domain.Interfaces;
using WeatherApi.Domain.Models;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherController> _logger;
    public WeatherController([FromKeyedServices("real")] IWeatherService weatherService, ILogger<WeatherController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    [HttpGet]
    [CustomCache(60, "weather")]
    [ProducesResponseType<WeatherForecast[]>(StatusCodes.Status200OK)]
    // [ProducesResponseType<Exception>(StatusCodes.Status503ServiceUnavailable)]
    public async Task<WeatherForecast[]> GetWeatherForecast()
    {
        _logger.LogDebug("Getting weather forecast.");
        var forecast = await _weatherService.GetWeather("Seattle");
        return forecast;
    }
}