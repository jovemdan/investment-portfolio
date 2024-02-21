using System;
using System.Linq;
using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Repositories
{
	public class TransactionRepository : ITransactionRepository
    {
        protected InvestmentPortfolioContext _context;

        public TransactionRepository(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }

        public void Delete(Guid transactionId)
        {
            var transaction = _context.Transactions.First(x => x.Id == transactionId);
            _context.Transactions.Attach(transaction);
            _context.Transactions.Remove(transaction);
        }

        #region consulting
        public async Task<Transaction> FindByAsync(Func<Transaction, bool> predicate)
        {
            var response = _context.Transactions
                .FirstOrDefault(predicate);

            return await Task.FromResult(response!);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .ToListAsync();
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> FindAllByAsync(Func<Transaction, bool> predicate)
        {
            var response = _context.Transactions.Where(predicate).ToList();
            return await Task.FromResult(response);
        }
    }
}

