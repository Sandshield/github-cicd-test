namespace WeatherApi.Domain.Interfaces;

public interface IWeatherApiClient
{
    Task<object> GetWeatherData();
}