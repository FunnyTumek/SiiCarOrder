using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Domain.Repositories
{
    public interface IAvailableConfigurationsRepository
    {
        Task<IEnumerable<AvailableCarConfiguration>> GetAll();
        Task<int> SaveConfiguration(AvailableCarConfiguration availableCarConfiguration);
        Task SaveEquipment(AvailableConfigurationAdditionalEquipment configurationEquipment);
        Task<IList<string>> GetAdditionalEquipmentCodesByConfigurationId(int configurationId);
    }
}
