using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
    public interface ICustomerRepository
    {
        #region commands
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Guid customerId);
        #endregion

        #region queries
        Task<Customer> FindByAsync(Func<Customer, bool> predicate);
        Task<List<Customer>> GetAllAsync();
        #endregion

        Task CommitAsync();
        void Dispose();
    }
}
