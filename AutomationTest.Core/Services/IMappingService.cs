using AutomationTest.Core.Models;
using AutomationTest.Data.Models;

namespace AutomationTest.Core.Services
{
    public interface IMappingService
    {
        PackageItem MapPackage(Package package);
        Package MapPackage(PackageItem package);
    }
}
