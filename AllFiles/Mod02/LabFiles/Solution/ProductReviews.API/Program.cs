using Microsoft.EntityFrameworkCore;
using ProductReviews.API.Middleware;
using ProductReviews.DAL.EntityFramework.Database;
using ProductReviews.Interfaces;
using ProductReviews.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductReviewsContext>(opt=>{
    opt.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Mod1DB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=true");
});
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddRepositories();

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
app.UseExecutionTime();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
