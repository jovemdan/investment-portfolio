using InvestmentPortfolio.Domain.Models.Entities;
using InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infrastructure.Persistence
{
    public class InvestmentPortfolioContext : DbContext
    {
        public InvestmentPortfolioContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
