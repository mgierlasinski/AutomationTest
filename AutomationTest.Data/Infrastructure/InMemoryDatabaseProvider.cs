using MvvmCross.Logging;
using Realms;
using System;

namespace AutomationTest.Data.Infrastructure
{
    public class InMemoryDatabaseProvider : IDatabaseProvider
    {
        private readonly IMvxLog _log;

        public InMemoryDatabaseProvider(IMvxLog log)
        {
            _log = log;
        }

        public Realm GetInstance()
        {
            try
            {
                var config = new InMemoryConfiguration(nameof(InMemoryDatabaseProvider));
                return Realm.GetInstance(config);
            }
            catch (Exception e)
            {
                _log.ErrorException("In-memory Database initialization failed", e);
                throw;
            }
        }
    }
}
