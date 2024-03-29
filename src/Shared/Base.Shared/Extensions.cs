﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Base.Shared.Database;
using Base.Shared.Exceptions;
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
            services.AddMemoryCache();
            services.AddCors();
            services.AddErrorHandling();
            services.AddPostgres(configuration);
            services.AddControllers();
            services.AddSingleton<IClock, UtcClock>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(options => options.EnableEndpointRouting =true);
            services.AddEndpointsApiExplorer();
            services.AddJwt(configuration);
            services.AddSwaggerOptions();


            return services;
        }
        
        public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseErrorHandling();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseJwt();
            app.UseSwaggerOptions();

           
            return app;
        }
    }
}