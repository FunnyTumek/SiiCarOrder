using MediatR;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Repositories;

namespace SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder
{
    public class CreateFactoryOrderCommandHandler : IRequestHandler<CreateFactoryOrderCommand, OrderedProductionDto>
    {
        private readonly IOrderedProductionRepository _orderedProductionRepository;

        public CreateFactoryOrderCommandHandler(IOrderedProductionRepository orderedProductionRepository)
        {
            _orderedProductionRepository = orderedProductionRepository;
        }

        public async Task<OrderedProductionDto> Handle(CreateFactoryOrderCommand request, CancellationToken cancellationToken)
        {
            var orderedProduction = new OrderedProduction()
            {
                BrandCode = request.BrandCode,
                ModelCode = request.ModelCode,
                EquipmentVersionCode = request.EquipmentVersionCode,
                ClassCode = request.ClassCode,
                EngineCode = request.EngineCode,
                GearboxCode = request.GearboxCode,
                ColorCode = request.ColorCode,
                InteriorCode = request.InteriorCode,
                DeliveryDate = DateTime.Today.AddDays(2),
                CreateDate = DateTime.Today,
                Vin = Guid.NewGuid(),
                Status = ProductionStatus.Started,
                OrderId = request.OrderId
            };

            await _orderedProductionRepository.InsertAsync(orderedProduction);

            return new OrderedProductionDto(orderedProduction);
        }
    }
}
