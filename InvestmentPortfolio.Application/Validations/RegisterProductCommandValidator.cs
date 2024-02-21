using FluentValidation;
using InvestmentPortfolio.Application.Commands.RegisterProduct;
using InvestmentPortfolio.Application.Validations.Utils;

namespace InvestmentPortfolio.Application.Validations
{
    public class RegisterProductCommandValidator : AbstractValidator<RegisterProductCommand>
    {
        public RegisterProductCommandValidator()
        {
            RuleFor(c => c.Name).ValidateName("Name");
            RuleFor(c => c.Price).ValidateNullOrEmpty("Price");
            RuleFor(c => c.DueDate).ValidateNullOrEmpty("DueDate");
        }
    }
}
