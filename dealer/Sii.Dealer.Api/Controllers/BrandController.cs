using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/configuration/brand")]
    [ApiController]
    public class BrandController : ControllerBase

    {
        private readonly IBrandService brandService;
        private readonly ILogger<BrandController> logger;
       
        public BrandController(
            IBrandService brandService,
            ILogger<BrandController> logger
            )
        {
            this.brandService = brandService;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all brands or only active brands, the result depends on isActive parametr.", typeof(IEnumerable<BrandDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Brands not found, return error message.")]

        public async Task<IActionResult> GetAllBrands([FromQuery] bool onlyActive = true)
        {
            IList<BrandDto> brands = await brandService.GetAll(onlyActive);
            return brands == null ? NotFound("Brands not found.") : Ok(brands);
        }

        [HttpGet("{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retrurn brand searching by code.", typeof(BrandDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Brands not found, return error message.")]
        public async Task<IActionResult> GetBrandByCode([FromRoute] string code)
        {
            BrandDto brand = await brandService.Get(code);
            return brand == null ? NotFound($"Brands not found searching by code:{code}.") : Ok(brand);
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Update Brand entity.")]
        public async Task<IActionResult> UpdateBrand([FromBody] BrandDto dto)
        {
            await brandService.Update(dto);
            return Ok();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new brand entity.")]
        public async Task<IActionResult> CreateBrand([FromBody] BrandDto dto)
        {
            await brandService.Create(dto);
            return Ok();
        }
    }
}