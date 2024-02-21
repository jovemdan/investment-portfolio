using System.Text.Json.Serialization;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Application.ViewModels;

public record CustomerViewModel : BaseEntityViewModel
{
    public CustomerViewModel(
        Guid id, DateTime createAt, DateTime? lastUpdate,
        string name, string cellPhone, string mainEmail)
        : base(id, createAt, lastUpdate)
    {
        Name = name;
        CellPhone = cellPhone;
        MainEmail = mainEmail;
    }

    [JsonPropertyName("name")]
    public string Name { get; private set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; private set; } = string.Empty;

    [JsonPropertyName("cell_phone")]
    public string CellPhone { get; private set; } = string.Empty;

    [JsonPropertyName("main_email")]
    public string MainEmail { get; private set; } = string.Empty;


    public static CustomerViewModel MapFromDomain(Customer entity)
    {

        var customerViewModel = new CustomerViewModel(
            entity.Id,
            entity.CreateAt,
            entity.LastUpdate,
            entity.Name,
            entity.CellPhone,
            entity.MainEmail
        );
        return customerViewModel;
    }

    public static IEnumerable<CustomerViewModel> MapFromDomain(IList<Customer> entity)
    {
        foreach (var item in entity)
        {
            yield return MapFromDomain(item);
        }
    }
}
