using Microsoft.Extensions.DependencyInjection;

namespace CubidSdk.Core;

public static class CubidClientServiceExtensions
{
    public static IServiceCollection AddCubidClient(
        this IServiceCollection services, string dappId, string apiKey)
    {
        services.AddSingleton(new CubidClientSettings(dappId, apiKey));
        services.AddScoped<CubidClient>();

        return services;
    }
}