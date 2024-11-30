using Graduation_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Graduation_Project.Extenstions
{
    public static class IServiceCollectionExtension
    {
        
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterConfigurations(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services , IConfiguration config)
        {

             services.AddDbContext<AppDbContext>(options =>
                {
                   options.UseSqlServer(config.GetConnectionString("Default")); 
                });
            return services;
        }
        
    }
}
