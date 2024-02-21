using System;
using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
	public interface ITransactionRepository
	{
        #region commands
        Task AddAsync(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Guid transactionId);
        #endregion

        #region queries
        Task<Transaction> FindByAsync(Func<Transaction, bool> predicate);
        Task<List<Transaction>> FindAllByAsync(Func<Transaction, bool> predicate);
        Task<List<Transaction>> GetAllAsync();
        #endregion

        Task CommitAsync();
        void Dispose();
    }
}

