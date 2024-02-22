using System;
using InvestmentPortfolio.Domain.Models.Entities;
using System.Linq;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Repositories
{
	public class InvestmentRepository: IInvestmentRepository
    {
        protected InvestmentPortfolioContext _context;

        public InvestmentRepository(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Investment investment)
        {
            await _context.Investments.AddAsync(investment);
        }

        public void Update(Investment investment)
        {
            _context.Investments.Update(investment);
        }

        public void Delete(Guid investmentId)
        {
            var investment = _context.Investments.First(x => x.Id == investmentId);
            _context.Investments.Attach(investment);
            _context.Investments.Remove(investment);
        }

        #region consulting
        public async Task<Investment> FindByAsync(Func<Investment, bool> predicate)
        {
            var response = _context.Investments
                .FirstOrDefault(predicate);

            return await Task.FromResult(response!);
        }

        public async Task<List<Investment>> GetAllAsync()
        {
            return await _context.Investments
                .ToListAsync();
        }

        public async Task<List<Investment>> FindAllByAsync(Func<Investment, bool> predicate)
        {
            var response = _context.Investments.Where(predicate).ToList();
            return await Task.FromResult(response);
        }

        public async Task<Investment> GetByCustomerIdAndProductId(Guid customerId, Guid productId)
        {
            return await _context.Investments
            .FirstOrDefaultAsync(i => i.CustomerId == customerId && i.ProductId == productId);
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
      
    }
}
