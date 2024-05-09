using System.ComponentModel.DataAnnotations;

namespace Configurator.Api.DataAccess;

public class ConfigurationsDatabaseSettings
{
	[Required]
	public string ConnectionString { get; set; } = string.Empty;

	[Required]
	public string DatabaseName { get; set; } = string.Empty;

	[Required]
	public string AvailableConfigurationsCollectionName { get; set; } = string.Empty;

	[Required]
	public string SavedConfigurationsCollectionName { get; set; } = string.Empty;
}
