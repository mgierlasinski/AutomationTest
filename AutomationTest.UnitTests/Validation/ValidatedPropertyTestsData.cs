using AutomationTest.Core.Resources;
using System.Collections.Generic;

namespace AutomationTest.UnitTests.Validation
{
    public class ValidatedPropertyTestsData
    {
        public static IEnumerable<object[]> FailedValidationMessages() => new List<string[]>
        {
            new [] { null, Strings.ValueIsMandatory },
            new [] { "I am not a number", Strings.ValueHasIncorrectFormat }
        };
    }
}
