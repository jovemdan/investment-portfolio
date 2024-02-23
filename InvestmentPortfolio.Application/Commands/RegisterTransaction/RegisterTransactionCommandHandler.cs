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

            if (command.Type == TypeEnum.purchase)
            {
                var investment = await _investmentRepository.GetByCustomerIdAndProductId(command.CustomerId, command.ProductId);

                if(investment is not null)
                {
                    AddError("You already have this product.");
                    return ValidationResult;
                }
                else
                {
                    var transaction = await CreateTransaction(command);

                    var investmentCommand = new RegisterInvestmentCommand(
                       customerId: transaction.CustomerId,
                       productId: transaction.ProductId,
                       transactionId: transaction.Id,
                       purchaseDate: DateTime.Now,
                       isAvailable: true);

                    var result = await _mediator.Send(investmentCommand);
                }
            }

            if (command.Type == TypeEnum.sale)
            {
                var investment = await _investmentRepository.GetByCustomerIdAndProductId(command.CustomerId, command.ProductId);

                if (investment is not null)
                {
                    await CreateTransaction(command);

                    investment.IsAvailable = false;

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


        public async Task<Transaction> CreateTransaction(RegisterTransactionCommand command)
        {
                var transaction = new Transaction(
                   id: Guid.NewGuid(),
                   productId: command.ProductId,
                   customerId: command.CustomerId,
                   type: command.Type,
                   quantity: command.Quantity,
                   value: command.Value,
                   transactionDate: DateTime.Now);

            await _repository.AddAsync(transaction);
            await _repository.CommitAsync();

            return transaction;
        }
    }
}

