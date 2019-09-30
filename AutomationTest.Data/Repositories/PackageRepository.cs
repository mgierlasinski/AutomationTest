using AutomationTest.Data.Models;
using MvvmCross.Logging;
using Realms;
using Realms.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomationTest.Data.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private Realm _realm;
        private readonly IMvxLog _log;

        public PackageRepository(IMvxLog log)
        {
            _log = log;
        }

        public async Task InitializeAsync()
        {
            if (_realm != null)
                return;

            try
            {
                _realm = await Realm.GetInstanceAsync();
            }
            catch (Exception e)
            {
                _log.ErrorException("InitializeAsync failed", e);
                throw;
            }
        }

        public void AddPackage(Package package)
        {
            try
            {
                _realm.Write(() => _realm.Add(package));
            }
            catch (RealmDuplicatePrimaryKeyValueException)
            {
                throw new ArgumentException($"Package with barcode {package.Barcode} already exists");
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
