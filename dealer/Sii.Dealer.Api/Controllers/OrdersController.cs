using Microsoft.AspNetCore.Mvc;
using Sii.Dealer.Core.Application.Services;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Swashbuckle.AspNetCore.Annotations;
using Sii.CarOrder.Contracts.Enums;
using MediatR;
using Sii.Dealer.ReadModel.Queries;
using Sii.Dealer.Core.Application.Commands;
using Sii.Dealer.Core.Application.Queries;
using System.IO;

namespace Sii.Dealer.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
		private readonly IMediator _mediator;


		public OrdersController(IMediator mediator)
        {
			_mediator = mediator;
        }
       
        [HttpGet()]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Orders due to pagination request.", typeof(IEnumerable<OrderDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Orders not found, return error message.")]
        public async Task<IActionResult> GetOrders([FromQuery] int pageIndex=0, int pageSize=50 )
        {
            var orders = await _mediator.Send(new GetAllOrdersWithPaginationQuery() { PageIndex = pageIndex, Pagesize = pageSize });
            return Ok(orders);
        }

        [HttpGet("all")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Orders searching by code.", typeof(IEnumerable<OrderDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Orders not found, return error message.")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Order searching by code.", typeof(ReadModel.Models.OrderDetailReadModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found, return error message.")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery() { Id = id});
            return Ok(order);
        }

        [HttpPost()]
        [SwaggerResponse(StatusCodes.Status200OK, "Create, new Configuration.")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/cancelOrder")]
        [SwaggerOperation("Cancel order.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order has been canceled.", typeof(OrderDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found, return error message.")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await _mediator.Send(new CancelOrderCommand() { Id = id});
            return Ok();
        }

        [HttpPost("{id}/confirmOrder")]
        [SwaggerOperation("Confirm order.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order has been confirmed.", typeof(OrderDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found, return error message.")]
        public async Task<IActionResult> ConfirmOrder(int id, bool accept, float percentage)
        {
            await _mediator.Send(new ConfirmOrderCommand() { Id = id, Accept = accept, Percentage = percentage });
			return Ok();
        }

        [HttpPost("{id}/payments/{paymentId}")]
        [SwaggerOperation("Confirm payment.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order has been paid.", typeof(OrderDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found, return error message.")]
        public async Task<IActionResult> ConfirmPayment(int id, int paymentId)
        {
            await _mediator.Send(new ConfirmPaymentCommand() { Id = id, PaymentId = paymentId });
			return Ok();
        }

        [HttpGet("{id}/payments")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Payments searching by order.", typeof(PaymentDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Payments not found, return error message.")]
        public async Task<IActionResult> GetPaymentsByOrder(int id)
        {
            IList<PaymentDto> payments = await _mediator.Send(new GetPaymentsByOrderQuery() { Id = id});
            return payments == null ? NotFound($"Payments not found.") : Ok(payments);
        }

        [HttpGet("{id}/calculatePayments")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return calculated value of advance and other needful payments due to given advance percentage value.", typeof(PaymentDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Payments not found, return error message.")]
        public async Task<IActionResult> CalculatePaymentsByOrder(int id, [FromQuery] float percentage)
        {
            IList<PaymentDto> payments = await _mediator.Send(new CalculatePaymentsByOrderQuery() { Id = id, Percentage = percentage });

			return payments == null ? NotFound($"Payments not found.") : Ok(payments);
        }

        [HttpPost("{id}/print")]
        [SwaggerOperation("Download agreement")]
        [SwaggerResponse(StatusCodes.Status200OK, "Agreement has been downloaded")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Agreement not found, return error message.")]
        public async Task<IActionResult> GenerateInvoice(int id)
        {
            byte[] file = await _mediator.Send(new GenerateInvoiceCommand() { Id = id });
            return File(file, "application/pdf", "Agreement.pdf");
        }

        [HttpPost]
        [Route("{id}/factoryOrder")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order has been sent")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order has not been sent, return error message.")]
        public async Task<IActionResult> OrderCarConfigurationInFactory(int id)
        {
			await _mediator.Send(new OrderCarConfigurationInFactoryCommand() { Id = id });
			return Ok();
		}

        [HttpPut]
        [Route("sendNotification")]
        public async Task<IActionResult> SendNotification(NotificationType type, string message)
        {
            await _mediator.Send(new SendNotificationCommand(){ Type = type, Message = message });
            return Ok();
        }

        [HttpPost]
        [Route("{id}/collectOrder")]
        public async Task<IActionResult> CollectOrder(int id)
        {
            await _mediator.Send(new CollectOrderCommand() { Id = id });
            return Ok();
        }

        [HttpPost]
        [Route("{id}/handOver")]
        public async Task<IActionResult> HandOverOrder(int id)
        {
            await _mediator.Send(new HandOverOrderCommand() { Id = id });
            return Ok();
        }
    }
}
