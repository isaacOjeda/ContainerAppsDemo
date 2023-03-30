using ContainerAppsDemo.Api.Data;
using ContainerAppsDemo.Api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ApiDbContext>(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

app.MapGet("/", () => "Container Apps Demo API");

app.MapGet("/api/products", (ApiDbContext context) =>
    context.Products.ToListAsync()
);

await Seed();

app.Run();



async Task Seed()
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();


    await db.Database.EnsureCreatedAsync();

    if (!await db.Products.AnyAsync())
    {
        foreach (var i in Enumerable.Range(1, 100))
        {
            db.Products.Add(new Product
            {
                Description = $"Product #{i}",
                Price = i
            });
        }

        await db.SaveChangesAsync();
    }
}