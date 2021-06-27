using System;
using System.Collections.Generic;
using Adventure.Core.Mappers.Interfaces;
using Adventure.Core.Models;
using Adventure.Ui.Abstractions.Interfaces;
using Adventure.Ui.Input;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Adventure.Ui.Tests.Input
{
    public class ReaderTests
    {
        #region ShowChoices

        [Fact]
        public void ShowChoices_NullChoices_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            Action action = () => _ = sut.ShowChoices(null);

            // Act / Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShowChoices_EmptyChoices_ThrowsArgumentException()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var choices = new List<string>();
            Action action = () => _ = sut.ShowChoices(choices);

            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShowChoices_ValidChoiceChosen_ReturnsInputChoiceChosenFromCommand()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var choices = new List<string>
            {
                "Ride a bike",
                "Take a walk",
                "Hop on the bus"
            };

            var bikeChoice = new InputChoice("R", "Ride a bike");
            var walkChoice = new InputChoice("T", "Take a walk");
            var busChoice = new InputChoice("H", "Hop on the bus");
            var inputChoices = new List<InputChoice> {bikeChoice, walkChoice, busChoice};

            this.InputChoiceMapper.MapToInputChoices(Arg.Any<List<string>>()).Returns(inputChoices);
            this.Console.ReadLine().Returns("r");
            
            // Act
            var result = sut.ShowChoices(choices);

            // Assert
            this.Console.Received(1).WriteLine(bikeChoice.FormattedChoice);
            this.Console.Received(1).WriteLine(walkChoice.FormattedChoice);
            this.Console.Received(1).WriteLine(busChoice.FormattedChoice);
            this.Console.Received(0).ForegroundColor = ConsoleColor.Red;
            this.Console.Received(0).WriteLine("That input was not valid. Please try again.");
            result.Should().BeEquivalentTo("Ride a bike");
        }

        [Fact]
        public void ShowChoices_ValidChoiceChosenAfterInvalidChoice_WritesErrorOnceAndReturnsInputChoice()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var choices = new List<string>
            {
                "Ride a bike",
                "Take a walk",
                "Hop on the bus"
            };

            var bikeChoice = new InputChoice("R", "Ride a bike");
            var walkChoice = new InputChoice("T", "Take a walk");
            var busChoice = new InputChoice("H", "Hop on the bus");
            var inputChoices = new List<InputChoice> {bikeChoice, walkChoice, busChoice};

            this.InputChoiceMapper.MapToInputChoices(Arg.Any<List<string>>()).Returns(inputChoices);
            this.Console.ReadLine().Returns("x", "r");
            
            // Act
            var result = sut.ShowChoices(choices);

            // Assert
            this.Console.Received(2).WriteLine(bikeChoice.FormattedChoice);
            this.Console.Received(2).WriteLine(walkChoice.FormattedChoice);
            this.Console.Received(2).WriteLine(busChoice.FormattedChoice);
            this.Console.Received(1).ForegroundColor = ConsoleColor.Red;
            this.Console.Received(1).WriteLine("That input was not valid. Please try again.");
            result.Should().BeEquivalentTo("Ride a bike");
        }

        #endregion

        #region Setup

        private Reader GetSystemUnderTest() => new Reader(this.Console, this.InputChoiceMapper);

        private IConsole Console { get; } = Substitute.For<IConsole>();

        private IInputChoiceMapper InputChoiceMapper { get; } = Substitute.For<IInputChoiceMapper>();

        #endregion
    }
}