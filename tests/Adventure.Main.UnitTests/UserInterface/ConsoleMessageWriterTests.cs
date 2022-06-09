using System.Text;
using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Adventure.Main.UnitTests.UserInterface;

public class ConsoleMessageWriterTests
{
    #region WriteMessage

    [Fact]
    public void WriteMessage_CalledWithMessage_WritesMessageToConsoleAdapter()
    {
        // Arrange
        var message = "This is a test message";
        var outputStream = new StringBuilder();
        
        this.ConsoleAdapter.When(ca => ca.Write(Arg.Any<string>()))
            .Do(s => outputStream.Append(s.Arg<string>()));
        
        // Act
        this.GetSystemUnderTest().WriteMessage(message);
        
        // Assert
        outputStream.ToString().Should().Be(message);
    }

    [Fact]
    public void WriteMessage_CalledWithColouredMessage_ReplacesEscapedCharacters()
    {
        // Arrange
        var message = "[[This,Yellow]] is a [[coloured,Cyan]] [[message,Magenta]]!";
        var expectedMessage = "This is a coloured message!";
        var outputStream = new StringBuilder();
        
        this.ConsoleAdapter.When(ca => ca.Write(Arg.Any<string>()))
            .Do(s => outputStream.Append(s.Arg<string>()));
        
        // Act
        this.GetSystemUnderTest().WriteMessage(message);
        
        // Assert
        outputStream.ToString().Should().Be(expectedMessage);
    }

    #endregion
    
    #region Setup

    private ConsoleMessageWriter GetSystemUnderTest() => new(this.ConsoleAdapter);

    private IConsoleAdapter ConsoleAdapter { get; } = Substitute.For<IConsoleAdapter>();

    #endregion
}