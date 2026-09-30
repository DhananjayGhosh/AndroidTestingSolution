using Android.Api.Middlewares;
using Android.Application;
using Android.Infrastructure;

namespace Android.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProblemDetails();
            services.AddExceptionHandler<ExceptionHandler>();
            services.AddApplication();
            services.AddInfrastructure(configuration);
            return services;
        }
    }
}
