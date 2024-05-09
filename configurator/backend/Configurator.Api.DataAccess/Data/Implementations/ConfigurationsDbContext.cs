using Configurator.Api.DataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Configurator.Api.DataAccess.Data.Implementations
{
    public class ConfigurationsDbContext : IConfigurationsDbContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public ConfigurationsDbContext(IOptions<ConfigurationsDatabaseSettings> settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromConnectionString(settings.Value.ConnectionString);
            _client = new MongoClient(mongoSettings);
            _database = _client.GetDatabase(settings.Value.DatabaseName);

            SavedConfigurations = _database.GetCollection<SavedConfiguration>(
                settings.Value.SavedConfigurationsCollectionName
            );
            AvailableConfigurations = _database.GetCollection<AvailableConfiguration>(
                settings.Value.AvailableConfigurationsCollectionName
            );
        }

        public IMongoCollection<SavedConfiguration> SavedConfigurations { get; }

        public IMongoCollection<AvailableConfiguration> AvailableConfigurations { get; }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}