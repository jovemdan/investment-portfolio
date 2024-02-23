using InvestmentPortfolio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.ConfigureBaseEntity();

            builder
             .HasMany(s => s.Administrators)
             .WithMany(c => c.Products)
             .UsingEntity(j => j.ToTable("ProductAdministrator"));
        }
    }
}
