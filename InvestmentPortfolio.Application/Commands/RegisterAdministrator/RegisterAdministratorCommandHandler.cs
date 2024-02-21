using FluentValidation.Results;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.RegisterAdministrator
{
    public class RegisterAdministratorCommandHandler :
        CommandHandler<RegisterAdministratorCommandHandler>,
        IRequestHandler<RegisterAdministratorCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IAdministratorRepository _repository;
        public RegisterAdministratorCommandHandler(
            ILogger<RegisterAdministratorCommandHandler> logger,
            IMediator mediator,
            IAdministratorRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(RegisterAdministratorCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterAdministratorCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var administrator = new Administrator(
                id: Guid.NewGuid(),
                name: command.Name,
                email: command.Email
            ); ;

            await _repository.AddAsync(administrator);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(RegisterAdministratorCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
