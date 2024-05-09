using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IEngineService
    {
        Task<IList<EngineDto>> GetAll(bool onlyActive);

        Task<EngineDto> Get(string code);

        Task Create(EngineDto dto);

        Task Update(EngineDto dto);
    }
}
