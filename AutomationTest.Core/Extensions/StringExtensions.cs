using System.Globalization;

namespace AutomationTest.Core.Extensions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string value)
        {
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }

            return 0;
        }
    }
}
