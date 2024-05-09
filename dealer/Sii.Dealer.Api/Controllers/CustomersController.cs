using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Customers.DataTransferObjects;
using Sii.Dealer.Customers.Services;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customerService;

        public CustomersController(ICustomersService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var customer = await _customerService.GetByEmail(email);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpGet("identityNo")]
        public async Task<IActionResult> GetByidentityNo([FromQuery] string identityNo)
        {
            var customer = await _customerService.GetByidentityNo(identityNo);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto dto)
        {
            await _customerService.Create(dto);

            return Ok();
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update([FromRoute] string email, [FromBody] CustomerDto dto)
        {
            var isUpdated = await _customerService.UpdateAsync(email, dto);
            if (!isUpdated) return NotFound();

            return Ok();
        }
    }
}
