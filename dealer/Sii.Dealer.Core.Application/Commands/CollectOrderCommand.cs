using MassTransit;
using MediatR;
using Sii.CarOrder.Contracts.Dealer;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
	public class CollectOrderCommand : IRequest
	{
		public int Id { get; set; }
		public class CollectOrderCommandHandler : IRequestHandler<CollectOrderCommand>
		{
			private readonly IBus _bus;
			public CollectOrderCommandHandler(IBus bus)
			{
				_bus = bus;
			}
			public async Task<Unit> Handle(CollectOrderCommand request, CancellationToken cancellationToken)
			{
				await _bus.Publish(new CollectOrderEvent(request.Id));
				return Unit.Value;
			}
		}
	}
}
