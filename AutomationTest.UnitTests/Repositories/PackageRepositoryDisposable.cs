using AutomationTest.Data.Infrastructure;
using AutomationTest.Data.Repositories;
using System;

namespace AutomationTest.UnitTests.Repositories
{
    public class PackageRepositoryDisposable : PackageRepository, IDisposable
    {
        private bool _disposed;

        public PackageRepositoryDisposable(IDatabaseProvider provider)
            : base(provider)
        {
        }

        private void CloseDatabase()
        {
            Realm?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                CloseDatabase();
            }

            _disposed = true;
        }

        ~PackageRepositoryDisposable()
        {
            Dispose(false);
        }
    }
}
