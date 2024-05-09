using MediatR;
using SiiCarOrder.Factory.Infrastructure.Repositories;

namespace SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder
{
    public class UpdateStatusFactoryOrderCommandHandler : IRequestHandler<UpdateStatusFactoryOrderCommand>
    {
        private readonly IOrderedProductionRepository _orderedProductionRepository;

        public UpdateStatusFactoryOrderCommandHandler(IOrderedProductionRepository orderedProductionRepository)
        {
            _orderedProductionRepository = orderedProductionRepository;
        }

        public async Task<Unit> Handle(UpdateStatusFactoryOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderedProductionRepository.UpdateStatusAsync(request.OrderId, request.ProductionStatus);
            return Unit.Value;
        }
    }
}
