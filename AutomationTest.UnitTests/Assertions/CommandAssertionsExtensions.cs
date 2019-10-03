using FluentAssertions;
using FluentAssertions.Primitives;
using MvvmCross.Commands;

namespace AutomationTest.UnitTests.Assertions
{
    public class CommandAssertionsExtensions : ReferenceTypeAssertions<IMvxCommand, CommandAssertionsExtensions>
    {
        protected override string Identifier => nameof(CommandAssertionsExtensions);

        public CommandAssertionsExtensions(IMvxCommand instance)
        {
            Subject = instance;
        }

        public AndConstraint<CommandAssertionsExtensions> Available()
        {
            Subject.Should().NotBeNull();
            Subject.CanExecute().Should().BeTrue();

            return new AndConstraint<CommandAssertionsExtensions>(this);
        }
    }
}
