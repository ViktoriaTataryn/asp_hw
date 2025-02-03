namespace Animals.API.Middlewares;

public class AnMiddlware :IMiddleware
{
    private readonly ILogger<AnMiddlware> _logger;
    public  async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Method.ToUpper().Equals("GET") &&
            !context.Request.Headers.Keys.Contains("Auth"))
        {
            context.Response.StatusCode = 401;
        }

        await next.Invoke(context);
       
    }
}

/*var req = context.Request.Method;
       _logger.LogInformation($"Request Method: {req}");
       await next.Invoke(context);


       var res = context.Response.StatusCode;
      _logger.LogInformation($"Response: {res}");*/