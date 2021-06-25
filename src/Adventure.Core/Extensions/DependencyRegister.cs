using Adventure.Core.Mappers;
using Adventure.Core.Mappers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Core.Extensions
{
    /// <summary>
    /// Contains dependency injection helpers and extensions.
    /// </summary>
    public static class DependencyRegister
    {
        /// <summary>
        /// Registers all dependencies in the <see cref="Adventure.Core"/> namespace.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> in which to register the dependencies.</param>
        /// <returns>The input <see cref="IServiceCollection"/> to enable chaining.</returns>
        public static IServiceCollection RegisterCoreDependencies(this IServiceCollection services)
        {
            services.AddTransient<IInputChoiceMapper, InputChoiceMapper>();

            return services;
        }
    }
}
