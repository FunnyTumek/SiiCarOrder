using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;

namespace SiiCarOrder.Factory.Infrastructure.Repositories
{
    public interface IOrderedProductionRepository
    {
        Task<IEnumerable<OrderedProduction>> GetAllAsync();
        Task<OrderedProduction?> GetByIdAsync(int id);
        Task<OrderedProduction?> GetByOrderIdAsync(int id);
        Task InsertAsync(OrderedProduction orderedProduction);
		Task UpdateStatusAsync(int orderId, ProductionStatus status);
		Task AddProgressStateAsync(OrderedProductionProgressState progressState);
        Task<IEnumerable<OrderedProductionProgressStateDto>> GetOrderedProductionStatesListAsync(int productionId);
        Task<OrderedProduction?> GetProductionByOrderId(int orderId);
    }
}
