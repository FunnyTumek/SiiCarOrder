using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IBrandService
    {
        Task<IList<BrandDto>> GetAll(bool onlyActive);

        Task<BrandDto> Get(string code);

        Task Create(BrandDto dto);

        Task Update(BrandDto dto);
    }
}
