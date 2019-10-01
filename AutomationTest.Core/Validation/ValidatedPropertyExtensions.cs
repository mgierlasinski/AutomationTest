using AutomationTest.Core.Validation.Rules;

namespace AutomationTest.Core.Validation
{
    public static class ValidatedPropertyExtensions
    {
        public static ValidatedProperty<string> IsRequired(this ValidatedProperty<string> property)
        {
            property.Rules.Add(new RequiredRule());
            return property;
        }
    }
}
