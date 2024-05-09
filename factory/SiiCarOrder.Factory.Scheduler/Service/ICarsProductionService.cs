using Quartz;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public interface ICarsProductionService
    {
        Task StartCarProduction(int orderId, Guid carVin, int productionId);

        Task<string> GetSchedulerReport();

        Task CancelProduction(int orderId, Guid carVin, string? reason);
    }
}