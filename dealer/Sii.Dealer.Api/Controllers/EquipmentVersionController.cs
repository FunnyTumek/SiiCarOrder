using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/equipmentversion")]
    [ApiController]
    public class EquipmentVersionController : ControllerBase

    {
        private readonly IEquipmentVersionService equipmentVersionService;
        private readonly ILogger<EquipmentVersionController> logger;

        public EquipmentVersionController(
            IEquipmentVersionService equipmentVersionService,
            ILogger<EquipmentVersionController> logger
            )
        {
            this.equipmentVersionService = equipmentVersionService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Equipment versions or only active Equipment versions.", typeof(IEnumerable<EquipmentVersionDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Equipment versions not found, return error message.")]
        public async Task<IActionResult> GetAllEquipmentVersions([FromQuery] bool onlyActive = true)
        {
            IList<EquipmentVersionDto> equipmentVersions = await equipmentVersionService.GetAll(onlyActive);
            return equipmentVersions == null ? NotFound("Equipment versions not found.") : Ok(equipmentVersions);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Equipment version searching by code.", typeof(EquipmentVersionDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Equipment version not found, return error message.")]
        public async Task<IActionResult> GetEquipmentVersionByCode([FromRoute] string code)
        {
            EquipmentVersionDto equipmentVersion = await equipmentVersionService.Get(code);
            return equipmentVersion == null ? NotFound($"EquipmentVersion not found searching by code:{code}.") : Ok(equipmentVersion);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Equipment version entity.")]
        public async Task<IActionResult> UpdateEquipmentVersion([FromBody] EquipmentVersionDto dto)
        {
            await equipmentVersionService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create new equipment version entity.")]
        public async Task<IActionResult> CreateGearbox([FromBody] EquipmentVersionDto dto)
        {
            await equipmentVersionService.Create(dto);
            return Ok();
        }
    }
}