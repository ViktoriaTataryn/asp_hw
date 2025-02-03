using System.Text;

namespace Animals.API.Middlewares;

public class CacheMiddleware :IMiddleware
{
    private static readonly List<(string keyWord, string result)> cashe = new();
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        
        if (context.Request.Method.ToUpper().Equals("GET") )
        {
            string keyW = context.Request.Path.Value + context.Request.QueryString.Value;
            var res = cashe.Find(x => x.keyWord == keyW);
            if (res != default)
            {
                //context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(res.result);
                return;
            }
            /*var result = await context.Request.BodyReader.ReadAsync();
            string body = Encoding.UTF8.GetString(result.Buffer);*/
            
          //  var statCode = context.Response.StatusCode;
          
            var body = context.Response.Body;
            using (var sr = new StreamReader(body))
            {
              var bodyText = await sr.ReadToEndAsync();
            }

            await context.Response.Body.FlushAsync();
            body.ToString();
          //  cashe.Add((keyW,body));
        }
        else
        {
            await next.Invoke(context);
        }
      
    }
}