using AutoMapper;
using MassTransit;
using MediatR;
using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Factory;
using SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder;

namespace SiiCarOrder.Factory.Api.Consumers
{
    public class CarProductionEndedConsumer : IConsumer<ProductionEndedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CarProductionEndedConsumer> _logger;

        public CarProductionEndedConsumer(IMediator mediator, IMapper mapper, ILogger<CarProductionEndedConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ProductionEndedEvent> context)
        {
            var command = _mapper.Map<UpdateStatusFactoryOrderCommand>(context.Message);
            command.ProductionStatus = ProductionStatus.Ended;
            await _mediator.Send(command);
            _logger.LogInformation("ProductionEndedEvent consumed successfully. Updated production status");
        }
    }
}
