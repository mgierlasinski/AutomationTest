using System.Globalization;

namespace AutomationTest.Core.Extensions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string value)
        {
            return double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }
    }
}
