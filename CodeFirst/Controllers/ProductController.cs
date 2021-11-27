using CodeFirst.Commands;
using CodeFirst.Queris;
using CodeFirst.Requests;
using CodeFirst.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            if (product == null)
                return BadRequest();
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var product = await _mediator.Send(new CreateProductCommand() { CreateProduct = request });
            if (product == default)
                return BadRequest();
            return Ok(product);
        }

    }
}
