using WeatherApi.Services;

namespace WeatherApi.Tests
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        private readonly FakeWeatherService _fakeWeatherService;

        public WeatherServiceTests()
        {
            _weatherService = new();
            _fakeWeatherService = new();
        }

        [Theory]
        [InlineData("Seattle")]
        public void GetWeather_ReturnsExpectedData_ForValidLocation(string location)
        {
            // Arrange
            
            // Act
            var result = _weatherService.GetWeather(location);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }
        
        [Theory]
        [InlineData("Seattle")]
        public void GetFakeWeather_ReturnsExpectedData_ForValidLocation(string location)
        {
            // Arrange
            // Act
            var result = _fakeWeatherService.GetWeather(location);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}