using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected InvestmentPortfolioContext _context;
        public ProductRepository(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Guid productId)
        {
            var product = _context.Products.First(x => x.Id == productId);
            _context.Products.Attach(product);
            _context.Products.Remove(product);
        }

        #region consulting
        public async Task<Product> FindByAsync(Func<Product, bool> predicate)
        {
            var response = _context.Products
                .FirstOrDefault(predicate);

            return await Task.FromResult(response!);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
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
