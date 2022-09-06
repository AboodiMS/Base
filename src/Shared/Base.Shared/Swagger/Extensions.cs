using Base.Shared.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Swagger
{
    public static class Extensions
    {
        private const string ProjectTitleSwaggerApi = "Base.Bootstrapper";
        private const string SwaggerVersion = "v1";
        private const string SecurityName = "Bearer";
        private static List<string> Modules = new List<string>();

        private static void setModules()
        {
            var dd = BaseModulesData.ModuleSettings;
            Modules.Add("users-module");
            Modules.Add("companies-module");
            Modules.Add("translation-module");
        }

        private static SwaggerGenOptions setSwaggerDocs( this SwaggerGenOptions c)
        {
            foreach( var module in Modules)
            {
                c.SwaggerDoc(module, new OpenApiInfo { Title = module, Version = module });
            }
              
            return c;
        }
        private static SwaggerUIOptions setSwaggerEndPoints(this SwaggerUIOptions c)
        {
            foreach (var module in Modules)
                c.SwaggerEndpoint($"/swagger/{module}/swagger.json", module);
            return c;
        }

        public static IServiceCollection AddSwaggerOptions(this IServiceCollection services)
        {

            setModules();

            services.AddSwaggerGen(c =>
           {
               //c.EnableAnnotations();
               c.setSwaggerDocs();

               //c.SwaggerDoc("v1", new OpenApiInfo { Title = ProjectTitleSwaggerApi, Version = SwaggerVersion });
               c.AddSecurityDefinition(SecurityName, openApiSecurityScheme);
               c.AddSecurityRequirement(openApiSecurityRequirement);
           });



            //services.AddSwaggerGen(gen =>
            //{
            //    gen.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Server API",
            //        Version = "1.0",
            //        Description = "This API features all public available endpoints showing different API features."
            //    });
            //});
            //services.AddSwaggerGen(gen =>
            //{
            //    gen.SwaggerDoc("v1-internal", new OpenApiInfo
            //    {
            //        Title = "Viewer Server API (internal)",
            //        Version = "v1-internal",
            //        Description = "This API features all public available endpoints showing different API features."
            //    });
            //});

            return services;
        }
        public static IApplicationBuilder UseSwaggerOptions(this IApplicationBuilder app)
        {
            app.UseSwagger();
            //app.UseSwaggerUI();
           
            app.UseSwaggerUI(c =>
            {
                c.setSwaggerEndPoints();
               
            });

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1-internal/swagger.json", "Viewer Server API v1 (internal)");
            //});
            return app;
        }

        private static OpenApiSecurityScheme openApiSecurityScheme
            => new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            };
        private static OpenApiSecurityRequirement openApiSecurityRequirement
            => new OpenApiSecurityRequirement()
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = SecurityName
                }
            },
                new string[] { }
            }
            };
    }
}
