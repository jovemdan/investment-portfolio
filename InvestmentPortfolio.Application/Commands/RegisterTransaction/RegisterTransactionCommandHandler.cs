using System;
using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.ChangeInvestment;
using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using InvestmentPortfolio.Application.Commands.RegisterInvestment;
using InvestmentPortfolio.Domain.Models;
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
        private readonly IInvestmentRepository _investmentRepository;

        public RegisterTransactionCommandHandler(
            ILogger<RegisterTransactionCommandHandler> logger,
            IMediator mediator,
            ITransactionRepository repository,
            IInvestmentRepository investmentRepository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
            _investmentRepository = investmentRepository;
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
               customerId: command.CustomerId,
               type: command.Type,
               quantity: command.Quantity,
               value: command.Value,
               transactionDate: DateTime.Now
            );



            await _repository.AddAsync(transaction);
            await _repository.CommitAsync();

            if (transaction.Type == TypeEnum.purchase)
            {
                var investmentCommand = new RegisterInvestmentCommand(
                    customerId: transaction.CustomerId,
                    productId: transaction.ProductId,
                    transactionId: transaction.Id,
                    purchaseDate: DateTime.Now,
                    isAvailable: true
                    );

                var result = await _mediator.Send(investmentCommand);
            }

            if (transaction.Type == TypeEnum.sale)
            {
                var investment = await _investmentRepository.GetByCustomerIdAndProductId(transaction.CustomerId, transaction.ProductId);
                investment.IsAvailable = false;

                if (investment != null)
                {
                    var investmentChangeCommand = new ChangeInvestmentCommand(
                           investment.Id,
                           investment.IsAvailable);

                    var result = await _mediator.Send(investmentChangeCommand);
                }
                else
                {
                    AddError("Investment not found for sale transaction");
                    return ValidationResult;
                }
            }

            _logger.LogInformation($"{nameof(RegisterTransactionCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}

