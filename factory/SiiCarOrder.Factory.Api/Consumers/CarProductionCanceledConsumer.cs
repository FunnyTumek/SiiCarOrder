using AutoMapper;
using MassTransit;
using MediatR;
using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Factory;
using SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder;

namespace SiiCarOrder.Factory.Api.Consumers
{
    public class CarProductionCanceledConsumer : IConsumer<ProductionCanceledEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CarProductionCanceledConsumer> _logger;

        public CarProductionCanceledConsumer(ILogger<CarProductionCanceledConsumer> logger,IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ProductionCanceledEvent> context)
        {
            var command = _mapper.Map<UpdateStatusFactoryOrderCommand>(context.Message);
            command.ProductionStatus = ProductionStatus.Canceled;
            await _mediator.Send(command);
            _logger.LogInformation("ProductionCanceledEvent consumed successfully. Updated production status");
        }
    }
}
