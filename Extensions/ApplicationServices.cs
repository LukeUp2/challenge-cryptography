using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Criptografia.Api.Repositories;
using Desafio_Criptografia.Api.Services;

namespace Desafio_Criptografia.Api.Extensions
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<UserRepository>();
        }
    }
}