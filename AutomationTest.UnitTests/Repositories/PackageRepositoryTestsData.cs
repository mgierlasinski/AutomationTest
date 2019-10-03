using System;
using System.Collections.Generic;

namespace AutomationTest.UnitTests.Repositories
{
    public class PackageRepositoryTestsData
    {
        public static DateTimeOffset TestDate { get; } = new DateTimeOffset(
            2019, 10, 03, 10, 30, 15, TimeSpan.Zero);

        public static IEnumerable<object[]> DatesInRange() => new List<object[]>
        {
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate.AddHours(1)
            },
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate
            },
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate.AddHours(2)
            }
        };

        public static IEnumerable<object[]> DatesOutOfRange() => new List<object[]>
        {
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate.AddHours(3)
            },
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate.AddMilliseconds(-1)
            },
            new object []
            {
                TestDate,
                TestDate.AddHours(2),
                TestDate.AddHours(2).AddMilliseconds(1)
            }
        };
    }
}
