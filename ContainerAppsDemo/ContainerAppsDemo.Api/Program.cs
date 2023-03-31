using ContainerAppsDemo.Api.Common.Services;
using ContainerAppsDemo.Api.Data;
using ContainerAppsDemo.Api.Entities;
using ContainerAppsDemo.Api.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ApiDbContext>(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddTransient<ICurrencyProvider, BanxicoService>();
builder.Services.AddHttpClient("Banxico", config =>
{
    config.BaseAddress = new Uri("https://www.banxico.org.mx");
});

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));
app.MapGet("/", () => "Container Apps Demo API");
app.MapGet("/api/products", (ApiDbContext context) =>
    context.Products.ToListAsync()
);
app.MapGet("/api/banxico", (ICurrencyProvider banxico) =>
    banxico.GetDollarValue()
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