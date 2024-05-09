using System.ComponentModel.DataAnnotations;

namespace Configurator.Api
{
	public class DefaultCarConfigurationSettings
	{
		[Required]
		public string FileName { get; set; } = string.Empty;
	}
}
