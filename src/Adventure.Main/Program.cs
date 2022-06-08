using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .BuildServiceProvider();

Console.WriteLine("Hello, World!");