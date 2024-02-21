using System;
using InvestmentPortfolio.Application.Queries.Customers.GetCustomersById;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Investment.GetInvestmentByCustomerId
{
	public class GetInvestmentByCustomerIdQueryHandler : IRequestHandler<GetInvestmentByCustomerIdQuery, IEnumerable<InvestmentViewModel>>
    {
        private readonly IInvestmentRepository _repository;

        public GetInvestmentByCustomerIdQueryHandler(
            IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InvestmentViewModel>> Handle(GetInvestmentByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var investments = await _repository.FindAllByAsync(x => x.CustomerId == request.CustomerId);

            if (investments == null) return null;

            var investmentsViewModel = InvestmentViewModel.MapFromDomain(investments);

            return investmentsViewModel;
        }
    }
}

