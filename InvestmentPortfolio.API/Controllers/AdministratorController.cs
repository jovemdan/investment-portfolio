using InvestmentPortfolio.Application.Commands.RegisterAdministrator;
using InvestmentPortfolio.Application.Queries.Administrator.GetAdministratorsById;
using InvestmentPortfolio.Application.Queries.Administrator.GetAllAdministrators;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InvestmentPortfolio.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/administrator-registration")]
public class AdministratorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdministratorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Registra um administrador.")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Add([FromBody] RegisterAdministratorCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsValid ? NoContent() : BadRequest();
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Busca todos os administradores registrados.")]
    [ProducesResponseType(typeof(IEnumerable<AdministratorViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAdministratorsQuery());
        return Ok(result);
    }

    [HttpGet("detail")]
    [SwaggerOperation(Summary = "Busca o detalhe de um administrador registrado.")]
    [ProducesResponseType(typeof(IEnumerable<AdministratorViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAdministratorDetail([FromQuery] Guid administratorId)
    {
        var result = await _mediator.Send(new GetAdministratorByIdQuery(administratorId));
        return result != null ? Ok(result) : NotFound();
    }
}
