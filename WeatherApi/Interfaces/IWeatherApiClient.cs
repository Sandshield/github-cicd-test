namespace WeatherApi.Interfaces;

public interface IWeatherApiClient
{
    Task<object> GetWeatherData();
}