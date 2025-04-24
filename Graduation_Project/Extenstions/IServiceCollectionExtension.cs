using System.Reflection;
using Graduation_Project.Data;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Graduation_Project.Controllers.Repository;
using Graduation_Project.Modules.Alerts.Repository;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.Email;
using Graduation_Project.Modules.Failures.Repository;
using Graduation_Project.Modules.FailuresPrediction;
using Graduation_Project.Modules.Machines.Service;
using Graduation_Project.Modules.MachineTypes.Repository;
using Microsoft.AspNetCore.Mvc;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Repository;
using Graduation_Project.Modules.MachinesMonitoringData.Service;
using Graduation_Project.Modules.MachinesMonitoringData.Repository;
using Graduation_Project.Modules.Simulation;
using RazorLight;
using Resend;


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
            services.AddScoped<IMachineFailuresService, MachineFailuresService>();
            services.AddScoped<IFailuresService, FailuresService>();



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
            services.AddScoped<IMachineFailuresRespository, MachineFailuresRespository>();
            services.AddScoped<IFailuresRepository, FailuresRepository>();
            services.AddScoped<IAlertsService, AlertsService>();
            services.AddScoped<IAlertsRepository, AlertsRepository>();
            services.AddScoped<IAlertsCachingService, AlertsCachingService>();
            services.AddScoped<ICreateAlertsService, CreateAlertsService>();
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
            {
                options.LogTo(_ => { }, LogLevel.None);
                options.UseSqlServer(config.GetConnectionString("Default"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
        public static void RegisterCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
        
        // public static void RegisterHttpClient(this IServiceCollection services)
        // {
        //     services.AddHttpClient<FailuresPredictionManger>();
        // }
        
        public static void RegisterFailuresPredictionBackground(this IServiceCollection services)
        {
            services.AddHostedService<FailuresPredctionBackgroundService>();
            services.AddSingleton<FailuresPredictionManger>();
        }        
        
        public static void RegisterSimulationDataBackground(this IServiceCollection services)
        {
            
            services.AddSingleton<SimulationDataPipelineFactory>();
            services.AddSingleton<SimulationDataGenerator>();
            
            services.AddHostedService<SimulationDataBackgroundService>();
            services.AddSingleton<SimulationManager>();
        }        
        
        public static void RegisterResend(this IServiceCollection services,IConfiguration config)
        {
            
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>( o =>
            {
                o.ApiToken = config.GetValue<string>("RESEND_API_TOKEN")!;
                Console.WriteLine("Resend API Token");
                Console.WriteLine(config.GetValue<string>("RESEND_API_TOKEN"));
            } );
            services.AddTransient<IResend, ResendClient>();
            services.AddTransient<EmailService>();
        }        
        public static void RegisterRazorLightEngine(this IServiceCollection services)
        {
            
            services.AddSingleton<RazorLightEngine>(provider =>
            {
                var env = provider.GetRequiredService<IWebHostEnvironment>();
                var templatesRoot = Path.Combine(env.ContentRootPath, "Modules\\Email\\Templates");
                Console.WriteLine(templatesRoot);
                return new RazorLightEngineBuilder()
                    .UseFileSystemProject(templatesRoot)
                    .UseMemoryCachingProvider()
                    .Build();
            });
        }
        
    }
}