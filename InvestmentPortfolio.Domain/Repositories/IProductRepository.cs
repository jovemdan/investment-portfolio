using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
    public interface IProductRepository
    {
        #region commands
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Guid productId);
        #endregion

        #region queries
        Task<Product> FindByAsync(Func<Product, bool> predicate);
        Task<List<Product>> GetAllAsync();
        #endregion

        Task CommitAsync();
        void Dispose();
    }
}
