using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Product.GetProductsById
{
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel?>
    {
        private readonly IProductRepository _repository;

        public GetProductsByIdQueryHandler(
            IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductViewModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByAsync(x => x.Id == request.ProductId);

            if (product == null) return null;

            var viewModel = ProductViewModel.MapFromDomain(product);

            return viewModel;
        }
    }
}
