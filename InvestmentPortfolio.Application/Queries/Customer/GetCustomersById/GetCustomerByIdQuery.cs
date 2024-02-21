using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Customers.GetCustomersById
{
    public class GetCustomerByIdQuery : IRequest<CustomerViewModel?>
    {
        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        [JsonPropertyName("customer_id")]
        public Guid CustomerId { get; private set; }
    }
}
