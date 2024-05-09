using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Persistance;

namespace SiiCarOrder.Factory.Infrastructure.Repositories.Implementations
{
    public class OrderedProductionRepository : IOrderedProductionRepository
    {
        private readonly FactoryDbContext dbContext;
        private readonly IServiceScopeFactory _scopeFactory;

        public OrderedProductionRepository(FactoryDbContext dbContext, IServiceScopeFactory scopeFactory)
        {
            this.dbContext = dbContext;
            this._scopeFactory = scopeFactory;
        }

        public async Task<IEnumerable<OrderedProduction>> GetAllAsync() =>
            await dbContext.OrderedProductions.ToListAsync();

        public async Task<OrderedProduction?> GetByIdAsync(int id) =>
            await dbContext.OrderedProductions.FirstOrDefaultAsync(x => x.Id == id);

		public async Task<OrderedProduction?> GetByOrderIdAsync(int id) =>
			await dbContext.OrderedProductions.FirstOrDefaultAsync(x => x.OrderId == id);

		public async Task InsertAsync(OrderedProduction orderedProduction)
        {
            await dbContext.OrderedProductions.AddAsync(orderedProduction);
            dbContext.SaveChanges();
        }

        public async Task UpdateStatusAsync(int orderId, ProductionStatus status)
        {
            OrderedProduction? production = await GetProductionByOrderId(orderId);

            if (production != null)
            {
                production.Status = status;
                await dbContext.SaveChangesAsync();
            }
        }


        public async Task AddProgressStateAsync(OrderedProductionProgressState progressState)
        {
            using (var scope = _scopeFactory.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FactoryDbContext>();
                await dbContext.OrderedProductionsProgressStates.AddAsync(progressState);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderedProductionProgressStateDto>> GetOrderedProductionStatesListAsync(int productionId) =>
            await dbContext.OrderedProductionsProgressStates.Where(x => x.ProductionId == productionId).Select(x => new OrderedProductionProgressStateDto(x)).ToListAsync();

        public async Task<OrderedProduction?> GetProductionByOrderId(int orderId) =>
           await dbContext.OrderedProductions.FirstOrDefaultAsync(x => x.OrderId == orderId);
    }
}
