using AutoMapper;
using MediatR;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiiCarOrder.Factory.Application.Functions.Queries
{
    public class GetAllOrderProductionStatesQuery : IRequest<IEnumerable<OrderedProductionProgressStateDto>>
    {
        public int ProductionId { get; set; }

        public class GetAllOrderProductionStatesQueryHandler : IRequestHandler<GetAllOrderProductionStatesQuery, IEnumerable<OrderedProductionProgressStateDto>>
        {
            private readonly IOrderedProductionRepository _orderedProductionRepository;
            private readonly IMapper _mapper;

            public GetAllOrderProductionStatesQueryHandler(IOrderedProductionRepository orderedProductionRepository, IMapper mapper)
            {
                _orderedProductionRepository = orderedProductionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<OrderedProductionProgressStateDto>> Handle(GetAllOrderProductionStatesQuery request, CancellationToken cancellationToken)
            {
                var productionStates = await _orderedProductionRepository.GetOrderedProductionStatesListAsync(request.ProductionId);

                if (productionStates == null)
                {
                    return new List<OrderedProductionProgressStateDto>();
                }

                return _mapper.Map<List<OrderedProductionProgressStateDto>>(productionStates);
            }
        }
    }
}
