using FluentValidation;
using InvestmentPortfolio.Application.Commands.RegisterAdministrator;
using InvestmentPortfolio.Application.Validations.Utils;

namespace InvestmentPortfolio.Application.Validations
{
    public class RegisterAdministratorCommandValidator : AbstractValidator<RegisterAdministratorCommand>
    {
        public RegisterAdministratorCommandValidator()
        {
            RuleFor(c => c.Name).ValidateName("Name");
            RuleFor(c => c.Email).ValidateNullOrEmpty("Email");
        }
    }
}
