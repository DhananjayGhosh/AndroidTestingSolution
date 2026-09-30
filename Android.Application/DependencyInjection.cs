using Android.Application.Interfaces;
using Android.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Android.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
