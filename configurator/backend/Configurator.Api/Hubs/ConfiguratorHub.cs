using Microsoft.AspNetCore.SignalR;

namespace Configurator.Api.Hubs
{
	public class ConfiguratorHub : Hub<IConfiguratorHub>
	{
		public async Task SendNotification(string type, string message)
		{
			await Clients.All.SendNotification(type, message);
		}
	}
}
