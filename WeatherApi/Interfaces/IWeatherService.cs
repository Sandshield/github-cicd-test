namespace WeatherApi.Interfaces;

public interface IWeatherService
{
    WeatherForecast[] GetWeather(string location);
}