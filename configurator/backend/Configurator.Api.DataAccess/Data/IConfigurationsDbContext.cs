using Configurator.Api.DataAccess.Models;
using MongoDB.Driver;

namespace Configurator.Api.DataAccess.Data
{
    public interface IConfigurationsDbContext
    {
        IMongoCollection<SavedConfiguration> SavedConfigurations { get; }
        IMongoCollection<AvailableConfiguration> AvailableConfigurations { get; }

        IMongoCollection<T> GetCollection<T>(string name);
    }
}