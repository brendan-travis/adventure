using Adventure.Core.Scenes;
using Adventure.Core.Scenes.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Core.Container;

/// <summary>
/// This class contains static methods for registering services within a given <see cref="IServiceCollection"/>.
/// The methods should return the modified <see cref="IServiceCollection"/> to allow for fluent chaining with other
/// extension methods.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all of the services from the Core project into the IoC container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> object in which to register the services.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> to allow for fluent chaining.</returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services) => services
        .AddTransient<ITitleScreen, TitleScreen>();
}