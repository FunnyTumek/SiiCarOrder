using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Swashbuckle.AspNetCore.Annotations;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/available")]
    [ApiController]
    public class AvailableConfigurationController : ControllerBase
    {
        private IAvailableConfigurationsService _availableConfigurationsService;

        public AvailableConfigurationController(IAvailableConfigurationsService availableConfigurationsService)
        {
            _availableConfigurationsService = availableConfigurationsService;
        }

        [HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, "Returns all available configurations", typeof(IList<CarConfigurationDto>))]
		public async Task<IActionResult> GetAllAvailableConfigurations()
		{
			var response = await _availableConfigurationsService.GetAll();
			return Ok(response);
		}

		[HttpPost]
		[SwaggerResponse(StatusCodes.Status200OK, "Created new available configuration")]
		public async Task<IActionResult> Save([FromBody] AvailableCarConfigurationDto availableConfigurationToAdd)
		{
			var response = await _availableConfigurationsService.SaveAsync(availableConfigurationToAdd);
			return Ok(response);
		}
	}
}
