using Quartz;

namespace SiiCarOrder.Factory.Scheduler.Models
{
    public interface ICarsProductionScheduler
    {
        IScheduler Scheduler { get; }
    }
}