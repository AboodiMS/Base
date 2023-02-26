using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Frontend
{
    public static class Extensions
    {
        public const string BasePath = "frontend";
        public static IServiceCollection AddCompaniesModule(this IServiceCollection services)
        {
            //services.AddCoreLayer();
            return services;
        }

        public static IApplicationBuilder UseCompaniesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}