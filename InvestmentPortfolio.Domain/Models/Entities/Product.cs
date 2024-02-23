using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Product : BaseEntity
    {
        public Product(Guid id, string name, decimal price, DateTime dueDate) : base(id)
        {
            Name = name;
            Price = price;
            DueDate = dueDate;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DueDate { get; private set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }

        public void ChangeProduct(string name, decimal price, DateTime dueDate)
        {
            Name = name;
            Price = price;
            DueDate = dueDate;
        }
    }
}
