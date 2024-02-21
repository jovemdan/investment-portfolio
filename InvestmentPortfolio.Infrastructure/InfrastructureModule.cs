using InvestmentPortfolio.Domain.Repositories;
using InvestmentPortfolio.Infrastructure.Persistence;
using InvestmentPortfolio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortfolio.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services
                .AddSqlServer()
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDbContext<InvestmentPortfolioContext>(opt => {
                opt.UseSqlServer(configuration!.GetConnectionString("Default"));
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }

}
