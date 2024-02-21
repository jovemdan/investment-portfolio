using InvestmentPortfolio.Domain.Models.Entities;
using System.Text.Json.Serialization;

namespace InvestmentPortfolio.Application.ViewModels
{
    public record ProductViewModel : BaseEntityViewModel
    {
        public ProductViewModel(
             Guid id, DateTime createAt, DateTime? lastUpdate,
             string name, decimal price, DateTime dueDate)
             : base(id, createAt, lastUpdate)
        {
            Name = name;
            Price = price;
            DueDate = dueDate;
        }

        [JsonPropertyName("name")]
        public string Name { get; private set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; private set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; private set; }

        public static ProductViewModel MapFromDomain(Product entity)
        {

            var productViewModel = new ProductViewModel(
                entity.Id,
                entity.CreateAt,
                entity.LastUpdate,
                entity.Name,
                entity.Price,
                entity.DueDate
            );
            return productViewModel;
        }

        public static IEnumerable<ProductViewModel> MapFromDomain(IList<Product> entity)
        {
            foreach (var item in entity)
            {
                yield return MapFromDomain(item);
            }
        }
    }
}
