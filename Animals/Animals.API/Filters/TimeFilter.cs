using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Animals.API.Filters;
[AttributeUsage(AttributeTargets.Method)]
public class TimeFilter :Attribute, IActionFilter
{
    private string name;
    private Stopwatch stopwatch;

    public TimeFilter([CallerMemberName]string? name = null)
    {
        this.name = name;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<TimeFilter>>();
        stopwatch = Stopwatch.StartNew();
        logger.LogInformation($"Endpoint : {name} started" );
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
            stopwatch.Stop();
           var logger= context.HttpContext.RequestServices.GetRequiredService<ILogger<TimeFilter>>();
            logger.LogInformation($"Endpoint : {name} ended" );
            logger.LogInformation($"Total time for {name}  = {stopwatch.ElapsedMilliseconds} ms" );
            
    }
}