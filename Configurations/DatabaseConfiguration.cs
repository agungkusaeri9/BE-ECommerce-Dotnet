using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            var defaultConnection = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

            if (string.IsNullOrEmpty(defaultConnection))
            {
                throw new Exception("DEFAULT_CONNECTION environment variable is not set.");
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection)));

            return services;
        }
    }
}