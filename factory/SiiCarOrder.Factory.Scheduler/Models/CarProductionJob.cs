using Quartz;
using SiiCarOrder.Factory.Scheduler.Service;
using System.Diagnostics;
using MassTransit;
using Sii.CarOrder.Contracts.Factory;
using Microsoft.Extensions.Options;

namespace SiiCarOrder.Factory.Scheduler.Models
{
    public class CarProductionJob : IJob
    {
        private readonly IBus _bus;
        private readonly ITimersManagerService _timersManagerService;
        private readonly IOptions<ProductionParams> _productionParams;

        public CarProductionJob(IBus bus, ITimersManagerService timersManagerService, IOptions<ProductionParams> productionParams)
        {
            _bus = bus;
            _timersManagerService = timersManagerService;
            _productionParams = productionParams;
        }

        public async Task Execute(IJobExecutionContext context)
    	{
            await Task.Delay(TimeSpan.FromSeconds(_productionParams.Value.DurationInSeconds)); //simulation of the production process duration

            await _bus.Publish(new ProductionEndedEvent((int)context.JobDetail.JobDataMap["OrderId"], (Guid)context.JobDetail.JobDataMap["CarVin"]));
        }
    }
}