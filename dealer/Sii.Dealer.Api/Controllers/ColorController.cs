using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/color")]
    [ApiController]
    public class ColorController : ControllerBase

    {
        private readonly IColorService colorService;
        private readonly ILogger<ColorController> logger;
       
        public ColorController(
            IColorService colorService,
            ILogger<ColorController> logger
            )
        {
            this.colorService = colorService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Colors or only active Colors, the result depends on isActive parametr.", typeof(IEnumerable<ColorDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Colors not found, return error message.")]
        public async Task<IActionResult> GetAllColors([FromQuery] bool onlyActive = true)
        {
            IList<ColorDto> colors = await colorService.GetAll(onlyActive);
            return colors == null ? NotFound($"Colors not found.") : Ok(colors);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Color searching by code.", typeof(ColorDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Color not found, return error message.")]
        public async Task<IActionResult> GetColorByCode([FromRoute] string code)
        {
            ColorDto color = await colorService.Get(code);
            return color == null ? NotFound($"Color not found searching by code:{code}.") : Ok(color);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Color entity.")]
        public async Task<IActionResult> UpdateColor([FromBody] ColorDto dto)
        {
            await colorService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Color entity.")]
        public async Task<IActionResult> CreateColor([FromBody] ColorDto dto)
        {
            await colorService.Create(dto);
            return Ok();
        }
    }
}