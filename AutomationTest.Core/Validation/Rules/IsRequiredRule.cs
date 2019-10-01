using AutomationTest.Core.Resources;

namespace AutomationTest.Core.Validation.Rules
{
    public class IsRequiredRule : IValidationRule<string>
    {
        public ValidationResult Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value)
                ? ValidationResult.Success()
                : ValidationResult.Failed(Strings.ValueIsMandatory);
        }
    }
}
