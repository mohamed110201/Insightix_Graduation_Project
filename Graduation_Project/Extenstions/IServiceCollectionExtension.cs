using FluentValidation;
using FluentValidation.AspNetCore;
using Graduation_Project.Data;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using Graduation_Project.Validators;


namespace Graduation_Project.Extenstions
{
    public static class IServiceCollectionExtension
    {
        
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMachineTypeServices, MachineTypeServices>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMachinetypeRepository,MachineTypeRepository>();
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
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<MachineTypeValidator>();
            return services;
        }

    }
}
