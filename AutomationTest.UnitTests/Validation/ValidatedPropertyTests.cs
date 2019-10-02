using AutomationTest.Core.Resources;
using AutomationTest.Core.Validation;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AutomationTest.UnitTests.Validation
{
    public class ValidatedPropertyTests
    {
        [Theory]
        [InlineData("qwerty")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Validate_EmptyRules_ValidationSuccess(string value)
        {
            // Arrange
            var property = new ValidatedProperty<string>(value);

            // Act
            var result = property.Validate();

            // Assert
            AssertSuccess(ref result, property);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Validate_IsRequiredNoValue_ValidationFailed(string value)
        {
            // Arrange
            var property = new ValidatedProperty<string>(value).IsRequired();

            // Act
            var result = property.Validate();

            // Assert
            AssertFailed(ref result, property, Strings.ValueIsMandatory);
        }

        [Fact]
        public void Validate_IsDoubleNoValue_ValidationFailed()
        {
            // Arrange
            var property = new ValidatedProperty<string>().IsDouble();

            // Act
            var result = property.Validate();

            // Assert
            AssertFailed(ref result, property, Strings.ValueHasIncorrectFormat);
        }

        [Theory]
        [MemberData(nameof(ValidatedPropertyTestsData.FailedValidationMessages), MemberType = typeof(ValidatedPropertyTestsData))]
        public void Validate_TwoRules_ValidationFailed(string value, string expectedError)
        {
            // Arrange
            var property = new ValidatedProperty<string>(value)
                .IsRequired()
                .IsDouble();

            // Act
            var result = property.Validate();

            // Assert
            AssertFailed(ref result, property, expectedError);
        }

        private void AssertSuccess(ref bool result, ValidatedProperty<string> property)
        {
            using (new AssertionScope())
            {
                result.Should().BeTrue();
                property.Error.Should().BeNull();
            }
        }

        private void AssertFailed(ref bool result, ValidatedProperty<string> property, string error)
        {
            using (new AssertionScope())
            {
                result.Should().BeFalse();
                property.Error.Should().Be(error);
            }
        }
    }
}
