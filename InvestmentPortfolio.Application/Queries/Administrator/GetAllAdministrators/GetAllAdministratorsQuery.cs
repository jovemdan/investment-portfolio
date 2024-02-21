using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Administrator.GetAllAdministrators
{
    public class GetAllAdministratorsQuery : IRequest<IEnumerable<AdministratorViewModel>>
    {
    }
}