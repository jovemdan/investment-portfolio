using FluentValidation.Results;
using InvestmentPortfolio.Application.Validations;
using MediatR;
using System.Text.Json.Serialization;

namespace InvestmentPortfolio.Application.Commands.RegisterProduct
{
    public class RegisterProductCommand : Command, IRequest<ValidationResult>
    {
        public RegisterProductCommand(string name, decimal price, DateTime dueDate)
        {
            Name = name;
            Price = price;
            DueDate = dueDate;
        }

        [JsonPropertyName("name")]
        public string Name { get; private set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; private set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
