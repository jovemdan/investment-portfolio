using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Product.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {
    }
}
