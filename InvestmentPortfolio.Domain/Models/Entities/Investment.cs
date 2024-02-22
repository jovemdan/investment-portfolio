using System.Transactions;
using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Investment : BaseEntity
    {
        public Investment(Guid id, Guid customerId, Guid productId, Guid transactionId, DateTime purchaseDate, bool isAvailable) : base(id)
        {
            CustomerId = customerId;
            ProductId = productId;
            PurchaseDate = purchaseDate;
            TransactionId = transactionId;
            IsAvailable = isAvailable;
        }

        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid TransactionId { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public bool IsAvailable { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
