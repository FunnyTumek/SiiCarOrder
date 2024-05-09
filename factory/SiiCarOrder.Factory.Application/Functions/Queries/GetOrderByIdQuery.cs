using AutoMapper;
using MediatR;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Infrastructure.Repositories;

namespace SiiCarOrder.Factory.Application.Functions.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderedProductionDto>
    {
        public int Id { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderedProductionDto>
        {
            private readonly IOrderedProductionRepository _orderedProductionRepository;
            private readonly IMapper mapper;

            public GetOrderByIdQueryHandler(IOrderedProductionRepository orderedProductionRepository, IMapper mapper)
            {
                _orderedProductionRepository = orderedProductionRepository;
                this.mapper = mapper;
            }

            public async Task<OrderedProductionDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
            {
                var orderedProduction = await _orderedProductionRepository.GetByIdAsync(query.Id);

                if (orderedProduction == null)
                {
                    return new OrderedProductionDto();
                }

                return mapper.Map<OrderedProductionDto>(orderedProduction);
            }
        }
    }
}
