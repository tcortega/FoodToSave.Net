using System;
using FoodToSave.Net.Authentication;
using FoodToSave.Net.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace FoodToSave.Net;

/// <summary>
/// Holding extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class FoodToSaveServiceCollectionExtensions
{
    /// <summary>
    /// Registers all the FoodToSave.Net infrastructure, including <see cref="FoodToSaveOptions"/>
    /// configuration data stored in the <see cref="FoodToSaveOptions.SectionKey"/> (<c>"FoodToSave"</c>)
    /// section of the provided <see cref="IConfigurationRoot"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to</param>
    /// <param name="configurationRoot">The configuration root that holds a <c>"FoodToSave"</c> section of configuration data for FoodToSave</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained</returns>
    public static IServiceCollection AddFoodToSaveApi(
        this IServiceCollection services,
        IConfigurationRoot configurationRoot)
        => services.AddFoodToSaveApi(configurationRoot.GetSection(FoodToSaveOptions.SectionKey));

    /// <summary>
    /// Registers the FoodToSave.Net infrastructure, including <see cref="FoodToSaveOptions"/> 
    /// configuration data stored in the provided configuration section.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to</param>
    /// <param name="configuration">The configuration being bound</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained</returns>
    public static IServiceCollection AddFoodToSaveApi(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .Configure<FoodToSaveOptions>(configuration)
            .AddFoodToSaveClient();

    /// <summary>
    /// Registers the <see cref="FoodToSaveClient"/> and it's dependencies, with the exception
    /// of the <see cref="FoodToSaveOptions"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained</returns>
    public static IServiceCollection AddFoodToSaveClient(this IServiceCollection services)
    {
        services.PostConfigure<FoodToSaveOptions>(o => { o.Validate(); });

        services.AddRefitClient<IFoodToSaveAuthApi>()
            .ConfigureHttpClient((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<FoodToSaveOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add(options);
            });

        services.AddSingleton<IAuthStore, AuthStore>();
        services.AddTransient<FoodToSaveMessageHandler>();

        services.AddRefitClient<IFoodToSaveApi>()
            .ConfigureHttpClient((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<FoodToSaveOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Add(options);
            })
            .AddHttpMessageHandler<FoodToSaveMessageHandler>();

        services.AddSingleton(sp => new FoodToSaveClient(
            sp.GetRequiredService<IAuthStore>(),
            sp.GetRequiredService<IFoodToSaveApi>()
        ));

        return services;
    }
}