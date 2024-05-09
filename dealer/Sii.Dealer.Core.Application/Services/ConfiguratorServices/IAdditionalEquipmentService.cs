using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IAdditionalEquipmentService
    {
        Task<IList<AdditionalEquipmentDto>> GetAll(bool onlyActive);

        Task<AdditionalEquipmentDto> Get(string code);

        Task Create(AdditionalEquipmentDto dto);

        Task Update(AdditionalEquipmentDto dto);
    }
}
