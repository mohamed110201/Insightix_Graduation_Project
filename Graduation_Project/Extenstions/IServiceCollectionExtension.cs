using System.Reflection;
using Graduation_Project.Data;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;


namespace Graduation_Project.Extenstions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMonitoringAttributesService, MonitoringAttributesService>();
            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IMachineTypeServices, MachineTypeServices>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMonitoringAttributesRepository, MonitoringAttributesRepository>();
            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<ISystemRepository, SystemRepository>();
            services.AddScoped<IMachinetypeRepository, MachineTypeRepository>();
        }

        public static void RegisterConfigurations(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
        
        public static void RegisterValidations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
    }
}