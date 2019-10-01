using AutomationTest.Core.Resources;
using AutomationTest.Core.Validation.Rules;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AutomationTest.UnitTests.Validation.Rules
{
    public class IsDoubleRuleTests
    {
        [Theory]
        [InlineData("6")]
        [InlineData("3.54")]
        [InlineData("2,75")]
        [InlineData("0.06")]
        [InlineData(".25")]
        [InlineData("9,88.3")]
        [InlineData("6.1-")]
        public void Validate_NumbersWithValidFormat_ValidationSuccess(string value)
        {
            // Arrange
            var rule = new IsDoubleRule();

            // Act
            var result = rule.Validate(value);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeTrue();
                result.Error.Should().BeEmpty();
            }
        }

        [Theory]
        [InlineData("3.54,6")]
        [InlineData("#,47")]
        public void Validate_NumbersWithInvalidFormat_ValidationError(string value)
        {
            // Arrange
            var rule = new IsDoubleRule();

            // Act
            var result = rule.Validate(value);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Error.Should().Be(Strings.ValueHasIncorrectFormat);
            }
        }
    }
}
