using System;
using InvestmentPortfolio.Application.Queries.Investment.GetAllInvestments;
using InvestmentPortfolio.Application.ViewModels;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using InvestmentPortfolio.Application.Commands.RegisterInvestment;
using InvestmentPortfolio.Application.Queries.Investment.GetInvestmentByCustomerId;

namespace InvestmentPortfolio.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/investment-registration")]
    public class InvestmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestmentController(IMediator mediator)
		{
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra um investimento.")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] RegisterInvestmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsValid ? NoContent() : BadRequest();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os investimento registrados.")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllInvestmentsQuery());
            return Ok(result);
        }

        [HttpGet("detail")]
        [SwaggerOperation(Summary = "Busca os investimentos de um cliente")]
        [ProducesResponseType(typeof(IEnumerable<InvestmentViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetInvestmentsByCustomerId([FromQuery] Guid customerId)
        {
            var result = await _mediator.Send(new GetInvestmentByCustomerIdQuery(customerId));
            return result != null ? Ok(result) : NotFound();
        }
    }
}

