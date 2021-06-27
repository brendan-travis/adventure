using System;
using Adventure.Core.Exceptions;
using Adventure.Core.Models;
using FluentAssertions;
using Xunit;

namespace Adventure.Core.Tests.Models
{
    public class InputChoiceTests
    {
        #region Constructor

        [Fact]
        public void Constructor_NullCommandKey_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _ = new InputChoice(null, "Example");

            // Act / Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_EmptyCommandKey_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => _ = new InputChoice("", "Example");

            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_WhitespaceCommandKey_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => _ = new InputChoice(" ", "Example");

            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_NullChoice_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => _ = new InputChoice("E", null);

            // Act / Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_EmptyChoice_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => _ = new InputChoice("E", "");

            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_WhitespaceChoice_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => _ = new InputChoice("E", " ");

            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }
        
        #endregion
        
        #region FormattedChoice

        [Fact]
        public void FormattedChoice_CommandDoesNotMatchChoice_ThrowsInvalidCommandKeyException()
        {
            // Arrange
            var sut = new InputChoice("Z", "Example Command");
            Action action = () => _ = sut.FormattedChoice;

            // Act / Assert
            action.Should().Throw<InvalidCommandKeyException>();
        }

        [Fact]
        public void FormattedChoice_ValidCommandKeyAndValidChoice_ReturnsExpectedValue()
        {
            // Arrange
            // ReSharper disable once StringLiteralTypo
            const string expected = "[E]xample Command";
            var sut = new InputChoice("E", "Example Command");

            // Act
            var result = sut.FormattedChoice;

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        #endregion
    }
}
