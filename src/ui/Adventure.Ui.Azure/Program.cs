using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Crimson.DependencyExtensions;
using Adventure.Ui.Azure.DependencyExtensions;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddUiDependencies()
    .AddGameplayEngineDependencies()
    .BuildServiceProvider();

var gameplayEngine = serviceProvider.GetService<IGameplayManager>();
gameplayEngine?.StartGame();
