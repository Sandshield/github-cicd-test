using WeatherApi;
namespace WeatherApi.Tests
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        
        public WeatherServiceTests()
        {
            _weatherService = new WeatherService();
        }

        [Fact]
        public void GetWeather_ReturnsExpectedData_ForValidLocation()
        {
            // Arrange
            var location = "Seattle";

            // Act
            var result = _weatherService.GetWeather(location);

            // Assert
            Assert.NotNull(result);
        }
    }
}