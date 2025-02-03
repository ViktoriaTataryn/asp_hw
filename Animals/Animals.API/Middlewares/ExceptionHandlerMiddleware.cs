namespace Animals.API.Middlewares;

public class ExceptionHandlerMiddleware :IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            _logger.LogInformation("Before middleware");
            //do work before endpoint
            await next.Invoke(context);
            //do work after endpoint
        }
        catch (NullReferenceException ex)
        {
            context.Response.StatusCode = 404; //not found
        }
        catch (ArgumentException ex)
        {
            context.Response.StatusCode = 400; //bad request

        }
        catch (InvalidOperationException ex)
        {
            context.Response.StatusCode = 500; //server error
        }
        _logger.LogInformation("After middleware");
    }
}