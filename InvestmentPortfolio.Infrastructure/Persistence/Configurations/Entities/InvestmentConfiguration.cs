using InvestmentPortfolio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investments");

            builder.ConfigureBaseEntity();

            builder
                .HasOne(x => x.Products)
                .WithMany()
                .HasForeignKey(transaction => transaction.ProductId);

            builder
               .HasOne(x => x.Customers)
               .WithMany()
               .HasForeignKey(transaction => transaction.CustomerId);
        }
    }
}
