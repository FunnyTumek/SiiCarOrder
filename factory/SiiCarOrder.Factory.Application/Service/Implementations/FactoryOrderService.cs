using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Persistance;
using SiiCarOrder.Factory.Infrastructure.Repositories;

namespace SiiCarOrder.Factory.Application.Service.Implementations
{
    public class FactoryOrderService : IFactoryOrderService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IOrderedProductionRepository _orderedProductionRepository;

        public FactoryOrderService(IServiceScopeFactory scopeFactory, IOrderedProductionRepository repository)
        {
            _scopeFactory = scopeFactory;
            _orderedProductionRepository = repository;
        }

        public async Task AddProgressStateAsync(OrderedProductionProgressState progressState)
        {
            _orderedProductionRepository.AddProgressStateAsync(progressState);
        }
        
        public async Task<IEnumerable<OrderedProductionProgressStateDto>> GetOrderedProductionStatesListAsync(int productionId) 
        {
            return await _orderedProductionRepository.GetOrderedProductionStatesListAsync(productionId);
        }
    }
}
