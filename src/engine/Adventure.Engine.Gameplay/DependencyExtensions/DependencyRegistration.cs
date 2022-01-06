using System.ComponentModel;
using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Core;
using Adventure.Engine.Gameplay.Locales.Towns.TownOfBeginnings;
using Adventure.Engine.Gameplay.Locales.Towns.TownOfBeginnings.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Engine.Gameplay.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddGameplayEngineDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddTransient<IGameplayManager, GameplayManager>()
            .AddTransient<ITutorialTower, TutorialTower>();
}