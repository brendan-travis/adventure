using Adventure.Core.Container;
using Adventure.Core.Scenes.Interfaces;
using Adventure.Main.Container;
using Microsoft.Extensions.DependencyInjection;

try
{
    var serviceProvider = new ServiceCollection()
        .AddMainServices()
        .AddCoreServices()
        .BuildServiceProvider();

    serviceProvider.GetService<ITitleScene>()!.ProcessTitleScene();
}
catch (Exception e)
{
    Console.Clear();
    Console.WriteLine(@"Unfortunately, the application has run into a serious error and must shut down.

Press any key to close the application window.");

    Console.ReadKey(true);
}

Console.WriteLine("Shutting down ...");