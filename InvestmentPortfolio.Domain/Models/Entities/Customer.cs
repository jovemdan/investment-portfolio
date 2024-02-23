using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(Guid id, string name, string cellPhone, string mainEmail) : base(id)
        {
            Name = name;
            CellPhone = cellPhone;
            MainEmail = mainEmail;
        }

        public string Name { get; private set; }
        public string CellPhone { get; private set; }
        public string MainEmail { get; private set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
