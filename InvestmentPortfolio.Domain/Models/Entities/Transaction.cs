using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(Guid id, Guid productId, Guid customerId, TypeEnum type, int quantity, decimal value, DateTime transactionDate): base(id)
        {
            ProductId = productId;
            CustomerId = customerId;
            Type = type;
            Quantity = quantity;
            Value = value;
            TransactionDate = transactionDate;
        }

        public Guid ProductId { get; private set; }
        public Guid CustomerId { get; private set; }
        public TypeEnum Type { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
