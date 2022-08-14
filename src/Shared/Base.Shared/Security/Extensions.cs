using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Security
{
    public static class Extensions
    {
        private const string SectionName = "jwt";
        private static string SymmetricKey;
        private static string Issuer;
        private static string Audience;

        private static List<Claim> setClimes(Guid id, Guid businessid, string username, List<string> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Guid", Guid.NewGuid().ToString()));
            claims.Add(new Claim("UserId", id.ToString()));
            claims.Add(new Claim("UserName", username));
            claims.Add(new Claim("Businessid", businessid.ToString()));
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            return claims;
        }
        public static string GenerateToken(Guid id,Guid businessid, string username,List<string> roles)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String(SymmetricKey));
            string algorithms = SecurityAlgorithms.HmacSha256Signature;
            List<Claim> claims = setClimes(id, businessid, username, roles);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Issuer,
                Audience = Audience,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(securityKey, algorithms)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken stoken = tokenHandler.CreateToken(tokenDescriptor);
            return "Bearer " + tokenHandler.WriteToken(stoken);
        }

        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            SymmetricKey = configuration[$"{SectionName}:{nameof(JwtOptions.SymmetricKey)}"];
            Issuer = configuration[$"{SectionName}:{nameof(JwtOptions.Issuer)}"];
            Audience = configuration[$"{SectionName}:{nameof(JwtOptions.Audience)}"];

            services.Configure<JwtOptions>(configuration.GetSection(SectionName));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(cfg =>
                    {
                        cfg.SaveToken = true;
                        byte[] symmetricKey = Convert.FromBase64String(SymmetricKey);
                        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(symmetricKey);
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            IssuerSigningKey = securityKey,
                            ValidIssuer = Issuer,
                            ValidAudience = Audience,
                            ValidateLifetime = true,
                            RequireExpirationTime = true,
                            ClockSkew = TimeSpan.FromDays(10),
                        };
                    });

            services.AddAuthorization();
            return services;
        }

        public static IApplicationBuilder UseJwt(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}

