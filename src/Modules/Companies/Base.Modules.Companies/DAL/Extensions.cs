
using Base.Modules.Companies.DAL.Database;
using Base.Modules.Companies.Domain.IServices;
using Base.Modules.Companies.DAL.Services;
using Base.Shared.Database;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Base.Modules.Companies.Domain.Mapping;

namespace Base.Modules.Companies.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config => config.AddProfile(new CompanyProfile())).CreateMapper());

            services.AddPostgres<CompaniesDbContext>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            return services;
        }
    }
}
