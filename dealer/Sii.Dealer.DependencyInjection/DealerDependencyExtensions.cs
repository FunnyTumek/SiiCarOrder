using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Sii.Dealer.Core.Infrastructure.Configuration;
using Sii.Dealer.Core.Infrastructure.Consumers;
using Sii.Dealer.Customers.Consumers;

namespace Sii.Dealer.DependencyInjection;

public static class DealerDependencyExtensions
{
    public static IServiceCollection RegisterDealerOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(
            configuration.GetSection(RabbitMqOptions.SectionName)
        );
        return services;
    }

    public static IServiceCollection RegisterDealerDependencies(this IServiceCollection services)
    {
        services.AddMassTransit(options =>
        {
            options.AddConsumer<CustomersEventConsumer>();
            options.AddConsumer<FinishProductionFactoryEvent>();
            options.AddConsumer<StartOfProductionFactoryEvent>();
            options.AddConsumer<OrderCreatedEventConsumer>();
            options.AddConsumer<CarReleasedEventConsumer>();

            options.UsingRabbitMq((context, cfg) =>
            {
                IOptionsSnapshot<RabbitMqOptions> optionsSnapshot = context.GetService<IOptionsSnapshot<RabbitMqOptions>>();
                RabbitMqOptions options = optionsSnapshot.Value;
                cfg.Host(options.Host, options.VirtualHost, h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
