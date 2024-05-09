using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IColorService
    {
        Task<IList<ColorDto>> GetAll(bool onlyActive);

        Task<ColorDto> Get(string code);

        Task Create(ColorDto dto);

        Task Update(ColorDto dto);
    }
}
