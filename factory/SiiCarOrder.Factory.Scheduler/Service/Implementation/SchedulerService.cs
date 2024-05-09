
using MassTransit;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Spi;
using SiiCarOrder.Factory.Scheduler.Models;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public class SchedulerService : ISchedulerService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IBus _bus;
        private readonly ITimersManagerService _timersManagerService;
        private readonly IOptions<ProductionParams> _productionParams;

        public SchedulerService(ISchedulerFactory schedulerFactory, IBus bus, ITimersManagerService timersManagerService, IOptions<ProductionParams> productionParams)
        {
            _schedulerFactory = schedulerFactory;
            _bus = bus;
            _timersManagerService = timersManagerService;
            _productionParams = productionParams;
        }

        public async Task<IScheduler> Get()
        {
            var scheduler = await _schedulerFactory.GetScheduler();
            scheduler.JobFactory = new CarProductionJobFactory(_bus, _timersManagerService, _productionParams);
            return await _schedulerFactory.GetScheduler();
        }

        public async Task Start()
        {
            var productionScheduler = await Get();
            if (!productionScheduler.IsStarted)
                productionScheduler?.Start();
        }

        public async Task Shutdown()
        {
            var productionScheduler = await Get();
            if (!productionScheduler.IsShutdown)
                productionScheduler?.Shutdown();
        }

        public async Task<string> GetReport()
        {
            var scheduler = await Get();
            StringBuilder jobsNames = new StringBuilder();

            foreach (var jobDetail in from jobGroupName in scheduler?.GetJobGroupNames().Result
                                      from jobName in scheduler?.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(jobGroupName)).Result
                                      select scheduler?.GetJobDetail(jobName))
            {
                jobsNames.Append(jobDetail.Result.Key).Append("; ");
            }

            return jobsNames.ToString();
        }

        public async Task CancelJob(JobKey jobKey)
        {
            var scheduler = await Get();
            await scheduler.DeleteJob(jobKey);
        }

    }
}