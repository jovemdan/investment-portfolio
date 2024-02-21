using System;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using InvestmentPortfolio.Domain.Models;
using MediatR;

namespace InvestmentPortfolio.Application.Commands.RegisterTransaction
{
	public class RegisterTransactionCommand : Command, IRequest<ValidationResult>
    {
        public RegisterTransactionCommand(Guid productId, TypeEnum type, int quantity, decimal value, DateTime transactionDate)
        {
            ProductId = productId;
            Type = type;
            Quantity = quantity;
            Value = value;
            TransactionDate = transactionDate;
        }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; private set; }

        [JsonPropertyName("type")]
        public TypeEnum Type { get; private set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; private set; }

        [JsonPropertyName("value")]
        public decimal Value { get; private set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}

