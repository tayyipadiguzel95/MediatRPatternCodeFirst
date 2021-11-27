using CodeFirst.Commands;
using CodeFirst.Queris.Orders;
using CodeFirst.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByDeviceAsync([FromQuery] GetOrderByDeviceQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
