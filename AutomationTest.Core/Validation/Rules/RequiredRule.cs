namespace AutomationTest.Core.Validation.Rules
{
    public class RequiredRule : IValidationRule<string>
    {
        public ValidationResult Validate(string value)
        {
            return !string.IsNullOrWhiteSpace(value)
                ? ValidationResult.Success()
                : ValidationResult.Failed("Value is mandatory");
        }
    }
}
