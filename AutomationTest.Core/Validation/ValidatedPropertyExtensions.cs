using AutomationTest.Core.Validation.Rules;

namespace AutomationTest.Core.Validation
{
    public static class ValidatedPropertyExtensions
    {
        public static ValidatedProperty<string> IsRequired(this ValidatedProperty<string> property)
        {
            property.Rules.Add(new IsRequiredRule());
            return property;
        }

        public static ValidatedProperty<string> IsDouble(this ValidatedProperty<string> property)
        {
            property.Rules.Add(new IsDoubleRule());
            return property;
        }
    }
}
