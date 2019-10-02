using AutomationTest.Core.Resources;
using AutomationTest.Core.Validation;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AutomationTest.UnitTests.Validation
{
    public class ValidationGroupTests
    {
        [Fact]
        public void Validate_NoProperties_ValidationSuccess()
        {
            // Arrange
            var group = new ValidationGroup();

            // Act
            var result = group.Validate();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Validate_AllPropertiesValid_ValidationSuccess()
        {
            // Arrange
            var propertyOne = new ValidatedProperty<string>("5")
                .IsRequired()
                .IsDouble();

            var propertyTwo = new ValidatedProperty<string>("12")
                .IsRequired()
                .IsDouble();

            var group = new ValidationGroup(propertyOne, propertyTwo);

            // Act
            var result = group.Validate();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Validate_FirstPropertyInvalid_ValidationFailed()
        {
            // Arrange
            var propertyOne = new ValidatedProperty<string>("qwerty")
                .IsRequired()
                .IsDouble();

            var propertyTwo = new ValidatedProperty<string>("12")
                .IsRequired()
                .IsDouble();

            var group = new ValidationGroup(propertyOne, propertyTwo);

            // Act
            var result = group.Validate();

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeFalse();
                propertyOne.Error.Should().Be(Strings.ValueHasIncorrectFormat);
                propertyTwo.Error.Should().BeNull();
            }
        }

        [Fact]
        public void Validate_AllPropertyInvalid_ValidationFailed()
        {
            // Arrange
            var propertyOne = new ValidatedProperty<string>().IsRequired();

            var propertyTwo = new ValidatedProperty<string>("qwerty")
                .IsRequired()
                .IsDouble();

            var group = new ValidationGroup(propertyOne, propertyTwo);

            // Act
            var result = group.Validate();

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeFalse();
                propertyOne.Error.Should().Be(Strings.ValueIsMandatory);
                propertyTwo.Error.Should().Be(Strings.ValueHasIncorrectFormat);
            }
        }

        [Fact]
        public void Validate_SecondPropertyInvalid_ValidationFailed()
        {
            // Arrange
            var propertyOne = new ValidatedProperty<string>("15")
                .IsRequired()
                .IsDouble();

            var propertyTwo = new ValidatedProperty<string>("abc")
                .IsRequired()
                .IsDouble();

            var group = new ValidationGroup(propertyOne, propertyTwo);

            // Act
            var result = group.Validate();

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeFalse();
                propertyOne.Error.Should().BeNull();
                propertyTwo.Error.Should().Be(Strings.ValueHasIncorrectFormat);
            }
        }
    }
}
