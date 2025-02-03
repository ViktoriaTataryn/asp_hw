using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Animals.API.Filters;
[AttributeUsage( AttributeTargets.Method)]
public class LogFilter :Attribute,IActionFilter
{
    private string name;

    public LogFilter([CallerMemberName]string? name = null)
    {
        this.name = name;
    }
    /*private readonly ILogger<LogFilter> _logger;

    public LogFilter(ILogger<LogFilter> logger)
    {
        _logger = logger;
    }*/

    //before endpoint
    public void OnActionExecuting(ActionExecutingContext context )
    {
        var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<LogFilter>>();
        logger.LogInformation("Before filter: {name}" );
        logger.LogInformation($"Controller: {context.Controller}; Path: {context.HttpContext.Request.Path}; ");
    }

    //after
    public void OnActionExecuted(ActionExecutedContext context)
    {
        var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<LogFilter>>();
        logger.LogInformation("After filter");
        logger.LogInformation($"{context.HttpContext.Response.StatusCode};  ");
    }
}