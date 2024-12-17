using System.Reflection;
using Graduation_Project.Data;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Graduation_Project.Modules.Machines.Service;
using Graduation_Project.Modules.MachineTypes.Repository;
using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Repository;
using Graduation_Project.Modules.MachinesMonitoringData.Service;
using Graduation_Project.Modules.MachinesMonitoringData.Repository;


namespace Graduation_Project.Extenstions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMonitoringAttributesService, MonitoringAttributesService>();
            services.AddScoped<IResourceConsumptionAttributesService, ResourceConsumptionAttributesService>();
            services.AddScoped<IMachinesService, MachinesService>();
            services.AddScoped<ISystemsService, SystemsService>();
            services.AddScoped<IMachineTypesService, MachineTypesService>();
            services.AddScoped<IMachinesResourceConsumptionDataService, MachinesResourceConsumptionDataService>();
            services.AddScoped<IMachinesMonitoringDataService, MachinesMonitoringDataService>();



        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMonitoringAttributesRepository, MonitoringAttributesRepository>();
            services.AddScoped<IResourceConsumptionAttributesRepository, ResourceConsumptionAttributesRepository>();
            services.AddScoped<IMachinesRepository, MachinesRepository>();
            services.AddScoped<ISystemsRepository, SystemsRepository>();
            services.AddScoped<IMachineTypesRepository, MachineTypesRepository>();
            services.AddScoped<IMachinesResourceConsumptionDataRepository, MachinesResourceConsumptionDataRepository>();
            services.AddScoped<IMachinesMonitoringDataRepository, MachinesMonitoringDataRepository>();


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