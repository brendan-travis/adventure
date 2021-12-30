using Adventure.Core.Ui;
using Adventure.Ui.Azure.Messaging;
using Adventure.Ui.Azure.Ui;
using Adventure.Ui.Azure.Ui.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui.Azure.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddUiDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddSingleton<IUiManager, UiManager>()
            .AddTransient<ITitleScreen, TitleScreen.TitleScreen>()
            .AddTransient<IMessageWriter, MessageWriter>();
}