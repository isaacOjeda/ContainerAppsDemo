using ContainerAppsDemo.Api.Entities;
using Microsoft.EntityFrameworkCore;


namespace ContainerAppsDemo.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();
}
