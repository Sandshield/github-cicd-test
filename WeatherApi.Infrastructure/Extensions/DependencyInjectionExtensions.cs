using Microsoft.Extensions.DependencyInjection;
using WeatherApi.Domain.Interfaces;
using WeatherApi.Infrastructure.Services;

namespace WeatherApi.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependendyInjectionContainer(this IServiceCollection services)
    {
        services.AddKeyedSingleton<IWeatherService, WeatherService>("real");
        services.AddKeyedSingleton<IWeatherService, FakeWeatherService>("fake");

        return services;
    }
}