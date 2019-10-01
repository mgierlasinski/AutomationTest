using AutomationTest.Core.Resources;
using System.Globalization;

namespace AutomationTest.Core.Validation.Rules
{
    public class IsDoubleRule : IValidationRule<string>
    {
        public ValidationResult Validate(string value)
        {
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failed(Strings.ValueHasIncorrectFormat);
        }
    }
}
