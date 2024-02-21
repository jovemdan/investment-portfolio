using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(
            IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            if (products == null) return new List<ProductViewModel>();

            var productsViewModel = ProductViewModel.MapFromDomain(products);

            return productsViewModel;
        }
    }
}
