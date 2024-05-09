using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/class")]
    [ApiController]
    public class CarClassController : ControllerBase

    {
        private readonly ICarClassService carClassService;
        private readonly ILogger<CarClassController> logger;
       
        public CarClassController(
            ICarClassService carClassService,
            ILogger<CarClassController> logger
            )
        {
            this.carClassService = carClassService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all CarClasses or only active CarClasses, the result depends on isActive parametr.", typeof(IEnumerable<CarClassDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Brands not found, return error message.")]
        public async Task<IActionResult> GetAllCarClasses([FromQuery] bool onlyActive = true)
        {
            IList<CarClassDto> classes = await carClassService.GetAll(onlyActive);
            return classes == null ? NotFound($"Car class not found") : Ok(classes);
        }

        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn car class searching by code.", typeof(CarClassDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Car class not found, return error message.")]
        public async Task<IActionResult> GetCarClassByCode([FromRoute] string code)
        {
            CarClassDto carClass = await carClassService.Get(code);
            return carClass == null ? NotFound($"Car class not found searching by code:{code}.") : Ok(carClass);
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update CarClass entity.")]
        public async Task<IActionResult> UpdateCarClass([FromBody] CarClassDto dto)
        {
            await carClassService.Update(dto);
            return Ok();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create new CarClass entity.")]
        public async Task<IActionResult> CreateCarClass([FromBody] CarClassDto dto)
        {
            await carClassService.Create(dto);
            return Ok();
        }
    }
}