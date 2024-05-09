using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Factory;
using Sii.Dealer.Core.Application.Services;
using System;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Consumers
{
    public class FinishProductionFactoryEvent : IConsumer<ProductionEndedEvent>
    {
        private readonly ILogger<FinishProductionFactoryEvent> logger;
        private readonly IOrdersApplicationService ordersApplicationService;

        public FinishProductionFactoryEvent(ILogger<FinishProductionFactoryEvent> logger, IOrdersApplicationService ordersApplicationService)
        {
            this.logger = logger;
            this.ordersApplicationService = ordersApplicationService;
        }

        public async Task Consume(ConsumeContext<ProductionEndedEvent> context)
        {
            await ordersApplicationService.SetStatusToProductionAfterResponse(context.Message.OrderId);
            this.logger.LogInformation("{EventType} handled by {ConsumerType}.", nameof(ProductionStartedEvent), nameof(FinishProductionFactoryEvent));
        }
    }
}
