using MediatR;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderCreationDto>
    {
        public CarConfigurationDto Configuration { get; set; }
        public CustomerOrderDto Customer { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderCreationDto>
    {
        private readonly IOrdersApplicationService _ordersApplicationService;
        public CreateOrderCommandHandler(IOrdersApplicationService ordersApplicationService)
        {
			_ordersApplicationService = ordersApplicationService;
        }

        public async Task<OrderCreationDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _ordersApplicationService.PlaceOrder(request.Configuration, request.Customer);
            return new OrderCreationDto();
        }
    }
}
