using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/model")]
    [ApiController]
    public class ModelController : ControllerBase

    {
        private readonly IModelService modelService;
        private readonly ILogger<ModelController> logger;
       
        public ModelController(
            IModelService modelService,
            ILogger<ModelController> logger
            )
        {
            this.modelService = modelService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Models or only avaliable Models.", typeof(IEnumerable<ModelDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Models not found, return error message.")]

        public async Task<IActionResult> GetAllModels([FromQuery] bool onlyActive = true)
        {
            IList<ModelDto> models = await modelService.GetAll(onlyActive);
            return models == null ? NotFound($"Models not found.") : Ok(models);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Model searching by code.", typeof(ModelDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Model not found, return error message.")]

        public async Task<IActionResult> GetCModelByCode([FromRoute] string code)
        {
            ModelDto model = await modelService.Get(code);
            return model == null ? NotFound($"Model not found searching by code:{code}.") : Ok(model);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Model entity.")]
        public async Task<IActionResult> UpdateModel([FromBody] ModelDto dto)
        {
            await modelService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Model entity.")]
        public async Task<IActionResult> CreateModel([FromBody] ModelDto dto)
        {
            await modelService.Create(dto);
            return Ok();
        }
    }
}