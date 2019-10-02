using MvvmCross.Logging;
using Realms;
using System;

namespace AutomationTest.Data.Infrastructure
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly IMvxLog _log;

        public DatabaseProvider(IMvxLog log)
        {
            _log = log;
        }

        public Realm GetInstance()
        {
            try
            {
                return Realm.GetInstance();
            }
            catch (Exception e)
            {
                _log.ErrorException("Database initialization failed", e);
                throw;
            }
        }
    }
}
