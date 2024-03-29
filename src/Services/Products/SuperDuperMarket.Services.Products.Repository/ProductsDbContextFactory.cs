using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SuperDuperMarket.Services.Products.Repository;

public class ProductsDbContextFactory : IDesignTimeDbContextFactory<ProductsDbContext>
{
    public ProductsDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json");

        IConfiguration configuration = configurationBuilder.Build();
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        DbContextOptionsBuilder<ProductsDbContext> builder = new();
        builder.UseSqlServer(connectionString);

        return (ProductsDbContext)Activator.CreateInstance(typeof(ProductsDbContext), builder.Options)!;
    }
}