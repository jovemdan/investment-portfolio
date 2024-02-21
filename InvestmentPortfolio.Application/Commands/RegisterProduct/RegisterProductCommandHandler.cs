using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.RegisterProduct
{
    public class RegisterProductCommandHandler :
        CommandHandler<RegisterProductCommandHandler>,
        IRequestHandler<RegisterProductCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _repository;

        public RegisterProductCommandHandler(
            ILogger<RegisterProductCommandHandler> logger,
            IMediator mediator,
            IProductRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ValidationResult> Handle(RegisterProductCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterProductCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var product = new Product(
                id: Guid.NewGuid(),
                name: command.Name,
                price: command.Price,
                dueDate: command.DueDate
            ); ;

            await _repository.AddAsync(product);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(RegisterCustomerCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
