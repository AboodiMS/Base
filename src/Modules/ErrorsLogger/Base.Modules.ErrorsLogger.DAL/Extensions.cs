using Base.Modules.ErrorsLogger.DAL.Database;
using Base.Modules.ErrorsLogger.DAL.Service;
using Base.Modules.ErrorsLogger.Domain.IService;
using Base.Shared.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.ErrorsLogger.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {
            //services.AddPostgres<ErrorsLoggerDbContext>();
            //services.AddTransient<IErrorLoggerService, ErrorLoggerService>();
            return services;
        }
        public static IServiceCollection AddErrorsLogggerModule(this IServiceCollection services)
        {
            services.AddCoreLayer();
            return services;
        }
        public static IApplicationBuilder UseErrorsLogggerModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
