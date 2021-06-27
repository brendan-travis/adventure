using System;
using System.Collections.Generic;
using System.Linq;
using Adventure.Core.Exceptions;
using Adventure.Core.Mappers;
using Adventure.Core.Models;
using FluentAssertions;
using Xunit;

namespace Adventure.Core.Tests.Mappers
{
    public class InputChoiceMapperTests
    {
        #region MapToInputChoices

        [Fact]
        public void MapToInputChoices_NonUniqueChoices_ThrowsNonUniqueCommandException()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var choices = new List<string> {"n", "n"};

            Action action = () => _ = sut.MapToInputChoices(choices).ToList();

            // Act / Assert
            action.Should().Throw<NonUniqueCommandException>();
        }

        [Theory]
        [MemberData(nameof(ValidChoices))]
        public void MapToInputChoices_ValidChoices_MapsToExpectedInputChoices(List<string> choices,
            List<InputChoice> expectedInputChoices)
        {
            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            var result = sut.MapToInputChoices(choices);

            // Assert
            result.Should().BeEquivalentTo(expectedInputChoices);
        }

        #endregion

        #region Setup

        private InputChoiceMapper GetSystemUnderTest() => new InputChoiceMapper();

        public static IEnumerable<object[]> ValidChoices =>
            new List<object[]>
            {
                new object[]
                {
                    new List<string> {"a"}, new List<InputChoice> {new InputChoice("a", "a")}
                },
                new object[]
                {
                    new List<string> {"a", "b", "c"},
                    new List<InputChoice>
                        {new InputChoice("a", "a"), new InputChoice("b", "b"), new InputChoice("c", "c")}
                },
                new object[]
                {
                    new List<string> {"aaa", "aaa", "aaa"},
                    new List<InputChoice>
                        {new InputChoice("a", "aaa"), new InputChoice("aa", "aaa"), new InputChoice("aaa", "aaa")}
                },
                new object[]
                {
                    new List<string> {"command alpha", "command beta", "additional command"},
                    new List<InputChoice>
                    {
                        new InputChoice("c", "command alpha"), new InputChoice("o", "command beta"),
                        new InputChoice("a", "additional command")
                    }
                },
                new object[]
                {
                    new List<string>
                    {
                        "paint a picture", "pick up a flower", "print the page", "pause everything", "patrol the area"
                    },
                    new List<InputChoice>
                    {
                        new InputChoice("p", "paint a picture"), new InputChoice("i", "pick up a flower"),
                        new InputChoice("r", "print the page"), new InputChoice("a", "pause everything"),
                        new InputChoice("t", "patrol the area")
                    }
                }
            };

        #endregion
    }
}