using Microsoft.OpenApi.Models;

namespace InvestmentPortfolio.API.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection service)
    {
        service.AddApiVersioning();

        service.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Investment Portfolio",
                Description = "API Documentation",
                Version = "1.0",
                Contact = new OpenApiContact { Name = "Danilo", Url = new Uri("https://danilo-menezes.vercel.app/") }
            });

            options.EnableAnnotations();
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investment Portfolio v1.0");
        }); 
    }
}