using Graduation_Project.Core.ErrorHandling;
using Graduation_Project.Data;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Extenstions;

public static class IApplicationBuilderExtensions
{
    public static void RegisterMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }


    public static async Task SeedAdminUser(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        const string adminUsername = "manufactureAdmin";
        const string adminEmail = "admin@factory.com";
        const string adminPassword = "AdminPassword123!";

        if (await userManager.FindByNameAsync(adminUsername) != null)
            return;

        var newAdmin = new IdentityUser
        {
            UserName = adminUsername,
            Email = adminEmail,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(newAdmin, adminPassword);
    }

}