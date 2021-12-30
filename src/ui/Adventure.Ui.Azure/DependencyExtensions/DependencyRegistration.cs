using Adventure.Core.Ui;
using Adventure.Ui.Azure.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Adventure.Ui.Azure.DependencyExtensions;

public static class DependencyRegistration
{
    public static IServiceCollection AddUiDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection.AddTransient<IMessageWriter, MessageWriter>();
}