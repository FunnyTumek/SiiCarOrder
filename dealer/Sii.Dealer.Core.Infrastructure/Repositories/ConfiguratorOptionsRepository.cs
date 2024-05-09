using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Repositories
{
    public class ConfiguratorOptionsRepository : IConfigurationOptionsRepository
    {
        private readonly SalesDbContext context;
        public ConfiguratorOptionsRepository(SalesDbContext context)
        {
            this.context = context;
        }

        public async Task Add<T>(T entity) where T : class, IConfigurationOption
        {
            await context.Set<T>().AddAsync(entity);
        }
        public async Task<IList<T>> GetAll<T>() where T : class, IConfigurationOption
        {
            var entities = await context.Set<T>().ToListAsync();
            return entities;
        }
        public async Task<IList<T>> GetActive<T>() where T : class, IConfigurationOption
        {
            var entities = await context.Set<T>().Where(b => b.Availability == true).ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByCode<TEntity>(string code) where TEntity : class, IConfigurationOption
        {
            var entity = await context.Set<TEntity>().Where(el => el.Code == code).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IList<decimal>> GetPriceOfAllOptionsByCode(string brandCode, string classCode, string modelCode, string colorCode, string engingeCode, string eqVersionCode, string gerboxCode, string interiorCode)
        {
            var result = context.Set<Brand>().Where(b => b.Code == brandCode).Select(b => b.Price)
                 .Concat(context.Set<CarClass>().Where(x => x.Code == classCode).Select(x => x.Price))
                 .Concat(context.Set<Model>().Where(m => m.Code == modelCode).Select(m => m.Price))
                 .Concat(context.Set<Color>().Where(c => c.Code == colorCode).Select(c => c.Price))
                 .Concat(context.Set<Engine>().Where(e => e.Code == engingeCode).Select(e => e.Price))
                 .Concat(context.Set<EquipmentVersion>().Where(eq => eq.Code == eqVersionCode).Select(eq => eq.Price))
                 .Concat(context.Set<Gearbox>().Where(g => g.Code == gerboxCode).Select(g => g.Price))
                 .Concat(context.Set<Interior>().Where(i => i.Code == interiorCode).Select(i => i.Price));
            return await result.ToListAsync();
        }
    }
}
