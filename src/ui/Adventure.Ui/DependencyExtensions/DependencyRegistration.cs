using Adventure.Core.Ui;
using Adventure.Ui.IO;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddUiDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddTransient<ITitleScreen, TitleScreen.TitleScreen>()
            .AddTransient<IMessageWriter, MessageWriter>()
            .AddTransient<IMessageReader, MessageReader>();
}