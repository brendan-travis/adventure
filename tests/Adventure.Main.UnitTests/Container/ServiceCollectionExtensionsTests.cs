using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.Container;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Adventure.Main.UnitTests.Container;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddMainServices_CalledOnNewServiceCollection_RegistersExpectedServices()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddMainServices();

        // Assert
        serviceCollection.Should().NotBeEmpty();
    }
}
