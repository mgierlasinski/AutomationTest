using AutomationTest.Core.Models;
using AutomationTest.Data.Models;

namespace AutomationTest.Core.Services
{
    public class MappingService : IMappingService
    {
        public PackageItem MapPackage(Package package) => new PackageItem
        {
            Barcode = package.Barcode,
            Width = package.Width,
            Height = package.Height,
            Depth = package.Depth,
            Date = package.Date
        };

        public Package MapPackage(PackageItem package) => new Package
        {
            Barcode = package.Barcode,
            Width = package.Width,
            Height = package.Height,
            Depth = package.Depth,
            Date = package.Date
        };
    }
}
