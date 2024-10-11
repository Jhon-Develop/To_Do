using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace To_Do.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // services.AddScoped<IRepositorie, Repositorie>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            // services.AddScoped<IService, Service>();
        }
    }
}