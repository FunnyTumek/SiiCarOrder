using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Factory;
using Sii.Dealer.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Consumers
{
    public class StartOfProductionFactoryEvent : IConsumer<ProductionStartedEvent>
    {
        private readonly ILogger<StartOfProductionFactoryEvent> logger;
        private readonly IOrdersApplicationService ordersApplicationService;

        public StartOfProductionFactoryEvent(ILogger<StartOfProductionFactoryEvent> logger, IOrdersApplicationService ordersApplicationService)
        {
            this.logger = logger;
            this.ordersApplicationService = ordersApplicationService;
        }

        public async Task Consume(ConsumeContext<ProductionStartedEvent> context)
        {
            await ordersApplicationService.SetStatusToProducted(context.Message.OrderId, context.Message.CarVin, context.Message.StartDate, context.Message.PlannedFinishDate);
            this.logger.LogInformation("{EventType} handled by {ConsumerType}.", nameof(ProductionStartedEvent), nameof(StartOfProductionFactoryEvent));
        }
    }
}
