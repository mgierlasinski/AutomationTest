namespace AutomationTest.Core.Validation.Rules
{
    public interface IValidationRule<T>
    {
        ValidationResult Validate(T value);
    }
}
