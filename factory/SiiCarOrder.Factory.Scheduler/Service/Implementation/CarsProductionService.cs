using SiiCarOrder.Factory.Scheduler.Models;
using Quartz;
using Quartz.Impl.Matchers;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using Sii.CarOrder.Contracts.Factory;
using MassTransit;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public class CarsProductionService : ICarsProductionService
    {
        private readonly ISchedulerService _schedulerService;
        private readonly IJobService _jobService;
        private readonly string _jobName = "CarProductionJob_";
        private readonly string _jobGroup = "CarProductionJob_";
        private readonly IBus _bus;

        public CarsProductionService(ISchedulerService schedulerService, IJobService jobService, IBus bus)
        {
            _schedulerService = schedulerService;
            _jobService = jobService;
            _bus = bus;
        }

        public async Task StartCarProduction(int orderId, Guid carVin, int productionId)
        {
            await _jobService.CreateAndAddToScheduler(orderId, carVin, productionId);
        }

        public async Task<string> GetSchedulerReport()
        {
            return await _schedulerService.GetReport();
        }

        public async Task CancelProduction(int orderId, Guid carVin, string? reason)
        {
            JobKey jobKey = new JobKey(_jobName + orderId, _jobGroup);
            await _schedulerService.CancelJob(jobKey);
            await _bus.Publish(new ProductionCanceledEvent() { OrderId = orderId, CarVin = carVin, Reason = reason});
        }
    }
}