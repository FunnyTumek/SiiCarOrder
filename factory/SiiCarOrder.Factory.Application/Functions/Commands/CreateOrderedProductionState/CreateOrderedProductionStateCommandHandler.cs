using MediatR;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiCarOrder.Factory.Application.Functions.Commands.CreateOrderedProductionState
{
    public class CreateOrderedProductionStateCommandHandler : IRequestHandler<CreateOrderedProductionStateCommand, OrderedProductionProgressStateDto>
    {
        private readonly IOrderedProductionRepository _orderedProductionRepository;

        public CreateOrderedProductionStateCommandHandler(IOrderedProductionRepository orderedProductionRepository) 
        {
            _orderedProductionRepository = orderedProductionRepository;
        }

        public async Task<OrderedProductionProgressStateDto> Handle(CreateOrderedProductionStateCommand request, CancellationToken cancellationToken)
        {
            await _orderedProductionRepository.AddProgressStateAsync(request.ProgressState);

            return new OrderedProductionProgressStateDto(request.ProgressState);
        }
    }
}
