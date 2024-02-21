using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Investment : BaseEntity
    {
        public Investment(Guid customerId, Guid productId, DateTime purchaseDate)
        {
            CustomerId = customerId;
            ProductId = productId;
            PurchaseDate = purchaseDate;
        }

        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
