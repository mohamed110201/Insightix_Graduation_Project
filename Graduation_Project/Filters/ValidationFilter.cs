using Graduation_Project.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Graduation_Project.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context) { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        
        var messages = context.ModelState
            .SelectMany(message => message.Value!.Errors)
            .Select(error => error.ErrorMessage)
            .ToList();
           
        context.Result = JSend.ValidationError(errors:messages);
    }
}