using FluentValidation.Results;
using InvestmentPortfolio.Application.Validations;
using MediatR;
using System.Text.Json.Serialization;

namespace InvestmentPortfolio.Application.Commands.RegisterAdministrator
{
    public class RegisterAdministratorCommand : Command, IRequest<ValidationResult>
    {
        public RegisterAdministratorCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("email")]
        public string Email { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterAdministratorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
