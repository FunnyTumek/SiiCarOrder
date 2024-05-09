using AutoMapper;
using MediatR;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Repositories;

namespace SiiCarOrder.Factory.Application.Functions.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderedProductionDto>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderedProductionDto>>
        {
            private readonly IOrderedProductionRepository _orderedProductionRepository;
            private readonly IMapper mapper;

            public GetAllOrdersQueryHandler(IOrderedProductionRepository orderedProductionRepository, IMapper mapper)
            {
                _orderedProductionRepository = orderedProductionRepository;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<OrderedProductionDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orderedProductions = await _orderedProductionRepository.GetAllAsync();

                if (orderedProductions == null)
                {
                    return new List<OrderedProductionDto>();
                }

                return mapper.Map<List<OrderedProductionDto>>(orderedProductions);
            }
        }
    }
}
