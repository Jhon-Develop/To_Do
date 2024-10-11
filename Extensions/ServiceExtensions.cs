using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using To_Do.Repositories;
using To_Do.Repositories.Interfaces;
using To_Do.Services;
using To_Do.Services.Interfaces;

namespace To_Do.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // services.AddScoped<IRepositorie, Repositorie>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            // services.AddScoped<IService, Service>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}