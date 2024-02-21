using FluentValidation.Results;
using InvestmentPortfolio.Application.Commands.RegisterProduct;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Application.Commands.ChangeProduct
{
    public class ChangeProductCommandHandler :
        CommandHandler<ChangeProductCommandHandler>,
        IRequestHandler<ChangeProductCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _repository;

        public ChangeProductCommandHandler(
            ILogger<ChangeProductCommandHandler> logger,
            IMediator mediator,
            IProductRepository repository) : base(logger)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(ChangeProductCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ChangeProductCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var product = await _repository.FindByAsync(x => x.Id == command.Id);

            if (product == null)
            {
                AddError("Product not found");
                return ValidationResult;
            }

            product.ChangeProduct(command.Name, command.Price, command.DueDate);

            _repository.Update(product);
            await _repository.CommitAsync();

            _logger.LogInformation($"{nameof(ChangeProductCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
