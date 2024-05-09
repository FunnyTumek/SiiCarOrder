using Quartz.Impl;
using Quartz;
using SiiCarOrder.Factory.Scheduler.Service;

namespace SiiCarOrder.Factory.Scheduler.Extensions
{
    public static class TimerManagerServiceCollectionExtensions
    {
        public static IServiceCollection AddTimerManager(this IServiceCollection services)
        {
            services.AddSingleton<ITimersManagerService, TimersManagerService>();

            return services;
        }
    }
}
