using System.Text;

namespace Animals.API.Middlewares;

public class AnimalMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.Value.Contains("animals") &&
            context.Request.Method.ToUpper().Equals("POST"))
        {
            var body= await context.Request.BodyReader.ReadAsync();
            string bodyText = Encoding.UTF8.GetString(body.Buffer);
            if (bodyText.Contains("\"id\""))
            {
                context.Response.StatusCode = 400;
                await context.Response.BodyWriter.WriteAsync("You cannot add Id"u8.ToArray());
            }
        }
        await next.Invoke(context);
        return;
    }
}