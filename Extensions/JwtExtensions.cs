using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using To_Do.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using To_Do.Services.Interfaces;
using To_Do.Repositories.Interfaces;
using To_Do.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace To_Do.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtKey = configuration["JWTKEY"] ?? throw new InvalidOperationException("JWT Key is not configured.");
            var jwtExpireMinutes = int.Parse(configuration["JWT_EXPIRE_MINUTES"] ?? "30");

            services.AddSingleton<IJwtService>(new JwtService(jwtKey, jwtExpireMinutes));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT_ISSUER"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT_AUDIENCE"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}