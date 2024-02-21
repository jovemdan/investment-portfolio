using InvestmentPortfolio.Application.ViewModels;
using MediatR;
using System.Text.Json.Serialization;

namespace InvestmentPortfolio.Application.Queries.Product.GetProductsById
{
    public class GetProductByIdQuery : IRequest<ProductViewModel?>
    {
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; private set; }
    }
}
