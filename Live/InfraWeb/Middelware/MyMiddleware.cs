namespace InfraWeb.Middelware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        Console.WriteLine("Incoming MW 3");
        httpContext.Items.Add("x", "twitter");
        await _next(httpContext);
        Console.WriteLine("Outgoing MW 3");
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}
