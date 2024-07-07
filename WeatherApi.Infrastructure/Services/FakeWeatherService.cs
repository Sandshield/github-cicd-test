using WeatherApi.Domain.Interfaces;
using WeatherApi.Domain.Models;

namespace WeatherApi.Infrastructure.Services;

public class FakeWeatherService : IWeatherService
{
    public async Task<WeatherForecast[]> GetWeather(string location) => [];
}