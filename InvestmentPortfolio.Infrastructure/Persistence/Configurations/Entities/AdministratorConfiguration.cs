using InvestmentPortfolio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrators");

            builder.ConfigureBaseEntity();

            builder
                .HasMany(s => s.Products)
                .WithMany(c => c.Administrators)
                .UsingEntity(j => j.ToTable("ProductAdministrator"));
        }
    }
}
