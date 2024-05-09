using Microsoft.EntityFrameworkCore;
using Sii.Dealer.Core.Base.Repositories;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Repositories
{
    public class AvailableConfigurationsRepository : AbstractRepository<AvailableCarConfiguration, int, SalesDbContext>, IAvailableConfigurationsRepository
    {
        public AvailableConfigurationsRepository(SalesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AvailableCarConfiguration>> GetAll()
        {
            return await Context.AvailableConfigurations
                .Include(x => x.Brand)
                .Include(x => x.Class)
                .Include(x => x.Model)
                .Include(x => x.Color)
                .Include(x => x.Engine)
                .Include(x => x.EquipmentVersion)
                .Include(x => x.Gearbox)
                .Include(x => x.Interior)
                .Include(x => x.ConfigurationAdditionalEquipments)
                .ThenInclude(x =>x.AdditionalEquipment)
                .ToListAsync();
        }

        public async Task<int> SaveConfiguration(AvailableCarConfiguration availableCarConfiguration)
        {
            await Context.AvailableConfigurations.AddAsync(availableCarConfiguration);
            Context.SaveChanges();
            return availableCarConfiguration.Id;
        }

        public async Task SaveEquipment(AvailableConfigurationAdditionalEquipment configurationEquipment)
        {
            await Context.AvailableConfigurationAdditionalEquipment.AddAsync(configurationEquipment);
            Context.SaveChanges();
        }

        public async Task<IList<string>> GetAdditionalEquipmentCodesByConfigurationId(int configurationId)
        {
            return await Context.AvailableConfigurationAdditionalEquipment.Where(x => x.AvailableConfigurationId == configurationId).Select(a => a.EquipmentCode).ToListAsync();
        }
    }
}
