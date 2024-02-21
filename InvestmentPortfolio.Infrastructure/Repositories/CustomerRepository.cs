using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected InvestmentPortfolioContext _context;
        public CustomerRepository(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Guid customerId)
        {
            var customer = _context.Customers.First(x => x.Id == customerId);
            _context.Customers.Attach(customer);
            _context.Customers.Remove(customer);
        }

        #region consulting
        public async Task<Customer> FindByAsync(Func<Customer, bool> predicate)
        {
            var response = _context.Customers
                .FirstOrDefault(predicate);

            return await Task.FromResult(response!);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers
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
    }
}
