using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/additionalequipment")]
    [ApiController]
    public class AdditionalEquipmentController : ControllerBase

    {
        private readonly IAdditionalEquipmentService additionalEquipmentService;
        private readonly ILogger<AdditionalEquipmentController> logger;

        public AdditionalEquipmentController(
            IAdditionalEquipmentService additionalEquipmentService,
            ILogger<AdditionalEquipmentController> logger
            )
        {
            this.additionalEquipmentService = additionalEquipmentService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Additional equipments or only active Additional equipments.", typeof(IEnumerable<AdditionalEquipmentDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Additional equipments not found, return error message.")]
        public async Task<IActionResult> GetAllAdditionalEquipments([FromQuery] bool onlyActive = true)
        {
            IList<AdditionalEquipmentDto> additionalEquipments = await additionalEquipmentService.GetAll(onlyActive);
            return additionalEquipments == null ? NotFound("Additional equipment not found.") : Ok(additionalEquipments);
        }

        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return additional equipment searching by code.", typeof(AdditionalEquipmentDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Additional equipment not found, return error message.")]
        public async Task<IActionResult> GetAdditionalEquipmentByCode([FromRoute] string code)
        {
            AdditionalEquipmentDto additionalEquipment = await additionalEquipmentService.Get(code);
            return additionalEquipment == null ? NotFound($"Additional equipment not found searching by code: {code}.") : Ok(additionalEquipment);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update additional equipment entity.")]
        public async Task<IActionResult> UpdateAdditionalEquipment([FromBody] AdditionalEquipmentDto dto)
        {
            await additionalEquipmentService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create new additional equipment entity.")]
        public async Task<IActionResult> CreateGearbox([FromBody] AdditionalEquipmentDto dto)
        {
            await additionalEquipmentService.Create(dto);
            return Ok();
        }
    }
}