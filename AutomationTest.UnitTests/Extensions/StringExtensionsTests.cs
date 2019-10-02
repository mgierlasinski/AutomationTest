using AutomationTest.Core.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace AutomationTest.UnitTests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToDouble_NullValue_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;

            // Act
            Action action = () => input.ToDouble();

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("6", 6)]
        [InlineData("3.54", 3.54)]
        [InlineData("2,75", 275)]
        [InlineData("0.06", 0.06)]
        [InlineData(".25", 0.25)]
        [InlineData("9,88.3", 988.3)]
        [InlineData("6.1-", -6.1)]
        public void ToDouble_NumbersWithValidFormat_DoubleValue(string input, double expectedResult)
        {
            // Act
            var result = input.ToDouble();

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("3.54,6")]
        [InlineData("#,47")]
        public void ToDouble_NumbersWithInvalidFormat_DoubleValue(string input)
        {
            // Act
            Action action = () => input.ToDouble();

            // Assert
            action.Should().Throw<FormatException>();
        }
    }
}
