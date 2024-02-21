using System;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Investment.GetAllInvestments
{
	public class GetAllInvestmentsQueryHandler : IRequestHandler<GetAllInvestmentsQuery, IEnumerable<InvestmentViewModel>>
    {
        private readonly IInvestmentRepository _repository;

        public GetAllInvestmentsQueryHandler(
            IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InvestmentViewModel>> Handle(GetAllInvestmentsQuery request, CancellationToken cancellationToken)
        {
            var investments = await _repository.GetAllAsync();

            if (investments == null) return new List<InvestmentViewModel>();

            var investmentsViewModel = InvestmentViewModel.MapFromDomain(investments);

            return investmentsViewModel;
        }
    }
}

