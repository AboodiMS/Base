
using Base.Modules.Companies.DAL.Database;
using Base.Modules.Companies.Domain.IServices;
using Base.Modules.Companies.DAL.Services;
using Base.Shared.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Modules.Companies.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            services.AddPostgres<CompaniesDbContext>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            return services;
        }
    }
}
