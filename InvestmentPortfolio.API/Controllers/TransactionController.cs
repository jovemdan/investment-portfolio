using System;
using InvestmentPortfolio.Application.Commands.RegisterInvestment;
using InvestmentPortfolio.Application.Queries.Investment.GetAllInvestments;
using InvestmentPortfolio.Application.Queries.Investment.GetInvestmentByCustomerId;
using InvestmentPortfolio.Application.ViewModels;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
using InvestmentPortfolio.Application.Commands.RegisterTransaction;
using InvestmentPortfolio.Application.Queries.Transaction.GetTransactionsByProduct;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/transaction-registration")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra uma transação. type - compra = 1 - venda = 2,")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)] 
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] RegisterTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsValid ? NoContent() : BadRequest(error: result.Errors);
        }


        [HttpGet("detail")]
        [SwaggerOperation(Summary = "Busca o extrato de um produto.")]
        [ProducesResponseType(typeof(IEnumerable<TransactionViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTransactionsByProductId([FromQuery] Guid productId)
        {
            var result = await _mediator.Send(new GetTransactionsByProductQuery(productId));
            return result != null ? Ok(result) : NotFound();
        }
    }
}

