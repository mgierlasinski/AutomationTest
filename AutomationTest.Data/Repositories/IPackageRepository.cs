using AutomationTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomationTest.Data.Repositories
{
    public interface IPackageRepository
    {
        Task InitializeAsync();
        void AddPackage(Package package);
        IEnumerable<Package> GetPackagesForRange(DateTimeOffset from, DateTimeOffset to);
    }
}
