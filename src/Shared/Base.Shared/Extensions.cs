using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Base.Shared.Commands;
using Base.Shared.Database;
using Base.Shared.Dispatchers;
using Base.Shared.Events;
using Base.Shared.Exceptions;
using Base.Shared.Messaging;
using Base.Shared.Queries;
using Base.Shared.Time;
using System.Text.Json;
using System.Text.Json.Serialization;
using Base.Shared.Security;
using Base.Shared.Swagger;

namespace Base.Shared
{
    public static class Extensions
    {
        private const string ApiTitle = "Base API";
        private const string ApiVersion = "v1";
        
        public static IServiceCollection AddSharedFramework(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddErrorHandling();
            services.AddCommands();
            services.AddEvents();
            services.AddQueries();
            services.AddMessaging();
            services.AddPostgres(configuration);
            services.AddControllers();
            services.AddSingleton<IClock, UtcClock>();
            services.AddSingleton<IDispatcher, InMemoryDispatcher>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddEndpointsApiExplorer();
            services.AddJwt(configuration);
            services.AddSwaggerOptions();


            return services;
        }
        
        public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            app.UseJwt();
            app.UseSwaggerOptions();

            app.UseHttpsRedirection();
            return app;
        }
    }
}