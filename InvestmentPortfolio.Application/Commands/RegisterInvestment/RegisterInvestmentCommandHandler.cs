using System;
using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.RegisterInvestment
{
	public class RegisterInvestmentCommandHandler :
        CommandHandler<RegisterInvestmentCommandHandler>,
        IRequestHandler<RegisterInvestmentCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IInvestmentRepository _repository;

        public RegisterInvestmentCommandHandler(
            ILogger<RegisterInvestmentCommandHandler> logger,
            IMediator mediator,
            IInvestmentRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(RegisterInvestmentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterInvestmentCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var investment = new Investment(
                id: Guid.NewGuid(),
                customerId: command.CustomerId,
                productId: command.ProductId,
                transactionId: command.TransactionId,
                purchaseDate: DateTime.Now,
                isAvailable: true
            ); ;

            await _repository.AddAsync(investment);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(RegisterInvestmentCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}

