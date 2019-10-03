using AutomationTest.Data.Models;
using AutomationTest.Data.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace AutomationTest.UnitTests.Repositories
{
    public static class PackageRepositoryExtensions
    {
        public static void MockRange(this IPackageRepository repository, DateTimeOffset day, Package entity)
        {
            var from = day.Date;
            var to = from.AddDays(1).AddMilliseconds(-1);

            repository.GetPackagesForRange(
                    Arg.Is<DateTimeOffset>(x => x >= from),
                    Arg.Is<DateTimeOffset>(x => x <= to))
                .Returns(new List<Package> { entity });
        }
    }
}
