using NUnit.Framework;
using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class DataStoreFactoryTests
    {
        [Test]
        public void GetDataStore_ShouldReturnBackupAccountDataStore_WhenTypeIsBackup()
        {
            var dataStore = DataStoreFactory.GetDataStore("Backup");

            Assert.That(dataStore, Is.TypeOf<BackupAccountDataStore>());
        }

        [Test]
        public void GetDataStore_ShouldReturnAccountDataStore_WhenTypeIsNotBackup()
        {
            var dataStore = DataStoreFactory.GetDataStore("Primary");

            Assert.That(dataStore, Is.TypeOf<AccountDataStore>());
        }

        [Test]
        public void GetDataStore_ShouldReturnAccountDataStore_WhenTypeIsNull()
        {
            var dataStore = DataStoreFactory.GetDataStore(null);

            Assert.That(dataStore, Is.TypeOf<AccountDataStore>());
        }
    }
}
