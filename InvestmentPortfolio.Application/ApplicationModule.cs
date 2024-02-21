using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using InvestmentPortfolio.Application.Validations;

namespace InvestmentPortfolio.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services
            .AddValidators()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterCustomerCommandValidator>(ServiceLifetime.Scoped);
        services.AddValidatorsFromAssemblyContaining<RegisterAdministratorCommandValidator>(ServiceLifetime.Scoped);
        services.AddValidatorsFromAssemblyContaining<RegisterProductCommandValidator>(ServiceLifetime.Scoped);

        return services;
    }
}
