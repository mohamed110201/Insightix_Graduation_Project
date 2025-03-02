namespace Graduation_Project.Core.ErrorHandling.Exceptions;

public class BadRequestError(string message) : AppError(StatusCodes.Status400BadRequest,message)
{
    
}