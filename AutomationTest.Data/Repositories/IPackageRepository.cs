using AutomationTest.Data.Models;
using System;
using System.Collections.Generic;

namespace AutomationTest.Data.Repositories
{
    public interface IPackageRepository
    {
        void AddPackage(Package package);

        IEnumerable<Package> GetPackagesForRange(DateTimeOffset from, DateTimeOffset to);
    }
}
