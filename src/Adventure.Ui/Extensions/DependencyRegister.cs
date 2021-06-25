using Adventure.Ui.Abstractions.Interfaces;
using Adventure.Ui.Input;
using Adventure.Ui.Input.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui.Extensions
{
    /// <summary>
    /// Contains dependency injection helpers and extensions.
    /// </summary>
    public static class DependencyRegistry
    {
        /// <summary>
        /// Registers all dependencies in the <see cref="Adventure.Ui"/> namespace.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> in which to register the dependencies.</param>
        /// <returns>The input <see cref="IServiceCollection"/> to enable chaining.</returns>
        public static IServiceCollection RegisterUiDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConsole, Abstractions.Console>();

            services.AddTransient<IReader, Reader>();

            return services;
        }
    }
}
