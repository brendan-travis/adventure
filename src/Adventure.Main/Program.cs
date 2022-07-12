using Adventure.Main.Container;
using Adventure.Main.Scenes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

ILogger? logger = null;

try
{
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => { services.AddMainServices(); })
        .UseSerilog((_, loggerConfiguration) => loggerConfiguration
            .WriteTo.File(new CompactJsonFormatter(), "log.txt"))
        .Build();

    var scope = host.Services.CreateScope();

    logger = scope.ServiceProvider.GetService<ILogger>();
    logger?.Information("Application starting.");

    scope.ServiceProvider.GetService<ITitleScene>()?.ProcessTitleScene();
}
catch (Exception e)
{
    const string fatalError = "The application has run into a serious error and must shut down.";
    logger?.Fatal(e, fatalError);

    Console.Clear();
    Console.WriteLine($"{fatalError}\n\nPress any key to close the application window.");
    Console.ReadKey(true);
}

logger?.Information("Application shutting down.");
Console.WriteLine("Shutting down ...");