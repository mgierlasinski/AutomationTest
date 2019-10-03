using AutomationTest.Core.Validation;
using MvvmCross.Commands;

namespace AutomationTest.UnitTests.Assertions
{
    public static class AssertionsExtensions
    {
        public static CommandAssertionsExtensions ShouldBe(this IMvxCommand command)
        {
            return new CommandAssertionsExtensions(command);
        }

        public static ValidatedPropertyAssertionExtensions<string> ShouldBe(this ValidatedProperty<string> property)
        {
            return new ValidatedPropertyAssertionExtensions<string>(property);
        }
    }
}
