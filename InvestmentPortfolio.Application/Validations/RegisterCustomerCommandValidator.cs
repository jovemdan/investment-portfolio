using InvestmentPortfolio.Application.Commands.RegisterCustomerCommand;
using FluentValidation;
using InvestmentPortfolio.Application.Validations.Utils;

namespace InvestmentPortfolio.Application.Validations;
public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(c => c.Name).ValidateName("Name");
        RuleFor(c => c.CellPhone).ValidateNullOrEmpty("CellPhone");
        RuleFor(c => c.MainEmail).ValidateNullOrEmpty("MainEmail");
    }
}
