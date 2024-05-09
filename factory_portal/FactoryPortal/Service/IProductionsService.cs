using FactoryPortal.Data;

namespace FactoryPortal.Service
{
    public interface IProductionsService
    {
        Task<ProductionDetails> GetProductionDetail(int id);
        Task<IEnumerable<ProductionDetails>> GetCurrentProductions();
        Task<IEnumerable<ProductionProgressState>> GetProductionStates(int id);
        Task CancelProduction(int id, Guid carVin, string reason);
    }
}
