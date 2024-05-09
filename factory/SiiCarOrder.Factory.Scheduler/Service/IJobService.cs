using Quartz;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public interface IJobService
    {
        Task CreateAndAddToScheduler(int orderId, Guid carVin, int productionId);
    }
}