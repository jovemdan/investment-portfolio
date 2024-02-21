using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Customers.GetCustomersById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(
            ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerViewModel?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.FindByAsync(x => x.Id == request.CustomerId);

            if (customer == null) return null;

            var viewModel = CustomerViewModel.MapFromDomain(customer);

            return viewModel;
        }
    }
}
