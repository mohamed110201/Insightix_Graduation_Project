using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Core;

public class JSendResponse: ObjectResult
{
    public JSendResponse(int statusCode,JSendBody? body=null) : base(body)
    {
        StatusCode = statusCode;
    }
    
}