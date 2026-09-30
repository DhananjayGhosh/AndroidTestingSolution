using Android.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Android.Application.Interfaces;
using Android.Infrastructure.Repositories;

namespace Android.Infrastructure
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseconfigurationSettings>(configuration.GetSection("DatabaseconfigurationSettings"));
            // Register PostgreSQL DbContext
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                var databaseSettings = serviceProvider
                    .GetRequiredService<IOptions<DatabaseconfigurationSettings>>()
                    .Value;

                options.UseNpgsql(
                    databaseSettings.DefaultConnection
                );
            });
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
