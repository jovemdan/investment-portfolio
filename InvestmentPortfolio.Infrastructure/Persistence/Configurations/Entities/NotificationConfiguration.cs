using InvestmentPortfolio.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortfolio.Infrastructure.Persistence.Configurations.Entities
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.ConfigureBaseEntity();

            builder
                .HasOne(x => x.Administrators)
                .WithMany()
                .HasForeignKey(transaction => transaction.AdministratorId);
        }
    }
}
