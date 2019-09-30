using AutomationTest.Core.Models;
using System;
using System.Collections.Generic;

namespace AutomationTest.Core.Services
{
    public interface IPackageService
    {
        void AddPackage(PackageItem package);
        IEnumerable<PackageItem> GetPackagesForDay(DateTimeOffset date);
    }
}
