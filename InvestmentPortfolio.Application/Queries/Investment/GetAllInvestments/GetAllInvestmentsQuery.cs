using System;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Investment.GetAllInvestments
{
	public class GetAllInvestmentsQuery : IRequest<IEnumerable<InvestmentViewModel>>
    {
	}
}

