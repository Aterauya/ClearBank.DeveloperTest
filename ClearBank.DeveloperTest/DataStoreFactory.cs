using System.Configuration;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest
{
    public class DataStoreFactory
    {
        public static IDataStore GetDataStore(string dataStoreType)
        {
            return dataStoreType == "Backup"
                ? new BackupAccountDataStore()
                : new AccountDataStore();
        }
    }
}
