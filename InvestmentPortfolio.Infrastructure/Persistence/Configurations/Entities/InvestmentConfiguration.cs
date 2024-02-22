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
                 .HasOne(x => x.Product)
                 .WithMany()
                 .HasForeignKey(transaction => transaction.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(x => x.Customer)
               .WithMany()
               .HasForeignKey(transaction => transaction.CustomerId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
