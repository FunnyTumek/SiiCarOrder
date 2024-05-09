
namespace Configurator.Api.Hubs
{
	public interface IConfiguratorHub
	{
		Task SendNotification(string type, string message);
	}
}
