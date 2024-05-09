using Microsoft.Extensions.Configuration;
using SiiCarOrder.Factory.Scheduler.Models;
using SiiCarOrder.Factory.Scheduler.Service;
using System.Configuration;

namespace SiiCarOrder.Factory.Api.Extensions
{
    public static class ProductionParamsServiceCollectionExtensions
    {
        public static IServiceCollection AddProductionParamsService(this IServiceCollection services)
        {
            using IHost host = Host.CreateDefaultBuilder()
                                   .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                IHostEnvironment env = hostingContext.HostingEnvironment;

                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                IConfigurationRoot configurationRoot = configuration.Build();

                services.Configure<ProductionParams>(configurationRoot.GetSection(key: nameof(ProductionParams)));
            })
            .Build();

            return services;
        }
    }
}
