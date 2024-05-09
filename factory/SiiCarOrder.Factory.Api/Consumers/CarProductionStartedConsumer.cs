using MassTransit;
using Sii.CarOrder.Contracts.Factory;
using Sii.CarOrder.Contracts.Dealer;
using SiiCarOrder.Factory.Scheduler.Service;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;
using MediatR;
using SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder;
using AutoMapper;
using Microsoft.Extensions.Options;
using SiiCarOrder.Factory.Scheduler.Models;
using SiiCarOrder.Factory.Infrastructure.Repositories;
using SiiCarOrder.Factory.Infrastructure.Repositories.Implementations;

namespace SiiCarOrder.Factory.Api.Consumers
{
    public class CarProductionStartedConsumer : IConsumer<PlaceOrderDealerEvent>
    {
        private readonly ILogger<CarProductionStartedConsumer> _logger;
        private readonly IMediator _mediator;
        private readonly ICarsProductionService _carsProductionService;
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IOptions<ProductionParams> _productionParams;
		private readonly IOrderedProductionRepository _orderedProductionRepository;

		public CarProductionStartedConsumer(ILogger<CarProductionStartedConsumer> logger, IMediator mediator, ICarsProductionService carsProductionService, 
                                            IBus bus, IMapper mapper, IOptions<ProductionParams> productionParams, IOrderedProductionRepository orderedProductionRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _carsProductionService = carsProductionService;
            _bus = bus;
            _mapper = mapper;
            _productionParams = productionParams;
            _orderedProductionRepository = orderedProductionRepository;
        }

        public async Task Consume(ConsumeContext<PlaceOrderDealerEvent> context)
        {
			var orderedProduction = new OrderedProduction()
			{
				BrandCode = context.Message.BrandCode,
				ModelCode = context.Message.ModelCode,
				EquipmentVersionCode = context.Message.EquipmentVersionCode,
				ClassCode = context.Message.ClassCode,
				EngineCode = context.Message.EngineCode,
				GearboxCode = context.Message.GearboxCode,
				ColorCode = context.Message.ColorCode,
				InteriorCode = context.Message.InteriorCode,
				DeliveryDate = DateTime.Today.AddDays(2),
				CreateDate = DateTime.Today,
				Status = ProductionStatus.Started,
				OrderId = context.Message.OrderId
			};

			var command = _mapper.Map<CreateFactoryOrderCommand>(orderedProduction);
            var productionDto = await _mediator.Send(command);

            var orderFromDataBase = await _orderedProductionRepository.GetByOrderIdAsync(orderedProduction.OrderId);
            orderedProduction.Vin = orderFromDataBase.Vin;
			orderedProduction.Id = productionDto.FactoryId;

            _logger.LogInformation("Order no {OrderId} accepted for production. Vin number assigned: {Vin}", orderedProduction.OrderId, orderedProduction.Vin);
            await _carsProductionService.StartCarProduction(orderedProduction.OrderId, orderedProduction.Vin.Value, orderedProduction.Id);
            await _bus.Publish(new ProductionStartedEvent(orderedProduction.OrderId, orderedProduction.Vin.Value, DateTime.Now, 
                               DateTime.Now.AddSeconds(TimeSpan.FromSeconds(_productionParams.Value.DurationInSeconds).TotalSeconds)));
        }
    }
}
