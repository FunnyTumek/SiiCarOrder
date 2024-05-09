using System.ComponentModel.DataAnnotations;

namespace Configurator.Api.Application;

public class RedisSettings
{
	[Required]
	public string ConfigurationString { get; set; } = string.Empty;

	[Required]
	public TimeSpan CacheTime { get; set; }
}
