using System;
using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Application.ViewModels
{
	public record InvestmentViewModel : BaseEntityViewModel
    {
		public InvestmentViewModel(
            Guid id, DateTime createAt, DateTime? lastUpdate,
			Guid customerId, Guid productId, DateTime purchaseDate)
            : base(id, createAt, lastUpdate)
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

        public static InvestmentViewModel MapFromDomain(Investment entity)
        {

            var customerViewModel = new InvestmentViewModel(
                entity.Id,
                entity.CreateAt,
                entity.LastUpdate,
                entity.CustomerId,
                entity.ProductId,
                entity.PurchaseDate
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

