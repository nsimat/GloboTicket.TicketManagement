using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("for-month", Name = "GetOrdersForMonth")]
        [ProducesResponseType(typeof(List<OrdersForMonthDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrdersForMonthDto>>> GetOrdersForMonth(DateTime date)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(dtos);
        }
    }
}
