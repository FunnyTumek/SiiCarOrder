using AutoMapper;
using MassTransit;
using MediatR;
using Sii.CarOrder.Contracts.Dealer;
using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Factory;
using SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder;

namespace SiiCarOrder.Factory.Api.Consumers
{
    public class CollectOrderConsumer : IConsumer<CollectOrderEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CollectOrderConsumer> _logger;
        private readonly IBus _bus;

        public CollectOrderConsumer(IMediator mediator, ILogger<CollectOrderConsumer> logger, IBus bus)
        {
            _mediator = mediator;
            _logger = logger;
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<CollectOrderEvent> context)
        {
            int orderId = context.Message.OrderId;
            var command = new UpdateStatusFactoryOrderCommand() { OrderId = orderId, ProductionStatus = ProductionStatus.OrderCompleted };
            await _mediator.Send(command);
            _logger.LogInformation("CollectOrderdEvent consumed successfully. Updated production status to Completed");
            await _bus.Publish(new CarReleasedEvent(orderId));
        }
    }
}

