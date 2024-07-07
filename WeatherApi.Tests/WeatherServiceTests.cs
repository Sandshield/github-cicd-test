using WeatherApi.Infrastructure.Services;

namespace WeatherApi.Tests;

public class WeatherServiceTests
{
    private readonly FakeWeatherService _fakeWeatherService;
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherService = new WeatherService();
        _fakeWeatherService = new FakeWeatherService();
    }

    [Theory]
    [InlineData("Seattle")]
    public async Task GetWeather_ReturnsExpectedData_ForValidLocation(string location)
    {
        // Arrange

        // Act
        var result = await _weatherService.GetWeather(location);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Count());
    }

    [Theory]
    [InlineData("Seattle")]
    public async Task GetFakeWeather_ReturnsExpectedData_ForValidLocation(string location)
    {
        // Arrange
        // Act
        var result = await _fakeWeatherService.GetWeather(location);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}