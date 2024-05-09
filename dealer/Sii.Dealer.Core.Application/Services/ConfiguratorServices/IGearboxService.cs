using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IGearboxService
    {
        Task<IList<GearboxDto>> GetAll(bool onlyActive);

        Task<GearboxDto> Get(string code);

        Task Create(GearboxDto dto);

        Task Update(GearboxDto dto);
    }
}
