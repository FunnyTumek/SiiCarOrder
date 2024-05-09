using Quartz;
using Quartz.Impl;

namespace SiiCarOrder.Factory.Scheduler.Service
{
    public interface ISchedulerService
    {
        Task<IScheduler> Get();

        Task Start();

        Task Shutdown();

        Task<string> GetReport();

        Task CancelJob(JobKey jobKey);
    }
}