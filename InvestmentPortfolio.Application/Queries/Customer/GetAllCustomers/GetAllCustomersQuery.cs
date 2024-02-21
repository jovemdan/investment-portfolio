using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerViewModel>>
    {
    }
}