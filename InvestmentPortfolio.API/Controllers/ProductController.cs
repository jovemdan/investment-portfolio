using InvestmentPortfolio.Application.Commands.ChangeProduct;
using InvestmentPortfolio.Application.Commands.RegisterProduct;
using InvestmentPortfolio.Application.Queries.Product.GetAllProducts;
using InvestmentPortfolio.Application.Queries.Product.GetProductsById;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/product-registration")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra um produto.")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] RegisterProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsValid ? NoContent() : BadRequest();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os produtos registrados.")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("detail")]
        [SwaggerOperation(Summary = "Busca o detalhe de um produto registrado.")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProductDetail([FromQuery] Guid productId)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(productId));
            return result != null ? Ok(result) : NotFound();
        }


        [HttpPut("change-product")]
        [SwaggerOperation(Summary = "Atualiza um produto registrado")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateProduct([FromBody] ChangeProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
