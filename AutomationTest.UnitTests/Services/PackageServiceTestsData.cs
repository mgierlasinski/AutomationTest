using System;
using System.Collections.Generic;

namespace AutomationTest.UnitTests.Services
{
    public class PackageServiceTestsData
    {
        public static DateTimeOffset TestDate { get; } = new DateTimeOffset(
            2019, 10, 03, 10, 30, 15, TimeSpan.Zero);

        public static IEnumerable<object[]> DatesInRange() => new List<object[]>
        {
            new object [] { TestDate, TestDate.AddHours(2) },
            new object [] { TestDate, new DateTimeOffset(2019, 10, 03, 23, 59, 59, TimeSpan.Zero) }
        };

        public static IEnumerable<object[]> DatesOutOfRange() => new List<object[]>
        {
            new object [] { TestDate, new DateTimeOffset(2019, 10, 04, 00, 00, 00, TimeSpan.Zero) },
            new object [] { TestDate, TestDate.AddDays(1) }
        };
    }
}
