using InvestmentPortfolio.Domain.Models.Abstracts;

namespace InvestmentPortfolio.Domain.Models.Entities
{
    public class Notification : BaseEntity
    {
        public Notification(Guid administratorId, Guid message, DateTime sentDate)
        {
            AdministratorId = administratorId;
            Message = message;
            SentDate = sentDate;
        }

        public Guid AdministratorId { get; private set; }
        public Guid Message { get; private set; }
        public DateTime SentDate { get; private set; }

        public virtual Administrator Administrator { get; set; }
    }
}
