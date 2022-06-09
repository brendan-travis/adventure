using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface;
using NSubstitute;
using Xunit;

namespace Adventure.Main.UnitTests.UserInterface;

public class ConsoleMessageUtilitiesTests
{
    #region ClearPreviousLines

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(100)]
    public void ClearPreviousLines_CalledWithVariousValues_CallsConsoleAdapterWriteWithBlankLinesXNumberOfTimes(
        int iterations)
    {
        // Arrange
        this.ConsoleAdapter.BufferWidth.Returns(10);
        
        // Act
        this.GetSystemUnderTest().ClearPreviousLines(iterations);
        
        // Assert
        this.ConsoleAdapter.Received(iterations).Write(new string(' ', 10));
    }
    
    [Fact]
    public void ClearPreviousLines_CalledWithNegativeValue_DoesNotCallWriteMethod()
    {
        // Arrange / Act
        this.GetSystemUnderTest().ClearPreviousLines(-5);
        
        // Assert
        this.ConsoleAdapter.Received(0).Write(Arg.Any<string>());
    }

    #endregion
    
    #region Setup

    private ConsoleMessageUtilities GetSystemUnderTest() => new(this.ConsoleAdapter);

    private IConsoleAdapter ConsoleAdapter { get; } = Substitute.For<IConsoleAdapter>();

    #endregion
}