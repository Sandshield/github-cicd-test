using WeatherApi.Interfaces;

namespace WeatherApi.Services;

public class FakeWeatherService: IWeatherService
{
    public WeatherForecast[] GetWeather(string location) => [];
}