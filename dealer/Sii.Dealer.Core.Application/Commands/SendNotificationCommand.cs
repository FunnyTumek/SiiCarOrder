using MassTransit;
using MediatR;
using Sii.CarOrder.Contracts.Enums;
using Sii.CarOrder.Contracts.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Application.Commands
{
	public class SendNotificationCommand : IRequest
	{
		public NotificationType Type { get; set; }
		public string Message { get; set; }
		public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
		{
			private readonly IBus _bus;
			public SendNotificationCommandHandler(IBus bus)
			{
				_bus = bus;
			}
			public async Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
			{
				await _bus.Publish(new NotificationEvent(request.Type, request.Message));
				return Unit.Value;
			}
		}
	}
}
