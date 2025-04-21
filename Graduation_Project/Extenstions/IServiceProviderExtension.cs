using System.Reflection;
using Graduation_Project.Data;
using Graduation_Project.Repositories.Implementation;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Graduation_Project.Data.Seed;


namespace Graduation_Project.Extenstions
{
    public static class IServiceProviderExtension
    {
        public static async Task AddSeedData(this IServiceProvider servicesProvider)
        {
            using var scope = servicesProvider.CreateScope();
            
            var services = scope.ServiceProvider;
            var db = services.GetRequiredService<AppDbContext>();


            if (db.Systems.Any()) return;
                
            var dataLoader = new SeedDataLoader(db);
            await dataLoader.Load();
        }

    }
}