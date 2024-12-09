namespace Graduation_Project.Core.ErrorHandling.Exceptions;

public class AppError(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; set; } = statusCode;
}