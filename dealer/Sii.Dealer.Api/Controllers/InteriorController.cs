using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.SharedKernel.Sales.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/interior")]
    [ApiController]
    public class InteriorController : ControllerBase

    {
        private readonly IInteriorService interiorService;
        private readonly ILogger<InteriorController> logger;
       
        public InteriorController(
            IInteriorService interiorService,
            ILogger<InteriorController> logger
            )
        {
            this.interiorService = interiorService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Interiors or only avaliable Interiors.", typeof(IEnumerable<InteriorDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Interiors not found, return error message.")]
        public async Task<IActionResult> GetAllInteriors([FromQuery] bool onlyActive = true)
        {
            IList<InteriorDto> interiors = await interiorService.GetAll(onlyActive);
            return interiors == null ? NotFound($"Interiors not found.") : Ok(interiors);
        }
        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn Interior searching by code.", typeof(OrderDetailViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Interior not found, return error message.")]

        public async Task<IActionResult> GetInteriorByCode([FromRoute] string code)
        {
            InteriorDto interior = await interiorService.Get(code);
            return interior == null ? NotFound($"Interior not found searching by code:{code}.") : Ok(interior);
        }
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Interior entity.")]
        public async Task<IActionResult> MarkInteriorAvailability([FromBody] InteriorDto dto)
        {
            await interiorService.Update(dto);
            return Ok();
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Gearbox entity.")]
        public async Task<IActionResult> CreateInterior([FromBody] InteriorDto dto)
        {
            await interiorService.Create(dto);
            return Ok();
        }
    }
}