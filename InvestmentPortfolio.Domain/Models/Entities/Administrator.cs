using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Administrator : BaseEntity
    {
        public Administrator(ICollection<Product> products)
        {
            Products = products;
        }

        public Administrator(Guid id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
