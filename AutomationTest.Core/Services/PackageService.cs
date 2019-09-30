using AutomationTest.Core.Models;
using AutomationTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTest.Core.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMappingService _mappingService;

        public PackageService(
            IPackageRepository packageRepository, 
            IMappingService mappingService)
        {
            _packageRepository = packageRepository;
            _mappingService = mappingService;
        }

        public void AddPackage(PackageItem package)
        {
            var packageDb = _mappingService.MapPackage(package);
            _packageRepository.AddPackage(packageDb);
        }

        public IEnumerable<PackageItem> GetPackagesForDay(DateTimeOffset date)
        {
            var from = date.Date;
            var to = from.AddDays(1).AddMilliseconds(-1);

            var result = _packageRepository.GetPackagesForRange(from, to);
            return result.Select(x => _mappingService.MapPackage(x));
        }
    }
}
