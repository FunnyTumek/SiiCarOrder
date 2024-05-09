using MediatR;
using Sii.Dealer.Core.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
    public class CancelOrderCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrdersApplicationService _ordersApplicationService;
        public CancelOrderCommandHandler(IOrdersApplicationService ordersApplicationService)
        {
            _ordersApplicationService = ordersApplicationService;
        }

        public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            await _ordersApplicationService.CancelOrder(request.Id);
            return Unit.Value;
        }
    }
}
