using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/engine")]
    [ApiController]
    public class EngineController : ControllerBase

    {
        private readonly IEngineService engineService;
        private readonly ILogger<EngineController> logger;
       
        public EngineController(
            IEngineService engineService,
            ILogger<EngineController> logger
            )
        {
            this.engineService = engineService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Engines or only active brands, the result depends on isActive parametr.", typeof(IEnumerable<EngineDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Engines not found, return error message.")]
        public async Task<IActionResult> GetAllEngines([FromQuery] bool onlyActive = true)
        {
            IList<EngineDto> engines = await engineService.GetAll(onlyActive);
            return engines == null ? NotFound($"Engines not found.") : Ok(engines);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Engine searching by code.", typeof(EngineDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Engine found, return error message.")]
        public async Task<IActionResult> GetEngineByCode([FromRoute] string code)
        {
            EngineDto engine = await engineService.Get(code);
            return engine == null ? NotFound($"Engine not found searching by code:{code}.") : Ok(engine);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Engine entity.")]
        public async Task<IActionResult> UpdateEngine([FromBody] EngineDto dto)
        {
            await engineService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Engine entity.")]
        public async Task<IActionResult> CreateEngine([FromBody] EngineDto dto)
        {
            await engineService.Create(dto);
            return Ok();
        }      
    }
}