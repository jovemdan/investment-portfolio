using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.Validations;
using FluentValidation.Results;
using MediatR;

namespace InvestmentPortfolio.Application.Commands.RegisterCustomerCommand
{
    public class RegisterCustomerCommand : Command, IRequest<ValidationResult>
    {
        public RegisterCustomerCommand(
            string name,
            string cellPhone, 
            string mainEmail)
        {
            Name = name;
            CellPhone = cellPhone;
            MainEmail = mainEmail;
        }

        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("cell_phone")]
        public string CellPhone { get; private set; }

        [JsonPropertyName("main_email")]
        public string MainEmail { get; private set; }

        public override bool IsValid() 
        {
            ValidationResult = new RegisterCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
