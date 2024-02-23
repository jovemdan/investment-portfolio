
using System;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
	public interface IInvestmentRepository
	{
        #region commands
        Task AddAsync(Investment investment);
        void Update(Investment investment);
        void Delete(Guid investmentId);
        #endregion

        #region queries
        Task<Investment> FindByAsync(Func<Investment, bool> predicate);
        Task<List<Investment>> FindAllByAsync(Func<Investment, bool> predicate);
        Task<List<Investment>> GetAllAsync();
        Task<Investment> GetByCustomerIdAndProductId(Guid customerId, Guid productId);
        Task<Investment> GetByTransactionId(Guid transactionId);
        #endregion

        Task CommitAsync();
        void Dispose();
    }
}

