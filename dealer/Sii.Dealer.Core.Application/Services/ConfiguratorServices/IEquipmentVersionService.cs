using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IEquipmentVersionService
    {
        Task<IList<EquipmentVersionDto>> GetAll(bool onlyActive);

        Task<EquipmentVersionDto> Get(string code);

        Task Create(EquipmentVersionDto dto);

        Task Update(EquipmentVersionDto dto);
    }
}
