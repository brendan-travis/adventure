using System;
using System.Collections.Generic;
using Adventure.Core.Extensions;
using FluentAssertions;
using Xunit;

namespace Adventure.Core.Tests.Extensions
{
    public class EnumerableExtensionsTests
    {
        #region NotNullOrEmpty

        [Fact]
        public void NotNullOrEmpty_NullTarget_ThrowsArgumentNullException()
        {
            // Arrange
            Action action = () => (null as IEnumerable<object>).NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotNullOrEmpty_EmptyTarget_ThrowsArgumentException()
        {
            // Arrange
            var target = new List<object>() as IEnumerable<object>;
            Action action = () => target.NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void NotNullOrEmpty_ValidTarget_ThrowsNoExceptions() 
        {
            // Arrange
            var target = new List<object>{"not empty"} as IEnumerable<object>;
            Action action = () => target.NotNullOrEmpty(null);
            
            // Act / Assert
            action.Should().NotThrow<ArgumentNullException>();
            action.Should().NotThrow<ArgumentException>();
        }

        #endregion
    }
}