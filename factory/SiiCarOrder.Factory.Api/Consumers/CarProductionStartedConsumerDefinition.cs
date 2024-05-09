using MassTransit;

namespace SiiCarOrder.Factory.Api.Consumers
{
    public class CarProductionStartedConsumerDefinition : ConsumerDefinition<CarProductionStartedConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<CarProductionStartedConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
