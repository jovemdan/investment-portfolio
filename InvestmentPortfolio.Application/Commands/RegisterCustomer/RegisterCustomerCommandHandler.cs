using MediatR;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.RegisterCustomerCommand
{
    public class RegisterCustomerCommandHandler : 
        CommandHandler<RegisterCustomerCommandHandler>,
        IRequestHandler<RegisterCustomerCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _repository;

        public RegisterCustomerCommandHandler(
            ILogger<RegisterCustomerCommandHandler> logger,
            IMediator mediator,
            ICustomerRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterCustomerCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var customer = new Customer(
                id: Guid.NewGuid(),
                name: command.Name,
                cellPhone: command.CellPhone,
                mainEmail: command.MainEmail
            ); ;

            await _repository.AddAsync(customer);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(RegisterCustomerCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
