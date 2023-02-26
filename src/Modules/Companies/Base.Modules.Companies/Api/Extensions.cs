
using Base.Modules.Companies.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Modules.Companies.Api
{
    public static class Extensions
    {


        public const string BasePath = "companies-module";
        public static IServiceCollection AddCompaniesModule(this IServiceCollection services)
        {
            services.AddCoreLayer();
            return services;
        }

        public static IApplicationBuilder UseCompaniesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
