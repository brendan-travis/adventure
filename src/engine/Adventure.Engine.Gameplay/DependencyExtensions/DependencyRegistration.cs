using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Engine.Gameplay.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddGameplayEngineDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddTransient<IGameplayManager, GameplayManager>();
}