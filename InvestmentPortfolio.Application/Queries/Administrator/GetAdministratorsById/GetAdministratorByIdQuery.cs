using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using MediatR;

namespace InvestmentPortfolio.Application.Queries.Administrator.GetAdministratorsById
{
    public class GetAdministratorByIdQuery : IRequest<AdministratorViewModel?>
    {
        public GetAdministratorByIdQuery(Guid administratorId)
        {
            AdministratorId = administratorId;
        }

        [JsonPropertyName("administrator_id")]
        public Guid AdministratorId { get; private set; }
    }
}
