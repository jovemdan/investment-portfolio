using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace InvestmentPortfolio.Application.Commands.ChangeProduct
{
    public class ChangeProductCommand : Command, IRequest<ValidationResult>
    {
        public ChangeProductCommand(Guid id, string name, decimal price, DateTime dueDate)
        {
            Id = id;
            Name = name;
            Price = price;
            DueDate = dueDate;
        }

        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; private set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; private set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; private set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
