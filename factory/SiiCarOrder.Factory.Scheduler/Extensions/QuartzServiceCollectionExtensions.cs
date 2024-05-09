using Quartz.Impl;
using Quartz;
using SiiCarOrder.Factory.Scheduler.Service;
using System.Collections.Specialized;

namespace SiiCarOrder.Factory.Scheduler.Extensions
{
    public static class QuartzServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartzScheduler(this IServiceCollection services)
        {
            // Add the required Quartz.NET services
            services.AddQuartz(q =>
            {
                // Use a Scoped container to create jobs
                q.UseMicrosoftDependencyInjectionScopedJobFactory();
            });

            // ASP.NET Core hosting
            services.AddQuartzServer(q =>
            {
                // when shutting down we want jobs to complete gracefully
                q.WaitForJobsToComplete = true;
            });

            // Add the Quartz.NET hosted service
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


            //builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            var properties = new NameValueCollection() { { "quartz.scheduler.instanceName", "CarsProductionScheduler" }, { "quartz.scheduler.instanceId", "AUTO" } };
            services.AddSingleton<ISchedulerFactory>(x => ActivatorUtilities.CreateInstance<StdSchedulerFactory>(x, properties));

            services.AddScoped<ICarsProductionService, CarsProductionService>();
            services.AddScoped<ISchedulerService, SchedulerService>();
            services.AddScoped<IJobService, JobService>();

            return services;
        }
    }
}
