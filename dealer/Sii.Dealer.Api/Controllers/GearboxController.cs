using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/gearbox")]
    [ApiController]
    public class GearboxController : ControllerBase

    {
        private readonly IGearboxService gearboxService;
        private readonly ILogger<GearboxController> logger;
       
        public GearboxController(
            IGearboxService gearboxService,
            ILogger<GearboxController> logger
            )
        {
            this.gearboxService = gearboxService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Gearboxes or only active brands, the result depends on isActive parametr.", typeof(IEnumerable<GearboxDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Gearboxes not found, return error message.")]
        public async Task<IActionResult> GetAllGearboxes([FromQuery] bool onlyActive = true)
        {
            IList<GearboxDto> gearboxes = await gearboxService.GetAll(onlyActive);
            return gearboxes == null ? NotFound($"Gearboxes not found.") : Ok(gearboxes);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Gearbox searching by code.", typeof(IEnumerable<GearboxDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Engines not found, return error message.")]
        public async Task<IActionResult> GetGearboxByCode([FromRoute] string code)
        {
            GearboxDto gearbox = await gearboxService.Get(code);
            return gearbox == null ? NotFound($"Gearbox not found searching by code:{code}.") : Ok(gearbox);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Gearbox entity.")]
        public async Task<IActionResult> UpdateGearbox([FromBody] GearboxDto dto)
        {
            await gearboxService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Gearbox entity.")]
        public async Task<IActionResult> CreateGearbox([FromBody] GearboxDto dto)
        {
            await gearboxService.Create(dto);
            return Ok();
        } 
    }
}