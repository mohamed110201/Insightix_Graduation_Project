using Graduation_Project.Data;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Graduation_Project.Extenstions
{
    public static class IServiceCollectionExtension
    {
        
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IMachineService, MachineService>();
            return services;

        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<ISystemRepository, SystemRepository>();
            return services;
        }

        public static IServiceCollection RegisterConfigurations(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services , IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("Default")));
            return services;
        }
        
    }
}
