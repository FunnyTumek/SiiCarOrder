using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;

namespace SiiCarOrder.Factory.Application.Service
{
    public interface IFactoryOrderService
    {
        Task AddProgressStateAsync(OrderedProductionProgressState progressState);
        Task<IEnumerable<OrderedProductionProgressStateDto>> GetOrderedProductionStatesListAsync(int productionId);
    }
}
