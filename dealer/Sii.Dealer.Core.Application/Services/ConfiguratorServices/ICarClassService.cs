using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface ICarClassService
    {
        Task<IList<CarClassDto>> GetAll(bool onlyActive);

        Task<CarClassDto> Get(string code);

        Task Create(CarClassDto dto);

        Task Update(CarClassDto dto);
    }
}
