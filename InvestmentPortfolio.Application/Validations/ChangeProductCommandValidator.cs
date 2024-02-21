using System;
using FluentValidation;
using InvestmentPortfolio.Application.Commands.ChangeProduct;
using InvestmentPortfolio.Application.Commands.RegisterAdministrator;
using InvestmentPortfolio.Application.Validations.Utils;

namespace InvestmentPortfolio.Application.Validations
{
	public class ChangeProductCommandValidator : AbstractValidator<ChangeProductCommand>
    {
		public ChangeProductCommandValidator()
		{
            RuleFor(c => c.Name).ValidateName("Name");
        }
	}
}

