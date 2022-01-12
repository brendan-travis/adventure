using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Core;
using Adventure.Engine.Gameplay.Locales.Factory;
using Adventure.Engine.Gameplay.Locales.Towns;
using Adventure.Engine.Gameplay.Locales.Towns.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Engine.Gameplay.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddGameplayEngineDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddTransient<IGameplayManager, GameplayManager>()
            .AddTransient<ICoreLoop, CoreLoop>()
            .AddTransient<ILocaleNexus, LocaleNexus>()
            .AddTransient<ITutorialTowerFloor3, TutorialTowerFloor3>();
}