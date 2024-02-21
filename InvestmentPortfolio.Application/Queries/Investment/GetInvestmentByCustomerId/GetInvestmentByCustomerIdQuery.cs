using System;
using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Investment.GetInvestmentByCustomerId
{
	public class GetInvestmentByCustomerIdQuery : IRequest<IEnumerable<InvestmentViewModel>>
    {
        public GetInvestmentByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        [JsonPropertyName("customer_id")]
        public Guid CustomerId { get; private set; }
    }
}

