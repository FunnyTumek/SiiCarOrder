using MassTransit;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Spi;
using SiiCarOrder.Factory.Scheduler.Service;
using static Quartz.Logging.OperationName;

namespace SiiCarOrder.Factory.Scheduler.Models
{
    public class CarProductionJobFactory : IJobFactory
    {
        private readonly IBus _bus;
        private readonly ITimersManagerService _timersManagerService;
        private readonly IOptions<ProductionParams> _productionParams;

        public CarProductionJobFactory(IBus bus, ITimersManagerService timersManagerService, IOptions<ProductionParams> productionParams)
        {
            _bus = bus;
            _timersManagerService = timersManagerService;
            _productionParams = productionParams;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return new CarProductionJob(_bus, _timersManagerService, _productionParams);
        }

        public void ReturnJob(IJob job)
        {
            var disposableJob = job as IDisposable;
            disposableJob?.Dispose();
        }
    }
}
