using WeatherApi.Interfaces;
using WeatherApi.Services;

namespace WeatherApi.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDependendyInjectionContainer(this IServiceCollection services)
    {
        services.AddKeyedSingleton<IWeatherService, WeatherService>("real");
        services.AddKeyedSingleton<IWeatherService, FakeWeatherService>("fake");

        return services;
    }
}