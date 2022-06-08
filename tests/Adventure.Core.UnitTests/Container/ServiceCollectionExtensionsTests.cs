using Adventure.Core.Container;
using Adventure.Core.Scenes.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Adventure.Core.UnitTests.Container;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddCoreServices_CalledOnNewServiceCollection_RegistersExpectedServices()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddCoreServices();

        var expectedService = serviceCollection.BuildServiceProvider().GetService<ITitleScreen>();

        // Assert
        expectedService.Should().NotBeNull();
    }
}