using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Animals.API.Filters;

public class NewFilter :Attribute, IActionFilter
{
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<LogFilter>>();
        logger.LogInformation("Before filter" );
        logger.LogInformation($" Method: {context.HttpContext.Request.Method}; ");
        if (context.HttpContext.Request.Method != "GET")
        {
            context.HttpContext.Response.StatusCode = 400;
            
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<LogFilter>>();
        logger.LogInformation("After filter");
        logger.LogInformation($"Status code{context.HttpContext.Response.StatusCode}, ");

       // var b = context.HttpContext.Response.Body.Read();
      
       // string text = Encoding.UTF8.GetString(b);
        //logger.LogInformation($"Body: {text} ");

    }
}


// var body = context.HttpContext.Response.Body.ReadAtLeast();