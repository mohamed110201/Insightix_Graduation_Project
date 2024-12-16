using System.Collections;

namespace Graduation_Project.Core.JSend;

public static class JSend
{
    public static JSendResponse Success(string? message = null, object? data = null)
    {
        return new JSendResponse(StatusCodes.Status200OK,
            new JSendBody { Status = "success", Message = message, Data = data });
    }
    public static JSendResponse Created(string? message = null, object? data = null)
    {
        return new JSendResponse(StatusCodes.Status201Created,
            new JSendBody { Status = "success", Message = message, Data = data });
    }  
    
    public static JSendResponse Edited(string? message = null, object? data = null)
    {
        return new JSendResponse(StatusCodes.Status200OK,
            new JSendBody { Status = "success", Message = message, Data = data });
    }
    
    public static JSendResponse Deleted()
    {
        return new JSendResponse(StatusCodes.Status204NoContent);
    }
    
    public static JSendResponse ValidationError(ICollection? errors = null)
    {
        return new JSendResponse(StatusCodes.Status400BadRequest,
            new JSendBody { Status = "fail", Errors = errors });
    }        
    
    public static JSendResponse BadRequest(object? error = null,ICollection? errors = null)
    {
        return new JSendResponse(StatusCodes.Status400BadRequest,
            new JSendBody { Status = "fail", Error = error ,Errors = errors });
    }    
    
    public static JSendResponse Unauthorized()
    {
        return new JSendResponse(StatusCodes.Status401Unauthorized,
            new JSendBody { Status = "fail", Error = $"Unauthorized, Sorry your request cannot be processed" });
    }    
    
    public static JSendResponse Forbidden()
    {
        return new JSendResponse(StatusCodes.Status403Forbidden,
            new JSendBody { Status = "fail", Error = $"Forbidden, Access Is Denied" });
    }
    
    public static JSendResponse ServerError()
    {
        return new JSendResponse(StatusCodes.Status500InternalServerError,
            new JSendBody { Status = "error", Message = "Internal Server Error" });
    }
}