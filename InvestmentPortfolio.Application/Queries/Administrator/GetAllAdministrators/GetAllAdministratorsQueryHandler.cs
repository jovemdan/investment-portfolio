using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Repositories;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Administrator.GetAllAdministrators
{
    public class GetAllAdministratorsQueryHandler : IRequestHandler<GetAllAdministratorsQuery, IEnumerable<AdministratorViewModel>>
    {
        private readonly IAdministratorRepository _repository;

        public GetAllAdministratorsQueryHandler(
            IAdministratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdministratorViewModel>> Handle(GetAllAdministratorsQuery request, CancellationToken cancellationToken)
        {
            var administrators = await _repository.GetAllAsync();

            if (administrators == null) return new List<AdministratorViewModel>();

            var administratorsViewModel = AdministratorViewModel.MapFromDomain(administrators);

            return administratorsViewModel;
        }
    }
}
