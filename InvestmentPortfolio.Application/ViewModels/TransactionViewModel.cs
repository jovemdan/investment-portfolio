using System;
using System.Text.Json.Serialization;
using InvestmentPortfolio.Domain.Models;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Application.ViewModels
{
	public record TransactionViewModel : BaseEntityViewModel
    {
        public TransactionViewModel(
            Guid id, DateTime createAt, DateTime? lastUpdate,
            Guid productId, TypeEnum type, int quantity, decimal value, DateTime transactionDate)
            : base(id, createAt, lastUpdate)
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

        public static TransactionViewModel MapFromDomain(Transaction entity)
        {

            var transactionViewModel = new TransactionViewModel(
                entity.Id,
                entity.CreateAt,
                entity.LastUpdate,
                entity.ProductId,
                entity.Type,
                entity.Quantity,
                entity.Value,
                entity.TransactionDate
            );
            return transactionViewModel;
        }

        public static IEnumerable<TransactionViewModel> MapFromDomain(IList<Transaction> entity)
        {
            foreach (var item in entity)
            {
                yield return MapFromDomain(item);
            }
        }
    }
}

