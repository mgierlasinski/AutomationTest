using AutomationTest.Data.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTest.Data.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly Realm _realm;

        public PackageRepository()
        {
            _realm = Realm.GetInstance();
        }

        public void AddPackage(Package package)
        {
            _realm.Write(() => _realm.Add(package));
        }

        public IEnumerable<Package> GetPackagesForDay(DateTimeOffset date)
        {
            return _realm.All<Package>()
                .Where(x => x.Date == date)
                .OrderByDescending(x => x.Barcode);
        }
    }
}
