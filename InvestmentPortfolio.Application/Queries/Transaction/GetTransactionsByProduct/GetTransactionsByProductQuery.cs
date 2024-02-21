using System;
using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Transaction.GetTransactionsByProduct
{
	public class GetTransactionsByProductQuery : IRequest<IEnumerable<TransactionViewModel>>
    {
        public GetTransactionsByProductQuery(Guid productId)
        {
            ProductId = productId;
        }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; private set; }
    }
}

