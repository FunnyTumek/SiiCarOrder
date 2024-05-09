using Sii.Dealer.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Domain.Repositories
{
    public interface IConfigurationOptionsRepository
    {
        public Task Add<T>(T entity) where T : class, IConfigurationOption;

        public Task<IList<T>> GetAll<T>() where T : class, IConfigurationOption;

        public Task<IList<T>> GetActive<T>() where T : class, IConfigurationOption;

        public Task<TEntity> GetByCode<TEntity>(string code) where TEntity : class, IConfigurationOption;

        public Task<IList<decimal>> GetPriceOfAllOptionsByCode(string brandCode, string classCode, string modelCode, string colorCode, string engingeCode, string EqVersionCode, string gerboxCode, string interiorCode);
    }
}
