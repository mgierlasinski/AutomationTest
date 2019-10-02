using Realms;

namespace AutomationTest.Data.Infrastructure
{
    public interface IDatabaseProvider
    {
        Realm GetInstance();
    }
}
