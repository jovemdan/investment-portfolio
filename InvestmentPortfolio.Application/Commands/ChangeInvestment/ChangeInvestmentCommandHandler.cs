using System;
using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.ChangeProduct;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentPortfolio.Application.Commands.ChangeInvestment
{
	public class ChangeInvestmentCommandHandler :
        CommandHandler<ChangeInvestmentCommandHandler>,
        IRequestHandler<ChangeInvestmentCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IInvestmentRepository _repository;

        public ChangeInvestmentCommandHandler(
            ILogger<ChangeInvestmentCommandHandler> logger,
            IMediator mediator,
            IInvestmentRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(ChangeInvestmentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ChangeProductCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var investment = await _repository.FindByAsync(x => x.Id == command.Id);

            if (investment == null)
            {
                AddError("Product not found");
                return ValidationResult;
            }

            investment.ChangeInvestment(command.IsAvailable);

            _repository.Update(investment);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(ChangeProductCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}

