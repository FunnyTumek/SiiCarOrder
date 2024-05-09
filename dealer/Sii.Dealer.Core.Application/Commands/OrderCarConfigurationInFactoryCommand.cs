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
	public class OrderCarConfigurationInFactoryCommand : IRequest
	{
		public int Id { get; set; }
		public class OrderCarConfigurationInFactoryCommandHandler : IRequestHandler<OrderCarConfigurationInFactoryCommand>
		{
			private readonly IFactoryService _factoryService;
			private readonly IOrdersApplicationService _ordersService;

			public OrderCarConfigurationInFactoryCommandHandler(IFactoryService factoryService, IOrdersApplicationService ordersService)
			{
				_factoryService = factoryService;
				_ordersService = ordersService;
			}

			public async Task<Unit> Handle(OrderCarConfigurationInFactoryCommand request, CancellationToken cancellationToken)
			{
				await _ordersService.SetStatusProduction(request.Id);
				await _factoryService.SendOrder(request.Id);

				return Unit.Value;
			}
		}
	}
}
