using Base.Modules.Users.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Api
{
    public static class Extensions
    {
        public const string BasePath = "users-module";
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
        {
            services.AddCoreLayer();
            return services;
        }
        public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
