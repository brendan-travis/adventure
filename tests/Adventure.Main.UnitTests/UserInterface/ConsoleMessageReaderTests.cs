using System;
using System.Collections.Generic;
using System.Text;
using Adventure.Main.Adapters.Interfaces;
using Adventure.Main.UserInterface;
using Adventure.Main.UserInterface.Interfaces;
using FluentAssertions;
using NSubstitute;
using Xunit;
using IMessageWriter = Adventure.Main.UserInterface.Interfaces.IMessageWriter;

namespace Adventure.Main.UnitTests.UserInterface;

public class ConsoleMessageReaderTests
{
    #region ShowChoices

    [Fact]
    public void ShowChoices_CalledWith3Options_WritesAll3OptionsToMessageWriter()
    {
        // Arrange
        var outputStream = new StringBuilder();
        var choices = new List<string> { "Option 1", "Option 2", "Option 3" };
        var expected =
            $"[[> Option 1, Cyan]]{Environment.NewLine}  Option 2{Environment.NewLine}  Option 3{Environment.NewLine}";

        this.MessageWriter.When(mw => mw.WriteMessage(Arg.Any<string>()))
            .Do(s => outputStream.AppendLine(s.Arg<string>()));
        this.ConsoleAdapter.ReadKey(true)
            .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));

        // Act
        this.GetSystemUnderTest().ShowChoices(choices);

        // Assert
        outputStream.ToString().Should().Be(expected);
    }

    [Fact]
    public void ShowChoices_OptionSelected_ReturnsGivenOption()
    {
        // Arrange
        var choices = new List<string> { "Option 1", "Option 2", "Option 3" };

        this.ConsoleAdapter.ReadKey(true)
            .Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));

        // Act
        var result = this.GetSystemUnderTest().ShowChoices(choices);

        // Assert
        result.Should().Be("Option 1");
    }

    [Fact]
    public void ShowChoices_SecondOptionSelected_ReturnsNextOption()
    {
        // Arrange
        var choices = new List<string> { "Option 1", "Option 2", "Option 3" };

        this.ConsoleAdapter.ReadKey(true)
            .Returns(new ConsoleKeyInfo((char)ConsoleKey.DownArrow, ConsoleKey.DownArrow, false, false, false),
                new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));

        // Act
        var result = this.GetSystemUnderTest().ShowChoices(choices);

        // Assert
        result.Should().Be("Option 2");
    }

    [Fact]
    public void ShowChoices_CalledWithNoOptions_ThrowsArgumentException()
    {
        // Arrange
        var act = () => this.GetSystemUnderTest().ShowChoices(new List<string>());

        // Act / Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ShowChoices_CalledWithInvalidType_ThrowsArgumentException()
    {
        // Arrange
        var act = () => this.GetSystemUnderTest().ShowChoices(new List<dynamic>());

        // Act / Assert
        act.Should().Throw<ArgumentException>();
    }

    #endregion

    #region Setup

    private ConsoleMessageReader GetSystemUnderTest() =>
        new(this.MessageWriter, this.ConsoleMessageUtilities, this.ConsoleAdapter);

    private IMessageWriter MessageWriter { get; } = Substitute.For<IMessageWriter>();

    private IConsoleMessageUtilities ConsoleMessageUtilities { get; } = Substitute.For<IConsoleMessageUtilities>();

    private IConsoleAdapter ConsoleAdapter { get; } = Substitute.For<IConsoleAdapter>();

    #endregion
}