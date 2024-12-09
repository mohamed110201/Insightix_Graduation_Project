namespace Graduation_Project.Core.ErrorHandling.Exceptions;

public class NotFoundError(string message) : AppError(StatusCodes.Status404NotFound,message)
{
    
}