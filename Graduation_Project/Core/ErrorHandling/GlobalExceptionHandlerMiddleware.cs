using System.Text.Json;
using Graduation_Project.Core.ErrorHandling.Exceptions;

namespace Graduation_Project.Core.ErrorHandling;

public class GlobalErrorHandlingMiddleware 
{
    
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        if (exception is AppError appError)
        {
            var jsendBody = new JSendBody()
            {
                Status = ((appError.StatusCode)/100) == 5 ? "error" : "fail",
                Message = appError.Message
            };
            response.StatusCode = appError.StatusCode;
            await response.WriteAsync(JsonSerializer.Serialize(jsendBody, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }
        else
        {
            var jsendBody = new JSendBody()
            {
                Status = "error",
                Message = exception.Message
            };
            response.StatusCode = StatusCodes.Status500InternalServerError;
            await response.WriteAsync(JsonSerializer.Serialize(jsendBody, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));

        }
    }
}

