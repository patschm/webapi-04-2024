
namespace MyFirst;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hoi");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        //app.MapControllerRoute("first", "{controller=HelloWorld}/{action=GetHello}/{id:int}", defaults:new { controller="HelloWorld", id=0}, constraints:new { id=0 });
        app.MapControllers();

        app.Run();
    }
}
