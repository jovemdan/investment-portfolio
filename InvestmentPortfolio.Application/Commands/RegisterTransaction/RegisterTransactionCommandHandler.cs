using System;
using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using InvestmentPortfolio.Application.Commands.RegisterInvestment;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.RegisterTransaction
{
	public class RegisterTransactionCommandHandler :
        CommandHandler<RegisterTransactionCommandHandler>,
        IRequestHandler<RegisterTransactionCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly ITransactionRepository _repository;

        public RegisterTransactionCommandHandler(
            ILogger<RegisterTransactionCommandHandler> logger,
            IMediator mediator,
            ITransactionRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(RegisterTransactionCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterTransactionCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var transaction = new Transaction(
                id: Guid.NewGuid(),
               productId: command.ProductId,
               type: command.Type,
               quantity: command.Quantity,
               value: command.Value,
               transactionDate: DateTime.Now
            ); ;

            await _repository.AddAsync(transaction);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(RegisterTransactionCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}

