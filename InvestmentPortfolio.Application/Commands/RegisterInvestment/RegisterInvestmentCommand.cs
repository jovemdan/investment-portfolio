using System;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using MediatR;

namespace InvestmentPortfolio.Application.Commands.RegisterInvestment
{
	public class RegisterInvestmentCommand : Command, IRequest<ValidationResult>
    {
        public RegisterInvestmentCommand(Guid customerId, Guid productId, DateTime purchaseDate)
        {
            CustomerId = customerId;
            ProductId = productId;
            PurchaseDate = purchaseDate;
        }

        [JsonPropertyName("customer_id")]
        public Guid CustomerId { get; private set; }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; private set; }

        [JsonPropertyName("purchase_date")]
        public DateTime PurchaseDate { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}

