using InvestmentPortfolio.Domain.Models.Entities;

namespace InvestmentPortfolio.Domain.Repositories
{
    public interface IAdministratorRepository
    {
        #region commands
        Task AddAsync(Administrator administrator);
        void Update(Administrator administrator);
        void Delete(Guid administratorId);
        #endregion

        #region queries
        Task<Administrator> FindByAsync(Func<Administrator, bool> predicate);
        Task<List<Administrator>> GetAllAsync();
        #endregion

        Task CommitAsync();
        void Dispose();
    }
}
