using System;
using System.Text.Json.Serialization;
using System.Transactions;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Application.ViewModels
{
	public record InvestmentViewModel : BaseEntityViewModel
    {
		public InvestmentViewModel(
            Guid id, DateTime createAt, DateTime? lastUpdate,
			Guid customerId, Guid productId, Guid transactionId, DateTime purchaseDate, bool isAvailable)
            : base(id, createAt, lastUpdate)
        {
            CustomerId = customerId;
            ProductId = productId;
            TransactionId = transactionId;
            PurchaseDate = purchaseDate;
            IsAvailable = isAvailable;
        }

        [JsonPropertyName("customer_id")]
        public Guid CustomerId { get; private set; }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; private set; }

        [JsonPropertyName("transaction_id")]
        public Guid TransactionId { get; private set; }

        [JsonPropertyName("purchase_date")]
        public DateTime PurchaseDate { get; private set; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; private set; }

        public static InvestmentViewModel MapFromDomain(Investment entity)
        {

            var customerViewModel = new InvestmentViewModel(
                entity.Id,
                entity.CreateAt,
                entity.LastUpdate,
                entity.CustomerId,
                entity.ProductId,
                entity.TransactionId,
                entity.PurchaseDate,
                entity.IsAvailable
            );
            return customerViewModel;
        }

        public static IEnumerable<InvestmentViewModel> MapFromDomain(IList<Investment> entity)
        {
            foreach (var item in entity)
            {
                yield return MapFromDomain(item);
            }
        }
    }
}

