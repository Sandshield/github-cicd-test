using WeatherApi.Interfaces;

namespace WeatherApi.Services;

public class WeatherService: IWeatherService
{
    private readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public WeatherForecast[] GetWeather(string location)
    {
        var result = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            Date: DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC: Random.Shared.Next(-20, 55),
            Summary: _summaries[Random.Shared.Next(_summaries.Length)]
        ))
        .ToArray();

        return result;
    }
}