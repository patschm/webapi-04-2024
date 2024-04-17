using InfraWeb.Middelware;

namespace InfraWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddKeyedScoped<ICounter, Counter>("normal");
            builder.Services.AddKeyedScoped<ICounter, WierdCounter>("weird");

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.Use(async (HttpContext ctn, RequestDelegate next) => {
                Console.WriteLine("===============================");        
                await next(ctn);
                Console.WriteLine("===============================");

            });

            app.Use(async (HttpContext ctn, RequestDelegate next) => {
                Console.WriteLine("Incoming MW 1");
                await next(ctn);
                Console.WriteLine("Outgoing MW 1");

            });

            app.Use(async (HttpContext ctn, RequestDelegate next) => {
                Console.WriteLine("Incoming MW 2");
                await next(ctn);
                Console.WriteLine("Outgoing MW 2");
            });

            //app.UseMiddleware<MyMiddleware>();  
            app.UseMyMiddleware();


            //app.Map("ok", (IApplicationBuilder ap) => {
            //    ap.Use(async (HttpContext ct, RequestDelegate next) => {
            //        Console.WriteLine("Branch 1");
            //       await  next(ct);
            //        Console.WriteLine("End Branch 1");
            //    });
            //});

            app.MapGet("ha", async (HttpContext ctx) =>
            {
                Console.WriteLine("\tSome sort of action");
                await ctx.Response.WriteAsync("Body");
            });

            // Configure the HTTP request pipeline.
            // ICounter cnt = new Counter(app.Services.GetRequiredService<ILogger<Counter>>());

            //app.MapGet("hoi", (ILogger<Counter> logger) =>
            //{   
            //    var scope1 = app.Services.CreateScope();
            //    var cnt1 = scope1.ServiceProvider.GetRequiredKeyedService<ICounter>("normal");
            //    cnt1.Increase();
            //    cnt1 = scope1.ServiceProvider.GetRequiredKeyedService<ICounter>("normal");
            //    cnt1.Increase();
            //    cnt1 = scope1.ServiceProvider.GetRequiredKeyedService<ICounter>("normal");
            //    cnt1.Increase();

            //    var scope2 = app.Services.CreateScope();
            //    var cnt2 = scope2.ServiceProvider.GetRequiredKeyedService<ICounter>("weird");
            //    cnt2.Increase();
            //    cnt2 = scope2.ServiceProvider.GetRequiredKeyedService<ICounter>("weird");
            //    cnt2.Increase();
            //    cnt2 = scope2.ServiceProvider.GetRequiredKeyedService<ICounter>("weird");
            //    cnt2.Increase();

            //    //logger.LogError("Dit is geen error");
            //});

            app.Run();
        }
    }
}
