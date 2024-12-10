using Graduation_Project.Core.ErrorHandling;

namespace Graduation_Project.Extenstions;

public static class IApplicationBuilderExtensions
{
    public static void RegisterMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}