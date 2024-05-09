using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IAvailableConfigurationsService
    {
        Task<IList<AvailableCarConfigurationDto>> GetAll();
        Task<int> SaveAsync(AvailableCarConfigurationDto dto);
    }
}
