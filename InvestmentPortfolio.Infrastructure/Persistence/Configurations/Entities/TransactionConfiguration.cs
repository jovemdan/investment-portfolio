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
                .HasOne(x => x.Products)
                .WithMany()
                .HasForeignKey(transaction => transaction.ProductId);

        }
    }
}
