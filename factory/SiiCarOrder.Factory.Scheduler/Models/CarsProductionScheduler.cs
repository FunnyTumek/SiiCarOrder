using Quartz;

namespace SiiCarOrder.Factory.Scheduler.Models
{
    public class CarsProductionScheduler : ICarsProductionScheduler
    {
        private readonly IScheduler _scheduler;

        public CarsProductionScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public IScheduler Scheduler 
        { 
            get { return _scheduler; }
        }
    }
}