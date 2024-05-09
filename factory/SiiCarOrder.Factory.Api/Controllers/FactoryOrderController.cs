using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;
using SiiCarOrder.Factory.Application.Functions.Queries;
using Swashbuckle.AspNetCore.Annotations;
using SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder;
using SiiCarOrder.Factory.Scheduler.Service;

namespace SiiCarOrder.Factory.Api.Controllers
{
    [ApiController]
    [Route("api/factory")]
    public class FactoryOrderController : ControllerBase
    {
        private readonly ILogger<FactoryOrderController> logger;
        private readonly IMediator mediator;
        private readonly ICarsProductionService _carsProductionService;

		public FactoryOrderController(ILogger<FactoryOrderController> logger, IMediator mediator, ICarsProductionService carsProductionService)
		{
			this.logger = logger;
			this.mediator = mediator;
			_carsProductionService = carsProductionService;
		}
    

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all ordered productions.", typeof(IEnumerable<OrderedProductionDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Ordered productions not found, return error message.")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return ordered production searching by id.", typeof(OrderedProductionDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Ordered production not found, return error message.")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await mediator.Send(new GetOrderByIdQuery() {  Id = id});
            return Ok(order);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Create new OrderedProduction entity.")]
        public async Task<IActionResult> Create([FromBody] CreateFactoryOrderCommand command)
        {
            var car = await mediator.Send(command);
            var orderedProductionFeedbackDto = new OrderedProductionFeedbackDto(car.FactoryId, car.PlannedDeliveryDate);
            logger.LogInformation("Order created with id {id}.", car.FactoryId);
            return Ok(orderedProductionFeedbackDto);
        }

        [HttpGet]
        [Route("{productionId}/getProductionStates")]
        public async Task<IActionResult> GetProductionStates(int productionId)
        {
            var states = await mediator.Send(new GetAllOrderProductionStatesQuery() { ProductionId = productionId });
            return Ok(states);
        }

		[HttpPut("cancel")]
		[SwaggerResponse(StatusCodes.Status200OK, "Canceled production of car.")]
		public async Task<IActionResult> Cancel(int id, Guid carVin, string? reason)
		{
            await _carsProductionService.CancelProduction(id, carVin, reason);
			return Ok();
		}
	}
}
