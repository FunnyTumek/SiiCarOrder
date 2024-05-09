using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IInteriorService
    {
        Task<IList<InteriorDto>> GetAll(bool onlyActive);

        Task<InteriorDto> Get(string code);

        Task Create(InteriorDto dto);

        Task Update(InteriorDto dto);
    }
}
