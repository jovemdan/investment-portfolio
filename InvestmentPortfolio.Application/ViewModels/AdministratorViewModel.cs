using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Application.ViewModels;

public record AdministratorViewModel : BaseEntityViewModel
{
    public AdministratorViewModel(
        Guid id, DateTime createAt, DateTime? lastUpdate,
        string name, string email)
        : base(id, createAt, lastUpdate)
    {
        Name = name;
        Email = email;
    }

    [JsonPropertyName("name")]
    public string Name { get; private set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; private set; } = string.Empty;


    public static AdministratorViewModel MapFromDomain(Administrator entity)
    {

        var administratorViewModel = new AdministratorViewModel(
            entity.Id,
            entity.CreateAt,
            entity.LastUpdate,
            entity.Name,
            entity.Email
        );
        return administratorViewModel;
    }

    public static IEnumerable<AdministratorViewModel> MapFromDomain(IList<Administrator> entity)
    {
        foreach (var item in entity)
        {
            yield return MapFromDomain(item);
        }
    }
}
