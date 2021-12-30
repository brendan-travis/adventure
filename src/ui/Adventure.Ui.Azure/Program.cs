using Adventure.Core.Ui;
using Adventure.Ui.Azure.DependencyExtensions;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddUiDependencies()
    .BuildServiceProvider();

var writer = serviceProvider.GetService<IMessageWriter>();
writer?.WriteMessage("DI works!");


Thread.Sleep(10_000);