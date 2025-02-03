using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Animals.API.Filters;

public class ErrorHandlerFilter :IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        
     
        if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        {
            context.Result = new ContentResult()
            {
                Content = context.Exception.Message,
                StatusCode = 401
            };
        }
       
        context.Result = new ContentResult()
        {
            Content = context.Exception.Message,
            StatusCode =500
        };
    }
}

/*var statusCode = context.Exception switch
{
    ArgumentException => 400,
    NullReferenceException => 404,
    UnauthorizedAccessException => 401,
    _ => 500
};*/