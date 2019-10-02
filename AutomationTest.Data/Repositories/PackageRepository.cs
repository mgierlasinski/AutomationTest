using AutomationTest.Data.Infrastructure;
using AutomationTest.Data.Models;
using AutomationTest.Data.Resources;
using Realms;
using Realms.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTest.Data.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly Realm _realm;

        public PackageRepository(IDatabaseProvider provider)
        {
            _realm = provider.GetInstance();
        }

        public void AddPackage(Package package)
        {
            try
            {
                _realm.Write(() => _realm.Add(package));
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PackageAlreadyExists, package.Barcode));
            }
        }

        public IEnumerable<Package> GetPackagesForRange(DateTimeOffset from, DateTimeOffset to)
        {
            return _realm.All<Package>()
                .Where(x => x.Date >= from && x.Date <= to)
                .OrderByDescending(x => x.Barcode);
        }
    }
}
