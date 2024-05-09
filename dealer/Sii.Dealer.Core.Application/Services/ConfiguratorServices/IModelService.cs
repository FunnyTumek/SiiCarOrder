using Sii.Dealer.Core.Application.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Services.ConfiguratorServices
{
    public interface IModelService
    {
        Task<IList<ModelDto>> GetAll(bool onlyActive);

        Task<ModelDto> Get(string code);

        Task Create(ModelDto dto);

        Task Update(ModelDto dto);
    }
}
