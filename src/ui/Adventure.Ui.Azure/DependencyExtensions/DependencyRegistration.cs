using Adventure.Core.Ui;
using Adventure.Ui.Azure.IO;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui.Azure.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddUiDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddTransient<ITitleScreen, TitleScreen.TitleScreen>()
            .AddTransient<IMessageWriter, MessageWriter>()
            .AddTransient<IMessageReader, MessageReader>();
}