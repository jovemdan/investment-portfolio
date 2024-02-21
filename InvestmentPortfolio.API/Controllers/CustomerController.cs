using System.Net;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using Swashbuckle.AspNetCore.Annotations;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Application.Queries.Customer.GetAllCustomers;
using InvestmentPortfolio.Application.Queries.Customers.GetCustomersById;

namespace InvestmentPortfolio.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/customer-registration")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Registra um cliente.")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Add([FromBody] RegisterCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsValid ? NoContent() : BadRequest();
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Busca todos os clientes registrados.")]
    [ProducesResponseType(typeof(IEnumerable<CustomerViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }

    [HttpGet("detail")]
    [SwaggerOperation(Summary = "Busca o detalhe de um cliente registrado.")]
    [ProducesResponseType(typeof(IEnumerable<CustomerViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCustomerDetail([FromQuery] Guid customerId)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(customerId));
        return result != null ? Ok(result) : NotFound();
    }
}
