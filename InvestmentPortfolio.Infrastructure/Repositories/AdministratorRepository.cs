using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        protected InvestmentPortfolioContext _context;
        public AdministratorRepository(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Administrator administrator)
        {
            await _context.Administrators.AddAsync(administrator);
        }

        public void Update(Administrator administrator)
        {
            _context.Administrators.Update(administrator);
        }

        public void Delete(Guid administratorId)
        {
            var administrator = _context.Administrators.First(x => x.Id == administratorId);
            _context.Administrators.Attach(administrator);
            _context.Administrators.Remove(administrator);
        }

        #region consulting
        public async Task<Administrator> FindByAsync(Func<Administrator, bool> predicate)
        {
            var response = _context.Administrators
                .FirstOrDefault(predicate);

            return await Task.FromResult(response!);
        }

        public async Task<List<Administrator>> GetAllAsync()
        {
            return await _context.Administrators
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
