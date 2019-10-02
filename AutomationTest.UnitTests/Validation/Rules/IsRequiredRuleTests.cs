using AutomationTest.Core.Resources;
using AutomationTest.Core.Validation.Rules;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AutomationTest.UnitTests.Validation.Rules
{
    public class IsRequiredRuleTests
    {
        [Fact]
        public void Validate_NotEmptyValue_ValidationSuccess()
        {
            // Arrange
            var rule = new IsRequiredRule();;

            // Act
            var result = rule.Validate("qwerty");

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeTrue();
                result.Error.Should().BeEmpty();
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_EmptyValue_ValidationError(string value)
        {
            // Arrange
            var rule = new IsRequiredRule();

            // Act
            var result = rule.Validate(value);

            // Assert
            using (new AssertionScope())
            {
                result.IsValid.Should().BeFalse();
                result.Error.Should().Be(Strings.ValueIsMandatory);
            }
        }
    }
}
