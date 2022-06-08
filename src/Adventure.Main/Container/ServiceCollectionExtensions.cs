using Adventure.Core.UserInterface.Interfaces;
using Adventure.Main.Adapters;
using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface;
using Adventure.Main.UserInterface.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Main.Container;

/// <summary>
/// This class contains static methods for registering services within a given <see cref="IServiceCollection"/>.
/// The methods should return the modified <see cref="IServiceCollection"/> to allow for fluent chaining with other
/// extension methods.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all of the services from the Main project into the IoC container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> object in which to register the services.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> to allow for fluent chaining.</returns>
    public static IServiceCollection AddMainServices(this IServiceCollection services) => services
        .AddSingleton<IConsoleAdapter, ConsoleAdapter>()
        .AddTransient<IMessageWriter, ConsoleMessageWriter>()
        .AddTransient<IMessageReader, ConsoleMessageReader>()
        .AddTransient<IConsoleMessageUtilities, ConsoleMessageUtilities>();
}
