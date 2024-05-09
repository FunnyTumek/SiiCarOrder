using Configurator.Api.Application.Services;
using Configurator.Api.Dtos.Contracts;
using Configurator.Api.Dtos.Contracts.CarConfigurationParts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Configurator.Api.Controllers;

[ApiController]
[Route("api/configuration")]
public class ConfigurationController : ControllerBase
{
	private readonly ISavedConfigurationsService _savedConfigurationsService;
	private readonly IAvailableConfigurationsService _availableConfigurationsService;
	private readonly IDefaultConfigurationsService _defaultConfigurationsService;

	public ConfigurationController(
		ISavedConfigurationsService savedConfigurationsService,
		IAvailableConfigurationsService availableConfigurationsService,
		IDefaultConfigurationsService defaultConfigurationsService)
	{
		_savedConfigurationsService = savedConfigurationsService;
		_availableConfigurationsService = availableConfigurationsService;
		_defaultConfigurationsService = defaultConfigurationsService;
	}

	[HttpGet]
	[Route("available")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns all available configurations", typeof(IEnumerable<CarConfigurationDto>))]
	public async Task<IActionResult> GetAvailableConfigurations()
	{
		var response = await _availableConfigurationsService.GetAvailableConfigurationsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("{id}")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns the configuration with the given id", typeof(CarConfigurationDto))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Configuration not found, returns error message", typeof(string))]
	public async Task<IActionResult> GetConfiguration([FromRoute] string id)
	{
		var response = await _savedConfigurationsService.GetByIdAsync(id);
		if (response is null)
		{
			return NotFound($"Configuration with id \"{id}\" does not exist.");
		}
		return Ok(response);
	}

	[HttpPost]
	[SwaggerResponse(StatusCodes.Status201Created, "Configuration saved successfully, returns created configuratoin id", typeof(string))]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Configuration validation failed, return validation errors", typeof(ValidationErrorResponse))]
	public async Task<IActionResult> SaveConfiguration(
		[FromBody] CarConfigurationBaseDto request,
		[FromServices] IValidator<CarConfigurationBaseDto> validator)
	{
		var validationResult = validator.Validate(request);
		if (!validationResult.IsValid)
		{
			return BadRequest(new ValidationErrorResponse(
				title: "Invalid request",
				errors: validationResult.Errors.Select(f => f.ErrorMessage)));
		}
		string id = await _savedConfigurationsService.SaveAsync(request);
		return CreatedAtAction(nameof(GetConfiguration), new { Id = id }, id);
	}

	[HttpPost]
	[Route("order")]
	public async Task<IActionResult> OrderConfiguration(
		[FromBody] CreateOrderDto request,
		[FromServices] IOrdersService ordersService)
	{
		await ordersService.SendOrder(request);
		return Ok();
	}

	[HttpGet]
	[Route("available/brand")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available brands for configurator", typeof(IEnumerable<CarBrandDto>))]
	public async Task<IActionResult> GetAvailableBrands()
	{
		var response = await _availableConfigurationsService.GetAvailableBrandsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/models")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available models for configurator", typeof(IEnumerable<CarModelDto>))]
	public async Task<IActionResult> GetAvailableModels()
	{
		var response = await _availableConfigurationsService.GetAvailableModelsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/classes")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available classes for configurator", typeof(IEnumerable<CarClassDto>))]
	public async Task<IActionResult> GetCarClassDataForConfigurator()
	{
		var response = await _availableConfigurationsService.GetAvailableClassesAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/equipmentVersions")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available equipment versions for configurator", typeof(IEnumerable<CarEquipmentVersionDto>))]
	public async Task<IActionResult> GetAvailableEquipmentVersions()
	{
		var response = await _availableConfigurationsService.GetAvailableEquipmentVersionsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/additionalEquipment")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available additional equipment for configurator", typeof(IEnumerable<CarAdditionalEquipmentDto>))]
	public async Task<IActionResult> GetAvailableAdditionalEquipment()
	{
		var response = await _availableConfigurationsService.GetAvailableAdditionalEquipmentAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/colors")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available colors for configurator", typeof(IEnumerable<CarColorDto>))]
	public async Task<IActionResult> GetAvailableColors()
	{
		var response = await _availableConfigurationsService.GetAvailableColorsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/interiors")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available interiors for configurator", typeof(IEnumerable<CarInteriorDto>))]
	public async Task<IActionResult> GetAvailableInteriors()
	{
		var response = await _availableConfigurationsService.GetAvailableInteriorsAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/engines")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available engines for configurator", typeof(CarEngineDto))]
	public async Task<IActionResult> GetAvailableEngines()
	{
		var response = await _availableConfigurationsService.GetAvailableEnginesAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("available/gearboxes")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns available gearboxes for configurator", typeof(CarGearboxDto))]
	public async Task<IActionResult> GetAvailableGearboxes()
	{
		var response = await _availableConfigurationsService.GetAvailableGearboxesAsync();
		return Ok(response);
	}

	[HttpGet]
	[Route("defaultConfiguration")]
	[SwaggerResponse(StatusCodes.Status200OK, "Returns default configuration", typeof(CarConfigurationDto))]
	public async Task<IActionResult> GetDefaultConfiguration()
	{
		var response = await _defaultConfigurationsService.GetDataForDefaultConfigurationAsync();
		return Ok(response);
	}
}
