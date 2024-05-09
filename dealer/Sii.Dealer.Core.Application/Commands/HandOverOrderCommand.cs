using MediatR;
using Sii.Dealer.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
	public class HandOverOrderCommand : IRequest
	{
		public int Id { get; set; }
		public class HandOverOrderCommandHandler : IRequestHandler<HandOverOrderCommand>
		{
			private readonly IOrdersApplicationService _ordersService;
			public HandOverOrderCommandHandler(IOrdersApplicationService ordersService)
			{
				_ordersService = ordersService;
			}

			public async Task<Unit> Handle(HandOverOrderCommand request, CancellationToken cancellationToken)
			{
				await _ordersService.SetStatusToDelivered(request.Id);
				return Unit.Value;
			}
		}
	}
}
