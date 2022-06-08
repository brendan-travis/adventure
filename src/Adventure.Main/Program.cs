using Adventure.Core.Container;
using Adventure.Core.Scenes.Interfaces;
using Adventure.Main.Container;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddMainServices()
    .AddCoreServices()
    .BuildServiceProvider();

serviceProvider.GetService<ITitleScreen>()!.ProcessTitleScreen();
