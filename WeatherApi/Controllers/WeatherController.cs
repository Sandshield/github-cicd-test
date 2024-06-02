using Microsoft.AspNetCore.Mvc;
using WeatherApi.Attributes;
using WeatherApi.Interfaces;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController([FromKeyedServices("real")] IWeatherService weatherService)
         => _weatherService = weatherService;

        [HttpGet]
        [CustomCache(duration: 60, key: "weather")]
        public IActionResult GetWeatherForecast()
        {
            var forecast = _weatherService.GetWeather("Seattle");
            return Ok(forecast);
        }
    }
}