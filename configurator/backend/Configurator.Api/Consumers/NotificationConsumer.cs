using System.Collections.Concurrent;
using Configurator.Api.Hubs;
using MassTransit;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Sii.CarOrder.Contracts.Notifications;

namespace Configurator.Api.Consumers
{
	public class NotificationConsumer : IConsumer<NotificationEvent> 
	{
		private readonly ILogger<NotificationConsumer> _logger;
		private readonly IHubContext<ConfiguratorHub, IConfiguratorHub> _hubContext;

		public NotificationConsumer(ILogger<NotificationConsumer> logger, IHubContext<ConfiguratorHub, IConfiguratorHub> hubContext)
		{
			_logger = logger;
			_hubContext = hubContext;
		}

		public async Task Consume(ConsumeContext<NotificationEvent> context)
		{
			await _hubContext.Clients.All.SendNotification(context.Message.Type.ToString(), context.Message.Message);
		}
	}
}
