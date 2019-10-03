using AutomationTest.Core.Validation;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace AutomationTest.UnitTests.Assertions
{
    public class ValidatedPropertyAssertionExtensions<T> 
        : ReferenceTypeAssertions<ValidatedProperty<T>, ValidatedPropertyAssertionExtensions<T>>
    {
        protected override string Identifier => "ValidatedPropertyAssertionExtensions";

        public ValidatedPropertyAssertionExtensions(ValidatedProperty<T> instance)
        {
            Subject = instance;
        }

        public AndConstraint<ValidatedPropertyAssertionExtensions<T>> Empty()
        {
            Subject.Should().NotBeNull();
            Subject.Value.Should().BeNull();
            Subject.Error.Should().BeNull();

            return new AndConstraint<ValidatedPropertyAssertionExtensions<T>>(this);
        }
    }
}
