using InvestmentPortfolio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.ConfigureBaseEntity();

            builder
              .HasOne(x => x.Product)
              .WithMany(a => a.Transactions)
              .HasForeignKey(transaction => transaction.ProductId)
              .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Customer)
                .WithMany(a => a.Transactions)
                .HasForeignKey(transaction => transaction.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
