using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Administrator.GetAdministratorsById
{
    public class GetAdministratorByIdQueryHandler : IRequestHandler<GetAdministratorByIdQuery, AdministratorViewModel?>
    {
        private readonly IAdministratorRepository _repository;

        public GetAdministratorByIdQueryHandler(
            IAdministratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdministratorViewModel?> Handle(GetAdministratorByIdQuery request, CancellationToken cancellationToken)
        {
            var administrator = await _repository.FindByAsync(x => x.Id == request.AdministratorId);

            if (administrator == null) return null;

            var viewModel = AdministratorViewModel.MapFromDomain(administrator);

            return viewModel;
        }
    }
}
