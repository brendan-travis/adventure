using System;
using Adventure.Core.Extensions;
using FluentAssertions;
using Xunit;

namespace Adventure.Core.Tests.Extensions
{
    public class StringExtensionsTests
    {
        #region NotNullOrEmpty

        [Fact]
        public void NotNullOrEmpty_NullValue_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => (null as string).NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotNullOrEmpty_EmptyValue_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => "".NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void NotNullOrEmpty_WhitespaceValue_ThrowsArgumentException()
        {
            // Arrange
            Action action = () => " ".NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void NotNullOrEmpty_ValidValue_ThrowsNoExceptions() 
        {
            // Arrange
            Action action = () => "Valid String".NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().NotThrow<ArgumentNullException>();
            action.Should().NotThrow<ArgumentException>();
        }

        #endregion
    }
}