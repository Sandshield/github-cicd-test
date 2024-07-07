using WeatherApi.Domain.Models;

namespace WeatherApi.Domain.Interfaces;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetWeather(string location);
}